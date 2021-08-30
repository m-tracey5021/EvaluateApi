using System;
using System.Collections.Generic;
using EvaluateApi.Managers.Interfaces;
using LSharp.Math.Symbols;
using LSharp.Math.Rules;

namespace EvaluateApi.Managers
{
    public class RulesManager : IRulesManager
    {
        private readonly IParsingManager parsingManager;
        public RulesManager(IParsingManager parsingManager)
        {
            this.parsingManager = parsingManager;
        }
        public Expression Execute(string instruction, string expression)
        {
            Expression parsed = parsingManager.Parse(expression);

            return parsed.ApplyRule(GetInstruction(instruction));
        }
        public List<Expression> ExecuteRange(List<string> instructions, string expression)
        {
            List<Expression> results = new List<Expression>();

            foreach (string instruction in instructions)
            {
                results.Add(Execute(instruction, expression));
            }
            return results;
        }
        public RuleApplicationInstruction GetInstruction(string instruction)
        {
            if (instruction == "exponentruleone")
            {
                return RuleApplicationInstruction.ExponentRuleOne;
            }
            else if (instruction == "exponentruletwo")
            {
                return RuleApplicationInstruction.ExponentRuleTwo;
            }
            else if (instruction == "exponentrulethree")
            {
                return RuleApplicationInstruction.ExponentRuleThree;
            }
            else if (instruction == "exponentrulefour")
            {
                return RuleApplicationInstruction.ExponentRuleFour;
            }
            else if (instruction == "exponentrulefive")
            {
                return RuleApplicationInstruction.ExponentRuleFive;
            }
            else if (instruction == "exponentrulesix")
            {
                return RuleApplicationInstruction.ExponentRuleSix;
            }
            else
            {
                throw new Exception("Instruction not recognised");
            }
        }
    }
}