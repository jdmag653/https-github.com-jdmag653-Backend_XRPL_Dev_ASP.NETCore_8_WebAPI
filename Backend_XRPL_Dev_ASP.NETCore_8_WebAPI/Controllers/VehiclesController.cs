using Microsoft.AspNetCore.Mvc;

namespace Backend_XRPL_Dev_ASP.NETCore_8_WebAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class VehiclesController : ControllerBase
    {
        private readonly VehicleDataRepository _vehicleRepository;

        public VehiclesController(VehicleDataRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        [HttpGet]
        [Route("GetAllVehicles")]
        public IActionResult GetAll()
        {
            // Log the incoming request
            Console.WriteLine("GetAllVehicles request received.");
            var vehicles = _vehicleRepository.GetAllVehicles();
            return Ok(vehicles);
        }

        [HttpGet]
        [Route("GetVehicle/{id}")]
        public IActionResult GetVehicleByIdController(int id)
        {
            var vehicle = _vehicleRepository.GetVehicleById(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            return Ok(vehicle);
        }

        [HttpPost]
        [Route("AddVehicle")]
        public IActionResult Add([FromForm] VehicleDataAddDTO vehicle)
        {
            // Perform any additional validation if needed

            _vehicleRepository.AddVehicle(vehicle);

            // Return the appropriate response
            return Ok("Vehicle added successfully");
        }

        [HttpPut]
        [Route("UpdateVehicle/{id}")]
        public IActionResult UpdateVehicleController(int id,  VehicleDataAddDTO updatedVehicle)
        {
            // Perform any additional validation if needed

            _vehicleRepository.UpdateVehicle(id, updatedVehicle);

            // Return the appropriate response
            return Ok("Vehicle updated successfully");
        }

        [HttpDelete]
        [Route("VehicleDelete/{id}")]
        public IActionResult DeleteVehicleController(int id)
        {
            // Perform any additional validation if needed

            // Check if the vehicle with the given ID exists
            var existingVehicle = _vehicleRepository.GetVehicleById(id);
            if (existingVehicle == null)
            {
                // If the vehicle doesn't exist, return NotFound
                return NotFound("Vehicle not found");
            }

            // If the vehicle exists, delete it
            _vehicleRepository.DeleteVehicle(id);

            // Return the appropriate response
            return Ok("Vehicle deleted successfully");
        }
    }

}
