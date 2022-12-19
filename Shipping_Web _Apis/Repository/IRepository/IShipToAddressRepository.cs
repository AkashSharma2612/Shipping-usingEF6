using Shipping_Web__Apis.Models;

namespace Shipping_Web__Apis.Repository.IRepository
{
    public interface IShipToAddressRepository
    {
        Task<List<ShipToAddress>> GetShipToAddresses();
        Task AddShipToAddress(ShipToAddress shipToAddress);
        Task UpdateShipToAddress(ShipToAddress shipToAddress);

        Task DeleteShipToAddress(int id);

    }
}
