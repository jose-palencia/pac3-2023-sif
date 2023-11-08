﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;

namespace WebApiAutores.Entities
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.HasDefaultSchema("security");

            builder.Entity<IdentityUser>().ToTable("users");
            builder.Entity<IdentityRole>().ToTable("roles");
            builder.Entity<IdentityUserRole<string>>().ToTable("users_roles");
            builder.Entity<IdentityUserClaim<string>>().ToTable("users_claims");
            builder.Entity<IdentityUserLogin<string>>().ToTable("users_logins");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("roles_claims");
            builder.Entity<IdentityUserToken<string>>().ToTable("users_tokens");

            builder.Entity<Book>()
                .HasIndex(x => x.ISBN)
                .IsUnique(true);
        }

        public DbSet<Autor> Autores { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
