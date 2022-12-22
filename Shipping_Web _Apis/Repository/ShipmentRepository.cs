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
    
        public bool CreateShipments(Shipment shipment)
        {
            _context.Shipments.Add(shipment);
            return save();
        }

        public bool DeleteShipments(int id)
        {
           var shipmentInDb= _context.Shipments.Find(id);
            _context.Shipments.Remove(shipmentInDb);
            return save();
        }

        public Shipment GetShipment(int shipmentId)
        {
            return _context.Shipments.Find(shipmentId);
        }

        public ICollection<Shipment> GetShipments()
        {
            return _context.Shipments.Include(c => c.Client).Include(c => c.ShipToAddress).Include(c => c.ShipFromAddress).ToList();
        }

        public bool save()
        {
            return _context.SaveChanges() == 1 ? true : false;
        }

        public bool UpdateShipment(Shipment shipment)
        {
            _context.Shipments.Update(shipment);
            return save();
        }
    }
}
