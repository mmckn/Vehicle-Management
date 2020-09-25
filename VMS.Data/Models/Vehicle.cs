using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace VMS.Data.Models
{
    public class Vehicle
    {
        public Vehicle()
        {
            ServiceRecords = new List<Service>();
        }

        public int Id { get; set; }
        
        // these are validation rules
        [Required] 
        public string Make { get; set; }

        [Required] 
        public string Model { get; set; }

        
        public DateTime DateOfRegistration { get; set; }

        [Required]
        public string RegistrationNumber { get; set; }
    
    public int AgeOfVehicle { get; } // calculate from date of registration
    
   [Required]
    public string FuelType { get; set; }

    public string Photo { get; set; }
    
    public int NumberOfDoors { get; set; }
    
    
    public IList<Service> ServiceRecords { get; set; }

       
    }
}