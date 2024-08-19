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

public class GetFormaCompraByIdHttpTrigger(IMediator _mediator)
{

    [FunctionName("GetFormaCompraByIdHttpTrigger")]
    [OpenApiOperation(operationId: "GetFormaCompraByIdHttpTrigger", tags: new[] { "FormaCompra" })]
    [OpenApiParameter(name: "id", In = ParameterLocation.Path, Required = true, Type = typeof(string), Description = "The **Name** parameter")]
    [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(ApiResponse<GetFormaCompraResponse>), Description = "The OK response")]
    public async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = "forma-compra/{id}")] HttpRequest req, int id)
    {
        var query = new GetFormaCompraByIdQuery() { CodFo = id};
        var result = await _mediator.Send(query);
        return new OkObjectResult(result);
    }
}