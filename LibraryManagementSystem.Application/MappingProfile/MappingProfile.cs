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
using LibraryManagementSystem.Application.Features.Commands.CategoryCommands.CreateCategory;
using LibraryManagementSystem.Application.Features.Commands.CategoryCommands.DeleteCategory;
using LibraryManagementSystem.Application.Features.Commands.CategoryCommands.UpdateCategory;
using LibraryManagementSystem.Application.Features.Commands.CreateUser;
using LibraryManagementSystem.Application.Features.Commands.LoanCommands.CreateLoan;
using LibraryManagementSystem.Application.Features.Commands.LoanCommands.DeleteLoan;
using LibraryManagementSystem.Application.Features.Commands.LoanCommands.UpdateLoan;
using LibraryManagementSystem.Application.Features.Queries.BookQueries.GetAllBooksQuery;
using LibraryManagementSystem.Application.Features.Queries.BookQueries.GetByIdBookQuery;
using LibraryManagementSystem.Application.Features.Queries.CategoryQueries.GetAllCategoryQuery;
using LibraryManagementSystem.Application.Features.Queries.CategoryQueries.GetByIdCategoryQuery;
using LibraryManagementSystem.Application.Features.Queries.LoanQueries.GetAllLoanQuery;
using LibraryManagementSystem.Application.Features.Queries.LoanQueries.GetByIdLoanQuery;
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
            CreateMap<Book, GetAllBooksResponse>().ReverseMap();



            CreateMap<Category, CreateCategoryCommand>().ReverseMap();
            CreateMap<Category, CreateCategoryResponse>().ReverseMap();
            
            CreateMap<Category, DeleteCategoryCommand>().ReverseMap();
            CreateMap<Category, DeleteCategoryResponse>().ReverseMap();

            CreateMap<Category, UpdateCategoryCommand>().ReverseMap();
            CreateMap<Category, UpdateCategoryResponse>().ReverseMap()
                ;
            CreateMap<Category, GetByIdCategoryQuery>().ReverseMap();
            CreateMap<Category, GetByIdCategoryResponse>().ReverseMap();

            CreateMap<Category, GetAllCategoryQuery>().ReverseMap();
            CreateMap<Category, GetAllCategoryResponse>().ReverseMap();


            CreateMap<Loan, CreateLoanCommand>().ReverseMap();
            CreateMap<Loan, CreateLoanResponse>().ReverseMap();

            CreateMap<Loan, DeleteLoanCommand>().ReverseMap();
            CreateMap<Loan, DeleteLoanResponse>().ReverseMap();

            CreateMap<Loan, UpdateLoanCommand>().ReverseMap();
            CreateMap<Loan, UpdateLoanResponse>().ReverseMap();

            CreateMap<Loan, GetByIdLoanQuery>().ReverseMap();
            CreateMap<Loan, GetByIdLoanResponse>().ReverseMap();

            CreateMap<Loan, GetAllLoanQuery>().ReverseMap();
            CreateMap<Loan, GetAllLoanResponse>().ReverseMap();

        }
    }
}
