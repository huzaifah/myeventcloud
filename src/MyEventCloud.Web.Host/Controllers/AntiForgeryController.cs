using Microsoft.AspNetCore.Antiforgery;
using MyEventCloud.Controllers;

namespace MyEventCloud.Web.Host.Controllers
{
    public class AntiForgeryController : MyEventCloudControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
