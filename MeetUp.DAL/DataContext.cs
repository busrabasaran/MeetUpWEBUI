namespace MeetUp.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using MeetUp.Entity;

    public partial class DataContext : DbContext
    {
        public DataContext()
            : base("name=DataContext")
        {
        }

        public virtual DbSet<Messages> Messages { get; set; }
        public virtual DbSet<Organizations> Organizations { get; set; }
        public virtual DbSet<Participants> Participants { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>()
                .HasMany(e => e.Messages)
                .WithOptional(e => e.Users)
                .HasForeignKey(e => e.FromUserID);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Messages1)
                .WithOptional(e => e.Users1)
                .HasForeignKey(e => e.ToUserID);
        }
    }
}
