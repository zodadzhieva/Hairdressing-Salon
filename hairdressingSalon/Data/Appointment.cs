using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hairdressingSalon.Data
{
    public class Appointment
    {
        public int Id { get; set; }
        public int IdClient { get; set; }
        public Client Client { get; set; }
        public int IdService { get; set; }
        public Service Service { get; set; }
        public int Data { get; set; }
        public string HairdresserName { get; set; }
    }
}
