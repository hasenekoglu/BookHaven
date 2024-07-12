﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace LibraryManagementSystem.Application.Features.Commands.CategoryCommands.DeleteCategory
{
    public class DeleteCategoryCommand :IRequest<DeleteCategoryResponse>
    {
        public Guid  Id { get; set; }
    }
}