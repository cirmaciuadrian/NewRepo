using BACDE10.BusinessLogic.Contracts.Responses;
using BACDE10.BusinessLogic.Interfaces.Repositories;
using BACDE10.BusinessLogic.Interfaces.Services;

namespace BACDE10.BusinessLogic.Services;

public class ClientService : IClientService
{
    private readonly IClient _client;

    public ClientService(IClient client)
    {
        _client = client;
    }

    public async Task<ClientResponse> GetAsync()
    {
         return await _client.GetAsync();
    }
}
