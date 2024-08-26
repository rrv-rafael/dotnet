using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.UserScreens
{
    public class UpdateUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Atualizar um usuário");
            Console.WriteLine("--------------------");

            Update(ReportData());

            Console.ReadKey();

            MenuUserScreen.Load();
        }

        private static void Update(User user)
        {
            var repository = new Repository<User>();

            try
            {
                repository.Update(user);

                Console.WriteLine("Usuário atualizado com sucesso.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível atualizar o usuário.");
                Console.WriteLine(ex.Message);
            }
        }

        private static User ReportData()
        {
            Console.WriteLine("Informe os dados, conforme solicitado abaixo.");

            Console.Write("Id: ");
            var id = Console.ReadLine()!;
            Console.Write("Nome: ");
            var name = Console.ReadLine()!;
            Console.Write("E-mail: ");
            var email = Console.ReadLine()!;
            Console.Write("PasswordHash: ");
            var passwordHash = Console.ReadLine()!;
            Console.Write("Bio: ");
            var bio = Console.ReadLine()!;
            Console.Write("Image: ");
            var image = Console.ReadLine()!;
            Console.Write("Slug: ");
            var slug = Console.ReadLine()!;

            var user = new User
            {
                Id = int.Parse(id),
                Name = name,
                Email = email,
                PasswordHash = passwordHash,
                Bio = bio,
                Image = image,
                Slug = slug
            };

            return user;
        }
    }
}