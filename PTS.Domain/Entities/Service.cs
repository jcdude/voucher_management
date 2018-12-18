﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PTS.Domain.Entities
{
    public class Service
    {
        public int ServiceId { get; set; }
        public int ProductId { get; set; }
        public bool Used { get; set; }
        public string Pin { get; set; }
        public int OrderDetailId { get; set; }

        public OrderDetail OrderDetail { get; set; }
        public Product Product { get; set; }
    }
}