using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _context;

        public ValuesController(DataContext context)
        {
            this._context = context;

        }

        [HttpGet("my-values")]
        public ActionResult GetTestObject()
        {
            var person = new Person() { Name = "Mattias Hensdal", Age = 46};

            return Ok(person);
        }

        public async Task<IActionResult> GetVales() 
        {
            var values = await _context.Values.ToListAsync();

            return Ok(values);
        }

        // GET api/values
        /*[HttpGet]
       public ActionResult<IEnumerable<string>> Get()
       {
           return new string[] { "value1", "value2" };
       }*/


        /*public ActionResult GetAction()
        {
            return Ok(new
            {
                firstName = "Mattias",
                lastName = "Hensdal",
            });
        }*/

        // GET api/values/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetValue(int id)
        {
            var value = await _context.Values.FirstOrDefaultAsync(x => x.Id == id);

            return Ok(value);
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

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
