using PTS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTS.Application.Product.Models
{
    public class GetProductsViewModel
    {
        public ICollection<ProductDetails> Products { get; set; }
    }

    public class ProductDetails
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public Domain.Entities.Customer Customer { get; set; }
    }
}
