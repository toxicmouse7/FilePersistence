using Domain.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Files.List;

public class ListFilesQueryHandler : IRequestHandler<ListFilesQuery, IEnumerable<FileResponse>>
{
    private readonly IApplicationDbContext _context;

    public ListFilesQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<FileResponse>> Handle(ListFilesQuery request, CancellationToken cancellationToken)
    {
        var files = await _context
            .Files
            .Select(f => new FileResponse(f.Id.Value, f.Name))
            .ToListAsync(cancellationToken);

        return files;
    }
}