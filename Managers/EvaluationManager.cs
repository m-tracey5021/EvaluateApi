using System;
using EvaluateApi.Managers.Interfaces;
using LSharp.Math.Symbols;
using LSharp.Math.Evaluation;

namespace EvaluateApi.Managers
{
    public class EvaluationManager : IEvaluationManager
    {
        private readonly IParsingManager parsingManager;
        public EvaluationManager(IParsingManager parsingManager)
        {
            this.parsingManager = parsingManager;
        }
        public Expression Execute(string instruction, string expression)
        {
            Expression parsed = parsingManager.Parse(expression);

            return parsed.Evaluate(GetInstruction(instruction));
        }
        public EvaluationInstruction GetInstruction(string instruction)
        {
            if (instruction == "evaluateconstants")
            {
                return EvaluationInstruction.EvaluateConstants;
            }
            else
            {
                throw new Exception("Instruction not recognised");
            }
        }
    }
}