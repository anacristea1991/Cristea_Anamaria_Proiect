using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Cristea_Anamaria_Proiect.Models;

namespace Cristea_Anamaria_Proiect.Data
{
    public class Cristea_Anamaria_ProiectContext : DbContext
    {
        public Cristea_Anamaria_ProiectContext (DbContextOptions<Cristea_Anamaria_ProiectContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>().Ignore(t => t.MedicalStaffId);
            modelBuilder.Entity<Appointment>().Ignore(t => t.PatientId);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Cristea_Anamaria_Proiect.Models.City> City { get; set; }

        public DbSet<Cristea_Anamaria_Proiect.Models.County> County { get; set; }

        public DbSet<Cristea_Anamaria_Proiect.Models.Room> Room { get; set; }

        public DbSet<Cristea_Anamaria_Proiect.Models.MedicalStaff> MedicalStaff { get; set; }

        public DbSet<Cristea_Anamaria_Proiect.Models.Patient> Patient { get; set; }

        public DbSet<Cristea_Anamaria_Proiect.Models.Appointment> Appointment { get; set; }
    }
}
