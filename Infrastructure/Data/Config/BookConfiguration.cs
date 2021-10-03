using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(b => b.Id).IsRequired();
            builder.Property(b => b.Title).IsRequired().HasMaxLength(100);
            builder.Property(b => b.Description).IsRequired().HasMaxLength(240);
            builder.Property(b => b.Price).HasColumnType("decimal(18,2)");
            builder.Property(b => b.PictureUrl).IsRequired();

            builder.HasOne(b => b.Author).WithMany().HasForeignKey(b => b.AuthorId);
            builder.HasOne(b => b.Genre).WithMany().HasForeignKey(b => b.GenreId);
            builder.HasOne(b => b.Publisher).WithMany().HasForeignKey(b => b.PublisherId);
            builder.HasOne(b => b.Language).WithMany().HasForeignKey(b => b.LanguageId);
        }
    }
}