using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using EvaluateApi.Models.Dbos;
using EvaluateApi.Models.Context;
using EvaluateApi.Repositories.Interfaces;

namespace EvaluateApi.Repositories
{
    public class ExpressionRepository : IExpressionRepository
    {
        private readonly EvaluateContext context;
        public ExpressionRepository(EvaluateContext context)
        {
            this.context = context;
        }
        public ExpressionDbo Get(int id)
        {
            foreach (ExpressionDbo expression in context.expressions)
            {
                if (id == expression.id)
                {
                    return expression;
                }
            }
            return null;
        }
        public ExpressionDbo Get(int userId, int id)
        {
            foreach (ExpressionDbo expression in context.expressions)
            {
                if (userId == expression.userId && id == expression.id)
                {
                    return expression;
                }
            }
            return null;
        }
        public List<ExpressionDbo> GetAll()
        {
            return context.expressions.ToList();
        }
        public List<ExpressionDbo> GetAll(int userId)
        {
            List<ExpressionDbo> result = new List<ExpressionDbo>();

            foreach (ExpressionDbo expression in context.expressions)
            {
                if (userId == expression.userId)
                {
                    result.Add(expression);
                }
            }
            return result;
        }
        public void Insert(ExpressionDbo expression)
        {
            context.Add(expression);

            context.SaveChanges();
        }
        public void Upsert(ExpressionDbo expression)
        {
            context.Entry(expression).State = expression.id == 0 ? EntityState.Added : EntityState.Modified;
            
            context.SaveChanges();
        }
    }
}