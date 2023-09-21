using Domain.Abstractions;
using Domain.Entities.File;
using Microsoft.EntityFrameworkCore;
using File = Domain.Entities.File.File;

namespace Infrastructure.Repositories;

public sealed class FileRepository : IFileRepository
{
    private readonly ApplicationDbContext _context;

    public FileRepository(ApplicationDbContext context) => _context = context;

    public async Task AddAsync(File file)
    {
        await _context.Set<File>().AddAsync(file);
    }

    public async Task<File?> GetByIdAsync(FileId id)
    {
        return await _context.Set<File>().FirstOrDefaultAsync(f => f.Id == id);
    }
}