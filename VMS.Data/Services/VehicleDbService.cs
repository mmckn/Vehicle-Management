using System;
using System.Linq;
using System.Collections.Generic;
using System.Xml;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SQLitePCL;
using VMS.Data.Models;
using VMS.Data.Repositories;
using VMS.Data.Seeders;

namespace VMS.Data.Services
{
    // implement each of these methods (removing the thow statements)
    public class VehicleDbService : IVehicleService
    {
        private readonly VehicleDbContext vtx;

        public VehicleDbService()
        { // constructor which implements instance of vehicleDbContext
             vtx = new VehicleDbContext();
           
            
        }
        
        public Service AddService(Service s)
        { // create service record linked to a vehicle and
            //add it to database

            var newService = new Service
            {
                VehicleId = s.VehicleId,
                MechanicName = s.MechanicName,
                VehicleMileage = s.VehicleMileage,
                ServiceCost =  s.ServiceCost,
                ServiceDate = s.ServiceDate,
                RepairSummary = s.RepairSummary
            };

            vtx.ServiceRecords.Add(newService);
            vtx.SaveChanges();
            return newService;
        }

        public Vehicle AddVehicle(string model, string make, 
            string reg, string fuelType, int noOfDoors, string photo )
        {// creates and adds a new vehicle to the database
            var v = new Vehicle {Model = model, Make = make, 
                RegistrationNumber = reg, FuelType = fuelType, 
                NumberOfDoors = noOfDoors, Photo =  photo};
             
            vtx.Vehicles.Add(v);
            vtx.SaveChanges();
        
            return v;
        }
        
        public bool DeleteService(int id)
        {// finds service by id and then removes it from database
            var matchedService = vtx.ServiceRecords.Find(id);
            if (matchedService != null)
            {
                vtx.ServiceRecords.Remove(matchedService);
                vtx.SaveChanges();
                return true;
            }

            return false;
        }
        
        public bool DeleteAssociatedServices(int id)
        {//deletes any services with a foreign key the same as the vehicle id passed in
            var list = vtx.ServiceRecords.Where
                (s => s.VehicleId == id);

            foreach (var s in list)
            {
                vtx.ServiceRecords.Remove(s);
                
            }

            vtx.SaveChanges();
            return true;

        }
        
        public bool DeleteVehicle(int id)
        {// deletes a vehicle from the database with matching id
            var matchedVehicle = vtx.Vehicles.Find(id);
            if(matchedVehicle != null)
            {
                vtx.Vehicles.Remove(matchedVehicle);
                vtx.SaveChanges();
                return true;
            }

            return false;
        }

        public IList<Vehicle> GetAllVehicles(string orderBy = null)
        {// returns a list of all vehicles
            return vtx.Vehicles.ToList();
        }

        public IList<Service> GetAllServicesById(int id)
        { // returns all services that have a matching vehicle foreign key id
            var list = vtx.ServiceRecords.Where(s => s.VehicleId == id);
            return list.ToList();
        }
        
        public Service GetServiceById(int id)
        {//returns a service with a matching id
            var matchedService = vtx.ServiceRecords.Find(id);
            if (matchedService != null)
            {
                return matchedService;
            }

            return null;
        }
        public IList<Vehicle> GetAllVehiclesById(int id)
        {// returns all vehicles with matching id
            var list = vtx.Vehicles.Where(s => s.Id == id);
            return list.ToList();
        }
  
        public Vehicle GetVehicleById(int id)
        {//returns a vehicle with a matching primary is
            var matchedVehicle = vtx.Vehicles.Find(id);
            if (matchedVehicle != null)
            {
                return matchedVehicle;
            }

            return null;
        }
        
        public void Initialise()
        {//goes to the vehicleDBContext and initialises database
            vtx.Initialise();

        }
        
        public Vehicle UpdateVehicle(Vehicle v)
        { //finds and updates a vehicle with the details of the vehicle passed in
          
            var originalVehicle = GetVehicleById(v.Id);
            
            if (originalVehicle != null)
            {
                originalVehicle.Make = v.Make;
                originalVehicle.Model = v.Model;
                originalVehicle.FuelType = v.FuelType;
                originalVehicle.NumberOfDoors = v.NumberOfDoors;
                originalVehicle.RegistrationNumber = v.RegistrationNumber;
                vtx.SaveChanges();
                return originalVehicle;
            }

            return null;
        }
    }
}