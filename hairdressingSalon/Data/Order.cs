using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hairdressingSalon.Data
{
    public class Order
    {
        public int Id { get; set; }
        public int IdClient { get; set; }
        public Client Client { get; set; }
        public int IdProduct { get; set; }
        public Product Product { get; set; }
        public int Number { get; set; }
    }
}
