using Domain.Abstractions;
using Domain.Entities;
using Domain.Entities.OneTimeFileLink;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class OneTimeFileLinkRepository : IOneTimeFileLinkRepository
{
    private readonly ApplicationDbContext _context;

    public OneTimeFileLinkRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(OneTimeFileLink link)
    {
        await _context.Set<OneTimeFileLink>().AddAsync(link);
    }

    public async Task<OneTimeFileLink?> GetByIdAsync(OneTimeFileLinkId id)
    {
        return await _context.Set<OneTimeFileLink>().FirstOrDefaultAsync(l => l.Id == id);
    }

    public void Remove(OneTimeFileLink link)
    {
        _context.Remove(link);
    }
}