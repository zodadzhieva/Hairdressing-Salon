using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hairdressingSalon.Data
{
    public class Hairdresser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Action { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
    }
}
