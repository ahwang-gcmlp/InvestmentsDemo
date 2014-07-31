using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InvestmentSystems.Infrastructure;
using InvestmentSystems.Information;
using GrosvenorFund.Domain.Entities;

namespace InvestmentSystems.Models
{
    public class WelcomeModel
    {
        public List<GrosvenorFundSummary> GrosvenorFundList;
        public List<PageSection> EvalPlanner;
        public List<PageSection> EvalNormal;
        public List<PageSection> Res;
        public List<PageSection> Plan;
    }
}