namespace KMS.Domain
{
    public class LongText
    {
        public Guid Id { get; set; }
        public int SortingNumber { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string LongTextValue { get; set; }

        public Form Form { get; set; }
        public Guid FormId { get; set; }
    }
}
