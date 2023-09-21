using Domain.Entities.File;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using File = Domain.Entities.File.File;

namespace Infrastructure.Configurations;

public class FileConfiguration : IEntityTypeConfiguration<File>
{
    public void Configure(EntityTypeBuilder<File> builder)
    {
        builder.HasKey(f => f.Id);

        builder.Property(f => f.Id).HasConversion(
            fileId => fileId.Value,
            value => new FileId(value));
    }
}