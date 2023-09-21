using Domain.Entities.File;
using Domain.Primitives;

namespace Domain.Entities.OneTimeFileLink;

public sealed class OneTimeFileLink : Entity<OneTimeFileLinkId>
{
    public FileId FileId { get; set; }

    public OneTimeFileLink(OneTimeFileLinkId id, FileId fileId)
    {
        Id = id;
        FileId = fileId;
    }
}