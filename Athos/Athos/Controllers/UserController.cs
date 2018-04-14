using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Athos.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Athos.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        UserDataAccessLayer dal = new UserDataAccessLayer();

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return dal.GetUsers();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            return dal.GetUserData(id);
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]User user)
        {
            dal.AddUser(user);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]User user)
        {
            user.ID = id;
            dal.UpdateUser(user);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            dal.DeleteUser(id);
        }
    }
}
