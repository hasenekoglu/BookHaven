using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace LibraryManagementSystem.Application.Features.Commands.BookCommands.UpdateBook
{
    public class UpdateBookCommand : IRequest<UpdateBookResponse>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public Guid? CategoryId { get; set; }
        public string? ImageURL { get; set; }
    }
}
