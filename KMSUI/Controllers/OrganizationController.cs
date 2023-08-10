using Microsoft.AspNetCore.Mvc;

namespace KMSUI.Controllers
{
    public class OrganizationController : Controller
    {
        public IActionResult OrganizationList()
        {
            return View();
        }
    }
}
