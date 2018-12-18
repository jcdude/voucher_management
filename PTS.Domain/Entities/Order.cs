using System;
using System.Collections.Generic;
using System.Text;

namespace PTS.Domain.Entities
{
    public class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int OrderId { get; set; }
        public string CustomerId { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }

        public Customer Customer { get; set; }
        public Employee Employee { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; private set; }
    }
}
