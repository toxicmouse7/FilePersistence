using Domain.Abstractions;
using Domain.Entities.OneTimeFileLink;
using MediatR;

namespace Application.OneTimeFileLinks.Remove;

public class RemoveOneTimeFileLinkCommandHandler : IRequestHandler<RemoveOneTimeFileLinkCommand>
{
    private readonly IOneTimeFileLinkRepository _oneTimeFileLinkRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RemoveOneTimeFileLinkCommandHandler(
        IOneTimeFileLinkRepository oneTimeFileLinkRepository,
        IUnitOfWork unitOfWork)
    {
        _oneTimeFileLinkRepository = oneTimeFileLinkRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(RemoveOneTimeFileLinkCommand request, CancellationToken cancellationToken)
    {
        var link = await _oneTimeFileLinkRepository.GetByIdAsync(request.Id);
        if (link is null)
        {
            throw new OneTimeFileLinkNotFoundException(request.Id);
        }
        
        _oneTimeFileLinkRepository.Remove(link);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}