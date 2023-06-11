using Microsoft.EntityFrameworkCore;
using System;
using Hunty.Chat.Back.Database.Configurations;
using Hunty.Chat.Back.Database.Entities;

namespace Hunty.Chat.Back.Database.Context
{
    public class TPContext : DbContext
    {
        public TPContext(DbContextOptions options) : base(options) { }

        #region DBSet
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Rooms> Rooms { get; set; }
        public virtual DbSet<Conversations> Conversations { get; set; }
        public virtual DbSet<Messages> Messages { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(TPContext).Assembly);

            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoomConfiguration());
            modelBuilder.ApplyConfiguration(new ConversationConfiguration());
            modelBuilder.ApplyConfiguration(new MessageConfiguration());
        }
    }
}
