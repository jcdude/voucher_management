using MediatR;
using Microsoft.EntityFrameworkCore;
using PTS.Application.Interfaces;
using PTS.Domain.Exceptions;
using PTS.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using PTS.Domain.Entities;
using System.Linq;
using PTS.Application.Customer.Models;

namespace PTS.Application.Customer.Queries.Login
{
    public class LoginCustomerQueryHandler : IRequestHandler<LoginCustomerQuery, CustomerViewModel>
    {
        private readonly PTSDbContext _context;
        private readonly INotificationService _notificationService;

        public LoginCustomerQueryHandler(
            PTSDbContext context,
            INotificationService notificationService)
        {
            _context = context;
            _notificationService = notificationService;
        }

        public async Task<CustomerViewModel> Handle(LoginCustomerQuery request, CancellationToken cancellationToken)
        {
            byte[] password = System.Text.Encoding.ASCII.GetBytes(request.Password);

            var entity = await _context.Customers
                .Where(e =>
                e.Username == request.Username
                && e.Password == System.Security.Cryptography.MD5.Create().ComputeHash(password))
                .FirstOrDefaultAsync(cancellationToken);

            if (entity.Equals(null))
            {
                throw new NotFoundException(nameof(entity), request.Username);
            }

            return new CustomerViewModel
            {
                CustomerId = entity.CustomerId,
                Password = entity.Password,
                Username = entity.Username
            };
        }
    }
}
