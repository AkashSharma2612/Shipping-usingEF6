using Shipping_Web__Apis.Models;

namespace Shipping_Web__Apis.Repository.IRepository
{
    public interface IShipmentRepository
    {
        Task<List<Shipment>> GetShipments();
        Task AddShipment(Shipment shipment);

        Task UpdateShipment(Shipment shipment);

        Task DeleteShipment(int id);
    }
}
