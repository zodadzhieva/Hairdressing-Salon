using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hairdressingSalon.Data
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
