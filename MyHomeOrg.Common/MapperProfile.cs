using System;
using AutoMapper;
using MyHomeOrg.Common.DbModels.User;
using MyHomeOrg.Common.DTO.User;
using MyHomeOrg.Common.Enums;

namespace MyHomeOrg.Common
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            this.CreateMap<RegisterUserDto, Account>()
                .ForMember(item => item.Id, opt => opt.Ignore())
                .ForMember(item => item.CreatedBy, opt => opt.Ignore())
                .ForMember(item => item.CreatedDate, opt => opt.MapFrom(x => DateTime.Now))
                .ForMember(item => item.Id, opt => opt.Ignore())
                .ForMember(item => item.Email, opt => opt.MapFrom(item => item.Email))
                .ForMember(item => item.Password, opt => opt.MapFrom(item => item.Password))
                .ForMember(item => item.Username, opt => opt.MapFrom(item => item.UserName))
                .ForMember(item => item.Permissions, opt => opt.MapFrom(x => PermissionTypes.Base));
            this.CreateMap<Account, LoginDto>()
                .ForMember(item => item.Login, opt => opt.MapFrom(item => item.Username));
        }
    }
}