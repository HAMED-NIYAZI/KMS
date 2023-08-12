using KMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace KMS.Application.Dtos.OrganizationDto
{
	public class OrganizationTree
	{
		public Guid Id { get; set; }
		public int SortingNumber { get; set; }
		public string PersianTitle { get; set; }
		public bool IsSelected { get; set; }
		public Guid? ParentId { get; set; }

		public ICollection<OrganizationTree> Children { get; set; }=new List<OrganizationTree>();


	}
}
