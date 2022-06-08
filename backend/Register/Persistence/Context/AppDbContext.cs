﻿using backend.Register.Domain.Models;
using backend.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace backend.Register.Persistence.Context;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Business> Businesses { get; set; }
    public DbSet<BusinessProject> BusinessProjects { get; set; }
    
    public DbSet<Activity> Activities { get; set; }
    
    public DbSet<Portfolio> Portfolios { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Business>().ToTable("Business");
        builder.Entity<Business>().HasKey(p => p.Id);
        builder.Entity<Business>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Business>().Property(p => p.Email).IsRequired().HasMaxLength(50);
        builder.Entity<Business>().Property(p => p.Password).IsRequired().HasMaxLength(50);
        builder.Entity<Business>().Property(p => p.ConfirmPassword).IsRequired().HasMaxLength(50);
        builder.Entity<Business>().Property(p => p.Name).IsRequired().HasMaxLength(50);
        builder.Entity<Business>().Property(p => p.Phone).IsRequired();

        builder.Entity<Business>()
            .HasMany(p => p.Client)
            .WithOne(p => p.Business)
            .HasForeignKey(p => p.BusinessId);  

        builder.Entity<Client>().ToTable("Clients");
        builder.Entity<Client>().HasKey(p => p.Id);
        builder.Entity<Client>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Client>().Property(p => p.Email).IsRequired().HasMaxLength(50);
        builder.Entity<Client>().Property(p => p.Password).IsRequired().HasMaxLength(50);
        builder.Entity<Client>().Property(p => p.ConfirmPassword).IsRequired().HasMaxLength(50);
        builder.Entity<Client>().Property(p => p.FirstName).IsRequired().HasMaxLength(50);
        builder.Entity<Client>().Property(p => p.LastName).IsRequired().HasMaxLength(50);
        
        builder.Entity<Portfolio>().ToTable("Portfolios");
        builder.Entity<Portfolio>().HasKey(p => p.Id);
        builder.Entity<Portfolio>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Portfolio>().Property(p => p.Email).IsRequired().HasMaxLength(50);
        builder.Entity<Portfolio>().Property(p => p.Name).IsRequired().HasMaxLength(50);
        builder.Entity<Portfolio>().Property(p => p.Phone).IsRequired();

        builder.Entity<Portfolio>()
            .HasMany(p => p.Activity)
            .WithOne(p => p.Portfolio)
            .HasForeignKey(p => p.PortfolioId);  

        builder.Entity<Activity>().ToTable("Activity");
        builder.Entity<Activity>().HasKey(p => p.Id);
        builder.Entity<Activity>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Activity>().Property(p => p.Description).IsRequired().HasMaxLength(50);
        builder.Entity<Activity>().Property(p => p.StartDate).IsRequired().HasMaxLength(50);
        builder.Entity<Activity>().Property(p => p.FinisDate).IsRequired().HasMaxLength(50);
        
        
        builder.Entity<BusinessProject>().ToTable("BusinessProjects");
        builder.Entity<BusinessProject>().HasKey(p => p.Id);
        builder.Entity<BusinessProject>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<BusinessProject>().Property(p => p.Style).IsRequired().HasMaxLength(50);
        builder.Entity<BusinessProject>().Property(p => p.Description).IsRequired();
        builder.Entity<BusinessProject>().Property(p => p.Location).IsRequired().HasMaxLength(100);
        builder.Entity<BusinessProject>().Property(p => p.Img);
        builder.Entity<BusinessProject>().Property(p => p.Score);
        builder.Entity<BusinessProject>().Property(p => p.BusinessId).IsRequired();

        builder.UseSnakeCaseNamingConvention();
    }
}