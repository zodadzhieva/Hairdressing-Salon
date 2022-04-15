using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace hairdressingSalon.Models
{
    public class CategoryVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string Name { get; set; }
        
         [Required(ErrorMessage = "This field is required")]
        public string ServiceId { get; set; }
       
      
    }
}
