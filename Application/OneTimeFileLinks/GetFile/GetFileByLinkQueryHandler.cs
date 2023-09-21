using Application.Files.Get;
using Domain.Abstractions;
using Domain.Entities.OneTimeFileLink;
using MediatR;
using Microsoft.EntityFrameworkCore;
using FileNotFoundException = Domain.Entities.File.FileNotFoundException;

namespace Application.OneTimeFileLinks.GetFile;

public class GetFileByLinkQueryHandler : IRequestHandler<GetFileByLinkQuery, FileResponse>
{
    private readonly IApplicationDbContext _context;

    public GetFileByLinkQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<FileResponse> Handle(GetFileByLinkQuery request, CancellationToken cancellationToken)
    {
        var link = await _context
            .OneTimeFileLinks
            .FirstOrDefaultAsync(l => l.Id == request.Id,
                cancellationToken);

        if (link is null)
        {
            throw new OneTimeFileLinkNotFoundException(request.Id);
        }

        var file = await _context
            .Files
            .FirstOrDefaultAsync(f => f.Id == link.FileId,
                cancellationToken);

        if (file is null)
        {
            throw new FileNotFoundException(link.FileId);
        }

        var fileResponse = new FileResponse(file.Id.Value, file.Name, file.Content);

        return fileResponse;
    }
}