using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class ResponseResultDTO
    {
        public int StatusCode { get; set; }
        public string? Result { get; set; }
        public object? Data { get; set; }

        public static ResponseResultDTO Ok(object? data = null)
        {
            return new ResponseResultDTO
            {
                StatusCode = 200,
                Result = "Ok Result",
                Data = data
            };
        }

        public static ResponseResultDTO NotFound(object? data = null)
        {
            return new ResponseResultDTO
            {
                StatusCode = 404,
                Result = "Not Found Result",
                Data = data
            };
        }
        public static ResponseResultDTO BadRequest(object? data = null)
        {
            return new ResponseResultDTO
            {
                StatusCode = 400,
                Result = "Bad Request Result",
                Data = data
            };
        }

    }
}
