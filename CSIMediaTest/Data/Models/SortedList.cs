namespace CSIMediaTest.Data.Models
{
    public class SortedList
    {
        public ICollection<int> Numbers { get; set; }
        public int TimeTakenToSort { get; set; }
        public bool InAscendingOrder { get; set; }
    }
}
