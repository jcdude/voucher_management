using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTS.Application.Order.Commands
{
    class CreateOrderCommand : IRequest
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public string ProductId { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}
