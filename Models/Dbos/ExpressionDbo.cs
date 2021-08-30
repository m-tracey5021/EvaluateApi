using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvaluateApi.Models.Dbos
{
    [Table("Expressions")]
    public class ExpressionDbo
    {
        public int id { get; set; }
        public int userId { get; set; }
        public string expression { get; set; }
        public string expressionName { get; set; }
    }
}