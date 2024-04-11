using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using TaskManager.Core.Entities;

namespace TaskManager.Infrastructure.Data.EntityTypeConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Login);

            builder.HasData(new User()
            {
                Id = 1,
                Name = "Администратор",
                Login = "admin",
                Password = "admin"
            });



        }
    }
}