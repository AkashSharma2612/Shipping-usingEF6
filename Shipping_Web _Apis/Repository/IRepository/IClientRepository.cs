using Shipping_Web__Apis.Models;

namespace Shipping_Web__Apis.Repository.IRepository
{
    public interface IClientRepository
    {

        Task<List<Client>> GetClients();
        Task AddClient(Client client);
        Task UpdateClient(Client client);

        Task DeleteClient(int id);

    }
}
