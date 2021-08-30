using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using EvaluateApi.Managers.Interfaces;

namespace EvaluateApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommandController : ControllerBase
    {
        private readonly IComparisonManager comparisonManager;
        private readonly IEvaluationManager evaluationManager;
        private readonly IManipulationManager manipulationManager;
        private readonly IRulesManager rulesManager;
        public CommandController
        (
            IComparisonManager comparisonManager,
            IEvaluationManager evaluationManager,
            IManipulationManager manipulationManager,
            IRulesManager rulesManager
        )
        {
            this.comparisonManager = comparisonManager;
            this.evaluationManager = evaluationManager;
            this.manipulationManager = manipulationManager;
            this.rulesManager = rulesManager;
        }

        [HttpGet]
        [Route("sumliketerms/{expression}")]
        public string SumLikeTerms(string expression)
        {
            return manipulationManager.Execute("sumliketerms", expression).ToString();
        }

        [HttpGet]
        [Route("distribute/{expression}")]
        public string Distribute(string expression)
        {
            return manipulationManager.Execute("distribute", expression).ToString();
        }

        [HttpGet]
        [Route("cancel/{expression}")]
        public string Cancel(string expression)
        {
            return manipulationManager.Execute("cancel", expression).ToString();
        }

        [HttpGet]
        [Route("evaluateconstants/{expression}")]
        public string EvaluateConstants(string expression)
        {
            return evaluationManager.Execute("evaluateconstants", expression).ToString();
        }

        [HttpGet]
        [Route("isequal/{expression}/{other}")]
        public bool IsEqual(string expression, string other)
        {
            return comparisonManager.Execute("isequal", expression, other);
        }

        [HttpGet]
        [Route("isequalbybase/{expression}/{other}")]
        public bool IsEqualByBase(string expression, string other)
        {
            return comparisonManager.Execute("isequalbybase", expression, other);
        }

        [HttpGet]
        [Route("applyexponentrules/{expression}")]
        public List<string> ApplyExponentRules(string expression)
        {
            List<string> instructions = new List<string>()
            {
                "exponentruleone",
                "exponentruletwo",
                "exponentrulethree",
                "exponentrulefour",
                "exponentrulefive",
                "exponentrulesix",
            };
            List<string> results = rulesManager.ExecuteRange(instructions, expression).Select(x => x.ToString()).ToList();

            return results;
        }

        [HttpGet]
        [Route("er1/{expression}")]
        public string ApplyExponentRuleOne(string expression)
        {
            return rulesManager.Execute("exponentruleone", expression).ToString();
        }

        [HttpGet]
        [Route("er2/{expression}")]
        public string ApplyExponentRuleTwo(string expression)
        {
            return rulesManager.Execute("exponentruletwo", expression).ToString();
        }

        [HttpGet]
        [Route("er3/{expression}")]
        public string ApplyExponentRuleThree(string expression)
        {
            return rulesManager.Execute("exponentrulethree", expression).ToString();
        }

        [HttpGet]
        [Route("er4/{expression}")]
        public string ApplyExponentRuleFour(string expression)
        {
            return rulesManager.Execute("exponentrulefour", expression).ToString();
        }

        [HttpGet]
        [Route("er5/{expression}")]
        public string ApplyExponentRuleFive(string expression)
        {
            return rulesManager.Execute("exponentrulefive", expression).ToString();
        }

        [HttpGet]
        [Route("er6/{expression}")]
        public string ApplyExponentRuleSix(string expression)
        {
            return rulesManager.Execute("exponentrulesix", expression).ToString();
        }
        

    }
}