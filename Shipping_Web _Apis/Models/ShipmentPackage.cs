namespace Shipping_Web__Apis.Models
{
    public class ShipmentPackage
    {
        public int Id { get; set; }

        public int ShipmentId { get; set; }
        public Shipment Shipment { get; set; }
        public double Weight { get; set; }

        public double Length { get; set; }

        public double Width { get; set; }

        public double Height { get; set; }

    }
}
