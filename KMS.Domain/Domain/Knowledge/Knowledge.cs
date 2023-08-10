namespace KMS.Domain
{
#nullable disable

    public class Knowledge : BaseEntity
    {
        public int Code { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public float? FinalScore { get; set; }
        public Guid OwnerUserId { get; set; }
        public Guid KnowledgeFieldId { get; set; }
        public Guid FormId { get; set; }








      //  #region

      //  public Form Form { get; set;}
      //  public User User { get; set;}
      ////  public KnowledgeField KnowledgeField { get; set;}
 
      //  #endregion



    }
}
