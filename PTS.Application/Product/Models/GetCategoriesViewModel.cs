using PTS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTS.Application.Product.Models
{
    public class GetCategoriesViewModel
    {
        public ICollection<CategoryDetails> Categories { get; set; }
    }

    public class CategoryDetails
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public Domain.Entities.Customer Customer { get; set; }
    }
}
