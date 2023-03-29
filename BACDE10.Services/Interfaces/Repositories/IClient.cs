using BACDE10.BusinessLogic.Contracts.Responses;
using BACDE10.BusinessLogic.Interfaces;

namespace BACDE10.BusinessLogic.Interfaces.Repositories;

public interface IClient
{
    Task<ClientResponse>  GetAsync();
}

