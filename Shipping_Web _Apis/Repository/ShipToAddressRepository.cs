using Microsoft.EntityFrameworkCore;
using Shipping_Web__Apis.DataAccess;
using Shipping_Web__Apis.Models;
using Shipping_Web__Apis.Repository.IRepository;

namespace Shipping_Web__Apis.Repository
{
    public class ShipToAddressRepository : IShipToAddressRepository
    {

        private readonly ApplicationDbContext _context;
        public ShipToAddressRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddShipToAddress(ShipToAddress shipToAddress)
        {
            await _context.ShipToAddresses.AddAsync(shipToAddress);
            await _context.SaveChangesAsync();

        }

        public async Task DeleteShipToAddress(int id)
        {
            var shipToAddressInDb = await _context.ShipToAddresses.FindAsync(id);
            _context.ShipToAddresses.Remove(shipToAddressInDb);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ShipToAddress>> GetShipToAddresses()
        {
            return await _context.ShipToAddresses.ToListAsync();
        }

        public async Task UpdateShipToAddress(ShipToAddress shipToAddress)
        {
            _context.ShipToAddresses.Update(shipToAddress);
            await _context.SaveChangesAsync();
        }
    }
}
