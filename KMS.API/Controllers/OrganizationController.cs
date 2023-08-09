using KMS.Application.Dtos.OrganizationDto;
using KMS.Application.Services.OrganizationService;
using KMS.Api.ViewModel.Organization;
using Microsoft.AspNetCore.Mvc;
using KMS.Data.Repositories.Organization;
using AutoMapper;
using KMS.Domain;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KMS.Api.Controllers
{
    public class OrganizationController : KmsBaseController
    {
        private readonly IOrganizationService organizationService;
        private readonly IMapper mapper;
        public OrganizationController(IOrganizationService organizationService, IMapper mapper)
        {
            this.organizationService = organizationService;
            this.mapper = mapper;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()//getall
        {
            var res = await organizationService.GetAll();
            return res == null ? NotFound() : Ok(res);

        }

        [HttpGet("GetPage")]
        public async Task<IActionResult> GetPage(int PageNumber = 1, int RowsOfPage = 10, string SortingCol = "Id", string SortType = "ASC")
        {
            var res = await organizationService.GetPage(PageNumber, RowsOfPage, SortingCol, SortType);
            return res == null ? NotFound() : Ok(res);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetByIdAsync(string id)//get
        {
            if (Guid.TryParse(id, out Guid result))
            {
                var res = mapper.Map<OrganizationDto>(await organizationService.Get(result));
                return res == null ? NotFound() : Ok(res);
            }
            return NotFound();
        }

        [HttpGet("GetByTitle/{title}")]
        public async Task<IActionResult> GetByTitle(string title)//get
        {
            if (!(string.IsNullOrEmpty(title) || string.IsNullOrWhiteSpace(title)))
            {
                var res = await organizationService.Get(title);
                return res == null ? NotFound() : Ok(res);
            }
            return NotFound();
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] OrganizationSaveViewModel organViewmodel)//create
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _ = Guid.TryParse(organViewmodel.ParentId.ToString(), out Guid result);
                    var dto = new OrganizationDto()
                    {
                        Id = Guid.NewGuid(),
                        SortingNumber = organViewmodel.SortingNumber,
                        PersianTitle = organViewmodel.PersianTitle,
                        ParentId = result == Guid.Empty ? null : result,
                    };
                    var res = await organizationService.Add(dto);
                    return res == 1 ? Ok(res) : BadRequest();
                }
                return BadRequest("ModelState inValid");
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] OrganizationDto organizationDto)//update
        {

            if (ModelState.IsValid)
            {
                var res = await organizationService.Update(organizationDto);

                return res == 1 ? Ok(res) : BadRequest();
            }

            return BadRequest("ModelState inValid");
        }

        #region Delete
        [HttpDelete("DeleteById/{id}")]
        public async Task<IActionResult> DeleteById(string id)
        {
            if (Guid.TryParse(id, out Guid result))
            {
                var res = await organizationService.Delete(result);
                return res == 1 ? Ok(res) : BadRequest();
            }
            return BadRequest("id is not Guid Type");
        }

        [HttpDelete("DeleteByName/{name}")]
        public async Task<IActionResult> DeleteByName(string name)
        {
            if (!(string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name)))
            {
                var res = await organizationService.Delete(name);
                return res == 1 ? Ok(res) : BadRequest();
            }
            return BadRequest("name is not a valid string Type");
        }
        #endregion Delete
    }
}
