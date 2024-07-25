using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Dto.CategoryDtos
{
    public class ResultCategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ImageURL { get; set; }
    }
}
