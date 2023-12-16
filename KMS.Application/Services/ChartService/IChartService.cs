using KMS.Application.Dtos.ChartDto;
using KMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMS.Application.Services.ChartService
{
#nullable enable

     
    public interface IChartService
    {
        Task<List<ChartDto>> GetAll();
        Task<List<ChartDto>> GetPage(int PageNumber = 1, int RowsOfPage = 10, string SortingCol = "Id", string SortType = "ASC");
        Task<ChartDto?> Get(Guid id);
        Task<ChartDto?> Get(string name);
        Task<int> Delete(Guid id);
        Task<int> Delete(string name);
        Task<int> Update(ChartDto Chart);
        Task<int> Add(ChartDto Chart);
		Task<List<ChartTree>?> GetChartTree();
 

	}
}
