using Microsoft.AspNetCore.Mvc;

namespace KMSUI.Controllers
{
    public class OrganizationController : Controller
    {
        public IActionResult OrganizationList()
        {
            return View();
        }


		public IActionResult OrganizationList2()
		{
			return View();
		}
	}
}
