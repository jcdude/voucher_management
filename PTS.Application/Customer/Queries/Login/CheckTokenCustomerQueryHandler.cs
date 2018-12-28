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
using PTS.Domain.Infrastructure;

namespace PTS.Application.Customer.Queries.Login
{
    public class CheckTokenCustomerQueryHandler : IRequestHandler<CheckTokenCustomerQuery, CheckTokenCustomerViewModel>
    {
        private readonly PTSDbContext _context;
        private readonly INotificationService _notificationService;

        public CheckTokenCustomerQueryHandler(
            PTSDbContext context,
            INotificationService notificationService)
        {
            _context = context;
            _notificationService = notificationService;
        }

        public async Task<CheckTokenCustomerViewModel> Handle(CheckTokenCustomerQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Customers
                .Where(e =>
                e.Username == request.Username
                && e.ExternalId == request.ExternalId
                )
                .FirstOrDefaultAsync(cancellationToken);

            if (entity.Equals(null) || entity.ExternalIdExpiry >= DateTime.Now)
            {
                return new CheckTokenCustomerViewModel
                {
                    IsValid = false,
                    ExternalId = request.ExternalId
                };
            }

            return new CheckTokenCustomerViewModel
            {
                IsValid = true,
                ExternalId = entity.ExternalId
            };
        }
    }
}
