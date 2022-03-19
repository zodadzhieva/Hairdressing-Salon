using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace hairdressingSalon.Data
{
    public class Service
    {
        public int Id { get; set; }

        public string Name { get; set; }
      
       
        public int IdCategory { get; set; }
        public Category Category { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }

        public double Price { get; set; }
        public DateTime DateOfEntry { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}

