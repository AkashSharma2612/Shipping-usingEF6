using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shipping_Web__Apis.Models;
using Shipping_Web__Apis.Repository.IRepository;

namespace Shipping_Web__Apis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipmentPackageController : ControllerBase
    {
        private readonly IShipmentPackageRepository _shipmentPackageRepository;
        public ShipmentPackageController(IShipmentPackageRepository shipmentPackageRepository)
        {
            _shipmentPackageRepository = shipmentPackageRepository;
        }
        [HttpGet]
        public async Task<IEnumerable<ShipmentPackage>> Get()
        {
            return await _shipmentPackageRepository.GetShipmentPackages();
        }
        [HttpPost]
        public async Task Post([FromBody] ShipmentPackage shipmentPackage)
        {
            await _shipmentPackageRepository.AddShipmentPackage(shipmentPackage);
        }

        [HttpPut]
        public async Task Put([FromBody] ShipmentPackage shipmentPackage)
        {
            await _shipmentPackageRepository.UpdateShipmentPackage(shipmentPackage);
        }


        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _shipmentPackageRepository.DeleteShipmentPackage(id);
        }

    }
}
