using AutoMapper;
using KMS.Data.Repositories.Organization;
using KMS.Domain;
using KMS.Domain.Dto.Organization;
using System.Collections.Generic;

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

		public async Task<int> Add(OrganizationDto organization)
		{
			if (organization.ParentId is not null)
            {
                var organizationParent = await organizationRepository.Get((Guid)organization.ParentId);
                if (organizationParent is null) throw new System.Exception("ParentId is not valid");
            }

            return await organizationRepository.Add(mapper.Map<Organization>(organization));
		}

        public async Task<int> Count()
        {
			return await organizationRepository.Count();
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
			return mapper.Map<OrganizationDto>(await organizationRepository.Get(id));
		}

		public async Task<OrganizationDto> Get(string name)
		{
			return mapper.Map<OrganizationDto>(await organizationRepository.Get(name));
		}

		public async Task<List<OrganizationDto>> GetAll()
		{
			return mapper.Map<List<OrganizationDto>>(await organizationRepository.GetAll());
		}

		public async Task<List<OrganizationTree>> GetOrganizationTree()
		{
			var data = await organizationRepository.GetAll();
			var roots = data.Where(d => d.ParentId == null).ToList();
			var datatemp = data.ToList();
			datatemp = datatemp.Where(d => d.ParentId != null).ToList();


			var listTree = new List<OrganizationTree>();

			foreach (var root in roots)
			{
				var mappedroot = mapper.Map<OrganizationTree>(root);
				var children = mapper.Map<List<OrganizationTree>>(datatemp.Where(d => d.ParentId == root.Id).ToList());
				listTree.Add(mappedroot);
				AddChildren(mappedroot,children);
			}


			List<OrganizationTree> AddChildren(OrganizationTree mappedroot, List<OrganizationTree> children)
			{

				children.ForEach(e=> mappedroot.Children.Add(e));

                foreach (var item in children)
                {
					var mappedrootinside = mapper.Map<OrganizationTree>(item);
					var childreninside = mapper.Map<List<OrganizationTree>>(datatemp.Where(d => d.ParentId == item.Id).ToList());

					AddChildren(mappedrootinside, childreninside);
				}
                return listTree;
			}
 



			return listTree;
		}



		public async Task<List<OrganizationDto>> GetPage(int PageNumber = 1, int RowsOfPage = 10, string SortingCol = "Id", string SortType = "ASC")
		{
			return mapper.Map<List<OrganizationDto>>(await organizationRepository.GetPage(PageNumber, RowsOfPage, SortingCol, SortType));
		}

		public async Task<int> Update(OrganizationDto organizationDto)
		{
			return await organizationRepository.Update(mapper.Map<Organization>(organizationDto));
		}
	}
}
