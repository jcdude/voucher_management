using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PTS.Application.Customer.Models;
using PTS.Application.Customer.Queries.Login;

namespace PTS.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : BaseController
    {
        // GET: api/Customer
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Customer/username/password
        [HttpGet("{username}/{password}", Name = "Get")]
        public async Task<ActionResult<LoginCustomerViewModel>> Login(string username, string password)
        {
            return Ok(await Mediator.Send(new LoginCustomerQuery { Username = username,Password = password }));
        }

        // GET: api/Customer/CheckToken/{token}
        [HttpGet("CheckToken/{token}", Name = "CheckToken")]
        public async Task<ActionResult<CheckTokenCustomerViewModel>> Login(Guid token)
        {
            return Ok(await Mediator.Send(new CheckTokenCustomerQuery { ExternalId = token }));
        }

        // POST: api/Customer
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Customer/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
