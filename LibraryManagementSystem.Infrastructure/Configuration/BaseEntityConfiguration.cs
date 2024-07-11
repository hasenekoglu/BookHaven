using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagementSystem.Infrastructure.Configuration
{
    public  abstract class BaseEntityConfiguration <T> : IEntityTypeConfiguration<T> where T : BaseEntity 
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id).ValueGeneratedOnAdd();
        }
    }
}
