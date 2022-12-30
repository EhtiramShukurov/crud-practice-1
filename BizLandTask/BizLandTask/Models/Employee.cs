using System.ComponentModel.DataAnnotations;

namespace BizLandTask.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [StringLength(20), Required]
        public string Name { get; set; }
        [StringLength(25), Required]
        public string Surname { get; set; }
        [StringLength(100), Required]
        public string ImageUrl { get; set; }
        [StringLength(20), Required]
        public string Position { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
