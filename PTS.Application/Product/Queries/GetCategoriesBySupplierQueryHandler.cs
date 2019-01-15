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
    public class GetCategoriesBySupplierQueryHandler : IRequestHandler<GetCategoriesBySupplierQuery, GetCategoriesViewModel>
    {
        private readonly PTSDbContext _context;
        private readonly INotificationService _notificationService;

        public GetCategoriesBySupplierQueryHandler(
            PTSDbContext context,
            INotificationService notificationService)
        {
            _context = context;
            _notificationService = notificationService;
        }

        public async Task<GetCategoriesViewModel> Handle(GetCategoriesBySupplierQuery request, CancellationToken cancellationToken)
        {
            var categories = await (from category in _context.Categories
                                join product in _context.Products
                                on category.CategoryId equals product.CategoryId
                                join stock in _context.Stocks
                                on product.ProductId equals stock.ProductId
                                join service in _context.Services
                                on stock.StockId equals service.StockId
                                join customer in _context.Customers
                                on service.CustomerId equals customer.CustomerId
                                where customer.ExternalId == request.ExternalId
                                && product.Supplier.ExternalId == request.SupplierExternalId
                                && service.Customer.ExternalIdExpiry >= DateTime.Now
                                    group product by new { category.CategoryId,category.Description,customer.CustomerId } into groupedByProduct
                                    select 
                                new 
                                {
                                    CategoryId = groupedByProduct.Key.CategoryId,
                                    CategoryName = groupedByProduct.Key.Description,
                                    groupedByProduct.Key.CustomerId
                                }
                                ).ToListAsync();


            if (categories.Equals(null) || categories.Count == 0)
            {
                throw new NotFoundException("Products", request.ExternalId);
            }

            var customerForUpdate = await _context.Customers.FirstOrDefaultAsync(c => c.CustomerId == categories.First().CustomerId);

            var expiryDate = DateTime.Now;
            expiryDate = expiryDate.AddHours(9);

            customerForUpdate.ExternalIdExpiry = expiryDate;
            _context.Update(customerForUpdate);
            await _context.SaveChangesAsync();

            return new GetCategoriesViewModel
            {
                Categories = (from categoryDetails in categories
                             select new CategoryDetails { CategoryId = categoryDetails.CategoryId, CategoryName = categoryDetails.CategoryName }).ToList()
            };
        }
    }
}
