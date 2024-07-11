using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LibraryManagementSystem.Application.Dtos;
using LibraryManagementSystem.Application.Features.Commands.CreateUser;
using LibraryManagementSystem.Domain.Entities;
using LibraryManagementSystem.Domain.Entities.Identity;

namespace LibraryManagementSystem.Application.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AppUser, CreateUserCommandRequest>().ReverseMap();

          }
    }
}
