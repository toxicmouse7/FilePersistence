using Domain.Abstractions;
using Domain.Entities;
using Domain.Entities.OneTimeFileLink;
using MediatR;

namespace Application.OneTimeFileLinks.Create;

public class CreateOneTimeFileLinkCommandHandler 
    : IRequestHandler<CreateOneTimeFileLinkCommand, OneTimeFileLinkResponse>
{
    private readonly IOneTimeFileLinkRepository _oneTimeFileLinkRepository;
    private readonly IFileRepository _fileRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateOneTimeFileLinkCommandHandler(
        IOneTimeFileLinkRepository oneTimeFileLinkRepository,
        IFileRepository fileRepository,
        IUnitOfWork unitOfWork)
    {
        _oneTimeFileLinkRepository = oneTimeFileLinkRepository;
        _unitOfWork = unitOfWork;
        _fileRepository = fileRepository;
    }

    public async Task<OneTimeFileLinkResponse> Handle(CreateOneTimeFileLinkCommand request, CancellationToken cancellationToken)
    {
        var file = await _fileRepository.GetByIdAsync(request.Id);

        if (file is null)
        {
            throw new NotImplementedException();
        }
        
        var link = new OneTimeFileLink(new OneTimeFileLinkId(Guid.NewGuid()), file.Id);

        await _oneTimeFileLinkRepository.AddAsync(link);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new OneTimeFileLinkResponse(link.Id);
    }
}