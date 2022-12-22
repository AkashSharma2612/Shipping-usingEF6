using Shipping_Web__Apis.Models;

namespace Shipping_Web__Apis.Repository.IRepository
{
    public interface IUserRepository
    {
        bool IsUniqueUser(string Username);
        USer Authenticate(string Username, string password);
        USer Register(string Username, string Password);

    }
}
