namespace KMS.Domain
{
    public class ComboDetail
    {
        public Guid Id { get; set; }
        public int ValueId { get; set; }
        public string ValueText { get; set; }
        public Combo Combo { get; set; }
        public Guid ComboId { get; set; }
    }
}
