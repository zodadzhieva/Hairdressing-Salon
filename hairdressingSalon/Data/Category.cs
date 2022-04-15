using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace hairdressingSalon.Data
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
       
        public ICollection<Service> Services { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
