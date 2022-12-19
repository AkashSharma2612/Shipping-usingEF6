﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shipping_Web__Apis.Models;
using Shipping_Web__Apis.Repository;
using Shipping_Web__Apis.Repository.IRepository;

namespace Shipping_Web__Apis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipToAddressController : ControllerBase
    {
        private readonly IShipToAddressRepository _shioToAddressRepository;
        public ShipToAddressController(IShipToAddressRepository shioToAddressRepository)
        {
            _shioToAddressRepository = shioToAddressRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<ShipToAddress>> Get()
        {
            return await _shioToAddressRepository.GetShipToAddresses();
        }

        [HttpPost]
        public async Task Post([FromBody] ShipToAddress shipToAddress)
        {
            await _shioToAddressRepository.AddShipToAddress(shipToAddress);
        }

        [HttpPut]
        public async Task Put([FromBody] ShipToAddress shipToAddress)
        {
            await _shioToAddressRepository.UpdateShipToAddress(shipToAddress);
        }


        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _shioToAddressRepository.DeleteShipToAddress(id);
        }

    }
}