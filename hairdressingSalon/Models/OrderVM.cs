using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace hairdressingSalon.Models
{
    public class OrderVM
    {
        public int Id { get; set; }

        public string IdClient { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public List<SelectListItem> Client { get; set; }

        public int IdProduct { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public List<SelectListItem> Product { get; set; }
        
        [Required(ErrorMessage = "This field is required")]
        public int Quantity { get; set; }

       

    
    }
}
