using PTS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTS.Application.Product.Models
{
    public class GetSuppliersViewModel
    {
        public ICollection<SupplierDetails> Suppliers { get; set; }
    }

    public class SupplierDetails
    {
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public Domain.Entities.Customer Customer { get; set; }
    }
}
