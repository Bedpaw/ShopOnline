﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Home : ControllerBase
    {
  
        // GET: api/<Home>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        /// <summary>
        /// Get specific user by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET api/<Home>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<Home>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<Home>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Home>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
