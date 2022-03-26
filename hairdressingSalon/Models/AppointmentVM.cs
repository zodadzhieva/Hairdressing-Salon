using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace hairdressingSalon.Models
{
    public class AppointmentVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public int IdClient { get; set; }
       
       

        public int IdService { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public List<SelectListItem> Service { get; set; }
       
        [DataType(DataType.Date)]
        [Display(Name = "Дата на запазване на час:")]
        public DateTime DateApropr { get; set; }
      
       
        public int IdHairdresser { get; set; }
       [Required(ErrorMessage = "This field is required")]
        public List<SelectListItem> Hairdresser { get; set; }


    }
}
