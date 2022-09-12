using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Oficina_Mecanica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MecanicoController : ControllerBase
    {
        // GET: api/<MecanicoController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<MecanicoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MecanicoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MecanicoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MecanicoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
