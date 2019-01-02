using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PTS.Application.Service.Commands;
using PTS.Application.Service.Models;

namespace PTS.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : BaseController
    {
        // POST api/customers
        [HttpPost("/purchase")]
        public async Task<ActionResult<PurchaseViewModel>> Purchase([FromBody]PurchaseCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}