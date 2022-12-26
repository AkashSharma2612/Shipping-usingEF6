using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shipping_Web__Apis.Models;
using Shipping_Web__Apis.Repository.IRepository;

namespace Shipping_Web__Apis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    //[AllowAnonymous]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository _clientRepository;
        public ClientController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<Client>> Get()
        {
            return await _clientRepository.GetClients();
        }

        [HttpPost]
        public async Task Post([FromBody] Client client)
        {

            await _clientRepository.AddClient(client);
        }

        [HttpPut]
        public async Task Put([FromBody] Client client)
        {
            await _clientRepository.UpdateClient(client);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _clientRepository.DeleteClient(id);
        }

    }
}
