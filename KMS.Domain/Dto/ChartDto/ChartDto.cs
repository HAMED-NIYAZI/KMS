namespace KMS.Domain.Dto.ChartDto
{
    public class ChartDto
    {
        public Guid Id { get; set; }

        public int SortingNumber { get; set; }
        public string PersianTitle { get; set; }

        public Guid? ParentId { get; set; }

    }
}
