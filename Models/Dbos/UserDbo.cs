using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvaluateApi.Models.Dbos
{
    [Table("Users")]
    public class UserDbo
    {
        public int id { get; set; }
        public string email { get; set; }
        public string pass { get; set; }
    }
}