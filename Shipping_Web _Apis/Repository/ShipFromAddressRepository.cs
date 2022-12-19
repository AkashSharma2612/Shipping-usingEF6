using Microsoft.EntityFrameworkCore;
using Shipping_Web__Apis.DataAccess;
using Shipping_Web__Apis.Models;
using Shipping_Web__Apis.Repository.IRepository;

namespace Shipping_Web__Apis.Repository
{
        public class ShipFromAddressRepository : IShipFromAddressRepository
        {

            private readonly ApplicationDbContext _context;
            public ShipFromAddressRepository(ApplicationDbContext context)
            {
                _context = context;
            }

            public async Task AddShipFromAddress(ShipFromAddress shipFromAddress)
            {
                await _context.ShipFromAddresses.AddAsync(shipFromAddress);
                await _context.SaveChangesAsync();
            }

        

           public async Task DeleteShipFromAddress(int id)
            {
                var ShipFromAddInDb = await _context.ShipFromAddresses.FindAsync(id);
                _context.ShipFromAddresses.Remove(ShipFromAddInDb);
                await _context.SaveChangesAsync();
            }

            public async Task<List<ShipFromAddress>> GetShipFromAddresses()
            {
                return await _context.ShipFromAddresses.ToListAsync();
            }

            public async Task UpdateShipFromAddress(ShipFromAddress shipFromAddress)
            {
                _context.ShipFromAddresses.Update(shipFromAddress);
                await _context.SaveChangesAsync();

            }

       
    }
}
