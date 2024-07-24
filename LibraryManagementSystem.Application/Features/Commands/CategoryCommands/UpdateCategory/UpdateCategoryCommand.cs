using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace LibraryManagementSystem.Application.Features.Commands.CategoryCommands.UpdateCategory
{
    public class UpdateCategoryCommand : IRequest<UpdateCategoryResponse>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ImageURL { get; set; }
    }
}

