
namespace KMS.Application.Dtos.ChartDto
{
    public class ChartTree
    {
		public Guid Id { get; set; }
		public int SortingNumber { get; set; }
		public string PersianTitle { get; set; }
		public bool IsSelected { get; set; }
		public Guid? ParentId { get; set; }

		public ICollection<ChartTree> Children { get; set; }=new List<ChartTree>();


	}
}
