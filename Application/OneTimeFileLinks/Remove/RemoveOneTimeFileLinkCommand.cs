using Domain.Entities.OneTimeFileLink;
using MediatR;

namespace Application.OneTimeFileLinks.Remove;

public record RemoveOneTimeFileLinkCommand(OneTimeFileLinkId Id) : IRequest;