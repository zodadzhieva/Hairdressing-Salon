using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace hairdressingSalon.Data
{
    public class Appointment
    {
        public int Id { get; set; }
       
        [ForeignKey("Clients")]
        public int IdClient { get; set; }
        public Client Client { get; set; }
       
        [ForeignKey("Service")]
        public int IdService { get; set; }
        public Service Service { get; set; }
       
        public DateTime DateApropr { get; set; }
       
        [ForeignKey("HairDresser")]
        public int IdHairDresser { get; set; }
        public Hairdresser Hairdresser { get; set; }
    }
}
