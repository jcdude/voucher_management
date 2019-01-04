using MediatR;
using PTS.Application.Product.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTS.Application.Product.Queries
{
    public class GetCategoriesBySupplierQuery : IRequest<GetCategoriesViewModel>
    {
        public Guid ExternalId { get; set; }
        public Guid SupplierExternalId { get; set; }
    }
}
