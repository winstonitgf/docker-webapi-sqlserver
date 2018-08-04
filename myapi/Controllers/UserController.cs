using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using myapi.Models;
using myapi.repository;

namespace myapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserRepository userRepository;
        public UserController()
        {
            userRepository = new UserRepository();
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return userRepository.GetAll();
        }
        // POST api/values
        [HttpPost]
        public User Post([FromBody]User prod)
        {
            if (ModelState.IsValid)
                userRepository.Add(prod);

            return prod;
        }
        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]User prod)
        {
            prod.id = id;
            if (ModelState.IsValid)
                userRepository.Update(prod);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            userRepository.Delete(id);
        }
    }
}