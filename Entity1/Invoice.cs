﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity1
{
    public class Invoice
    {
        public int invoice_id { get; set; }
        public int  customer_id { get; set; }
        public DateTime date { get; set; }
        public decimal total { get; set; }
        public Boolean active { get; set; }
    }
}
