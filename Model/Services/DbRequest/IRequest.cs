using orm.Model.Entities;

namespace orm.Model.Services.DbRequest
{
    public interface IRequest
    {
        public void Insert(Client client);
        public void Select();
        public void Delete(int ClientId);
        public void Update(int ClientId);
        public bool IsThereResidenceInDb(Residence residence); 
    }
}
