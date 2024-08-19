using Basis.BibliotecaVirtual.Application.Queries.Livro;
using Basis.BibliotecaVirtual.Application.Responses;
using Basis.BibliotecaVirtual.Application.Responses.Livro;
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
public class GetLivrosHttpTrigger(IMediator _mediator)
{

    [FunctionName("GetLivrosHttpTrigger")]
    [OpenApiOperation(operationId: "GetLivrosHttpTrigger", tags: new[] { "Livro" })]
    [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(ResponseEnumerable<GetLivrosQueryResponse>), Description = "The OK response")]
    public async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = "livros")] HttpRequest req)
    {
        var query = new GetLivrosQuery();
        var result = await _mediator.Send(query);
        return new OkObjectResult(result);
    }
}