using AutoMapper;
using CarsBuisnessLayer.DTOs;
using CarsCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsBuisnessLayer.MapperProfiles
{
    public class AccountInfoProfile : Profile
    {
        public AccountInfoProfile()
        {
            CreateMap<AccountInfoDTO, AccountInfo>()
                .ForMember(x => x.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(x => x.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(x => x.IsActive, opt => opt.MapFrom(src => true))
                .ForMember(x => x.LoginInfo, opt => opt.MapFrom(src => src.LoginInfo))
                .ForMember(x => x.Role, opt => opt.MapFrom(src => Role.User))
                .ForMember(x => x.Email, opt => opt.Ignore())
                .ForMember(x => x.EmailId, opt => opt.Ignore());
        }
    }
}
