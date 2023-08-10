namespace KMS.Domain
{
#nullable disable

    public class ShortTest
    {
        public Guid Id { get; set; }
        public int SortingNumber { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ShortTestValue { get; set; }

        public Form Form { get; set; }
        public Guid FormId { get; set; }
    }
}
