using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.Application.Interfaces;
using LibraryManagementSystem.Domain.Entities;
using LibraryManagementSystem.Infrastructure.Data;

namespace LibraryManagementSystem.Infrastructure.Repositories
{
    public class RoleRepository : GenericRepository<Role> , IRoleRepository
    {
        public RoleRepository(LibraryContext context) : base(context)
        {
        }
    }
}
