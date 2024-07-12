using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace LibraryManagementSystem.Application.Features.Commands.BookCommands.DeleteBook
{
    public class DeleteBookCommand : IRequest<DeleteBookResponse>
    {
        public Guid Id { get; set; }

        public DeleteBookCommand(Guid id) 
        {
            Id = id;
        }

       

    }
}
