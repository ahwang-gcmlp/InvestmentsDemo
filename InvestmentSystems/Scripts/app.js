(function () {
    var app = angular.module('AthenaDemo', ['ngAnimate']);

    app.controller('PanelController', function ($scope) {

        this.tab = 1;

        $scope.evalTabs = __evalPlanner;
        $scope.evalTabs2 = __evalNormal;
        $scope.resTabs = __res;
        $scope.planTabs = __plan;

        this.selectPrimaryTab = function(setTab) {
            this.tab = setTab;
        };

        this.isPrimarySelected = function(checkTab) {
            return this.tab === checkTab;
        };
        this.selectSecondaryTab = function(tab) {
            this.tab = tab.id;
        };

        this.isSecondarySelected = function(tab) {
            return this.tab === tab.id;
        };

        this.evalHideLine = function (tab, tabs, tabs2) {
            return tab.id === tabs.length + tabs2.length;
        };

        this.hideLine = function(tab, tabs) {
            return tab.id === tabs.length;
        };

    });

    app.controller('FundController', function ($scope) {
        $scope.grosvenorFundOptions = __grosvenorFundOptions;

        this.evalTabs = eval;
        this.resTabs = res;
        this.planTabs = plan;
        this.append = 0;

        this.selectAppend = function (tab) {
            return this.append = 1;
        };


    });

    var evalPlanner = [
{
    name: "Fund Performance Summary",
    id: 1,
    summary: "The Fund Performance Summary shows basic fund information, risk and return statistics, " +
        "top Portfolio Fund contributors, and top 10 Portfolio Fund allocations.",
    link: "http://localhost/planner/Reports/PopOut?grosvenorFundId=",
    link2: "&scenarioId=0&reportName=Performance&asOfDate=08/01/2010"
},

{
    name: "Allocation Summary",
    id: 2,
    summary: "The Allocation Summary shows current and planned allocations across strategies, " +
        "sub-strategies, and Portfolio Funds.",
    link: "http://localhost/planner/Reports/PopOut?grosvenorFundId=",
    link2: "&scenarioId=0&reportName=Allocation&asOfDate=08/01/2010"
},

{
    name: "Liquidity Analysis",
    id: 3,
    summary: "The Liquidity Analysis shows the full redemption summary, " +
        "liquidity schedule, and liquidity by Portfolio Fund.",
    link: "http://localhost/planner/Reports/PopOut?grosvenorFundId=",
    link2: "&scenarioId=0&reportName=Liquidity&asOfDate=08/01/2010"
},

{
    name: "Risk Summary",
    id: 4,
    summary: "The Risk Summary contains quantitative analyses of the portfolio, " +
        "including MVaR, betas, historical simulation, factor sensitivities, " +
        "and risk-based allocation statistics.",
    link: "http://localhost/planner/Reports/PopOut?grosvenorFundId=",
    link2: "&scenarioId=0&reportName=Risk&asOfDate=08/01/2010"
},

{
    name: "Financial Shocks",
    id: 5,
    summary: "The Financial Shocks shows how the Portfolio Fund would have performed " +
        "during certain historical financial shock periods. This allows us to better " +
        "understand how a portfolio can be expected to perform during different " +
        "distressed market environments.",
    link: "http://localhost/planner/Reports/PopOut?grosvenorFundId=",
    link2: "&scenarioId=0&reportName=Financial Shocks&asOfDate=08/01/2010"
},

{
    name: "Exposure Summary",
    id: 6,
    summary: "By providing look-through strategy and sub-strategy exposures, " +
        "the Exposure Report can be used to avoid inadvertent strategy and " +
        "sub-strategy concentration, as well as monitor leverage and geographic " +
        "diversity within the overall Grosvenor Fund. The Exposure Summary Report " +
        "aggregates look-through exposure information provided by each Investment Manager.",
    link: "http://localhost/planner/Reports/PopOut?grosvenorFundId=",
    link2: "&scenarioId=0&reportName=Exposure&asOfDate=08/01/2010"

}];

    var evalNormal = [

{
    name: "Historical Simulation",
    id: 7,
    summary: "The Historical Simulation Summary uses the historical realized returns " +
    "of each underlying Portfolio Fund within a Grosvenor Fund to model the performance " + 
    "of a given set of allocations over a variety of historical periods.",
    link: "http://athenawebprod/static/RiskReport.html?report_action=HistoricalSimulationStatisticsSummary&report_title=Historical%20Simulation%20Summary%20Parameters"

},

{
    name: "Risk Based Allocation",
    id: 8,
    summary: "The Risk Based Allocation helps estimate and monitor the potential effects " +
        "of an extreme market drawdown on a Grosvenor Fund. Using forward-looking estimates for " +
        "return, standard deviation, and Severe Case Loss, this report assesses each Portfolio " +
        "Fund’s and each strategy’s contribution to total Grosvenor Fund risk. The report " +
        "additionally supplies a portfolio-level Severe Case Loss estimate, which is the " +
        "estimated Grosvenor Fund loss over a 12-month period in the event of an extreme " +
        "market drawdown.",
    link: "http://athenawebprod/static/RiskReport.html?report_action=RBA&report_title=Risk%20Based%20Allocation%20Report%20Parameters"

}];



var res = [
    {
        name: "Manager Blog",
        id: 1,
        summary: "The Manager Blog allows our investment team to easily search across all availble Portfolio " +
            "Fund notes that Manager Research and ODD teams have entered. It also shows the most " +
            "recent Portfolio Fund notes entered into our systems.",
        link: "http://gcm-sp-01/Resources/researchblog/default.aspx"
    },
    {
        name: "Hedge Fund Research",
        id: 2,
        summary: "This is our quarterly outlook piece that is put together by our Manager Research and Risk " +
            "Management teams. It includes our latest investment views and economic outlook.",
        link: "http://gcm-sp-01/Departments/ClientGroup/Grab-n-Go/External-CommentariesDeliverables/Forms/HFSIRO.aspx"


    },
    {
        name: "Manager Profiles",
        id: 3,
        summary: "The Manager Profile is the main portal in which information for Portfolio Funds is entered. " +
            "For example exposure, meeting notes, and liquidity terms are all inputted here.",
        link: "http://athenawebprod/profiles/MPprofile/static/MP_ManagerProfileSkeleton.html"


    }
];

    var plan = [
        {
            name: "GCM Planner",
            id: 1,
            summary: "GCM Planner is Grosvenor's proprietary portfolio planning and construction tool. " +
                "It is a “what-if” scenario modeling " +
                "tool that empowers portfolio managers to plan potential investments over multiple periods " +
                "and evaluate the impact the proposed changes have on the portfolio.",
            link: "http://gcmplanner/"

        },
        {
            name: "Capacity Allocation Tool",
            id: 2,
            summary: "The Capacity Allocation Tool systematically allocates scarce or limited " +
                "capacity from our underlying portfolio funds on a pro-rata basis based " +
                "upon each Grosvenor fund's need.",
            link: "http://capacityallocationtool/"

        },
        {
            name: "Objectives and Constraints Report",
            id: 3,
            summary: "The Formal Objectives and Constraints gives a listing of the formal objectives and" +
                "constraints defined for a portfolio along with the automated test results. The report " +
                "performs the required calculations and displays the values in the test results column along " +
                "with FAIL if there is a violation to one of the defined rules.",
            link: "http://athenawebprod/static/ObjConFormal.html?report_action=ObjectivesConstraints&report_title=Objectives and Constraints Report Parameters"
        }
    ];

})();