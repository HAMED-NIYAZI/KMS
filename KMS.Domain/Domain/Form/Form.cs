namespace KMS.Domain
{
    public class Form : BaseEntity
    {
        public int SortingNumber { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int FormTypeId { get; set; }


        public ICollection<Knowledge> Knowledges { get; set; }
        public ICollection<ShortTest> ShortTests { get; set; }
        public ICollection<LongText> LongTexts { get; set; }
        public ICollection<RadioButtonYesNo> RadioButtonYesNos { get; set; }
        public ICollection<Combo> Combos { get; set; }
        public ICollection<DateText> DateTexts { get; set; }

    }
}
