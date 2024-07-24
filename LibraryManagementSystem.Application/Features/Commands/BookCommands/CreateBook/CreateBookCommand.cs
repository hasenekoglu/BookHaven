using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace LibraryManagementSystem.Application.Features.Commands.BookCommands.CreateBook
{
    public class CreateBookCommand : IRequest<CreateBookResponse>
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public string? ImageURL { get; set; }

        public Guid? CategoryId { get; set; }
        //public string CategoryName { get; set; }
        public DateTime PublishedDate { get; set; }
    }
}
