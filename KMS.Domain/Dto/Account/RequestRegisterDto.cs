using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMS.Domain.Dto.Account
{
    public class RequestRegisterDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string CodeMeli { get; set; }
        public string PersonnelNumber { get; set; }
        public Guid ChartId { get; set; }
    }
}
