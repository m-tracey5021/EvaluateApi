using System;
using EvaluateApi.Managers.Interfaces;
using LSharp.Math.Symbols;
using LSharp.Math.Comparison;

namespace EvaluateApi.Managers
{
    public class ComparisonManager : IComparisonManager
    {
        private readonly IParsingManager parsingManager;
        public ComparisonManager(IParsingManager parsingManager)
        {
            this.parsingManager = parsingManager;
        }
        public bool Execute(string instruction, string expression, string other)
        {
            Expression parsed = parsingManager.Parse(expression);

            Expression otherParsed = parsingManager.Parse(other);

            return parsed.Compare(GetInstruction(instruction), otherParsed);
        }
        public ComparisonInstruction GetInstruction(string instruction)
        {
            if (instruction == "isequal")
            {
                return ComparisonInstruction.IsEqual;
            }
            else if (instruction == "isequalbybase")
            {
                return ComparisonInstruction.IsEqualByBase;
            }
            else
            {
                throw new Exception("Instruction not recognised");
            }
        }
    }
}