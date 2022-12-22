using Microsoft.EntityFrameworkCore;
using Shipping_Web__Apis.DataAccess;
using Shipping_Web__Apis.Models;
using Shipping_Web__Apis.Repository.IRepository;

namespace Shipping_Web__Apis.Repository
{
    public class ShipmentPackageRepository : IShipmentPackageRepository
    {
        private readonly ApplicationDbContext _context;
        public ShipmentPackageRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool CreateShipmentPackage(ShipmentPackage shipmentPackage)
        {
            _context.ShipmentPackages.Add(shipmentPackage);
                return save();
        }

        public bool DeleteShipmentPackage(ShipmentPackage shipmentPackage)
        {
            _context.ShipmentPackages.Remove(shipmentPackage);
            return save();

        }

        public ShipmentPackage GetShipmentPackage(int shipmentPackId)
        {
            return _context.ShipmentPackages.Find(shipmentPackId);
        }

        public ICollection<ShipmentPackage>GetShipmentPackages()
        {
            return _context.ShipmentPackages.Include(s => s.Shipment).Include(s=>s.Shipment.Client).Include(s=>s.Shipment.ShipToAddress).Include(s=>s.Shipment.ShipFromAddress).ToList();
        }

        public bool save()
        {
            return _context.SaveChanges() == 1 ? true : false;
        }

        public bool UpdateShipmentPackage(ShipmentPackage shipmentPackage)
        {
            _context.ShipmentPackages.Update(shipmentPackage);
            return save();

        }
    }
}
