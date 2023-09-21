namespace Domain.Entities.File;

public class FileNotFoundException : Exception
{
    public FileNotFoundException(FileId id)
        : base($"File with ID = '{id.Value}' was not found")
    {
    }
}