using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelToBackend.Models
{
    public class Turebi
    {

        [Key]
        public int id { get; set; }
        [MaxLength(50,ErrorMessage ="Name was too large the max is 50")]
        public string Name { get; set; } = string.Empty;
        [Range(1,900000)]
        public double Price { get; set; }
        [MaxLength(200,ErrorMessage ="Description was too large max lenght is 200")]
        public string? Description { get; set; }
        public string? image_name { get; set; }
        public int? Company_Id { get; set; }
        [ForeignKey("Company_Id")]
        public Company? Company { get; set; }

    }
}