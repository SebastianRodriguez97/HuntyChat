using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Hunty.Chat.Back.Database.Entities;

namespace Hunty.Chat.Back.Database.Configurations
{
    public class ConversationConfiguration : IEntityTypeConfiguration<Conversations>
    {
        public void Configure(EntityTypeBuilder<Conversations> builder)
        {
            builder.ToTable("Conversations", "Chat");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .HasColumnType("INT")
                .ValueGeneratedOnAdd()
                .IsRequired();            

            builder.Property(e => e.Id_User)
                .HasColumnType("INT")
                .IsRequired();

            builder.Property(e => e.Id_Room)
                .HasColumnType("INT")
                .IsRequired();

            builder.HasOne(d => d.User)
                .WithMany(p => p.Conversations)
                .HasForeignKey(d => d.Id_User)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_Conversations");

            builder.HasOne(d => d.Room)
                .WithMany(p => p.Conversations)
                .HasForeignKey(d => d.Id_Room)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Rooms_Conversations");
        }
    }
}
