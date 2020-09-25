using System;
using System.ComponentModel.DataAnnotations;

namespace VMS.Data.Models
{
    public class Service
    {     public int Id { get; set; }
          
    public String MechanicName { get; set; }
    public DateTime ServiceDate { get; set; }
    public String RepairSummary { get; set; }
    public int VehicleMileage { get; set; }
    public double ServiceCost { get; set; }
    public int VehicleId { get; set; }
    
    public Vehicle Vehicle { get; set; }
        
    }
}