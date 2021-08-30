using System;
using EvaluateApi.Managers.Interfaces;
using LSharp.Math.Symbols;
using LSharp.Math.Manipulation;

namespace EvaluateApi.Managers
{
    public class ManipulationManager : IManipulationManager
    {
        private readonly IParsingManager parsingManager;
        public ManipulationManager(IParsingManager parsingManager)
        {
            this.parsingManager = parsingManager;
        }
        public Expression Execute(string instruction, string expression)
        {
            Expression parsed = parsingManager.Parse(expression);

            return parsed.Manipulate(GetInstruction(instruction));
        }
        public ManipulationInstruction GetInstruction(string instruction)
        {
            if (instruction == "sumliketerms")
            {
                return ManipulationInstruction.SumLikeTerms;
            }
            else if (instruction == "distribute")
            {
                return ManipulationInstruction.Distribute;
            }
            else if (instruction == "cancel")
            {
                return ManipulationInstruction.Cancel;
            }
            else
            {
                throw new Exception("Instruction not recognised");
            }
        }
    }
}