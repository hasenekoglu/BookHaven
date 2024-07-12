using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LibraryManagementSystem.Application.Dtos;
using LibraryManagementSystem.Application.Features.Commands.BookCommands.CreateBook;
using LibraryManagementSystem.Application.Features.Commands.BookCommands.DeleteBook;
using LibraryManagementSystem.Application.Features.Commands.BookCommands.UpdateBook;
using LibraryManagementSystem.Application.Features.Commands.CreateUser;
using LibraryManagementSystem.Application.Features.Queries.BookQueries.GetAllBooksQuery;
using LibraryManagementSystem.Application.Features.Queries.BookQueries.GetByIdBookQuery;
using LibraryManagementSystem.Domain.Entities;
using LibraryManagementSystem.Domain.Entities.Identity;

namespace LibraryManagementSystem.Application.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AppUser, CreateUserCommandRequest>().ReverseMap();


            CreateMap<Book, CreateBookCommand>().ReverseMap();
            CreateMap<Book, CreateBookResponse>().ForMember(i=>i.CategoryName,opt =>opt.MapFrom(x=>x.CategoryId) ).ReverseMap();

            CreateMap<Book, DeleteBookCommand>().ReverseMap();
            CreateMap<Book,DeleteBookResponse>().ReverseMap();

            CreateMap<Book, UpdateBookCommand>().ReverseMap();
            CreateMap<Book, UpdateBookResponse>().ReverseMap();

            CreateMap<Book, GetByIdBookQuery>().ReverseMap();
            CreateMap<Book, GetByIdBookResponse>().ReverseMap();
            

            CreateMap<Book, GetAllBooksQuery>().ReverseMap();
            CreateMap<Book, GetlAllBooksResponse>().ReverseMap();
        }
    }
}
