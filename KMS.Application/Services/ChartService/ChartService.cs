using AutoMapper;
using KMS.Data.Repositories.Charts;
using KMS.Domain;
using KMS.Domain.Dto.ChartDto;

namespace KMS.Application.Services.ChartService
{
    public class ChartService : IChartService
    {
        private readonly IChartRepository ChartRepository;
        private readonly IMapper mapper;
        public ChartService(IChartRepository ChartRepository, IMapper mapper)
        {
            this.ChartRepository = ChartRepository;
            this.mapper = mapper;
        }

        public Task<int> Add(ChartDto Chart)
        {
            return ChartRepository.Add(mapper.Map<Chart>(Chart));
        }

        public Task<int> Delete(Guid id)
        {
            return ChartRepository.Delete(id);
        }

        public async Task<int> Delete(string name)
        {
            return await ChartRepository.Delete(name);
        }

        public async Task<ChartDto> Get(Guid id)
        {
            return mapper.Map<ChartDto>(await ChartRepository.Get(id));
        }

        public async Task<ChartDto> Get(string name)
        {
            return mapper.Map<ChartDto>(await ChartRepository.Get(name));
        }

        public async Task<List<ChartDto>> GetAll()
        {
            return mapper.Map<List<ChartDto>>(await ChartRepository.GetAll());
        }

        public async Task<List<ChartTree>> GetChartTree()
        {
            var data = await ChartRepository.GetAll();
            var roots = data.Where(d => d.ParentId == null).ToList();
            var datatemp = data.ToList();
            datatemp = datatemp.Where(d => d.ParentId != null).ToList();


            var listTree = new List<ChartTree>();

            foreach (var root in roots)
            {
                var mappedroot = mapper.Map<ChartTree>(root);
                var children = mapper.Map<List<ChartTree>>(datatemp.Where(d => d.ParentId == root.Id).ToList());
                listTree.Add(mappedroot);
                AddChildren(mappedroot, children);
            }


            List<ChartTree> AddChildren(ChartTree mappedroot, List<ChartTree> children)
            {

                children.ForEach(e => mappedroot.Children.Add(e));

                foreach (var item in children)
                {
                    var mappedrootinside = mapper.Map<ChartTree>(item);
                    var childreninside = mapper.Map<List<ChartTree>>(datatemp.Where(d => d.ParentId == item.Id).ToList());

                    AddChildren(mappedrootinside, childreninside);
                }
                return listTree;
            }




            return listTree;
        }



        public async Task<List<ChartDto>> GetPage(int PageNumber = 1, int RowsOfPage = 10, string SortingCol = "Id", string SortType = "ASC")
        {
            return mapper.Map<List<ChartDto>>(await ChartRepository.GetPage(PageNumber, RowsOfPage, SortingCol, SortType));
        }

        public async Task<int> Update(ChartDto ChartDto)
        {
            return await ChartRepository.Update(mapper.Map<Chart>(ChartDto));
        }
    }
}
