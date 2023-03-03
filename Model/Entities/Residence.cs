using System.ComponentModel.DataAnnotations;

namespace orm.Model.Entities
{
    public class Residence
    {
        public int ResidenceId { get; set; }
        [Required]        
        public string? City { get; set; }
        [Required]
        public string? Country { get; set; }
        public List<Client> Clients { get; set; }
    }
}
