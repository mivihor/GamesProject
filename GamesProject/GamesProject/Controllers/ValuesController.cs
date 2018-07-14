using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GamesProject.DataAccessLayer.Entities;
using GamesProject.DataAccessLayer.EntitiFramework;
using GamesProject.DataAccessLayer.Repositories;
using GamesProject.DataAccessLayer.Interfaces;
using Newtonsoft.Json;
using GamesProject.BusinessLogicLayer.Interfaces;
using GamesProject.BusinessLogicLayer.DataTransferModels;

namespace GamesProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        //private IUnitOfWork _db;
        private IUserService _userService;
        public ValuesController(IUserService userService)
        {
            //_db = db;
            _userService = userService;
        }


        [HttpGet]
        public ActionResult<string> Create()
        {
            UserDTM user = new UserDTM() { LoginDTM = "SH@RK", NameDTM = "Igor", SurnameDTM = "Mykula", PasswordDTM = "MyHashPassword", RoleDTM = "Admin" };
            _userService.CreateUser(user);
            return Ok(user.LoginDTM);
        }

        // GET api/values
        //[HttpPost]
        // public ActionResult<IEnumerable<string>> Get()
        // {
        //     _db.Users.Create(new User() { Login = "shark", Name = "igor", Surname = "mykula", Password = "b10b10f3e2" });
        //     _db.Save();
        //     return Ok();
        // }
        // public JsonResult GetAll()
        // {
        //     return new JsonResult(_db.Users.GetAll().ToList<User>());
        // }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

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
