using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace CSIMediaTest.Data.Models
{
    public class SortedNumbers
    {
         public SortedNumbers() { }
         public SortedNumbers(bool inAscendingOrder, float timeElapsed) { 
            InAscendingOrder = inAscendingOrder;
            TimeTakenToSort = timeElapsed;
        }

        [Key]
        public int Id { get; set; }
        public float TimeTakenToSort { get; set; }
        public bool InAscendingOrder { get; set; }
        public string Numbers { get; set; }

    }
}
