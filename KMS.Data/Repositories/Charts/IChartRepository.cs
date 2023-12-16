using KMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMS.Data.Repositories.Charts
{
    public interface IChartRepository
    {
        Task<List<Chart>?> GetAll();
        Task<List<Chart>?> GetPage(int PageNumber = 1, int RowsOfPage = 10, string SortingCol = "Id", string SortType = "ASC");
        Task<Chart?> Get(Guid id);
        Task<Chart?> Get(string name);
        Task<int> Delete(Guid id);
        Task<int> Delete(string name);
        Task<int> Update(Chart chart);
        Task<int> Add(Chart chart);
        Task<int> Count();
    }
}
