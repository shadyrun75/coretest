namespace CoreTest.Models.Common
{
    public class CommonResponse
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public Error? Error { get; set; }
        public CommonResponse(bool success = true, string? message = null, Error? error = null)
        {
            Success = success;
            Message = message;
            Error = error;
        }
    }

    public class CommonResponse<T>
        where T: class
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public Error? Error { get; set; }
        public T? Data { get; set; }

        public CommonResponse(bool success = true, string? message = null, Error? error = null) 
        {
            Success = success;
            Message = message;
            Error = error;
        }
        public CommonResponse(T data, bool success = true, string? message = null, Error? error = null) 
        { 
            Success = success;
            Message = message;
            Error = error;
            Data = data;
        }
    }

    public class CommonListResponse<T>
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public Error? Error { get; set; }
        public IEnumerable<T>? Data { get; set; }
        public long TotalCount { get; set; }        

        public CommonListResponse(bool success = true, string? message = null, Error? error = null)
        {
            Success = success;
            Message = message;
            Error = error;
        }

        public CommonListResponse(IEnumerable<T> data, bool success = true, string? message = null, Error? error = null)
        {
            Success = success;
            Message = message;
            Error = error;
            TotalCount = data?.Count() ?? 0;
            Data = data;
        }
    }
}
