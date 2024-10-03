using AutoMapper;
using Microsoft.AspNetCore.Http;
using MinimalBankAPI_OnionArch.Application.Common.Interfaces.UnitOfWorks;
using System.Security.Claims;

namespace MinimalBankAPI_OnionArch.Application.Common.BaseHandler
{
    public class BaseHandler
    {
        public readonly IMapper _mapper;
        public readonly IUnitOfWork _unitOfWork;
        public readonly IHttpContextAccessor _httpContextAccessor;
        public string? _userId;

        public BaseHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
            _userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
