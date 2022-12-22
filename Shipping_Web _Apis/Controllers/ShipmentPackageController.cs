using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shipping_Web__Apis.DTOModels;
using Shipping_Web__Apis.Models;
using Shipping_Web__Apis.Repository;
using Shipping_Web__Apis.Repository.IRepository;

namespace Shipping_Web__Apis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ShipmentPackageController : ControllerBase
    {
        private readonly IShipmentPackageRepository _shipmentPackageRepository;
        private readonly IMapper _mapper;
        public ShipmentPackageController(IShipmentPackageRepository shipmentPackageRepository,IMapper mapper)
        {
            _shipmentPackageRepository = shipmentPackageRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetShipmentPackages()
        {
            var shipmentPackDtoInList = _shipmentPackageRepository.GetShipmentPackages().ToList();
            return Ok(shipmentPackDtoInList);
        }
        [HttpPost]
        public IActionResult SaveShipmentPackage(ShipmentPackageDTO shipmentPackageDTO)
        {
            if (shipmentPackageDTO == null) return BadRequest();
            var shipPackdto = _mapper.Map<ShipmentPackageDTO, ShipmentPackage>(shipmentPackageDTO);
            if (shipmentPackageDTO == null) return BadRequest();
            _shipmentPackageRepository.CreateShipmentPackage(shipPackdto);
            return Ok(shipPackdto);
        }
        [HttpPut]
        public IActionResult UpdateShipmentPackage(ShipmentPackageDTO shipmentPackageDTO) 
        {
            var shipmentPackage = _mapper.Map<ShipmentPackage>(shipmentPackageDTO);
            _shipmentPackageRepository.UpdateShipmentPackage(shipmentPackage);
            _shipmentPackageRepository.save();
            return Ok(shipmentPackage);
        }
        [HttpDelete("{id:int}")]
        public IActionResult DeleteShipmentPackage(int id)
        {
            var shipmentPackage = _shipmentPackageRepository.GetShipmentPackage(id);
            _shipmentPackageRepository.DeleteShipmentPackage(shipmentPackage);
            _shipmentPackageRepository.save();
            return Ok();
        }
    }
}
