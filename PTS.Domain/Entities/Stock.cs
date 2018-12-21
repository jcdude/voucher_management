using PTS.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTS.Domain.Entities
{
    public class Stock
    {
        private string _pin;

        public int StockId { get; set; }
        public int ProductId { get; set; }
        public string Pin
        {
            get
            {
                return this._pin;
            }

            set
            {
                this._pin = Encypt.EncryptString(value);
            }
        }
        public bool Used { get; set; }


    }
}
