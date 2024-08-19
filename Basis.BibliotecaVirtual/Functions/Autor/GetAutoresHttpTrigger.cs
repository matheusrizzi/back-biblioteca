using Basis.BibliotecaVirtual.Application.Queries.Autor;
using Basis.BibliotecaVirtual.Application.Responses;
using Basis.BibliotecaVirtual.Application.Responses.Autor;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.OpenApi.Models;
using System.Net;
using System.Threading.Tasks;

namespace Basis.BibliotecaVirtual.Functions.Autor;

public class GetAutoresHttpTrigger(IMediator _mediator)
{
    [FunctionName("GetAutoresHttpTrigger")]
    [OpenApiOperation(operationId: "GetAutoresHttpTrigger", tags: ["Autor"])]
    [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(ResponseEnumerable<GetAutoresQueryResponse>), Description = "The OK response")]
    public async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = "autores")] HttpRequest req)
    {
        var query = new GetAutoresQuery();
        var result = await _mediator.Send(query);

        return new OkObjectResult(result);
    }
}