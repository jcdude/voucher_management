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
using PTS.Application.Product.Models;
using PTS.Domain.Infrastructure;

namespace PTS.Application.Product.Queries
{
    public class GetSuppliersQueryHandler : IRequestHandler<GetSuppliersQuery, GetSuppliersViewModel>
    {
        private readonly PTSDbContext _context;
        private readonly INotificationService _notificationService;

        public GetSuppliersQueryHandler(
            PTSDbContext context,
            INotificationService notificationService)
        {
            _context = context;
            _notificationService = notificationService;
        }

        public async Task<GetSuppliersViewModel> Handle(GetSuppliersQuery request, CancellationToken cancellationToken)
        {
            var suppliers = await (from category in _context.Categories
                                join product in _context.Products
                                on category.CategoryId equals product.CategoryId
                                join stock in _context.Stocks
                                on product.ProductId equals stock.ProductId
                                join service in _context.Services
                                on stock.StockId equals service.StockId
                                join customer in _context.Customers
                                on service.CustomerId equals customer.CustomerId
                                where service.Customer.ExternalId == request.ExternalId
                                select new SupplierDetails
                                {
                                    SupplierId = product.Supplier.SupplierId,
                                    SupplierName = product.Supplier.CompanyName,
                                    Customer = customer
                                }).ToListAsync();


            if (suppliers.Equals(null))
            {
                throw new NotFoundException("Suppliers", request.ExternalId);
            }

            var expiryDate = DateTime.Now;
            expiryDate.AddHours(9);

            var customerForUpdate = suppliers.First().Customer;
            customerForUpdate.ExternalIdExpiry = expiryDate;
            _context.Update(customerForUpdate);
            await _context.SaveChangesAsync();

            return new GetSuppliersViewModel
            {
                Suppliers = suppliers
            };
        }
    }
}
