using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shipping_Web__Apis.Models;
using Shipping_Web__Apis.Repository.IRepository;

namespace Shipping_Web__Apis.Controllers
{
    [Route("api/Shipment")]
    [ApiController]
    public class ShipmentController : ControllerBase
    {
        private readonly IShipmentRepository _shipmentRepository;
        public ShipmentController(IShipmentRepository shipmentRepository)
        {
            _shipmentRepository = shipmentRepository;

        }
        [HttpGet]
        public async Task<IEnumerable<Shipment>> Get()
        {
            return await _shipmentRepository.GetShipments();
        }

        [HttpPost]
        public async Task Post([FromBody] Shipment shipment)
        {
            await _shipmentRepository.AddShipment(shipment);
        }

        [HttpPut]
        public async Task Put([FromBody] Shipment shipment)
        {
            await _shipmentRepository.UpdateShipment(shipment);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _shipmentRepository.DeleteShipment(id);
        }

    }
}
