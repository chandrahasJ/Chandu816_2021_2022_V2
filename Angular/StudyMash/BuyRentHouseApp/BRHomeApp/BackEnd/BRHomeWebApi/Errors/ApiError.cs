using System.Text.Json;

namespace BRHomeWebApi.Errors
{
    public class ApiError
    {
        public ApiError()
        {
            
        }

        public ApiError(int errorCode, string errorMessage, string errorDetails = null)
        {
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
            ErrorDetails = errorDetails;
        }

        public ApiError(int errorCode, string errorDetails)
        {
            this.ErrorCode = errorCode;
            this.ErrorDetails = errorDetails;

        }
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorDetails { get; set; }

        public override string ToString()
        {
            var options = new JsonSerializerOptions(){
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            return JsonSerializer.Serialize(this, options);
        }
    }
}