using Shipping_Web__Apis.Models;

namespace Shipping_Web__Apis.DTOModels
{
    public class ShipmentPackageDTO
    {
        public int Id { get; set; }

        public int ShipmentId { get; set; }
        public double Weight { get; set; }

        public double Length { get; set; }

        public double Width { get; set; }

        public double Height { get; set; }

    }
}
