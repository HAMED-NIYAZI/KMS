namespace KMS.Domain
{
#nullable disable
    public class DateText 
    {
        public Guid Id { get; set; }
        public int SortingNumber { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateTextValue { get; set; }
        public Form Form { get; set; }
        public Guid FormId { get; set; }

    }
}
