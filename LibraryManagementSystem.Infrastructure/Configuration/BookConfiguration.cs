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
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Category).IsRequired().HasMaxLength(255);
            builder.Property(b => b.Author).IsRequired().HasMaxLength(255);
            builder.Property(b => b.ISBN).IsRequired().HasMaxLength(13);
        }
    }
}
