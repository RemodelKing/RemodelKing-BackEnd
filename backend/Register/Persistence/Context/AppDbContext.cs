using backend.Register.Domain.Models;
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