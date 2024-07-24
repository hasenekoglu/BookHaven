using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Dto.BookDtos
{
    public class ResultBookDetailsDto
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public DateTime PublishedDate { get; set; }
        public string CategoryName { get; set; }
        public string? ImageURL { get; set; }

    }
}
