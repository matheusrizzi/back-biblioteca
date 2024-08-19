using Basis.BibliotecaVirtual.Application.Commands.Autor;
using Basis.BibliotecaVirtual.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.OpenApi.Models;
using System.Net;
using System.Threading.Tasks;

namespace Basis.BibliotecaVirtual.Functions.Autor
{
    public class DeleteAutorHttpTrigger(IMediator _mediator)
    {

        [FunctionName("DeleteAutorHttpTrigger")]
        [OpenApiOperation(operationId: "DeleteAutorHttpTrigger", tags: ["Autor"])]
        [OpenApiParameter(name: "id", In = ParameterLocation.Path, Required = true, Type = typeof(int), Description = "Código de identificação do autor.")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(ApiResponse<bool>), Description = "The OK response")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "delete", Route = "autor/{id}")] HttpRequest req, int id)
        {
            var isDeleted = await _mediator.Send(new DeleteAutorCommand() { CodAu = id });
            return new OkObjectResult(isDeleted);
        }
    }
}

