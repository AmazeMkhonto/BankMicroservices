using System.Net.Mime;
using System.Security.AccessControl;
using static BankServices.Utility.SD;

namespace BankServices.Models
{
    public class RequestDTO
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Url { get; set; }
        public object Data { get; set; }
        public string AccessToken { get; set; }

    }
}
    