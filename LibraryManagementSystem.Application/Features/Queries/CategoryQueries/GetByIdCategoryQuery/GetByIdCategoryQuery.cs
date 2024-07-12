using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace LibraryManagementSystem.Application.Features.Queries.CategoryQueries.GetByIdCategoryQuery
{
    public class GetByIdCategoryQuery : IRequest<GetByIdCategoryResponse>
    {
        public Guid Id { get; set; }
    }
}
