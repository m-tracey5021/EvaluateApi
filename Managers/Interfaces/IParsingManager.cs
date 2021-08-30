using System;
using LSharp.Math.Symbols;

namespace EvaluateApi.Managers.Interfaces
{
    public interface IParsingManager
    {
        Expression Parse(string expression);
    }
}