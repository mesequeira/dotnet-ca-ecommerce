using System.Net;

namespace Domain.Shared;

public class Response
{
    public object Content { get; set; }
    public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
    public string Message { get; set; }
}

public class Response<T>
{
    public T Content { get; set;  }
    public HttpStatusCode StatusCode { get; set; }
    public string Message { get; set; }
}
