using Domain.Entities.File;
using Domain.Entities.OneTimeFileLink;
using MediatR;

namespace Application.OneTimeFileLinks.Create;

public record CreateOneTimeFileLinkCommand(FileId Id) : IRequest<OneTimeFileLinkResponse>;

public record OneTimeFileLinkResponse(OneTimeFileLinkId Id);