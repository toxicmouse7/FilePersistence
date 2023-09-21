using Domain.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Files.Get;

public sealed class GetFileQueryHandler : IRequestHandler<GetFileQuery, FileResponse>
{
    private readonly IApplicationDbContext _context;

    public GetFileQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<FileResponse> Handle(GetFileQuery request, CancellationToken cancellationToken)
    {
        var file = await _context
            .Files
            .Where(f => f.Id == request.Id)
            .Select(f => new FileResponse(f.Id.Value, f.Name, f.Content))
            .FirstOrDefaultAsync(cancellationToken);

        if (file is null)
        {
            throw new NotImplementedException();
        }
        
        return file;
    }
}