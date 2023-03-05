using Microsoft.EntityFrameworkCore;
using orm.Model.Entities;
using orm.Model.Services.DbRequest;

namespace orm
{
    public class Comunnication
    {
        private readonly IRequest user;
        public Comunnication()
        {
            user = new DbRequest();
        }
        private void StartMenu()
        {
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Выберите операцию:");
            Console.WriteLine("1. Добавить нового пользователя");
            Console.WriteLine("2. Удалить пользователя");
            Console.WriteLine("3. Обновить данные пользователя");
            Console.WriteLine("4. Показать всех пользователей");
            Console.WriteLine("Для выхода из программы нажмите ESC");
        }
        private void InsertMenu()
        {
            Console.WriteLine("Введите ФИО");
            string? FullName = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Введите номер телефона");
            string? Telephone = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Введите реквизиты");
            string? Requisites = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Введите город");
            string? City = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Введите страну");
            string? Country = Console.ReadLine();
            Console.WriteLine();

            Residence residence = new Residence()
            {
                City = City,
                Country = Country
            };
            Client client = new Client()
            {
                ClientName = FullName,
                Telephone = Telephone,
                Requisites = Requisites,
                Residence = residence
            };

            user.Insert(client);
        }
        private void DeleteMenu()
        {
            DbRequest db = new DbRequest();
            Console.WriteLine("------------------------------------");
            db.Select();
            Console.WriteLine("------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Выбирай айди типа которого хочешь удалить нахуй)))");
            int UserId;
            try
            {
                UserId = Convert.ToInt32(Console.ReadLine());
                db.Delete(UserId);
            }
            catch
            {
                Console.WriteLine("СУКА ВВЕДИ ЧИСЛО БЛЯТЬ А НЕ ХУЙНЮ КАКУЮ-ТО");
            }
        }
        private void UpdateMenu()
        {
            DbRequest db = new DbRequest();
            Console.WriteLine("------------------------------------");
            db.Select();
            Console.WriteLine("------------------------------------");
            Console.WriteLine();
            Console.WriteLine("напиши ка айдишник чела у кого тыхочешь обновить инфу");
            int UserId;
            try
            {
                UserId = Convert.ToInt32(Console.ReadLine());
                db.Update(UserId);
            }
            catch
            {
                Console.WriteLine("ты долбоеб? введи ЧИСЛО");
            }
        }
        private void SelectMenu()
        {
            DbRequest db = new DbRequest();
            db.Select();
        }
        public void Dialog()
        {
            ConsoleKeyInfo escape = Console.ReadKey();
            Console.ReadLine();
            while (escape.Key != ConsoleKey.Escape)
            {
                StartMenu();
                Console.WriteLine();
                escape = Console.ReadKey();
                Console.WriteLine();

                if (escape.Key == ConsoleKey.D1)
                {
                    Console.WriteLine();
                    InsertMenu();
                }
                else if (escape.Key == ConsoleKey.D2)
                {
                    Console.WriteLine();
                    DeleteMenu();
                }
                else if (escape.Key == ConsoleKey.D3)
                {
                    Console.WriteLine();
                    UpdateMenu();
                }
                else if (escape.Key == ConsoleKey.D4)
                {
                    Console.WriteLine();
                    SelectMenu();
                }
            }
        }
        
    }
}
