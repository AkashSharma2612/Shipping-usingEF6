using Shipping_Web__Apis.Models;

namespace Shipping_Web__Apis.Repository.IRepository
{
    public interface IShipmentRepository
    {
        ICollection<Shipment> GetShipments();

        bool CreateShipments(Shipment shipment);
        bool UpdateShipment(Shipment shipment);
        bool DeleteShipments(int id);
        Shipment GetShipment(int shipmentPackId);
        bool save();
    }
}
