using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace orm.Model.Entities
{
    public class Client
    {
        public int ClientId { get; set; }
        [Required]
        public string? FullName { get; set; }
        [Required]
        public string? Requisites { get; set; }

        [ForeignKey("Residence")]  
        public int ResidenceForeignKey { get; set; } 
        public Residence? Residence{ get; set; }
        public Telephone? Telephone { get; set; }
    }
}
