namespace Domain.Entities.OneTimeFileLink;

public class OneTimeFileLinkNotFoundException : Exception
{
    public OneTimeFileLinkNotFoundException(OneTimeFileLinkId id)
        : base($"One time file link with ID = '{id.Value}' was not found")
    {
    }
}