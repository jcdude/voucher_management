using System;
using System.Collections.Generic;
using System.Text;

namespace PTS.Application.Customer.Models
{
    public class CheckTokenCustomerViewModel
    {
        public bool IsValid { get; set; }
        public Guid ExternalId { get; set; }
    }
}
