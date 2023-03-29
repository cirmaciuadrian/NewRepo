using AutoMapper;
using BACDE10.BusinessLogic.Contracts.Responses;
using BACDE10.DataAccess.Entities;

namespace BACDE10.WEBAPI.Mappers;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        AllowNullCollections = true;

        CreateMap<ClientEntity, ClientResponse>();
    }
}