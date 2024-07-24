using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Domain.Entities
{
    public class Book : BaseEntity
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public DateTime PublishedDate { get; set; }
        public Guid? CategoryId { get; set; }
        public string? ImageURL { get; set; } = "https://birkhauser.com/product-not-found.png";


        public ICollection<Loan> Loans { get; set; }
        public Category Category { get; set; }
    }
}
