using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace LibraryManagementSystem.Application.Features.Queries.LoanQueries.GetByIdLoanQuery
{
    public class GetByIdLoanQuery : IRequest<GetByIdLoanResponse>
    {
        public Guid Id { get; set; }
    }
}
