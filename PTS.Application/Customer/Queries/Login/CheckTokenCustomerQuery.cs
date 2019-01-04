using MediatR;
using PTS.Application.Customer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTS.Application.Customer.Queries.Login
{
    public class CheckTokenCustomerQuery : IRequest<CheckTokenCustomerViewModel>
    {
        public Guid ExternalId { get; set; }
    }
}
