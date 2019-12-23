﻿using BookManager.Catalog.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookManager.Catalog.Data.Mappings
{
    public class AuthorMapping : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(c => c.Birthdate)
                .IsRequired();

            builder.OwnsOne(c => c.Cpf, cm =>
            {
                cm.Property(c => c.Cpf)
                    .HasColumnName("Cpf")
                    .HasColumnType("varchar");
            });

            // 0 : N => Author : Books
            builder.HasMany(c => c.Books)
                   .WithOne(b => b.Author)
                   .HasForeignKey(b => b.AuthorId);
        }
    }
}
