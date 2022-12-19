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
        public async Task AddShipmentPackage(ShipmentPackage shipmentPackage)
        {
            await _context.ShipmentPackages.AddAsync(shipmentPackage);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteShipmentPackage(int id)
        {
            var shipPackInDb = await _context.ShipmentPackages.FindAsync(id);
            _context.ShipmentPackages.Remove(shipPackInDb);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ShipmentPackage>> GetShipmentPackages()
        {
            return await _context.ShipmentPackages.Include(s => s.Shipment).
            Include(s => s.Shipment.Client).Include(s => s.Shipment.ShipFromAddress).
            Include(s => s.Shipment.ShipToAddress).ToListAsync();
        }

        public async Task UpdateShipmentPackage(ShipmentPackage shipmentPackage)
        {
            _context.ShipmentPackages.Update(shipmentPackage);
            await _context.SaveChangesAsync();
        }
    }
}
