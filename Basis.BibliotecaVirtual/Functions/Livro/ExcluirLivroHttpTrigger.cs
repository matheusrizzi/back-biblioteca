using Basis.BibliotecaVirtual.Application.Commands.Livro;
using Basis.BibliotecaVirtual.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.OpenApi.Models;
using System.Net;
using System.Threading.Tasks;

namespace Basis.BibliotecaVirtual.Functions.Livro;

public class ExcluirLivroHttpTrigger(IMediator _mediator)
{

    [FunctionName("ExcluirLivroHttpTrigger")]
    [OpenApiOperation(operationId: "ExcluirLivroHttpTrigger", tags: new[] { "Livro" })]
    [OpenApiParameter(name: "id", In = ParameterLocation.Path, Required = true, Type = typeof(int), Description = "Código de identificação do livro.")]
    [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(ApiResponse<bool>), Description = "The OK response")]
    public async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Function, "delete", Route = "livro/{id}")] HttpRequest req, int id)
    {
        var isDeleted = await _mediator.Send(new DeleteLivroCommand() { CodL = id });
        return new OkObjectResult(isDeleted);
    }
}