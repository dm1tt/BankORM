using Microsoft.EntityFrameworkCore;
using orm.Model.Entities;

namespace orm.Model.Services.DbRequest
{
    public class DbRequest : IRequest
    {
        public bool IsThereResidenceInDb(Residence residence)
        {
            Context context = new Context();
            if(context.Residences.Where(r => r.City == residence.City).ToList().Count != 0)
                return true;
            return false;
        }
        public void Insert(Client client)
        {
            Context context = new Context();
            if(!IsThereResidenceInDb(client.Residence)) 
            {
                context.Add(client);
            }
            else
            {
                var res = context.Residences.Include(r => r.Clients).First();
                var person = new Client
                {
                    ClientName = client.ClientName,
                    Requisites = client.Requisites,
                    Telephone = client.Telephone,
                    Residence = res
                };
                res.Clients.Add(person);
            }
            context.SaveChanges();
        }
        public void Select()    
        {            
            Context context = new Context();
            var client = context.Clients.Include(c => c.Residence);
            foreach (var person in client)
            {
                Console.WriteLine($"{person.ClientId}" +
                    $" {person.ClientName}" +
                    $" {person.Telephone}" +
                    $" {person.Requisites}" +
                    $" {person.Residence.City}" +
                    $" {person.Residence.Country}");
            }
        }
        public void Delete(int ClientId)
        {
            Context context = new Context();
            try
            {
                var person = context.Clients.Where(c => c.ClientId == ClientId).First();
                if(person != null)
                {
                    context.Clients.Remove(person);
                }
                context.SaveChanges();
            }
            catch
            {
                Console.WriteLine("Пользователь с таким ID не найден!");
            }
        }
        public void Update (int ClientId)
        {
            Context context = new Context();

            var person = context.Clients
                .Where(c => c.ClientId == ClientId)
                .Include(c => c.Residence).First();

            Console.WriteLine("ты выбрал апдейт. Если хочешь изменить данные пиши новые,");
            Console.WriteLine(" если не хочешь менять определенный пункт просто нажми энтер");

            Console.WriteLine("1.ФИО");
            string? NewClientName = Console.ReadLine();
            Console.WriteLine("2.Телефончик");
            string? NewTelephone = Console.ReadLine();
            Console.WriteLine("3.Реквизитики");
            string? NewRequisites = Console.ReadLine();
            Console.WriteLine("4.Город + страна");

            Residence newResidence = new Residence()
            {
                City = Console.ReadLine(),
                Country = Console.ReadLine(),
            };

            if (NewClientName != "")
            {
                person.ClientName = NewClientName;
            }
            if (NewTelephone != "")
            {
                person.Telephone = NewTelephone;
            }
            if (NewRequisites != "")
            {
                person.Requisites = NewRequisites;

            }
            if (newResidence.City != "")
                person.Residence = newResidence;
            
            
            context.Clients.Update(person);
            context.SaveChanges();
        }
    }
}

