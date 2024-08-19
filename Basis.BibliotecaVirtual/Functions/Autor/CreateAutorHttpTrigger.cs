using Basis.BibliotecaVirtual.Application.Commands.Autor;
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

namespace Basis.BibliotecaVirtual.Functions.Autor;

public class CreateAutorHttpTrigger(IMediator _mediator)
{
    [FunctionName("CreateAutorHttpTrigger")]
    [OpenApiOperation(operationId: "CreateAutorHttpTrigger", tags: ["Autor"])]
    [OpenApiRequestBody("application/json", typeof(CreateAutorCommand))]
    [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(ApiResponse<int>), Description = "The OK response")]
    public async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Function, "post", Route = "autor")] HttpRequest req)
    {
        var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
        var command = JsonConvert.DeserializeObject<CreateAutorCommand>(requestBody);
        var result = await _mediator.Send(command);

        return new OkObjectResult(result);
    }

}

