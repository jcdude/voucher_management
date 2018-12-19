using MediatR;
using PTS.Application.Customer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTS.Application.Customer.Queries.Login
{
    public class LoginCustomerQuery : IRequest<CustomerViewModel>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
