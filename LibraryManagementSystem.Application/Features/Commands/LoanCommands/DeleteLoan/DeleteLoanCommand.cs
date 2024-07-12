using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace LibraryManagementSystem.Application.Features.Commands.LoanCommands.DeleteLoan
{
    public class DeleteLoanCommand : IRequest<DeleteLoanResponse>
    {
        public DeleteLoanCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
