using AutoMapper;
using KMS.Application.Dtos.OrganizationDto;
using KMS.Data.Repositories.Organization;
using KMS.Domain;

namespace KMS.Application.Services.OrganizationService
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IMapper _mapper;
        public OrganizationService(IOrganizationRepository organizationRepository, IMapper mapper)
        {
            _organizationRepository = organizationRepository;
            _mapper = mapper;
        }

        public Task<int> Add(Organization organization)
        {
            return _organizationRepository.Add(organization);
        }

        public Task<int> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(string name)
        {
            throw new NotImplementedException();
        }

        public Task<Organization> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Organization> Get(string name)
        {
            throw new NotImplementedException();
        }

        public Task<List<Organization>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<Organization>> GetAll(int page, int pageCount)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(Organization organization)
        {
            throw new NotImplementedException();
        }
    }
}
