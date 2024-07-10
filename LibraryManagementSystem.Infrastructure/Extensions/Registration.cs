using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.Application.Token;
using LibraryManagementSystem.Domain.Entities.Identity;
using LibraryManagementSystem.Domain.Interfaces;
using LibraryManagementSystem.Infrastructure.Data;
using LibraryManagementSystem.Infrastructure.Helpers.Token;
using LibraryManagementSystem.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryManagementSystem.Infrastructure.Extensions
{
    public static class Registration
    {
        public static IServiceCollection AddInfrastructureRegistration(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<LibraryContext>(conf =>
            {
                var connStr = configuration["BookHavenConnectionStrings"].ToString();
                conf.UseSqlServer(connStr, opt =>
                {
                    opt.EnableRetryOnFailure();
                });
            });


            services.AddIdentity<AppUser,AppRole>().AddEntityFrameworkStores<LibraryContext>();


            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<ILoanRepository, LoanRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<ITokenHandler, TokenHandler>();



            return services;
        }
    }
}
