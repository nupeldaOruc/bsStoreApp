using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using webApi.Models;

namespace webApi.Repositories.Config
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Books");
            builder.HasKey(b => b.Id);
            
            builder.HasData(
                new Book { Id = 1, Title = "Karagöz ve Hacivat", Price = 75 },
                new Book { Id = 2, Title = "Mesnevi", Price = 52 },
                new Book { Id = 3, Title = "Devlet", Price = 37 }
            );
        }
    }
}