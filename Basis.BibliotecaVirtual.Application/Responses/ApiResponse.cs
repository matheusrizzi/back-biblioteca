using MediatR;

namespace Basis.BibliotecaVirtual.Application.Responses;

public interface IResponse<out TResponse>
{
    TResponse Result { get; }
    ErrorResult Error { get; }
    bool IsSuccess { get; }
}

public class ErrorResult
{
    public string Message { get; set; }
}

public class ApiResponse<TResponse> : IResponse<TResponse>, INotification
{
    public TResponse Result { get; set; }

    public ErrorResult Error { get; set; }

    public bool IsSuccess => Error != null ? false : true;
}