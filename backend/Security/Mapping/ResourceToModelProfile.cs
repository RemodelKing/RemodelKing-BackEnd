using AutoMapper;
using backend.Register.Domain.Models;
using backend.Security.Domain.Models;
using backend.Security.Domain.Services.Communication;

namespace backend.Security.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<RegisterRequest, Business>();
        CreateMap<UpdateRequest, Business>().ForAllMembers(options => 
            options.Condition((source, target, property) =>
                {
                    if (property == null) return false;
                    if (property.GetType() == typeof(string) && string.IsNullOrEmpty((string)property)) return false;
                    return true;
                }
                
            ));
    }
}