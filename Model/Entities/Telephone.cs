namespace orm.Model.Entities
{

    public class Telephone
    {
        public int TelephoneId { get; set; }
        public string? Phone { get; set; }
        public List<Client>? Clients { get; set; }
    }
}
