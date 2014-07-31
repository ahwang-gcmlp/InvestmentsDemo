using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InvestmentSystems.Infrastructure;
using InvestmentSystems.Information;
using InvestmentSystems.Models;
using GrosvenorFund.Domain.Entities;

namespace InvestmentSystems.Controllers
{
    public class WelcomeController : Controller
    {
        //
        // GET: /Welcome/

        public ActionResult Index()
        {
            
            var Model = new WelcomeModel();

            var grosvenorFundRepository = new GrosvenorFundRepository();
            Model.GrosvenorFundList = grosvenorFundRepository.GetAllGrosvenorFundSummaries();
            Model.EvalPlanner = dbConnect.GetEvalPlannerSections();
            Model.EvalNormal = dbConnect.GetEvalNormalSections();
            Model.Res = dbConnect.GetResSections();
            Model.Plan = dbConnect.GetPlanSections();
            

            return View("Index", Model);
        }

    }
}
