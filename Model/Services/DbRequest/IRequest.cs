using orm.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace orm.Model.Services.DbRequest
{
    public interface IRequest
    {

        public void Insert(Client client);
        public void Select();
        public void Update(Client client, Telephone telephone, Residence residence);
    }
}
