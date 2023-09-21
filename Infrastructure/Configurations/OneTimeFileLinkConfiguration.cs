using Domain.Entities.File;
using Domain.Entities.OneTimeFileLink;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using File = Domain.Entities.File.File;

namespace Infrastructure.Configurations;

public class OneTimeFileLinkConfiguration : IEntityTypeConfiguration<OneTimeFileLink>
{
    public void Configure(EntityTypeBuilder<OneTimeFileLink> builder)
    {
        builder.HasKey(l => l.Id);
        
        builder.Property(l => l.Id).HasConversion(
            linkId => linkId.Value,
            value => new OneTimeFileLinkId(value));

        builder.Property(l => l.FileId).HasConversion(
            fileId => fileId.Value,
            value => new FileId(value));

        builder.HasOne<File>()
            .WithOne()
            .HasForeignKey<OneTimeFileLink>(l => l.FileId);
    }
}