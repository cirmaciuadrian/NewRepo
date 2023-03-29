using BACDE10.BusinessLogic.Contracts.Responses;

namespace BACDE10.BusinessLogic.Interfaces.Services;
public interface IClientService
{
    Task<ClientResponse> GetAsync();
}
