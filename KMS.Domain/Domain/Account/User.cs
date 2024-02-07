namespace KMS.Domain
{
#nullable disable

    public class User : BaseEntity
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public bool ConfirmedPhone { get; set; }
        public string Email { get; set; }
        public bool ConfirmedEmail { get; set; }
        public string Address { get; set; }
        public string CodeMeli { get; set; }
        public string PersonnelNumber { get; set; }
        public string About { get; set; }
        public string PositionName { get; set; }
        public string PositionId { get; set; }
        public string ImagePath { get; set; }
        public Guid GradeId { get; set; }
        public Guid ChartId { get; set; }




        //#region navigation Properties
        //public Chart Chart { get; set; }

        //public ICollection<Knowledge> Knowledges { get; set; }

        //#endregion

    }
}
