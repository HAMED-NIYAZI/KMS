 
namespace KMS.Domain.Dto.Response;

public class ResponseModel
{
    public Result Result { get; set; }
    public string? Message { get; set; }
    public object? Data { get; set; }
    public short StatusCode { get; set; }

    public ResponseModel()
    {
    }

    public ResponseModel(Result result, string? message, object? data, short statusCode)
    {
        Result = result;
        Message = message;
        Data = data;
        StatusCode = statusCode;
    }

}

public enum Result
{
    Success=0,
    Failed=1,
    IsExists=2,
    ServerError=3,
    ExeptionError=4,
    NotFound=5
}

public static class ApiResponse
{
    public static ResponseModel Response(object? Data)
    {
        return Data is null ?
                new ResponseModel { Data = null, Message = "دیتا یافت نشد", Result = Result.NotFound, StatusCode = 404 }
                  :
                  new ResponseModel { Data = Data, Message = "دیتا یافت شد", Result = Result.Success, StatusCode = 200 }
               ;
    }

    public static ResponseModel Response(string msg = "خطای پیش بینی نشده")
    {
        return new ResponseModel { Data = null, Message = msg, Result = Result.ExeptionError, StatusCode = 500 };
    }
}
