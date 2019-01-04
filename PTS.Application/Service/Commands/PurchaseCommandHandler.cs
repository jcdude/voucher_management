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
using PTS.Application.Service.Models;
using PTS.Domain.Infrastructure;
using PTS.Application.Service.Commands;

namespace PTS.Application.Service.Queries.Login
{
    public class PurchaseCommandHandler : IRequestHandler<PurchaseCommand, PurchaseViewModel>
    {
        private readonly PTSDbContext _context;
        private readonly INotificationService _notificationService;

        public PurchaseCommandHandler(
            PTSDbContext context,
            INotificationService notificationService)
        {
            _context = context;
            _notificationService = notificationService;
        }

        public async Task<PurchaseViewModel> Handle(PurchaseCommand request, CancellationToken cancellationToken)
        {
            var data = await (from category in _context.Categories
                                    join product in _context.Products
                                    on category.CategoryId equals product.CategoryId
                                    join stock in _context.Stocks
                                    on product.ProductId equals stock.ProductId
                                    join service in _context.Services
                                    on stock.StockId equals service.StockId
                                    join customer in _context.Customers
                                    on service.CustomerId equals customer.CustomerId
                                    where service.Customer.ExternalId == request.ExternalId
                                    select new 
                                    {
                                        stock.Pin,
                                        Customer = customer,
                                        StockItem = stock
                                    }).FirstAsync();


            if (data.Equals(null))
            {
                throw new NotFoundException("Pin Retreival", request.ExternalId);
            }

            var expiryDate = DateTime.Now;
            expiryDate.AddHours(9);

            data.Customer.ExternalIdExpiry = expiryDate;
            _context.Update(data.Customer);

            data.StockItem.Used = true;
            _context.Update(data.StockItem);

            await _context.SaveChangesAsync();

            return new PurchaseViewModel
            {
                Pin = Encypt.DecryptString(data.Pin)
            };
        }
    }
}
