using Domain.Abstractions;
using Domain.Entities.File;
using MediatR;
using File = Domain.Entities.File.File;

namespace Application.Files.Upload;

public class UploadFileCommandHandler : IRequestHandler<UploadFileCommand>
{
    private readonly IFileRepository _fileRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UploadFileCommandHandler(IFileRepository fileRepository, IUnitOfWork unitOfWork)
    {
        _fileRepository = fileRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UploadFileCommand request, CancellationToken cancellationToken)
    {
        var file = new File(new FileId(Guid.NewGuid()), request.Name, request.Content);

        await _fileRepository.AddAsync(file);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}