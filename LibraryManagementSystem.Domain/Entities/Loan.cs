using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.Domain.Entities.Identity;

namespace LibraryManagementSystem.Domain.Entities
{
    public class Loan : BaseEntity
    {
        
        public Guid BookId { get; set; }
        public DateTime LoanDate { get; set; }
        public string UserName { get; set; }
        public DateTime? ReturnDate { get; set; }

        public Book Books { get; set; }
        
     

     
    }
}
