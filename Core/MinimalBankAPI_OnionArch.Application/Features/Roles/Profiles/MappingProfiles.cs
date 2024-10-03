using AutoMapper;
using MinimalBankAPI_OnionArch.Application.Features.Role.Command.Create;
using MinimalBankAPI_OnionArch.Application.Features.Roles.Command.Update;
using MinimalBankAPI_OnionArch.Application.Features.Roles.Queries.GetAllRoles;
using MinimalBankAPI_OnionArch.Application.Features.Roles.Queries.GetRoleById;
using MinimalBankAPI_OnionArch.Domain.Entities;
using MinimalBankAPI_OnionArch.Persistance.Repositories.Base.Pagination;
using MinimalBankAPI_OnionArch.Persistance.Repositories.Base.Response;


namespace MinimalBankAPI_OnionArch.Application.Features.Roles.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Domain.Entities.Auth.Role, CreateRoleCommandRequest>().ReverseMap();
            CreateMap<Domain.Entities.Auth.Role, UpdateRoleCommandRequest>().ReverseMap();
            CreateMap<Domain.Entities.Auth.Role, UpdateRoleCommandResponse>().ReverseMap();
            CreateMap<Domain.Entities.Auth.Role, GetRoleByIdQueryResponse>().ReverseMap();

            #region IPaginate şeklinde dönmesi için Dataların bu şekilde yapılmalıdı.


            CreateMap<IPaginate<Domain.Entities.Auth.Role>, GetListResponse<GetAllRolesQueryResponse>>().ReverseMap();
            //CreateMap<Domain.Entities.Auth.Role,GetAllRolesQueryResponse>().ReverseMap();

            #endregion



            CreateMap<Domain.Entities.Auth.Role, GetAllRolesQueryResponse>()
              .ForMember(dest => dest.RoleOperationClaims, opt => opt.MapFrom(src => src.RoleOperationClaims));
        }
    }
}
