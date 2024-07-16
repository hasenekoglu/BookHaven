using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace LibraryManagementSystem.Application.Features.Commands.LoanCommands.CreateLoan
{
    public class CreateLoanCommand :IRequest<CreateLoanResponse>
    {
        public Guid BookId { get; set; }
        public string UserId { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
