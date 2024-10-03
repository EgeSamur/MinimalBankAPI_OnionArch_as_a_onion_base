using AutoMapper;
using MinimalBankAPI_OnionArch.Application.Features.Auth.Command.Me;
using MinimalBankAPI_OnionArch.Application.Features.Auth.Command.Register;
using MinimalBankAPI_OnionArch.Domain.Entities;

namespace MinimalBankAPI_OnionArch.Application.Features.Auth.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Customer,RegisterCommandRequest>().ReverseMap();
            CreateMap<Customer,MeCommandResponse>().ReverseMap();
        }
    }
}
