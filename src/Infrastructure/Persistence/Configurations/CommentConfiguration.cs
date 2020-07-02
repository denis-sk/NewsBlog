using System;
using System.Collections.Generic;
using System.Text;
using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Persistence.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(t => t.Autor)
                .IsRequired();
            builder.Property(t => t.NewsItemId)
                .IsRequired();
            builder.Property(t => t.Text)
                .IsRequired();
            builder.HasIndex(i => i.Text);
        }
    }
}
