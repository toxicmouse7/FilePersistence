using Domain.Entities;
using Domain.Entities.OneTimeFileLink;
using Microsoft.EntityFrameworkCore;
using File = Domain.Entities.File.File;

namespace Domain.Abstractions;

public interface IApplicationDbContext
{
    public DbSet<File> Files { get; set; }
    public DbSet<OneTimeFileLink> OneTimeFileLinks { get; set; }
}