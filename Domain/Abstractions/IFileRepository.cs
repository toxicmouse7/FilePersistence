using Domain.Entities.File;
using File = Domain.Entities.File.File;

namespace Domain.Abstractions;

public interface IFileRepository
{
    public Task AddAsync(File file);
    public Task<File?> GetByIdAsync(FileId id);
}