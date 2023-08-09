namespace KMS.Domain
{
#nullable disable
    public class Combo
    {
        public Guid Id { get; set; }
        public int SortingNumber { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid ComboDetailId { get; set; }
        public ICollection<ComboDetail> ComboDetails { get; set; }
        public Form Form { get; set; }
        public Guid FormId { get; set; }

    }
}
