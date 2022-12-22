using System.ComponentModel.DataAnnotations.Schema;

namespace Shipping_Web__Apis.Models
{
    public class USer
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        [NotMapped]
        public string Token { get; set; }

    }
}
