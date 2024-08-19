using Basis.BibliotecaVirtual.Application.Queries.FormaCompra;
using Basis.BibliotecaVirtual.Application.Responses;
using Basis.BibliotecaVirtual.Application.Responses.FormaCompra;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.OpenApi.Models;
using System.Net;
using System.Threading.Tasks;

namespace Basis.BibliotecaVirtual.Functions.FormaCompra;

public class GetFormasCompraHttpTrigger(IMediator _mediator)
{

    [FunctionName("GetFormasCompraHttpTrigger")]
    [OpenApiOperation(operationId: "GetFormasCompraHttpTrigger", tags: new[] { "FormaCompra" })]
    [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(ResponseEnumerable<GetFormaCompraResponse>), Description = "The OK response")]
    public async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = "forma-compra")] HttpRequest req)
    {
        var result = await _mediator.Send(new GetAllFormaCompraQuery());
        return new OkObjectResult(result);
    }
}

