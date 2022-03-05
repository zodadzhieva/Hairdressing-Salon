using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hairdressingSalon.Data
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ServiceId { get; set; }
        public ICollection<Service> Services { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
