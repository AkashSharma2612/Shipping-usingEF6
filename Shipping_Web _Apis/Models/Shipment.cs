namespace Shipping_Web__Apis.Models
{
    public class Shipment
    {
        public int Id { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime AlteredDate { get; set; }

        public int ClientId { get; set; }

        public Client Client { get; set; }

        public int ServiceId { get; set; }

        public int ShipFromAddressId { get; set; }
        public ShipFromAddress ShipFromAddress { get; set; }
        public int ShipToAddressId { get; set; }
        public ShipToAddress ShipToAddress { get; set; }
        public bool IsDeleted { get; set; }

        public bool IsPending { get; set; }

        public bool IsShipped { get; set; }



    }
}
