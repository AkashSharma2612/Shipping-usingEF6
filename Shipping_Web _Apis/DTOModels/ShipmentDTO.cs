using Shipping_Web__Apis.Models;

namespace Shipping_Web__Apis.DTOModels
{
    public class ShipmentDTO
    {
        public int Id { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime AlteredDate { get; set; }

        public int ClientId { get; set; }
        public int ServiceId { get; set; }

        public int ShipFromAddressId { get; set; }
        public int ShipToAddressId { get; set; }
        public bool IsDeleted { get; set; }

        public bool IsPending { get; set; }

        public bool IsShipped { get; set; }

    }
}
