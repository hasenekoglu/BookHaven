﻿using AutoMapper;
using LibraryManagementSystem.Application.Exceptions;
using LibraryManagementSystem.Application.Interfaces;
using LibraryManagementSystem.Domain.Entities;

using MediatR;

namespace LibraryManagementSystem.Application.Features.Queries.BookQueries.GetByIdBookQuery;

public class GetByIdBookQueryHandler : IRequestHandler<GetByIdBookQuery,GetByIdBookResponse>
{
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;
    private readonly ICategoryRepository _categoryRepository;

    public GetByIdBookQueryHandler(IMapper mapper, IBookRepository bookRepository, ICategoryRepository categoryRepository)
    {
        _mapper = mapper;
        _bookRepository = bookRepository;
        _categoryRepository = categoryRepository;
    }

    public async Task<GetByIdBookResponse> Handle(GetByIdBookQuery request, CancellationToken cancellationToken)
    {
        Book book = await _bookRepository.GetByIdAsync(request.Id);
        if (book is null)
            throw new DatabaseValidationException("Kitap bulunamadı!");

        GetByIdBookResponse response = _mapper.Map<GetByIdBookResponse>(book);
        if (response.CategoryId is not null)
        {
            var category = await _categoryRepository.GetByIdAsync(response.CategoryId.Value);
            category.Name = response.Name;
        }


        return response;

    }
}