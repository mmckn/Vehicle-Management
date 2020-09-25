using System;
using System.Threading.Tasks.Sources;
using VMS.Data.Models;
using VMS.Data.Services;
using VMS.Web.ViewModels;



using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace VMS.Web.Controllers
{

    public class VehiclesController : Controller
    {
        private readonly VehicleDbService vtx;

        public VehiclesController()
        {
            vtx = new VehicleDbService();
        }

        public IActionResult Index()
        {//gets a list of all vehicles and passes them to the index view for display
            var vehicles = vtx.GetAllVehicles();
            
            return View(vehicles);
        }
        
        
        public IActionResult ServiceInformation(int id)
        { // assign the vehicle and its service records to model variable
            //then pass these to view
            var model = new ServiceAndVehicleViewModel();
            model.Services = vtx.GetAllServicesById(id);
            model.Vehicles = vtx.GetVehicleById(id);
           
            if (model.Vehicles == null)
            {
                return NotFound();
            }

            return View(model);
        }

        public IActionResult DeleteServiceRecords(int id)
        {// deletes vehicle and its service records
            vtx.DeleteAssociatedServices(id);
            
            return RedirectToAction(nameof(Index));

        }
        
        public IActionResult DeleteServiceRecordSingle(int id)
        {// deletes service records
          
            
            return RedirectToAction(nameof(Index));

        }


        public IActionResult AddVehicles(Vehicle v)
        {//view for recieving information from user and updating vehicle with same Id in the database
            if (ModelState.IsValid)
            {
                vtx.AddVehicle(v.Model, v.Make, v.RegistrationNumber,v.FuelType, v.NumberOfDoors, v.Photo);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(v);
            }
        }
        [HttpPost]
        public IActionResult AddService(Service v)
        {//
            Console.WriteLine(v.VehicleId + " check12");
            if (ModelState.IsValid)
            {
                
                vtx.AddService(v);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
        }


        public IActionResult DeleteVehicleById(int id)
        { // lets user delete vehicle by id
            // checks if vehicle exists, if true delete and redirect
            var checkExistence = vtx.DeleteVehicle(id);
            if (checkExistence)
            {



                return RedirectToAction(nameof(Index));


            }


            return View();

        }

        [HttpPost]
        public IActionResult ServiceInformation(ServiceAndVehicleViewModel v)
        { //receives view model containing new vehicle and uses this to update the vehicle with the same primary key in the database
          
            if (ModelState.IsValid)
            {
              
              
                vtx.UpdateVehicle(v.Vehicles);
                return RedirectToAction(nameof(Index));
            }


           
            return RedirectToAction(nameof(Index)) ;
    }

        public IActionResult DeleteServiceRecordIndividual(int id)
        { // finds the Service and give access to it (called by index)
            var matchedVehicle = vtx.GetServiceById(id);
            if (matchedVehicle == null)
            {
                return NotFound();
            }
           
            return View(matchedVehicle); 
        }
        
        
public IActionResult DeleteVehicleIndividual(int id)
        { // finds the vehicle and give access to it (called by index)
            var matchedVehicle = vtx.GetVehicleById(id);
            if (matchedVehicle == null)
            {
                
                return NotFound();
            }
            Console.WriteLine("not working");
           
            return View(matchedVehicle); 
        }

        [HttpPost]
        public IActionResult DeleteVehicleFinal(int id)
        { // lets user delete vehicle by id
            // check if vehicle exists, if true delete and redirect
            
            if (vtx.DeleteVehicle(id))
            {
                vtx.DeleteAssociatedServices(id);

                return RedirectToAction(nameof(Index));

            }

            return NotFound();

        }

        [HttpPost]
        public IActionResult DeleteServiceFinal(int id)
        { // check if Service exists, if true delete and redirect
            
            if (vtx.DeleteService(id))
            {
                

                return RedirectToAction(nameof(Index));

            }

            return NotFound();
        }
        
    }
}