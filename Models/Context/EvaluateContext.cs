using System;
using Microsoft.EntityFrameworkCore;
using EvaluateApi.Models.Dbos;

namespace EvaluateApi.Models.Context
{
    public class EvaluateContext : DbContext
    {
        public DbSet<ExpressionDbo> expressions { get; set; }
        public DbSet<UserDbo> users { get; set; }
        public EvaluateContext(DbContextOptions<EvaluateContext> options) : base(options)
        {

        }
    }
}