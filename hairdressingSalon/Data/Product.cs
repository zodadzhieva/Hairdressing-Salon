using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace hairdressingSalon.Data
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("Category")]
        public int IdCategory { get; set; }
        public Category Category { get; set; }
        public string Manufacture { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public DateTime DateOfEntryy { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
