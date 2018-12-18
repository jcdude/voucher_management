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

namespace PTS.Application.Customer.Queries.Login
{
    public class LoginCustomerQueryHandler : IRequestHandler<LoginCustomerQuery, Unit>
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

        public async Task<Customer> Handle(LoginCustomerQuery request, CancellationToken cancellationToken)
        {
            byte[] password = System.Text.Encoding.ASCII.GetBytes(request.Password);

            var entity = await _context.Customers
                .AnyAsync(e => e.Username == request.Username && e.Password == System.Security.Cryptography.MD5.Create().ComputeHash(password));

            if (entity == null)
            {
                throw new NotFoundException(nameof(Customer), request.Username);
            }

            return entity;
        }
}
