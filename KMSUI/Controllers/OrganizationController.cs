using KMS.Application.Services.OrganizationService;
using Microsoft.AspNetCore.Mvc;

namespace KMSUI.Controllers
{
    public class OrganizationController : Controller
    {
        private readonly IOrganizationService organizationService;

		public OrganizationController(IOrganizationService organizationService)
		{
			this.organizationService = organizationService;
		}

		public async Task<IActionResult> OrganizationList()
        {
			var organizationTree = await organizationService.GetOrganizationTree();
			ViewBag.OrganizationTree = organizationTree;
			return View();
        }


		public IActionResult OrganizationList2()
		{
			return View();
		}
	}
}
