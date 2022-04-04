using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace hairdressingSalon.Data
{
    public class HairdresserContext : IdentityDbContext<Client>
       {
        public HairdresserContext()
        {

        }

        public HairdresserContext(DbContextOptions<HairdresserContext> options) :
            base(options)
        {

        }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Hairdresser> Hairdressers { get; set; }
        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
    }
}
