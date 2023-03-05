using System.ComponentModel.DataAnnotations;

namespace orm.Model.Entities
{
    public class Client
    {
        public int ClientId { get; set; }
        [Required]
        public string? ClientName { get; set; }
        [Required]
        public string? Requisites { get; set; }
        [Required]
        public string? Telephone { get; set; }
        public int ResidenceId { get; set; }
        public Residence? Residence { get; set; }
    }
}
