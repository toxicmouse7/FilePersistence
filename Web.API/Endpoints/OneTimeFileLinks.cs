using Application.OneTimeFileLinks.Create;
using Application.OneTimeFileLinks.GetFile;
using Application.OneTimeFileLinks.Remove;
using Carter;
using Domain.Entities.File;
using Domain.Entities.OneTimeFileLink;
using MediatR;

namespace Web.API.Endpoints;

public class OneTimeFileLinks : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("oneTimeFileLinks");

        group.MapPost("{id:guid}", async (Guid id, ISender sender) =>
        {
            var command = new CreateOneTimeFileLinkCommand(new FileId(id));
            var link = await sender.Send(command);
            return link.Id;
        }).WithSummary("Create one time link for the file");

        group.MapPost("download/{id:guid}", async (Guid id, ISender sender) =>
        {
            var linkId = new OneTimeFileLinkId(id);
            
            var query = new GetFileByLinkQuery(linkId);
            var fileResponse = await sender.Send(query);

            var command = new RemoveOneTimeFileLinkCommand(linkId);
            await sender.Send(command);
            
            return Results.File(fileResponse.Content, null, fileResponse.Name);
        }).WithSummary("Download file by one time link");

        group.WithTags("OneTimeFileLinks").WithOpenApi();
    }
}