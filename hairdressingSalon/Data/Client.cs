using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace hairdressingSalon.Data
{
    public class Client:IdentityUser
    {

        public string Name { get; set; }
       
        public string LastName { get; set; }
       
        public int Phone { get; set; }
      
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
