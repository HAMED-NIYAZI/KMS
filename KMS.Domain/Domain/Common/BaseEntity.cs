namespace KMS.Domain
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
