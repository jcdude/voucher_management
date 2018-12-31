using System;
using System.Collections.Generic;
using System.Text;

namespace PTS.Domain.Entities
{
    public class Service
    {
        public int ServiceId { get; set; }
        public int StockId { get; set; }
        public int CustomerId { get; set; }
        public bool Used { get; set; }
        public string Pin { get; set; }
        
        public Stock Stock { get; set; }
        public Customer Customer { get; set; }
    }
}
