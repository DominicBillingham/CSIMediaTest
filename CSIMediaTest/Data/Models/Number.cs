using System.ComponentModel.DataAnnotations;

namespace CSIMediaTest.Data.Models
{
    public class Number
    {
        public Number(int value) {
            Value = value;
        }

        [Key]
        public int Id { get; set; }
        public int Value { get; set; }

    }
}
