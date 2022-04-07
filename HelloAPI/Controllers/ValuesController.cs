using HelloAPIDatabase;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HelloAPI.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class ValuesController : ControllerBase
   {
      IMongoDBBase _mongoDBBase;
      public ValuesController(IMongoDBBase mongoDBBase)
      {
         _mongoDBBase = mongoDBBase;
         _mongoDBBase.CollectionName = "users";
      }
      // GET: api/<ValuesController>
      [HttpGet]
      public IEnumerable<string> Get()
      {
         return new string[] { "value1", "value2" };
      }

      // GET api/<ValuesController>/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
         BsonDocument data = new BsonDocument();
         _mongoDBBase.Get("id", id.ToString());
         return "value";
      }

      // POST api/<ValuesController>
      [HttpPost]
      public void Post([FromBody] string value)
      {
         BsonDocument data = new BsonDocument();
         BsonDocument.Parse(value);
         _mongoDBBase.Insert(data);
      }

      // PUT api/<ValuesController>/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody] string value)
      {
         _mongoDBBase.Update("id", id.ToString(), value);
      }

      // DELETE api/<ValuesController>/5
      [HttpDelete("{id}")]
      public void Delete(int id)
      {
         _mongoDBBase.Delete("id", id.ToString());
      }
   }
}
