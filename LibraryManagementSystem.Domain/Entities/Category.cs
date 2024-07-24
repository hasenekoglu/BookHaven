using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Domain.Entities
{
    public class Category : BaseEntity
    {
       
        public string Name { get; set; }
        public string ImageURL { get; set; } = "https://static.thenounproject.com/png/101469-200.png";
        public ICollection<Book> Books { get; set; }
    }
}
