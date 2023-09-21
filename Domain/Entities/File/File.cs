using Domain.Primitives;

namespace Domain.Entities.File;

public sealed class File : Entity<FileId>
{
    public string Name { get; set; }
    public byte[] Content { get; set; }

    public File(FileId id, string name, byte[] content)
    {
        Id = id;
        Name = name;
        Content = content;
    }
}