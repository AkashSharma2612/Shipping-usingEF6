using AutoMapper;
using Shipping_Web__Apis.DTOModels;
using Shipping_Web__Apis.Models;
using System.Diagnostics;

namespace Shipping_Web__Apis
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Shipment, ShipmentDTO>().ReverseMap();
            CreateMap<ShipmentPackage, ShipmentPackageDTO>().ReverseMap();
        }
    }
}
