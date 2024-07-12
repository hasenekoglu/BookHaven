using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace LibraryManagementSystem.Application.Features.Queries.BookQueries.GetByIdBookQuery
{
    public class GetByIdBookQuery : IRequest<GetByIdBookResponse>
    {
        public Guid Id { get; set; }
    }
}
