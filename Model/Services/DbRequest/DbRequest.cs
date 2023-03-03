using orm.Model.Entities;

namespace orm.Model.Services.DbRequest
{
    public class DbRequest : IRequest
    {
        public void Insert(Client client)
        {
            using (var context = new Context())
            {
                if (context.Residences.Where(r => r.City == client.Residence.City).ToList().Count() == 0)
                {
                    context.Add(client);
                }
                else
                {
                    var piska = context.Residences.Single(p => p.City == "Струнино");
                    var person = new Client()
                    {
                        ResidenceForeignKey = piska.ResidenceId,
                        FullName = "писька",
                        Requisites = "564456456456"
                    };
                    context.Add(person);
                    
                    context.SaveChanges();
                }

            }             
        }

        public void Select()
        {
            
        }

        public void Update(Client client, Telephone telephone, Residence residence)
        {

        }
    }
}

