using System.Net;

namespace Application.Common.Models.Response;

public class Response<T>
{
    public T Content { get; set; }
    public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
    public string Message { get; set; }
}
