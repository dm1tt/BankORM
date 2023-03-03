using orm.Model.Entities;
using orm.Model.Services.DbRequest;

namespace orm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Context ct = new Context();
            DbRequest popa = new DbRequest();
            var telephone = new Telephone()
            {
                Phone = "88005553535"
            };
            var residence = new Residence()
            {
                City = "Струнино",
                Country = "Россия"
            };
            var client = new Client()
            {
                FullName = "баба",
                Requisites = "54445656456235656",
                Residence = residence,
                Telephone = telephone
            };
            popa.Insert(client);
            
        }
    }
}