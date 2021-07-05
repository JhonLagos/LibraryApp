using System.Collections.Generic;
using System.Net;
using System.Text.Json.Serialization;

namespace LibraryAppBackend.Transversal.Response
{
    public class ResultWrapper
    {
        [JsonIgnore]
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
        public string Message { get; set; } = string.Empty;
        public List<ErrorWrapper> Errors { get; set; }

        public ResultWrapper()
        {
        }

        public ResultWrapper(string message)
        {
            Message = message;
        }

        public ResultWrapper(HttpStatusCode statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }
    }

    public class ResultWrapper<T> : ResultWrapper where T : class
    {
        public T Result { get; set; }
    }
}
