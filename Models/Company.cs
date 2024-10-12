using System.ComponentModel.DataAnnotations;

namespace TravelToBackend.Models
{
    public class Company
    {
        [Key]
        public int Company_Id { get; set; }
        [MaxLength(100,ErrorMessage ="The COmpany name is too large it should be under 100 chars")]
        public string? Name { get; set; }
        [MaxLength(300,ErrorMessage ="The COmpany description is too large it should be under 300 chars")]
        public string? description { get; set; }
        [MinLength(10,ErrorMessage ="Owner name must be 10 chars")]
        [MaxLength(100,ErrorMessage ="Owner lenght must be under 100 chars")]
        public string? owner { get; set; }
        public string? img_name { get; set; }
        public ICollection<Turebi> Turebi { get; set; }

    }
}