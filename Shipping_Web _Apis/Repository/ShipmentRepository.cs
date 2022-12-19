using Microsoft.EntityFrameworkCore;
using Shipping_Web__Apis.DataAccess;
using Shipping_Web__Apis.Models;
using Shipping_Web__Apis.Repository.IRepository;

namespace Shipping_Web__Apis.Repository
{
    public class ShipmentRepository : IShipmentRepository
    {
         private readonly ApplicationDbContext _context;
        public ShipmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddShipment(Shipment shipment)
        {
            await _context.Shipments.AddAsync(shipment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteShipment(int id)
        {
            var shipmentInDb = await _context.Shipments.FindAsync(id);
            _context.Shipments.Remove(shipmentInDb);
             await _context.SaveChangesAsync();
        }

        public async Task<List<Shipment>> GetShipments()
        {
            return await _context.Shipments.Include(c=>c.Client).
            Include(c=>c.ShipFromAddress).Include(c=>c.ShipToAddress).ToListAsync();
        }

        public async Task UpdateShipment(Shipment shipment)
        {
            _context.Shipments.Update(shipment);
            await _context.SaveChangesAsync();
        }

    }
}
