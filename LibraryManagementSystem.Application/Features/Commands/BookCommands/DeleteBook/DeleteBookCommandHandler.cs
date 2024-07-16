using AutoMapper;
using LibraryManagementSystem.Application.Interfaces;
using LibraryManagementSystem.Domain.Entities;

using MediatR;

namespace LibraryManagementSystem.Application.Features.Commands.BookCommands.DeleteBook
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand,DeleteBookResponse>
    {
        private readonly IBookRepository repository;
        private readonly IMapper mapper;

        public DeleteBookCommandHandler(IMapper mapper, IBookRepository repository)
        {
            this.mapper=mapper;
            this.repository=repository;
        }

        public async Task<DeleteBookResponse> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            Book? book = await repository.GetByIdAsync(request.Id);
            await repository.DeleteAsync(book);

            DeleteBookResponse response = mapper.Map<DeleteBookResponse>(book);
            return response;
        }
    }
}
