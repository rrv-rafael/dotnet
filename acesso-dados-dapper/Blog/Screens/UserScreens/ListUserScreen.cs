using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.UserScreens
{
    public class ListUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de usuários");
            Console.WriteLine("-----------------");

            List();

            Console.ReadKey();

            MenuUserScreen.Load();
        }

        private static void List()
        {
            var repository = new Repository<User>();

            try
            {
                var users = repository.Get();

                foreach (var user in users)
                {
                    Console.WriteLine($"{user.Id} - {user.Name} - {user.Email}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível listar os usuários.");
                Console.WriteLine(ex.Message);
            }
        }
    }
}