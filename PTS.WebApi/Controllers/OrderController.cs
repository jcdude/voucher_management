using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PTS.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : BaseController
    {
        // POST: api/Order
        /*[HttpPost]
        public async Task<ActionResult<T>> Place(string username, string password)
        {
            return Ok(await Mediator.Send(new LoginCustomerQuery { Username = username, Password = password }));
        }*/
    }
}