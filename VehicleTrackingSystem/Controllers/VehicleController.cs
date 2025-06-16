//mvc

using Microsoft.AspNetCore.Mvc;
using VehicleTrackingSystem.Models;
using VehicleTrackingSystem.Services;

namespace VehicleTrackingSystem.Controllers
{
    public class VehicleController : Controller
    {
        private readonly VehicleService _vehicleService;

        public VehicleController(VehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        public IActionResult Index()
        {
            var vehicles = _vehicleService.GetAll();
            return View(vehicles);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Create(Vehicle vehicle)
        {
            //foreach(var entry in ModelState)
            //{
            //    foreach(var error in entry.Value.Errors)
            //    {
            //        Console.WriteLine($"Field:{entry.Key},Error:{error.ErrorMessage}");

            //    }
            //}

            if (ModelState.IsValid)
            {
                _vehicleService.Create(vehicle);
                return RedirectToAction("Index");
            }
            return View(vehicle);
        }


        // GET: Vehicles/Edit/5
        public IActionResult Edit(string id)
        {
            var vehicle = _vehicleService.GetById(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            return View(vehicle);
        }

        // POST: Vehicles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, Vehicle vehicle)
        {

            foreach (var entry in ModelState)
            {
                foreach (var error in entry.Value.Errors)
                {
                    Console.WriteLine($"Field:{entry.Key},Error:{error.ErrorMessage}");

                }
            }

            if (!ModelState.IsValid)
            {
                return View(vehicle);
            }

            _vehicleService.Update(id, vehicle);
            return RedirectToAction(nameof(Index));
        }


    }
}
