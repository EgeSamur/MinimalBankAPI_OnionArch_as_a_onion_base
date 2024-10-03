using System.Text.Json;

namespace MinimalBankAPI_OnionArch.Application.Common.CCC.Exceptions
{
    public class ExceptionModel
    {
        public IEnumerable<string> Errors { get; set; }
        public IEnumerable<string> Messages { get; set; }
        public int StatusCode { get; set; }
        public string Title { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            }); ;
        }
    }
}
