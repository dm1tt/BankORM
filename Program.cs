using orm.Model.Entities;
using orm.Model.Services.DbRequest;

namespace orm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Comunnication test = new Comunnication();
            test.Dialog();
        }
    }
}