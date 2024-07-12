using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace LibraryManagementSystem.Application.Features.Queries.CategoryQueries.GetAllCategoryQuery
{
    public class GetAllCategoryQuery : IRequest<List<GetAllCategoryResponse>>
    {

    }
}
