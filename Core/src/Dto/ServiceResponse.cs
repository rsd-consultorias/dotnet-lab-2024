using Core.Model;

namespace Core.Dto;

public class ServiceResponse<T> where T : BaseModel
{
    public T? Value { get; private set; }
    public string Error { get; private set; }
    public bool Success { get; private set; }

    public ServiceResponse(T value)
    {
        Success = true;
        Value = value;
        Error = string.Empty;
    }

    public ServiceResponse(string error)
    {
        Success = false;
        Error = error;
    }
}