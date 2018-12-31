using MediatR;
using PTS.Application.Product.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTS.Application.Product.Queries
{
    public class GetSuppliersQuery : IRequest<GetSuppliersViewModel>
    {
        public Guid ExternalId { get; set; }
    }
}
