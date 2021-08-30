using System;
using LSharp.Math.Symbols;
using LSharp.Math.Evaluation;

namespace EvaluateApi.Managers.Interfaces
{
    public interface IEvaluationManager
    {
        Expression Execute(string instruction, string expression);
        EvaluationInstruction GetInstruction(string instruction);
    }
}