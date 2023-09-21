using MediatR;

namespace Application.Files.Upload;

public sealed record UploadFileCommand(string Name, byte[] Content) : IRequest;