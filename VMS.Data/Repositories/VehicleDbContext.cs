using System;
using System.Data.Common;
using VMS.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using VMS.Data.Seeders;

namespace VMS.Data.Repositories
{
    public class VehicleDbContext : DbContext
    {
        // complete the context
        public DbSet<Vehicle> Vehicles {get; set;}
        public DbSet<Service> ServiceRecords {get; set;}

        //use sqlite database

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder )
    {
            optionsBuilder.UseSqlite("Filename=SMS.db");
        
        
        
     }

    public void Initialise()
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
      
    }
    }
}