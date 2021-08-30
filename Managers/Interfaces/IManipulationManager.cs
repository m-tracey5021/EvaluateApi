using System;
using LSharp.Math.Symbols;
using LSharp.Math.Manipulation;

namespace EvaluateApi.Managers.Interfaces
{
    public interface IManipulationManager
    {
        Expression Execute(string instruction, string expression);
        ManipulationInstruction GetInstruction(string instruction);
    }
}