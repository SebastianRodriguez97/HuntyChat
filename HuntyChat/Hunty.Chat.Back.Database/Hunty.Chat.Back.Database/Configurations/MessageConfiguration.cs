using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Hunty.Chat.Back.Database.Entities;

namespace Hunty.Chat.Back.Database.Configurations
{
    public class MessageConfiguration : IEntityTypeConfiguration<Messages>
    {
        public void Configure(EntityTypeBuilder<Messages> builder)
        {
            builder.ToTable("Messages", "Chat");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .HasColumnType("INT")
                .IsRequired();

            builder.Property(e => e.Text)
                .HasColumnType("NVARCHAR")
                .IsRequired()
                .HasMaxLength(300);

            builder.Property(e => e.DateCreated)
               .HasColumnType("DATETIME")
               .IsRequired();

            builder.Property(e => e.IsFromWebhook)
               .HasColumnType("BIT")
               .IsRequired();

            builder.Property(e => e.Id_Conversation)
                .HasColumnType("INT")
                .IsRequired();

            builder.HasOne(d => d.Conversation)
                .WithMany(p => p.Messages)
                .HasForeignKey(d => d.Id_Conversation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Conversations_Messages");
        }
    }
}
