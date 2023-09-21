using Application.Files.Get;
using Application.Files.List;
using Application.Files.Upload;
using Carter;
using Domain.Entities.File;
using MediatR;
using FileNotFoundException = Domain.Entities.File.FileNotFoundException;
using FileResponse = Application.Files.List.FileResponse;

namespace Web.API.Endpoints;

public class Files : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("files");

        group.MapPost("", async (IFormFile file, ISender sender) =>
        {
            using var ms = new MemoryStream();
            await file.CopyToAsync(ms);

            var uploadFileCommand = new UploadFileCommand(file.FileName, ms.ToArray());
            await sender.Send(uploadFileCommand);

            return Results.Ok();
        }).WithSummary("Upload file");

        group.MapGet("{id:guid}", async (Guid id, ISender sender) =>
        {
            var query = new GetFileQuery(new FileId(id));
            
            try
            {
                var fileResponse = await sender.Send(query);
                return Results.File(fileResponse.Content, null, fileResponse.Name);
            }
            catch (FileNotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
            
        }).WithSummary("Download file");
        
        group.MapGet("", async (ISender sender) =>
        {
            var files = await sender.Send(new ListFilesQuery());
            return Results.Ok(files);
        }).WithSummary("List files")
            .Produces<IEnumerable<FileResponse>>();

        group.WithTags("Files").WithOpenApi();
    }
}