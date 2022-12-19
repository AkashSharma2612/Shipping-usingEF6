using System.ComponentModel.DataAnnotations;

namespace Shipping_Web__Apis.Models
{
    public class Client
    {
       public int Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool IsEnabled { get; set; }

        public bool IsDeleted { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address1 { get; set; }

        public string Address2 { get; set; }
        public string City { get; set; }
        
        public int Zip { get; set; }
        
        public string State { get; set; }
        public int CountryCode { get; set; }



    }
}
