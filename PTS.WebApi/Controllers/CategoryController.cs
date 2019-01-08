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
    public class CategoryController : BaseController
    {
        // GET: api/Category/BySupplier
        [HttpGet("BySupplier/{token}/{supplierToken}", Name = "BySupplier")]
        public async Task<ActionResult<GetCategoriesViewModel>> Login(Guid token,Guid supplierToken)
        {
            return Ok(await Mediator.Send(new GetCategoriesBySupplierQuery { ExternalId = token,SupplierExternalId = supplierToken }));
        }
    }
}