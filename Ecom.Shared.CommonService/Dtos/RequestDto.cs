namespace Ecom.Web.Models
{
    public class RequestDto
    {
        public APIMethod APIType { get; set; } = APIMethod.GET;
        public string Url { get; set; }
        public object Data { get; set; }
        public string AccessToken { get; set; }
    }
    public enum APIMethod
    {
        GET,
        POST,
        PUT,
        DELETE
    }
}
