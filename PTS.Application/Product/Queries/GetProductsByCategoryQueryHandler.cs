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
    public class GetProductsByCategoryQueryHandler : IRequestHandler<GetProductsByCategoryQuery, GetProductsViewModel>
    {
        private readonly PTSDbContext _context;
        private readonly INotificationService _notificationService;

        public GetProductsByCategoryQueryHandler(
            PTSDbContext context,
            INotificationService notificationService)
        {
            _context = context;
            _notificationService = notificationService;
        }

        public async Task<GetProductsViewModel> Handle(GetProductsByCategoryQuery request, CancellationToken cancellationToken)
        {
            var products = await (from category in _context.Categories
                                join product in _context.Products
                                on category.CategoryId equals product.CategoryId
                                join stock in _context.Stocks
                                on product.ProductId equals stock.ProductId
                                join service in _context.Services
                                on stock.StockId equals service.StockId
                                join customer in _context.Customers
                                on service.CustomerId equals customer.CustomerId
                                where customer.ExternalId == request.ExternalId
                                && category.ExternalId == request.CategoryExternalId
                                && service.Customer.ExternalIdExpiry == DateTime.Now
                                  group product by new { product.ProductId,product.ProductName,customer } into groupedByProduct
                                select new ProductDetails
                                {
                                    ProductId = groupedByProduct.Key.ProductId,
                                    ProductName = groupedByProduct.Key.ProductName,
                                    Customer = groupedByProduct.Key.customer
                                }).ToListAsync();


            if (products.Equals(null))
            {
                throw new NotFoundException("Products", request.ExternalId);
            }

            var expiryDate = DateTime.Now;
            expiryDate.AddHours(9);

            var customerForUpdate = products.First().Customer;
            customerForUpdate.ExternalIdExpiry = expiryDate;
            _context.Update(customerForUpdate);
            await _context.SaveChangesAsync();

            return new GetProductsViewModel
            {
                Products = products
            };
        }
    }
}
