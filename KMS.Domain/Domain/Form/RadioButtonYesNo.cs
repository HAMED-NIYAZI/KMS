namespace KMS.Domain
{
#nullable disable

    public class RadioButtonYesNo
    {
        public Guid Id { get; set; }
        public int SortingNumber { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool RadioButtonYesNoValue { get; set; }

        public Form Form { get; set; }
        public Guid FormId { get; set; }
    }
}
