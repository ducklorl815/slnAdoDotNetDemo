﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjAdoDotNetDemo.Module
{
    public class CProduct
    {
        public int id { get; set; }
        public string name { get; set; }
        public int qty { get; set; }
        public decimal cost { get; set; }
        public decimal price { get; set; }
        public bool sell { get; set; }
    }
}
