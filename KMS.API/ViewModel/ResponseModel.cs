﻿using Microsoft.AspNetCore.Mvc;

namespace KMS.API.ViewModel
{
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
            this.Result = result;
            this.Message = message;
            this.Data = data;
            this.StatusCode = statusCode;
        }


    }
    public enum Result
    {
        Success,
        Failed,
        IsExists,
        ServerError,
        ExeptionError,
        NotFound
    }

    public static class ApiResponse
    {
        public  static IActionResult Response(object? Data)
        {
            return (Data is null ?
                     (IActionResult)new ResponseModel { Data = null, Message = "دیتا یافت نشد", Result = Result.NotFound, StatusCode = 200 }
                      :
                     (IActionResult)new ResponseModel { Data = Data, Message = "دیتا یافت شد", Result = Result.Success, StatusCode = 200 }
                   );
        }

        public static IActionResult Response(string msg="خطای پیش بینی نشده")
        {
            return (IActionResult)new ResponseModel { Data = null, Message = msg, Result = Result.ExeptionError, StatusCode = 200 };
        }
    }
}
