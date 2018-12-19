using System;
using System.Collections.Generic;
using System.Text;

namespace PTS.Application.Customer.Models
{
    public class CustomerViewModel
    {
        public string CustomerId { get; set; }
        public string Username { get; set; }
        public byte[] Password { get; set; }
        public Guid ExternalId { get; set; }
    }
}
