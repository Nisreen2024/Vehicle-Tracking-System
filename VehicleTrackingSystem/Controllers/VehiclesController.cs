
//api
using Microsoft.AspNetCore.Mvc;
using VehicleTrackingSystem.Models;
using VehicleTrackingSystem.Services;

namespace VehicleTrackingSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehiclesController : ControllerBase
    {
        private readonly VehicleService _vehicleService;

        public VehiclesController(VehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpGet]
        public ActionResult<List<Vehicle>> Get() =>
            _vehicleService.GetAll();

        [HttpGet("{id}")]
        public ActionResult<Vehicle> Get(string id)
        {
            var vehicle = _vehicleService.GetById(id);
            if (vehicle == null)
                return NotFound();
            return vehicle;
        }

        [HttpPost]
        public ActionResult<Vehicle> Create(Vehicle vehicle)
        {
            _vehicleService.Create(vehicle);
            return CreatedAtAction(nameof(Get), new { id = vehicle.Id }, vehicle);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, Vehicle vehicleIn)
        {
            var vehicle = _vehicleService.GetById(id);
            if (vehicle == null)
                return NotFound();

            _vehicleService.Update(id, vehicleIn);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var vehicle = _vehicleService.GetById(id);
            if (vehicle == null)
                return NotFound();

            _vehicleService.Delete(id);
            return NoContent();
        }


    }
}
