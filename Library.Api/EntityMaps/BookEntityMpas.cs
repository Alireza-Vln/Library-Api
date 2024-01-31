using Library.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Api.EntityMaps
{
    public class BookEntityMaps : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(_ => _.Name).HasMaxLength(50).IsRequired();
            builder.Property(_=>_.Category).HasMaxLength(50).IsRequired();
            builder.Property(_=>_.Price).IsRequired();
        }
    }
}
