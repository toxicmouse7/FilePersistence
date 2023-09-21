using Domain.Entities.OneTimeFileLink;

namespace Domain.Abstractions;

public interface IOneTimeFileLinkRepository
{
    public Task AddAsync(OneTimeFileLink link);
    public Task<OneTimeFileLink?> GetByIdAsync(OneTimeFileLinkId id);
    public void Remove(OneTimeFileLink link);
}