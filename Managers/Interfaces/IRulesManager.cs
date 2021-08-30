using System;
using System.Collections.Generic;
using LSharp.Math.Symbols;
using LSharp.Math.Rules;

namespace EvaluateApi.Managers.Interfaces
{
    public interface IRulesManager
    {
        Expression Execute(string instruction, string expression);
        List<Expression> ExecuteRange(List<string> instructions, string expression);
        RuleApplicationInstruction GetInstruction(string instruction);
    }
}