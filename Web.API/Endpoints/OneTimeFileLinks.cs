using Application.OneTimeFileLinks.Create;
using Application.OneTimeFileLinks.GetFile;
using Application.OneTimeFileLinks.Remove;
using Carter;
using Domain.Entities.File;
using Domain.Entities.OneTimeFileLink;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using FileNotFoundException = Domain.Entities.File.FileNotFoundException;

namespace Web.API.Endpoints;

public class OneTimeFileLinks : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("oneTimeFileLinks");

        group.MapPost("{id:guid}", async (Guid id, ISender sender) =>
        {
            var command = new CreateOneTimeFileLinkCommand(new FileId(id));
            try
            {
                var link = await sender.Send(command);
                return Results.Ok(link.Id);
            }
            catch (FileNotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
            
        }).WithSummary("Create one time link for the file");

        group.MapPost("download/{id:guid}", async (Guid id, ISender sender) =>
        {
            var linkId = new OneTimeFileLinkId(id);

            try
            {
                var query = new GetFileByLinkQuery(linkId);
                var fileResponse = await sender.Send(query);

                var command = new RemoveOneTimeFileLinkCommand(linkId);
                await sender.Send(command);

                return Results.File(fileResponse.Content, null, fileResponse.Name);
            }
            catch (FileNotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
            catch (OneTimeFileLinkNotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
            
        }).WithSummary("Download file by one time link");

        group.WithTags("OneTimeFileLinks").WithOpenApi();
    }
}