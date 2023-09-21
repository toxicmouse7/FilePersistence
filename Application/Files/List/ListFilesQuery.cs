using Domain.Entities.File;
using MediatR;

namespace Application.Files.List;

public record ListFilesQuery : IRequest<IEnumerable<FileResponse>>;
public record FileResponse(Guid Id, string Name);