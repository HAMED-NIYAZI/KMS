using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMS.Domain.Domain.Grade
{
    public class Grade:BaseEntity
    {
        public string? GradeName { get; set; }
        public int SortingNumber { get; set; } = 0;
    }
}
