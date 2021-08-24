using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using LSharp.Parsing;
using LSharp.Symbols;

namespace EvaluateApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParsingController : ControllerBase
    {
        public ParsingController()
        {

        }
        [HttpGet]
        [Route("parse/{expression}")]
        public async Task<string> ParseExpression(string expression)
        {
            Symbol add = new Operation(true, SymbolType.Summation);

            Symbol x = new Variable(true, 'x');

            Symbol y = new Variable(true, 'y');

            Expression result = new Expression();

            result.SetRoot(add);

            result.AddNode(add, x);

            result.AddNode(add, y);

            return result.ToString();
        }
    }
}