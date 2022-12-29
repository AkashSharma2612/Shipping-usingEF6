using AutoMapper;
using Shipping_Web__Apis.DTOModels;
using System.Diagnostics;

namespace Shipping_Web__Apis.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Shipment, ShipmentDTO>().ReverseMap();
            CreateMap<ShipmentPackage, ShipmentPackageDTO>().ReverseMap();
        }
    }
}
