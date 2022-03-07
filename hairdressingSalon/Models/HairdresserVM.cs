using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace hairdressingSalon.Models
{
    public class HairdresserVM
    {
       
        public int Id { get; set; }
       
        [Required(ErrorMessage = "This field is required")]
        public string Name { get; set; }
      
        [Required(ErrorMessage = "This field is required")]
        public string LastName { get; set; }
       
       [Required(ErrorMessage = "This field is required")]
        public string Speciality { get; set; }
       
       
    }
}
