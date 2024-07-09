using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.Domain.Entities;
using LibraryManagementSystem.Domain.Interfaces;
using LibraryManagementSystem.Infrastructure.Data;

namespace LibraryManagementSystem.Infrastructure.Repositories
{
    public class LoanRepository : GenericRepository<Loan>,ILoanRepository
    {
        public LoanRepository(LibraryContext context) : base(context)
        {
        }
    }
}
