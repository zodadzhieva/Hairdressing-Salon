﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hairdressingSalon.Data
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Manufacture { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Data { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
