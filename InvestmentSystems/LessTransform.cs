using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Hosting;
using System.Web.Optimization;
using dotless.Core;
using dotless.Core.Abstractions;
using dotless.Core.Importers;
using dotless.Core.Input;
using dotless.Core.Loggers;
using dotless.Core.Parser;

namespace UserExperience
{
    public class LessTransform : IBundleTransform
    {
        public void Process(BundleContext context, BundleResponse bundle)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            if (bundle == null)
            {
                throw new ArgumentNullException("bundle");
            }

            context.HttpContext.Response.Cache.SetLastModifiedFromFileDependencies();

            var lessParser = new Parser();
            ILessEngine lessEngine = CreateLessEngine(lessParser);

            var content = new StringBuilder(bundle.Content.Length);

            var bundleFiles = new List<FileInfo>();

            foreach (var bundleFile in bundle.Files)
            {
                bundleFiles.Add(bundleFile);

                SetCurrentFilePath(lessParser, bundleFile.FullName);
                string source = File.ReadAllText(bundleFile.FullName);
                content.Append(lessEngine.TransformToCss(source, bundleFile.FullName));
                content.AppendLine();

                bundleFiles.AddRange(GetFileDependencies(lessParser));
            }

            if (BundleTable.EnableOptimizations)
            {
                // include imports in bundle files to register cache dependencies
                bundle.Files = bundleFiles.Distinct();
            }

            bundle.ContentType = "text/css";
            bundle.Content = content.ToString();
        }
        private ILessEngine CreateLessEngine(Parser lessParser)
        {
            var logger = new AspNetTraceLogger(LogLevel.Debug, new Http());
            return new LessEngine(lessParser, logger, true, false);
        }
        private IEnumerable<FileInfo> GetFileDependencies(Parser lessParser)
        {
            IPathResolver pathResolver = GetPathResolver(lessParser);

            foreach (var importPath in lessParser.Importer.Imports)
            {
                yield return new FileInfo(pathResolver.GetFullPath(importPath));
            }

            lessParser.Importer.Imports.Clear();
        }
        private IPathResolver GetPathResolver(Parser lessParser)
        {
            var importer = lessParser.Importer as Importer;
            var fileReader = importer.FileReader as FileReader;

            return fileReader.PathResolver;
        }
        private void SetCurrentFilePath(Parser lessParser, string currentFilePath)
        {
            var importer = lessParser.Importer as Importer;

            if (importer == null)
                throw new InvalidOperationException("Unexpected dotless importer type.");

            var fileReader = importer.FileReader as FileReader;

            if (fileReader == null || !(fileReader.PathResolver is ImportedFilePathResolver))
            {
                fileReader = new FileReader(new ImportedFilePathResolver(currentFilePath));
                importer.FileReader = fileReader;
            }
        }
    }
    public class ImportedFilePathResolver : IPathResolver
    {
        private string currentFileDirectory;
        private string currentFilePath;

        public ImportedFilePathResolver(string currentFilePath)
        {
            if (string.IsNullOrEmpty(currentFilePath))
            {
                throw new ArgumentNullException("currentFilePath");
            }

            CurrentFilePath = currentFilePath;
        }

        /// <summary>
        /// Gets or sets the path to the currently processed file.
        /// </summary>
        public string CurrentFilePath
        {
            get { return currentFilePath; }
            set
            {
                currentFilePath = value;
                currentFileDirectory = Path.GetDirectoryName(value);
            }
        }

        /// <summary>
        /// Returns the absolute path for the specified improted file path.
        /// </summary>
        /// <param name="filePath">The imported file path.</param>
        public string GetFullPath(string filePath)
        {
            if (filePath.StartsWith("~"))
            {
                filePath = VirtualPathUtility.ToAbsolute(filePath);
            }

            if (filePath.StartsWith("/"))
            {
                filePath = HostingEnvironment.MapPath(filePath);
            }
            else if (!Path.IsPathRooted(filePath))
            {
                filePath = Path.GetFullPath(Path.Combine(currentFileDirectory, filePath));
            }

            return filePath;
        }
    }
}