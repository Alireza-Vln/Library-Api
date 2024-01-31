using Library.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Api.EntityMaps
{
    public class UserEntityMaps : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
          
            builder.Property(_ => _.FullName).HasMaxLength(50).IsRequired();
            builder.Property(_ => _.Email).HasMaxLength(100).IsRequired();
           
        }
    }
}
