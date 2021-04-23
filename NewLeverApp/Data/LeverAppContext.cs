using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewLeverApp.Models;


namespace NewLeverApp.Data
{
    public partial class LeverAppContext : DbContext
    {


        public LeverAppContext(DbContextOptions<LeverAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Level> Levels { get; set; }
        public virtual DbSet<Mentee> Mentees { get; set; }
        public virtual DbSet<View1> View1s { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LXIBY1166\\SQLEXPRESS;Database=LeverApp;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Level>(entity =>
            {
                entity.ToTable("Level");

                entity.Property(e => e.LevelId).ValueGeneratedNever();

                entity.Property(e => e.Position)
                    .HasMaxLength(10)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Mentee>(entity =>
            {
                entity.ToTable("Mentee");

                entity.Property(e => e.MenteeId).ValueGeneratedNever();

                entity.Property(e => e.MenteeName)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.HasOne(d => d.Level)
                    .WithMany(p => p.Mentees)
                    .HasForeignKey(d => d.LevelId)
                    .HasConstraintName("FK__Mentee__LevelId__628FA481");
            });

            modelBuilder.Entity<View1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_1");

                entity.Property(e => e.MenteeName)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Position)
                    .HasMaxLength(10)
                    .IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
