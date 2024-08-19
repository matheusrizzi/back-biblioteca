using Basis.BibliotecaVirtual.Application.Queries.Assunto;
using Basis.BibliotecaVirtual.Application.Responses;
using Basis.BibliotecaVirtual.Application.Responses.Assunto;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System.Net;
using System.Threading.Tasks;

namespace Basis.BibliotecaVirtual.Functions.Assunto;

public class GetAssuntosHttpTrigger
{
    private IMediator _mediator;

    public GetAssuntosHttpTrigger(IMediator mediator) => _mediator = mediator;


    [FunctionName("GetAssuntosHttpTrigger")]
    [OpenApiOperation(operationId: "GetAssuntosHttpTrigger", tags: new[] { "Assunto" })]
    [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(ResponseEnumerable<GetAssuntosQueryResponse>), Description = "The OK response")]
    public async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = "assuntos")] HttpRequest req, ILogger logger)
    {
        logger.LogInformation("C# HTTP trigger function processed a request.");

        var query = new Application.Queries.Assunto.GetAssuntosQuery();
        var result = await _mediator.Send(query);

        return new OkObjectResult(result);
    }
}