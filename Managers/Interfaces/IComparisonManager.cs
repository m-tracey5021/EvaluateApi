using System;
using LSharp.Math.Symbols;
using LSharp.Math.Comparison;

namespace EvaluateApi.Managers.Interfaces
{
    public interface IComparisonManager
    {
        bool Execute(string instruction, string expression, string other);
        ComparisonInstruction GetInstruction(string instruction);
    }
}