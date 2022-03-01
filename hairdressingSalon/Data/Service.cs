using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hairdressingSalon.Data
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string category { get; set; }
        public string description { get; set; }
        public string photo { get; set; }

        public double price { get; set; }
        public int data { get; set; }
        public virtual ICollection<Service> Services { get; set; }
    }
}

