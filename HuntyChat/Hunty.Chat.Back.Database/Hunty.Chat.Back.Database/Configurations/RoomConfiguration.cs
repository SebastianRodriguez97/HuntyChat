using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Hunty.Chat.Back.Database.Entities;

namespace Hunty.Chat.Back.Database.Configurations
{
    public class RoomConfiguration : IEntityTypeConfiguration<Rooms>
    {
        public void Configure(EntityTypeBuilder<Rooms> builder)
        {
            builder.ToTable("Rooms", "Chat");

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
        }
    }
}
