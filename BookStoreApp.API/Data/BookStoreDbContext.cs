using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApp.API.Data;

public partial class BookStoreDbContext : IdentityDbContext<ApiUser>
{
    public BookStoreDbContext()
    {
    }

    public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Authors__3214EC0775DF637E");

            entity.Property(e => e.Bio).HasMaxLength(250);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Books__3214EC07D640B492");

            entity.HasIndex(e => e.Isbn, "UQ__Books__447D36EA9ED5901E").IsUnique();

            entity.Property(e => e.Image).HasMaxLength(50);
            entity.Property(e => e.Isbn)
                .HasMaxLength(50)
                .HasColumnName("ISBN");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Summary).HasMaxLength(250);
            entity.Property(e => e.Title).HasMaxLength(50);

            entity.HasOne(d => d.Author).WithMany(p => p.Books)
                .HasForeignKey(d => d.AuthorId)
                .HasConstraintName("FK_Books_ToTable");
        });

        modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Name="User",
                    NormalizedName="USER",
                    Id= "a5fe66c6-746e-47fc-9e6b-99c0fd9d29ec"
                },
                new IdentityRole
                {
                    Name="Administrator",
                    NormalizedName="ADMINISTRATOR",
                    Id= "fd67e261-fd62-4be2-9328-04bbbbf4315c"
                }
            );
        var hasher = new PasswordHasher<ApiUser>();
        modelBuilder.Entity<ApiUser>().HasData(
                new ApiUser
                {
                    Id= "a5c661b7-7774-4af5-8327-28259dc9b53c",
                    Email="admin@bookstore.com",
                    NormalizedEmail="ADMIN@BOOKSTORE.COM",
                    UserName="admin@bookstore.com",
                    NormalizedUserName="ADMIN@BOOKSTORE.COM",
                    FirstName="System",
                    LastName="Admin",
                    PasswordHash=hasher.HashPassword(null, "P@ssword1")

                },
                new ApiUser
                {
                    Id= "53ea03e5-6201-4544-964f-3e7e3e93e2b2",
                    Email = "user@bookstore.com",
                    NormalizedEmail = "USER@BOOKSTORE.COM",
                    UserName = "user@bookstore.com",
                    NormalizedUserName = "USER@BOOKSTORE.COM",
                    FirstName = "System",
                    LastName = "User",
                    PasswordHash = hasher.HashPassword(null, "P@ssword1")
                }
            );
        modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId= "a5fe66c6-746e-47fc-9e6b-99c0fd9d29ec",
                    UserId= "53ea03e5-6201-4544-964f-3e7e3e93e2b2"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "fd67e261-fd62-4be2-9328-04bbbbf4315c",
                    UserId = "a5c661b7-7774-4af5-8327-28259dc9b53c"
                }
            );

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
