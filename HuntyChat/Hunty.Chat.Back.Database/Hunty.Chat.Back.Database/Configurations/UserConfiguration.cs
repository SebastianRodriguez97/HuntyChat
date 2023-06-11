using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Hunty.Chat.Back.Database.Entities;

namespace Hunty.Chat.Back.Database.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.ToTable("Users", "Chat");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .HasColumnType("INT")
                .IsRequired();

            builder.Property(e => e.Uid)
                .HasColumnType("NVARCHAR")
                .IsRequired()
                .HasMaxLength(300);

            builder.Property(e => e.Name)
                .HasColumnType("NVARCHAR")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.AccessToken)
                .HasColumnType("NVARCHAR")
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(e => e.ExpirationToken)
               .HasColumnType("DATETIME")
               .IsRequired();
        }
    }
}
