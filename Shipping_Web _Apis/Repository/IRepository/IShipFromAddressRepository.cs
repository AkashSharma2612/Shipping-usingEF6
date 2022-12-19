using Shipping_Web__Apis.Models;

namespace Shipping_Web__Apis.Repository.IRepository
{
    public interface IShipFromAddressRepository
    {
        Task<List<ShipFromAddress>> GetShipFromAddresses();
        Task AddShipFromAddress(ShipFromAddress shipFromAddress);
        Task UpdateShipFromAddress(ShipFromAddress shipFromAddress);

        Task DeleteShipFromAddress(int id);
    }
}
