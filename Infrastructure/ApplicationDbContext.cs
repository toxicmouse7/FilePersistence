using Domain.Abstractions;
using Domain.Entities;
using Domain.Entities.OneTimeFileLink;
using Microsoft.EntityFrameworkCore;
using File = Domain.Entities.File.File;

namespace Infrastructure;

public sealed class ApplicationDbContext : DbContext, IUnitOfWork, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions options)
        : base(options)
    {
        Database.Migrate();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

    public DbSet<File> Files { get; set; } = null!;
    public DbSet<OneTimeFileLink> OneTimeFileLinks { get; set; } = null!;
}