using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using EvaluateApi.Models;
using LSharp.Parsing;
using LSharp.Symbols;

namespace EvaluateApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ManipulationController : ControllerBase
    {
        public ManipulationController()
        {

        }
        [HttpGet]
        [Route("sumliketerms/{expression}")]
        public string SumLikeTerms(string expression)
        {
            ExpressionParser parser = new ExpressionParser();

            parser.ParseExpression(expression);

            Expression parsed = parser.parseTree;
            
            Expression result = parsed.SumLikeTerms(parsed.GetRoot());

            return result.ToString();
        }
        [HttpGet]
        [Route("distribute/{expression}")]
        public string Distribute(string expression)
        {
            ExpressionParser parser = new ExpressionParser();

            parser.ParseExpression(expression);

            Expression parsed = parser.parseTree;
            
            Expression result = parsed.Distribute(parsed.GetRoot());

            return result.ToString();
        }
        
    }
}