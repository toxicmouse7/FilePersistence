using Domain.Entities.File;
using MediatR;

namespace Application.Files.Get;

public record GetFileQuery(FileId Id) : IRequest<FileResponse>;

public record FileResponse(Guid Id, string Name, byte[] Content);