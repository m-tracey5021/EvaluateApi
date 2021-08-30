using System;
using EvaluateApi.Managers.Interfaces;
using LSharp.Math.Symbols;
using LSharp.Parsing;

namespace EvaluateApi.Managers
{
    public class ParsingManager : IParsingManager
    {
        public Expression Parse(string expression)
        {
            ExpressionParser parser = new ExpressionParser();

            return parser.ParseExpression(expression);
        }
    }
}