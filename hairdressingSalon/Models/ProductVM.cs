using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace hairdressingSalon.Models
{
    public class ProductVM
    {
        public int Id { get; set; }
       
     
        public string Name { get; set; }

        public int IdCategory { get; set; }
       //Required(ErrorMessage = "This field is required")]
        public List<SelectListItem> Categories { get; set; }
       
     
        public string Manufacture { get; set; }
       
        [Required(ErrorMessage = "This field is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.Date)]
        [Display(Name = "Дата на вписване:")]
        public DateTime DateOfEntryy { get; set; }
    }
}
