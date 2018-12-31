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
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, GetCategoriesViewModel>
    {
        private readonly PTSDbContext _context;
        private readonly INotificationService _notificationService;

        public GetCategoriesQueryHandler(
            PTSDbContext context,
            INotificationService notificationService)
        {
            _context = context;
            _notificationService = notificationService;
        }

        public async Task<GetCategoriesViewModel> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
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
                                where service.Customer.ExternalId == request.ExternalId
                                select new CategoryDetails
                                {
                                    CategoryId = category.CategoryId,
                                    CategoryName = category.CategoryName,
                                    Customer = customer
                                }).ToListAsync();


            if (categories.Equals(null))
            {
                throw new NotFoundException("Categories", request.ExternalId);
            }

            var expiryDate = DateTime.Now;
            expiryDate.AddHours(9);

            var customerForUpdate = categories.First().Customer;
            customerForUpdate.ExternalIdExpiry = expiryDate;
            _context.Update(customerForUpdate);
            await _context.SaveChangesAsync();

            return new GetCategoriesViewModel
            {
                Categories = categories
            };
        }
    }
}
