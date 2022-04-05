using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace hairdressingSalon.Data
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
       
        [ForeignKey("Client")]
        public string IdClient { get; set; }
        public Client Client { get; set; }
        
        [ForeignKey("Product")]
        public int IdProduct { get; set; }
        public Product Product { get; set; }

        public int Quantity { get; set; }
        
    }
}
