using Basis.BibliotecaVirtual.Application.Commands.Livro;
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

namespace Basis.BibliotecaVirtual.Functions.Livro;

public class UpdateLivroHttpTrigger(IMediator _mediator)
{

    [FunctionName("UpdateLivroHttpTrigger")]
    [OpenApiOperation(operationId: "UpdateLivroHttpTrigger", tags: new[] { "Livro" })]
    [OpenApiRequestBody("application/json", typeof(UpdateLivroCommand))]
    [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(ApiResponse<bool>), Description = "The OK response")]
    public async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Function, "put", Route = "livro")] HttpRequest req)
    {
        var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
        var command = JsonConvert.DeserializeObject<UpdateLivroCommand>(requestBody);
        var isUpdated = await _mediator.Send(command);
        return new OkObjectResult(isUpdated);
    }
}

