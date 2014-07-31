using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Simple.Data;

namespace InvestmentSystems.Information
{
    public class dbConnect
    {
        public static List<PageSection> GetEvalPlannerSections()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["InvestmentSystems"];
            var db = Database.OpenConnection(connectionString.ConnectionString);
            List<PageSection> evalPlanner = db.PageSections.FindAll(db.PageSections.category == "eval" && db.PageSections.numlinks == 2);
            return evalPlanner;        
        }

        public static List<PageSection> GetEvalNormalSections()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["InvestmentSystems"];
            var db = Database.OpenConnection(connectionString.ConnectionString);
            List<PageSection> evalNormal = db.PageSections.FindAll(db.PageSections.category == "eval" && db.PageSections.numlinks == 1);
            return evalNormal;
        }

        public static List<PageSection> GetResSections()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["InvestmentSystems"];
            var db = Database.OpenConnection(connectionString.ConnectionString);
            List<PageSection> res = db.PageSections.FindAll(db.PageSections.category == "res");
            return res;
        }

        public static List<PageSection> GetPlanSections()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["InvestmentSystems"];
            var db = Database.OpenConnection(connectionString.ConnectionString);
            List<PageSection> plan = db.PageSections.FindAll(db.PageSections.category == "plan");
            return plan;
        }
    }

    public class PageSection
    {
        public string name { get; set; }
        public int id { get; set; }
        public string summary { get; set; }
        public string link { get; set; }
        public string link2 { get; set; }
        public string category { get; set; }
        public int numlink { get; set; }

    }
}

