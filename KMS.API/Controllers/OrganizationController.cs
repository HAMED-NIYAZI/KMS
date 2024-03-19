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

        #region Add
        /// <summary>
        ///  ادد سازمان مدل ورودی OrganizationInsertViewModel
        /// </summary>
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
        #endregion Add

        #region Get
        /// <summary>
        /// تعداد سازمان
        /// </summary>
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

        /// <summary>
        /// لیست تمامی سازمان ها را برمی گرداند   GetAll()
        /// </summary>
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
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
        [HttpGet("GetOrganizationTree")]
        public async Task<IActionResult> GetOrganizationTree()
        {
            try
            {
                 
                var res = await organizationService.GetOrganizationTree();
                return Ok(ApiResponse.Response(res));
            }
            catch (Exception ex)
            {
                return Ok(ApiResponse.Response(ex.Message));
            }
        }

        /// <summary>
        /// یک پیج از سازمان برمی گرداند 
        /// GetPage(int pageNumber = 1, int rowsOfPage = 10, string sortingCol = "Id", string sortType = "ASC")
        /// </summary>
        [HttpGet("GetPage")]
        public async Task<IActionResult> GetPage(int pageNumber = 1, int rowsOfPage = 10, string sortingCol = "Id", string sortType = "ASC")
        {
            try
            {
                var res = await organizationService.GetPage(pageNumber, rowsOfPage, sortingCol, sortType);
                return Ok(ApiResponse.Response(res));
            }
            catch (Exception ex)
            {
                return Ok(ApiResponse.Response(ex.Message));
            }
        }

        /// <summary>
        ///  GetById/{id}
        /// </summary>
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

        /// <summary>
        /// GetByTitle/{title}
        /// </summary>
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
        #endregion Get

        #region Update
        /// <summary>
        ///  Update(OrganizationDto organizationDto)
        /// </summary>
        [HttpPut("Update")]
        public async Task<IActionResult> Update(OrganizationDto organizationDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var res = await organizationService.Update(organizationDto);

                    return Ok(ApiResponse.Response(res));
                }
                return Ok(ApiResponse.Response(msg: "ModelState Is not Valid"));
            }
            catch (Exception ex)
            {
                return Ok(ApiResponse.Response(ex.Message));
            }
        }
        #endregion Update

        #region Delete
        /// <summary>
        /// DeleteById/{id}  DeleteById(string id)
        /// </summary>
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
        #endregion Delete
    }
}
