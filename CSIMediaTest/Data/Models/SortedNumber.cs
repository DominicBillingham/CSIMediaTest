using System.ComponentModel.DataAnnotations;

namespace CSIMediaTest.Data.Models
{
    public class SortedNumbers
    {
         public SortedNumbers() { }

         public SortedNumbers(bool inAscendingOrder, int timeElapsed) { 
            InAscendingOrder = inAscendingOrder;
            TimeTakenToSort = timeElapsed;
            Numbers = new List<Number>();
        }

        [Key]
        public int Id { get; set; }
        public ICollection<Number> Numbers { get; set; }
        public int TimeTakenToSort { get; set; }
        public bool InAscendingOrder { get; set; }
    }
}
