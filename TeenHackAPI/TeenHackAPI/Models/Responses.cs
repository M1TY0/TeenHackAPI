using System.Net;
namespace TeenHackAPI.Models
{
    public  class Result
    {
        public int Id { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess => StatusCode == HttpStatusCode.OK;
    }
}
