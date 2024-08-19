using Basis.BibliotecaVirtual.Application.Commands.Assunto;
using Basis.BibliotecaVirtual.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace Basis.BibliotecaVirtual.Functions.Assunto;

public class UpdateAssuntoHttpTrigger
{
    private readonly IMediator _mediator;

    public UpdateAssuntoHttpTrigger(IMediator mediator)
    {
        _mediator = mediator;
    }

    [FunctionName("UpdateAssuntoHttpTrigger")]
    [OpenApiOperation(operationId: "UpdateAssuntoHttpTrigger", tags: new[] { "Assunto" })]
    [OpenApiRequestBody("application/json", typeof(UpdateAssuntoCommand))]
    [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(ApiResponse<bool>), Description = "The OK response")]
    public async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Function, "put", Route = "assunto")] HttpRequest req)
    {
        var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
        var command = JsonConvert.DeserializeObject<UpdateAssuntoCommand>(requestBody);
        var isUpdated = await _mediator.Send(command);
        return new OkObjectResult(isUpdated);
    }
}