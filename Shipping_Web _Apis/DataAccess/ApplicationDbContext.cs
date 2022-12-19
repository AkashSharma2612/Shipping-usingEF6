using Microsoft.EntityFrameworkCore;
using Shipping_Web__Apis.Models;

namespace Shipping_Web__Apis.DataAccess
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        public DbSet <Client> Clients { get; set; }

        public DbSet<Shipment> Shipments { get; set; }

        public DbSet<ShipFromAddress> ShipFromAddresses { get; set; }

        public DbSet<ShipToAddress> ShipToAddresses { get; set; }

        public DbSet<ShipmentPackage> ShipmentPackages { get; set; }

    }
}
