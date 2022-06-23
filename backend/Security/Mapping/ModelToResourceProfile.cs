using AutoMapper;
using backend.Register.Domain.Models;
using backend.Register.Resources;
using backend.Security.Domain.Models;
using backend.Security.Domain.Services.Communication;
using backend.Security.Resources;
using UserResource = backend.Register.Resources.UserResource;

namespace backend.Security.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Business, AuthenticateResponse>();
        CreateMap<Business, UserResourceX>();
    }
}