﻿using BookManager.Catalog.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookManager.Catalog.Data.Mappings
{
    public class BookMapping : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Title)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(c => c.ReleaseDate)
                .IsRequired();

            builder.OwnsOne(c => c.Isbn, cm =>
            {
                cm.Property(c => c.Isbn)
                    .HasColumnName("Isbn")
                    .HasColumnType("varchar");
            });

            // N : 1 => Books : Author
            builder.HasOne(b => b.Author)
                   .WithMany(a => a.Books)
                   .HasForeignKey(b => b.AuthorId);

            builder.ToTable("Books");
        }
    }
}
