using AutoMapper;
using backend.Register.Domain.Models;
using backend.Register.Resources;

namespace backend.Register.Mapping;

public class ModelToResourceProfile: Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Client, ClientResource>();
        CreateMap<Business, BusinessResource>();
    }
}