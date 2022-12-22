using Shipping_Web__Apis.Models;

namespace Shipping_Web__Apis.Repository.IRepository
{
    public interface IShipmentPackageRepository
    {
        ICollection<ShipmentPackage> GetShipmentPackages();

        bool CreateShipmentPackage(ShipmentPackage shipmentPackage);
        bool UpdateShipmentPackage(ShipmentPackage shipmentPackage);
        bool DeleteShipmentPackage(ShipmentPackage shipmentPackage);
        ShipmentPackage GetShipmentPackage(int shipmentId);
        bool save();
    }
}
