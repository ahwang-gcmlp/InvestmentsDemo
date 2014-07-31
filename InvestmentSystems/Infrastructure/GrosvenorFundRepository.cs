using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using GrosvenorFund.Client;
using GrosvenorFund.Domain.Entities;
using GCM.Enterprise.HttpClient;

namespace InvestmentSystems.Infrastructure
{

    public class GrosvenorFundRepository
    {
        public List<GrosvenorFundSummary> GetAllGrosvenorFundSummaries()
        {
            var baseEndpoint = ConfigurationManager.AppSettings["GrosvenorFundServiceEndpoint"];
            var httpclient = new HttpRestClient(baseEndpoint);
            var httpResponseParser = new HttpResponseParser();

            var client = new GrosvenorFundSummaryServiceClient(httpclient, httpResponseParser);
            return client.GetAllGrosvenorFundSummaries().Where(w => (!w.IsFeeder || w.PortfolioCategory == "Simulated Portfolio") && w.IsActive.GetValueOrDefault())
                .OrderBy(w => w.Acronym)
                .ToList();
        }
    }
}