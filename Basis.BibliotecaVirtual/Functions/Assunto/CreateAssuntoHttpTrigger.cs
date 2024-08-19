using Basis.BibliotecaVirtual.Application.Commands.Assunto;
using Basis.BibliotecaVirtual.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace Basis.BibliotecaVirtual.Functions.Assunto;

public class CreateAssuntoHttpTrigger(IMediator _mediator)
{
    [FunctionName("CreateAssuntoHttpTrigger")]
    [OpenApiOperation(operationId: "CreateAssuntoHttpTrigger", tags: ["Assunto"])]
    [OpenApiRequestBody("application/json", typeof(CreateAssuntoCommand))]
    [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(ApiResponse<int>), Description = "The OK response")]
    public async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Function, "post", Route = "assunto")] HttpRequest req, ILogger logger)
    {

        logger.LogInformation("C# HTTP trigger function processed a request.");

        var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
        var command = JsonConvert.DeserializeObject<CreateAssuntoCommand>(requestBody);
        var result = await _mediator.Send(command);

        return new OkObjectResult(result);
    }
}