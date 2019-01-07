using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PTS.Application.Product.Models;
using PTS.Application.Product.Queries;

namespace PTS.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : BaseController
    {
        // GET: api/Supplier/Available
        [HttpGet("Available/{token}", Name = "Available")]
        public async Task<ActionResult<GetSuppliersViewModel>> Login(Guid token)
        {
            return Ok(await Mediator.Send(new GetSuppliersQuery { ExternalId = token }));
        }
    }
}