using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TicketApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private static List<string> test;
        public ValuesController()
        {
            if (test == null)
            {
                test = new List<string>();
            }
        }
        // GET api/values //
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return test;
        //}

        // GET api/values/5
        [HttpGet]
        public string Get(int id)
        {
            try
            {
                
                return test[id];
            }
            catch
            {
                return "Namnet finns ej";
            }
        }

        // POST api/values
       
        [HttpPost]
        public void Post([FromBody]string value)
        {
          
            test.Add(value);
          

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
            test[id] = value;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            test.RemoveAt(id);
        }
    }
}
