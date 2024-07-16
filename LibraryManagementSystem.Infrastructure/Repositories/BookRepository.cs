using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.Application.Interfaces;
using LibraryManagementSystem.Domain.Entities;
using LibraryManagementSystem.Infrastructure.Data;

namespace LibraryManagementSystem.Infrastructure.Repositories
{
    public class BookRepository : GenericRepository<Book>,IBookRepository
    {
        public BookRepository(LibraryContext context) : base(context)
        {
        }
    }
}
