using Shipping_Web__Apis.Models;

namespace Shipping_Web__Apis.Repository.IRepository
{
    public interface IUserRepository
    {
        ICollection<USer> GetUsers();
        bool IsUniqueUser(string Username);
        USer Authenticate(string Username, string Password);
        USer Register(string Username, string Password);

    }
}
