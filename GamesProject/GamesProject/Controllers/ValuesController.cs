using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GamesProject.DataAccessLayer.Entities;
using GamesProject.DataAccessLayer.EntitiFramework;
using GamesProject.DataAccessLayer.Repositories;
using GamesProject.DataAccessLayer.Interfaces;

namespace GamesProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IUnitOfWork _db;
        public ValuesController(IUnitOfWork db)
        {
            _db = db;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            _db.Users.Create(new User() { Login = "shark", Name = "igor", Surname = "mykula", Password="b10b10f3e2" });
            _db.Save();
            return Ok();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
