using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;



namespace ProblemSolverUPT.WebAPI.Models
{
    public partial class ProblemSolverUPTDatabaseContext : DbContext
    {
        public ProblemSolverUPTDatabaseContext()
        {
        }

        public ProblemSolverUPTDatabaseContext(DbContextOptions<ProblemSolverUPTDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<FeedbackCamine> FeedbackCamines { get; set; }
        public virtual DbSet<FeedbackCantina> FeedbackCantinas { get; set; }
        public virtual DbSet<GeneralProblem> GeneralProblems { get; set; }
        public virtual DbSet<TeachersFeedback> TeachersFeedbacks { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<FeedbackCamine>(entity =>
            {
                entity.ToTable("FeedbackCamine");

                entity.Property(e => e.Camera)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Camin)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.DataPostare).HasColumnType("date");

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(255)
                    .IsFixedLength(true);

                entity.Property(e => e.Imagine).HasColumnType("image");

                entity.Property(e => e.Status)
                    .HasMaxLength(30)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<FeedbackCantina>(entity =>
            {
                entity.ToTable("FeedbackCantina");

                entity.Property(e => e.DataPostare).HasColumnType("date");

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(255)
                    .IsFixedLength(true);

                entity.Property(e => e.Imagine).HasColumnType("image");

                entity.Property(e => e.Status)
                    .HasMaxLength(30)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<GeneralProblem>(entity =>
            {
                entity.Property(e => e.DataPostare).HasColumnType("date");

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(255)
                    .IsFixedLength(true);

                entity.Property(e => e.Imagine).HasColumnType("image");

                entity.Property(e => e.Status)
                    .HasMaxLength(30)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<TeachersFeedback>(entity =>
            {
                entity.ToTable("TeachersFeedback");

                entity.Property(e => e.AnStudiu)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.CadrulDidactic)
                    .HasMaxLength(255)
                    .IsFixedLength(true);

                entity.Property(e => e.DataPostare).HasColumnType("date");

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(255)
                    .IsFixedLength(true);

                entity.Property(e => e.Facultate)
                    .HasMaxLength(255)
                    .IsFixedLength(true);

                entity.Property(e => e.Materia)
                    .HasMaxLength(255)
                    .IsFixedLength(true);

                entity.Property(e => e.Sectie)
                    .HasMaxLength(100)
                    .IsFixedLength(true);

                entity.Property(e => e.Status)
                    .HasMaxLength(30)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.EmailAddress)
                    .HasName("PK_UsersTable");

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(255)
                    .IsFixedLength(true);

                entity.Property(e => e.Faculty)
                    .HasMaxLength(255)
                    .IsFixedLength(true);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsFixedLength(true);

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
