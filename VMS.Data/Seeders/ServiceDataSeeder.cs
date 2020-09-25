using System;
using System.Collections.Generic;
using System.Xml.Schema;
using VMS.Data.Models;
using VMS.Data.Repositories;
using VMS.Data.Services;


namespace VMS.Data.Seeders
{
    public static class ServiceDataSeeder
    {
   
        public static void Seed(IVehicleService vtx)
        {    
            // use the service to seed the database with sample data 
            // when running the web project     
            
            // mmckn - create instance of service and initialise
            //mmcnk - vtx already as an instance of the database
            //we can access database using vtx
            vtx.Initialise();


            vtx.AddVehicle("ford", "mondeo", "nRZ4246", "Petrol",4,"https://images.pexels.com/photos/2071/broken-car-vehicle-vintage.jpg?auto=compress&cs=tinysrgb&dpr=3&h=650&w=940");
            vtx.AddVehicle("Vauxhall", "Astra", "CYX5624", "Diesel",4,"https://images.pexels.com/photos/116675/pexels-photo-116675.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940");
            vtx.AddVehicle("Ford", "Focus", "MNY6879", "Petrol", 4,"https://images.pexels.com/photos/170811/pexels-photo-170811.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940");
            var newService = new Service
            {
                VehicleId = 1,
                MechanicName = "John",
                VehicleMileage = 1000000,
                RepairSummary = "unfixable",
                ServiceCost = 50.50,
                ServiceDate = DateTime.Today
                
                
            };
            vtx.AddService(newService);
            var nService = new Service
            {
                VehicleId = 2,
                MechanicName = "Jon",
                VehicleMileage = 1000,
                RepairSummary = "Repaired rear tire puncture",
                ServiceCost = 50.50,
                ServiceDate = DateTime.Today

            };
            vtx.AddService(nService);
            var nervice = new Service
            {
                VehicleId = 2,
                MechanicName = "Joseph",
                VehicleMileage = 1000,
                RepairSummary = "Replaced Engine",
                ServiceCost = 1000,
                ServiceDate = DateTime.Now
            };
            vtx.AddService(nervice);









        }
    }
}
   