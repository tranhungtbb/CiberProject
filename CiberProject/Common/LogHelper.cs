
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace PAKNAPI.Common
{
    public class LogHelper
    {
        public LogHelper()
        {
        }

        public string GetFullNameFromRequest(HttpContext httpContext)
        {
            return httpContext.User.Claims.FirstOrDefault(c => c.Type == "FullName")?.Value;
        }

        public string GetJwtIdFromRequest(HttpContext httpContext)
        {
            return httpContext.User.Claims.FirstOrDefault(c => c.Type == "jti")?.Value;
        }
    }

}
