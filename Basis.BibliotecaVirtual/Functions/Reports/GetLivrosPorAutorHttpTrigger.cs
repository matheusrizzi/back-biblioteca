using Basis.BibliotecaVirtual.Application.Queries.Reports;
using Basis.BibliotecaVirtual.Application.Responses;
using Basis.BibliotecaVirtual.Application.Responses.Reports;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.OpenApi.Models;
using System.Net;
using System.Threading.Tasks;

namespace Basis.BibliotecaVirtual.Functions.Reports;

public class GetLivrosPorAutorHttpTrigger(IMediator _mediator)
{
    [FunctionName("GetLivrosPorAutorHttpTrigger")]
    [OpenApiOperation(operationId: "GetLivrosPorAutorHttpTrigger", tags: new[] { "Reports" })]
    [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(ResponseEnumerable<GetLivrosPorAutorResponse>), Description = "The OK response")]
    public async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = "report/livros-por-autor")] HttpRequest req)
    {
        var query = new GetLivrosPorAutorQuery();
        var result = await _mediator.Send(query);
        return new OkObjectResult(result);
    }
}

