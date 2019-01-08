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
    public class ProductController : BaseController
    {
        // GET: api/Product/BySupplier
        [HttpGet("ByCategory/{token}/{supplierToken}", Name = "ByCategory")]
        public async Task<ActionResult<GetProductsViewModel>> Login(Guid token, Guid supplierToken)
        {
            return Ok(await Mediator.Send(new GetProductsByCategoryQuery { ExternalId = token, CategoryExternalId = supplierToken }));
        }
    }
}