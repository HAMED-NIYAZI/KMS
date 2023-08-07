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

        public bool Add(OrganizationDto organizationDto)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Delete(string name)
        {
            throw new NotImplementedException();
        }

        public OrganizationDto Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public OrganizationDto Get(string name)
        {
            throw new NotImplementedException();
        }

        public List<OrganizationDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(OrganizationDto organizationDto)
        {
            throw new NotImplementedException();
        }
    }
}
