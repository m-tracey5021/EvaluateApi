using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using EvaluateApi.Repositories.Interfaces;
using EvaluateApi.Models.Dbos;

namespace EvaluateApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExpressionController : ControllerBase
    {
        private readonly IExpressionRepository repository;
        public ExpressionController(IExpressionRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        [Route("{userId}/{id}")]
        public ExpressionDbo Get(int userId, int id)
        {
            return repository.Get(userId, id);
        }

        [HttpGet]
        [Route("{userId}")]
        public List<ExpressionDbo> GetAll(int userId)
        {
            return repository.GetAll(userId);
        }

        [HttpPost]
        [Route("add")]
        public void Add([FromBody] ExpressionDbo expression)
        {
            repository.Insert(expression);
        }

        [HttpPost]
        [Route("save")]
        public void Save([FromBody] ExpressionDbo expression)
        {
            repository.Upsert(expression);
        }
    }
}