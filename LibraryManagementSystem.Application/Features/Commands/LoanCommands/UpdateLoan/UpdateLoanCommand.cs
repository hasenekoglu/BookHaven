using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace LibraryManagementSystem.Application.Features.Commands.LoanCommands.UpdateLoan
{
    public class UpdateLoanCommand : IRequest<UpdateLoanResponse>
    {
        public Guid Id { get; set; }
        public Guid BookId { get; set; }
        public int UserId { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
