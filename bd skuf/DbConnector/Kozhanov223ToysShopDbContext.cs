using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using bd_skuf.Models;

namespace bd_skuf.DbConnector;

public partial class Kozhanov223ToysShopDbContext : DbContext
{
    public Kozhanov223ToysShopDbContext()
    {
    }

    public Kozhanov223ToysShopDbContext(DbContextOptions<Kozhanov223ToysShopDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Executor> Executors { get; set; }

    public virtual DbSet<Music> Musics { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=83.147.246.87;Database=kozhanov_223_toys_shop_db;Username=kozhanov_223_toys_shop;Password=12345");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Executor>(entity =>
        {
            entity.HasKey(e => e.Executorid).HasName("executor_pk");

            entity.ToTable("executor");

            entity.HasIndex(e => e.Usersid, "executor_pk_2").IsUnique();

            entity.Property(e => e.Executorid)
                .ValueGeneratedOnAdd()
                .HasColumnName("executorid");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .HasColumnName("name");
            entity.Property(e => e.Nickname)
                .HasMaxLength(20)
                .HasColumnName("nickname");
            entity.Property(e => e.Surename)
                .HasMaxLength(20)
                .HasColumnName("surename");
            entity.Property(e => e.Usersid).HasColumnName("usersid");

            entity.HasOne(d => d.ExecutorNavigation).WithOne(p => p.Executor)
                .HasPrincipalKey<Music>(p => p.Executorid)
                .HasForeignKey<Executor>(d => d.Executorid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("executor___fk");
        });

        modelBuilder.Entity<Music>(entity =>
        {
            entity.HasKey(e => e.Musicid).HasName("music_pk");

            entity.ToTable("music");

            entity.HasIndex(e => e.Userid, "music_pk_2").IsUnique();

            entity.HasIndex(e => e.Executorid, "music_pk_3").IsUnique();

            entity.Property(e => e.Musicid).HasColumnName("musicid");
            entity.Property(e => e.Executorid).HasColumnName("executorid");
            entity.Property(e => e.Userid).HasColumnName("userid");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Userid).HasName("users_pk");

            entity.ToTable("users");

            entity.Property(e => e.Userid)
                .ValueGeneratedNever()
                .HasColumnName("userid");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .HasColumnName("name");
            entity.Property(e => e.Nickname)
                .HasMaxLength(40)
                .HasColumnName("nickname");
            entity.Property(e => e.Surename)
                .HasMaxLength(20)
                .HasColumnName("surename");

            entity.HasOne(d => d.UserNavigation).WithOne(p => p.User)
                .HasPrincipalKey<Music>(p => p.Userid)
                .HasForeignKey<User>(d => d.Userid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("users___fk");

            entity.HasOne(d => d.User1).WithOne(p => p.User)
                .HasPrincipalKey<Executor>(p => p.Usersid)
                .HasForeignKey<User>(d => d.Userid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("users___fk_2");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
