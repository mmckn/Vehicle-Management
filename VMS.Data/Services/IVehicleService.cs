using System.Collections.Generic;
using VMS.Data.Models;

namespace VMS.Data.Services
{
    public interface IVehicleService
    {
        // initialise the database - only for development
        void Initialise();

        // Retrieve a list of vehicles 
        // optional order parameter allows result list
        // to be ordered by “make”, “fuel” or “registered”
        IList<Vehicle> GetAllVehicles(string orderBy=null);

        // return vehicle (with associated services) identified by id or null if not found
        Vehicle GetVehicleById(int id);

        // delete the vehicle identified by id
        // return true if completed else false
        bool DeleteVehicle(int id);

        // update the vehicle identified by id
        // return true if completed else false
        Vehicle UpdateVehicle(Vehicle v);
            
        // add the new vehicle and return vehicle if successful otherwise return null
        
        Vehicle AddVehicle(string model, string make, string reg, string fuelType, int noOfDoors, string photo);
        
        
         // return the servicer identified by id or null if not found
        IList<Service> GetAllServicesById(int id);
        
        Service GetServiceById(int id);

        bool DeleteAssociatedServices(int id);

        // add the new service and return service if successful otherwise return null
        Service AddService(Service s);

        // delete the service identified by id and return true if successful otherwise return false 
        bool DeleteService(int id);
        
    }
}