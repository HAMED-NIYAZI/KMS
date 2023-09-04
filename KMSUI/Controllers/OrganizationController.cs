using KMS.Application.Dtos.OrganizationDto;
using KMS.Application.Services.OrganizationService;
using KMSUI.ViewModels.Organization;
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

        public async Task<IActionResult> OrganizationCreate()
        {
            var organizationTree = await organizationService.GetOrganizationTree();
            ViewBag.OrganizationTree = organizationTree;
            return View();
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(OrganizationAddViewModel org)
        {
            //validation
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(OrganizationCreate));
            }


            OrganizationDto dto = new OrganizationDto
            {
                Id = Guid.NewGuid(),
                PersianTitle = org.PersianTitle,
                SortingNumber = org.SortingNumber
            };
            if (org.ParentId != null && org.ParentId != Guid.Empty ) { dto.ParentId = org.ParentId; }


            await organizationService.Add(dto);


            return RedirectToAction(nameof(OrganizationCreate));
        }



        public async Task<IActionResult> OrganizationEdit()
        {
            var organizationTree = await organizationService.GetOrganizationTree();
            ViewBag.OrganizationTree = organizationTree;
            return View();
        }
    }
}
