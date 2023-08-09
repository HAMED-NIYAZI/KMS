using AutoMapper;
using KMS.Application.Dtos.OrganizationDto;
using KMS.Data.Repositories.Organization;
using KMS.Domain;

namespace KMS.Application.Services.OrganizationService
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IOrganizationRepository organizationRepository;
        private readonly IMapper mapper;
        public OrganizationService(IOrganizationRepository organizationRepository, IMapper mapper)
        {
            this.organizationRepository = organizationRepository;
            this.mapper = mapper;
        }

        public Task<int> Add(OrganizationDto organization)
        {
            return organizationRepository.Add(mapper.Map<Organization>(organization));
        }

        public Task<int> Delete(Guid id)
        {
            return organizationRepository.Delete(id);
        }

        public async Task<int> Delete(string name)
        {
            return await organizationRepository.Delete(name);
        }

        public async Task<OrganizationDto> Get(Guid id)
        {
            return mapper.Map<OrganizationDto>( await organizationRepository.Get(id));
        }

        public async Task<OrganizationDto> Get(string name)
        {
            return mapper.Map<OrganizationDto>(await organizationRepository.Get(name));
        }

        public async Task<List<OrganizationDto>> GetAll()
        {
            return mapper.Map<List<OrganizationDto>>(await organizationRepository.GetAll());
        }

        public async Task<List<OrganizationDto>> GetPage(int PageNumber = 1, int RowsOfPage = 10, string SortingCol = "Id", string SortType = "ASC")
        {
            return mapper.Map<List<OrganizationDto>>(await organizationRepository.GetPage(PageNumber,RowsOfPage,SortingCol,SortType));
        }

        public async Task<int> Update(OrganizationDto organizationDto)
        {
            return  await organizationRepository.Update(mapper.Map<Organization>(organizationDto));
        }
    }
}
