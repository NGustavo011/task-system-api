using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskSystem.Models;

namespace TaskSystem.Data.Map
{
    public class UserMap : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
            builder.HasKey(user => user.Id);
            builder.Property(user => user.Name).IsRequired().HasMaxLength(255);
            builder.Property(user => user.Email).IsRequired().HasMaxLength(150);
        }
    }
}
