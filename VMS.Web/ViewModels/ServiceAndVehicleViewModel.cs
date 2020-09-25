using System.Collections.Generic;
using VMS.Data.Models;

namespace VMS.Web.ViewModels
{
    public class ServiceAndVehicleViewModel
    {
        public ServiceAndVehicleViewModel()
        {
            this.Vehicles = new Vehicle();
            this.Service = new Service();
          
        }
        public Vehicle Vehicles { get; set; }
        public IList<Service> Services { get; set; }
        
        public Service Service { get; set; }
    }
}