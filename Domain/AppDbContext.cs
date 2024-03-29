﻿using System;
using System.Data.SqlTypes;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyCompany.Domain.Entities;

namespace MyCompany.Domain
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TextField> TextFields { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                Name = "admin",
                NormalizedName = "ADMIN"
            });

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "33546e06-8719-4ad8-b88a-f271ae9d6ecs",
                Name = "user",
                NormalizedName = "USER"
            });

            modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = "2c62472e-4f66-49fa-a20f-e7685b9565e9",
                UserName = "user",
                NormalizedUserName = "USER",
                Email = "user@email.com",
                NormalizedEmail = "MY@EMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "superpassword"),
                SecurityStamp = string.Empty
            });

            modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@email.com",
                NormalizedEmail = "MY@EMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "superpassword"),
                SecurityStamp = string.Empty
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string> // для пользователя
            {
                RoleId = "33546e06-8719-4ad8-b88a-f271ae9d6ecs",
                UserId = "2c62472e-4f66-49fa-a20f-e7685b9565e9"
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string> //для админа
            {
                RoleId = "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                UserId = "3b62472e-4f66-49fa-a20f-e7685b9565d8"
            });

            modelBuilder.Entity<TextField>().HasData(new TextField { 
                Id = new Guid("63dc8fa6-07ae-4391-8916-e057f71239ce"),
                CodeWord = "PageIndex", 
                Title = "Главная"
            });
            modelBuilder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("70af165a-700a-4156-91c0-e83fce0a277f"), 
                CodeWord = "PageTarget", 
                Title = "Цели и задачи работы"
            });
            modelBuilder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("4ab76a4c-c59d-409a-84c1-06e6487a137a"), 
                CodeWord = "PageInputData", 
                Title = "Исходные данные"
            });
            modelBuilder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("63da8fa6-07ae-4391-8916-e057f71239ce"),
                CodeWord = "PagePlanJob",
                Title = "План работы и календарные сроки"
            });
            modelBuilder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("70bf166a-700a-4156-91c0-e83fce0a277f"),
                CodeWord = "PageResult",
                Title = "Теоретические и практические результаты"
            });
            modelBuilder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("71af175a-700a-4156-91c0-e83fce0a277f"),
                CodeWord = "PageAprobe",
                Title = "Апробация результатов"
            });
        }
    }
}
