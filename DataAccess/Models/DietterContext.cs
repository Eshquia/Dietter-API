using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataAccess.Models
{
    public partial class DietterContext : DbContext
    {
        public DietterContext()
        {
        }

        public DietterContext(DbContextOptions<DietterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AssignedList> AssignedList { get; set; }
        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<FoodTypes> FoodTypes { get; set; }
        public virtual DbSet<Foods> Foods { get; set; }
        public virtual DbSet<Lists> Lists { get; set; }
        public virtual DbSet<Logs> Logs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=Your Server;Database=Dietter;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AssignedList>(entity =>
            {
                entity.ToTable("assignedList");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.ClientId).HasColumnName("clientId");

                entity.Property(e => e.Date).HasColumnName("date");

                entity.Property(e => e.FoodId).HasColumnName("foodId");

                entity.Property(e => e.ListId).HasColumnName("listId");

                entity.HasOne(d => d.Food)
                    .WithMany(p => p.AssignedList)
                    .HasForeignKey(d => d.FoodId)
                    .HasConstraintName("FK_assignedList_Foods");

                entity.HasOne(d => d.List)
                    .WithMany(p => p.AssignedList)
                    .HasForeignKey(d => d.ListId)
                    .HasConstraintName("FK_assignedList_Lists");
            });

            modelBuilder.Entity<Clients>(entity =>
            {
                entity.HasKey(e => e.ClientId);

                entity.Property(e => e.ClientId)
                    .HasColumnName("clientID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ClientName)
                    .IsRequired()
                    .HasColumnName("clientName")
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.Isdeleted).HasColumnName("isdeleted");
            });

            modelBuilder.Entity<FoodTypes>(entity =>
            {
                entity.HasKey(e => e.FoodTypeId);

                entity.Property(e => e.FoodTypeId).HasColumnName("foodTypeId");

                entity.Property(e => e.FoodTypeName)
                    .HasColumnName("foodTypeName")
                    .HasMaxLength(50)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Foods>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Calorie).HasColumnName("calorie");

                entity.Property(e => e.FoodName)
                    .HasColumnName("foodName")
                    .HasMaxLength(100);

                entity.Property(e => e.FoodType).HasColumnName("foodType");

                entity.HasOne(d => d.FoodTypeNavigation)
                    .WithMany(p => p.Foods)
                    .HasForeignKey(d => d.FoodType)
                    .HasConstraintName("FK_Foods_FoodTypes");
            });

            modelBuilder.Entity<Lists>(entity =>
            {
                entity.Property(e => e.ClientId).HasColumnName("clientID");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.ListId).HasColumnName("listID");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Lists)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK_Lists_Clients");
            });

            modelBuilder.Entity<Logs>(entity =>
            {
                entity.ToTable("Logs", "EventLogging");

                entity.Property(e => e.TimeStamp).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
