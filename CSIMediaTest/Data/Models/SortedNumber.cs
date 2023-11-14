using System.ComponentModel.DataAnnotations;

namespace CSIMediaTest.Data.Models
{
    public class SortedNumbers
    {
        [Key]
        public int Id { get; set; }
        public ICollection<Number> Numbers { get; set; }
        public int TimeTakenToSort { get; set; }
        public bool InAscendingOrder { get; set; }
    }
}
