using Application.Files.Get;
using Domain.Entities.OneTimeFileLink;
using MediatR;

namespace Application.OneTimeFileLinks.GetFile;

public record GetFileByLinkQuery(OneTimeFileLinkId Id) : IRequest<FileResponse>;