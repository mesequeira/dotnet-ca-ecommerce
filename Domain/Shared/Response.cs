using System.Net;

namespace Domain.Shared;

public class Response
{
    public object Content { get; set; }
    public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.InternalServerError;
    public string Message { get; set; }
}

public class Response<T>
{
    public T Content { get; set;  }
    public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.InternalServerError;
    public string Message { get; set; }
}
