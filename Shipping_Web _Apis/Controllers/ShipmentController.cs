using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shipping_Web__Apis.DTOModels;
using Shipping_Web__Apis.Models;
using Shipping_Web__Apis.Repository.IRepository;

namespace Shipping_Web__Apis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ShipmentController : ControllerBase
    {
        private readonly IShipmentRepository _shipmentRepository;
        private readonly IMapper _mapper;
        public ShipmentController(IShipmentRepository shipmentRepository,IMapper mapper)
            
        {
            _shipmentRepository = shipmentRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetShipments()
        {
            var shipmentDtoInList = _shipmentRepository.GetShipments().ToList();
            return Ok(shipmentDtoInList);
        }
        [HttpPost]
        public IActionResult SaveShipment(ShipmentDTO shipmentDTO)
        {
            if (shipmentDTO == null) return BadRequest();
            var shipdto= _mapper.Map<ShipmentDTO,Shipment>(shipmentDTO);
            if(shipdto==null)return BadRequest();
             _shipmentRepository.CreateShipments(shipdto);
                return Ok(shipdto);
            
        }
        [HttpPut]
        public IActionResult UpdateShipment(ShipmentDTO shipmentDTO)
        {
            var shipment=_mapper.Map<Shipment>(shipmentDTO);
            _shipmentRepository.UpdateShipment(shipment);
            _shipmentRepository.save();
            return Ok(shipment);

        }
        [HttpDelete("{id:int}")]
        public IActionResult DeleteShipment(int shipmentId)
        {
            var shipment= _shipmentRepository.GetShipment(shipmentId);
            if (shipment == null) return NotFound();
            _shipmentRepository.DeleteShipments(shipmentId);
            _shipmentRepository.save();
            return Ok();


        }
    }
}
