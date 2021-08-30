using System;
using System.Collections.Generic;
using EvaluateApi.Models.Dbos;

namespace EvaluateApi.Repositories.Interfaces
{
    public interface IExpressionRepository
    {
        ExpressionDbo Get(int id);
        ExpressionDbo Get(int userId, int id);
        List<ExpressionDbo> GetAll();
        List<ExpressionDbo> GetAll(int userId);
        void Insert(ExpressionDbo expression);
        void Upsert(ExpressionDbo expression);
    }
    
}