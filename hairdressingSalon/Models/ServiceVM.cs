using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace hairdressingSalon.Models
{
    public class ServiceVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Name { get; set; }

        public int IdCategory { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public List<SelectListItem> Categories { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string Description { get; set; }
      
        [Required(ErrorMessage = "This field is required")]
        public string Photo { get; set; }
       
        [Required(ErrorMessage = "This field is required")]
        public double Price { get; set; }
       
        [DataType(DataType.Date)]
        [Display(Name = "Дата на вписване:")]
        public DateTime DateOfEntry { get; set; }
    }
}