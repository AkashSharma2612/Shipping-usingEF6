using Shipping_Web__Apis.Models;

namespace Shipping_Web__Apis.Repository.IRepository
{
    public interface IShipmentPackageRepository
    {
        Task<List<ShipmentPackage>> GetShipmentPackages();

        Task AddShipmentPackage(ShipmentPackage shipmentPackage);

        Task UpdateShipmentPackage(ShipmentPackage shipmentPackage);

        Task DeleteShipmentPackage(int id);

    }
}
