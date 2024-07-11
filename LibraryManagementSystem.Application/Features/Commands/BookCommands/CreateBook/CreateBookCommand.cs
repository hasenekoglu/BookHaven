using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LibraryManagementSystem.Domain.Entities;
using LibraryManagementSystem.Domain.Interfaces;
using MediatR;

namespace LibraryManagementSystem.Application.Features.Commands.BookCommands.CreateBook
{
    public class CreateBookCommand : IRequest<CreateBookResponse>
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }

        public Guid? CategoryId { get; set; }
        //public string CategoryName { get; set; }
        public DateTime PublishedDate { get; set; }
    }

    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, CreateBookResponse>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public CreateBookCommandHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<CreateBookResponse> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            Book book = _mapper.Map<Book>(request);
            book.Id = Guid.NewGuid();

            await _bookRepository.AddAsync(book);

            CreateBookResponse createBookResponse = _mapper.Map<CreateBookResponse>(book);
            return createBookResponse;

        }
    }
}
