using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shipping_Web__Apis.Models;
using Shipping_Web__Apis.Repository.IRepository;

namespace Shipping_Web__Apis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ShipFromAddressController : ControllerBase
    {
        private readonly IShipFromAddressRepository _shipFromAddressRepository;
        public ShipFromAddressController(IShipFromAddressRepository shipFromAddressRepository)
        {
            _shipFromAddressRepository = shipFromAddressRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<ShipFromAddress>> Get()
        {
            return await _shipFromAddressRepository.GetShipFromAddresses();
        }

        [HttpPost]
        public async Task Post([FromBody] ShipFromAddress shipFromAddress)
        {
            await _shipFromAddressRepository.AddShipFromAddress(shipFromAddress);
        }


        [HttpPut]
        public async Task Put([FromBody] ShipFromAddress shipFromAddress)
        {
            await _shipFromAddressRepository.UpdateShipFromAddress(shipFromAddress);
        }

        // DELETE api/<ShipFromAddressController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _shipFromAddressRepository.DeleteShipFromAddress(id);
        }

    }
}
