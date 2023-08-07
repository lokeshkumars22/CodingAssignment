using System.ComponentModel.DataAnnotations;

namespace CodingTest.Models
{
    public class ListObjects
    {
        public int Id { get; set; }
        [StringLength(10)]
        public string Name { get; set; } = string.Empty;

    }
}
