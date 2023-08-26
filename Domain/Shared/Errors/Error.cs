namespace Domain.Shared.Errors;

public class Error
{
    public string Code { get; set; }
    public string Message { get; set; }

    public Error(string message, string code)
    {
        Message = message;
        Code = code;
    }
}
