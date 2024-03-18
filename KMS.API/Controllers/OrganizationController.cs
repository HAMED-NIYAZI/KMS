using KMS.Application.Services.OrganizationService;
using Microsoft.AspNetCore.Mvc;
using KMS.Data.Repositories.Organization;
using AutoMapper;
using KMS.Domain;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using static KMS.Domain.Enums;
using KMS.Domain.Dto.Organization;
using KMS.Domain.Dto.Response;


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

        [HttpPost("Add")]
        public async Task<IActionResult> Add(OrganizationInsertViewModel organViewmodel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Guid.TryParse(organViewmodel.ParentId.ToString(), out Guid result);
                    var dto = new OrganizationDto()
                    {
                        Id = Guid.NewGuid(),
                        SortingNumber = organViewmodel.SortingNumber,
                        PersianTitle = organViewmodel.PersianTitle,
                        ParentId = result == Guid.Empty ? null : result,
                    };
                    var res = await organizationService.Add(dto);
                    return Ok(ApiResponse.Response(Data: res));
                }
                return Ok(ApiResponse.Response(msg: "Validation Error :ModelState Is Not Valid"));
            }
            catch (Exception ex)
            {
                return Ok(ApiResponse.Response(ex.Message));
            }
        }

        [HttpGet("Count")]
        public async Task<IActionResult> Count()
        {
            try
            {
                    var res = await organizationService.Count();
                    return Ok(ApiResponse.Response(Data: res));
             }
            catch (Exception ex)
            {
                return Ok(ApiResponse.Response(ex.Message));
            }
        }
       [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()//getall
        {
            try
            {
                var res = await organizationService.GetAll();
                return Ok(ApiResponse.Response(res));
            }
            catch (Exception ex)
            {
                return Ok(ApiResponse.Response(ex.Message));
            }
        }

        [HttpGet("GetPage")]
        public async Task<IActionResult> GetPage(int PageNumber = 1, int RowsOfPage = 10, string SortingCol = "Id", string SortType = "ASC")
        {
            try
            {
                var res = await organizationService.GetPage(PageNumber, RowsOfPage, SortingCol, SortType);
                return Ok(ApiResponse.Response(res));
            }
            catch (Exception ex)
            {
                return Ok(ApiResponse.Response(ex.Message));
            }
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetByIdAsync(string id)
        {
            try
            {
                if (Guid.TryParse(id, out Guid result))
                {
                    var res = mapper.Map<OrganizationDto>(await organizationService.Get(result));
                    return Ok(ApiResponse.Response(res));
                }
                return Ok(ApiResponse.Response(Data: null));
            }
            catch (Exception ex)
            {
                return Ok(ApiResponse.Response(ex.Message));
            }
        }

        [HttpGet("GetByTitle/{title}")]
        public async Task<IActionResult> GetByTitle(string title)
        {
            try
            {
                if (!(string.IsNullOrEmpty(title) || string.IsNullOrWhiteSpace(title)))
                {
                    var res = await organizationService.Get(title);
                    return Ok(ApiResponse.Response(Data: res));
                }
                return Ok(ApiResponse.Response(Data: null));
            }
            catch (Exception ex)
            {
                return Ok(ApiResponse.Response(ex.Message));
            }
        }



        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] OrganizationDto organizationDto)//update
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var res = await organizationService.Update(organizationDto);

                    return Ok(ApiResponse.Response(res));
                }
                return Ok(ApiResponse.Response(msg: "ModelState.IsValid"));
            }
            catch (Exception ex)
            {
                return Ok(ApiResponse.Response(ex.Message));
            }
        }

        #region Delete
        [HttpDelete("DeleteById/{id}")]
        public async Task<IActionResult> DeleteById(string id)
        {
            try
            {
                if (Guid.TryParse(id, out Guid result))
                {
                    var res = await organizationService.Delete(result);
                    return Ok(ApiResponse.Response(res));
                }

                return Ok(ApiResponse.Response(msg: "id is not Guid Type"));
            }
            catch (Exception ex)
            {
                return Ok(ApiResponse.Response(ex.Message));
            }
        }

        [HttpDelete("DeleteByName/{name}")]
        public async Task<IActionResult> DeleteByName(string name)
        {
             try
            {
                if (!(string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name)))
                {
                    var res = await organizationService.Delete(name);
                    return Ok(ApiResponse.Response(res));
                }

                return Ok(ApiResponse.Response(msg: "name is not a valid string Type"));
            }
            catch (Exception ex)
            {
                return Ok(ApiResponse.Response(ex.Message));
            }
        }
        #endregion Delete
    }
}
