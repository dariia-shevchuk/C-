using Newtonsoft.Json;

namespace MyFirstWebApi.Exceptions
{
    public class ErrorDetail
    {
            public ErrorDetail(string message, string code)
            {
                Message = message;
                Code = code;
            }

            public string Message { get; set; }

            public string Code { get; set; }

            public override string ToString()
            {
                return JsonConvert.SerializeObject(this);
            }
    }
}
