using Core.Dtos;
using Core.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Core
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Hour, HourDto>().ReverseMap();
            CreateMap<FreeSick, FreeSickDto>().ReverseMap();

        }
       
    }
}
