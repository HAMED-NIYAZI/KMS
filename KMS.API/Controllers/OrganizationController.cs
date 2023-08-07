using KMS.Application.Dtos.OrganizationDto;
using KMS.Application.Services.OrganizationService;
using KMS.Api.ViewModel.Organization;
using Microsoft.AspNetCore.Mvc;
using KMS.Data.Repositories.Organization;
using AutoMapper;
using KMS.Domain;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KMS.Api.Controllers
{
    public class OrganizationController : KmsBaseController
    {
        private readonly IOrganizationService _organizationService;
        private readonly IOrganizationRepository organizationRepository;
        private readonly IMapper mapper;
        public OrganizationController(IOrganizationService organizationService, IOrganizationRepository organizationRepository, IMapper mapper)
        {
            _organizationService = organizationService;
            this.organizationRepository = organizationRepository;
            this.mapper = mapper;
        }

        //[HttpGet("GetAll")]
        //public List<OrganizationDto> GetAll()//getall
        //{
        //    return _organizationService.GetAll();
        //}


        //[HttpGet("GetAll_SP")]
        //public List<OrganizationDto> GetAll_SP()
        //{
        //    var data = organizationRepository.GetAll();
        //    return mapper.Map<List<OrganizationDto>>(data);
        //}

        //[HttpGet("Get/{id}")]
        //public OrganizationDto Get(string id)//get
        //{
        //    var data = _organizationService.Get(Guid.Parse(id));
        //    return data;
        //}

        //[HttpGet("Get_SP/{id}")]
        //public OrganizationDto Get_SP(string id)//get
        //{
        //    var data = organizationRepository.Get(Guid.Parse(id));
        //    return mapper.Map< OrganizationDto>(data);
        //}


        //[HttpGet("GetByTitle/{title}")]
        //public OrganizationDto GetByTitle(string title)//get
        //{
        //    var data = _organizationService.Get(title);
        //    return data;
        //}

        [HttpPost]
        public async Task<bool> Post([FromBody] OrganizationSaveViewModel organ)//create
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Guid.TryParse(organ.ParentId.ToString(), out Guid result);
                    var domain = new Organization()
                    {
                        Id = Guid.NewGuid(),
                        SortingNumber = organ.SortingNumber,
                        PersianTitle = organ.PersianTitle,
                        ParentId = result == Guid.Empty ? null : result,
                    };
                    var res = await _organizationService.Add(domain);
                    return res==1 ?  true :false;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }




        //[HttpPut]
        //public void Put([FromBody] OrganizationDto organizationDto)//update
        //{
        //    _organizationService.Update(organizationDto);
        //}

        //[HttpDelete("{id}")]
        //public void Delete(string id)//
        //{
        //    _organizationService.Delete(Guid.Parse(id));
        //}

        //[HttpPatch]
        //public void Patch([FromBody] OrganizationDto organizationDto)//
        //{
        //    _organizationService.Update(organizationDto);
        //}
    }
}
