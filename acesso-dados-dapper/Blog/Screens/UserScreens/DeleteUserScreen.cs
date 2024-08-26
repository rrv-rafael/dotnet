using System.Data.Common;
using System.Xml.Serialization;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.UserScreens
{
    public class DeleteUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Atualizar um usuário");
            Console.WriteLine("--------------------");

            Delete(ReportData());

            Console.ReadKey();

            MenuUserScreen.Load();
        }

        private static void Delete(int id)
        {
            var repository = new Repository<User>();

            try
            {
                repository.Delete(id);
                Console.WriteLine("Usuário excluído com sucesso.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível excluir o usuário.");
                Console.WriteLine(ex.Message);
            }
        }

        private static int ReportData()
        {
            Console.WriteLine("Informe abaixo o id referente ao usuário que deseja excluir.");

            Console.Write("Id: ");
            var id = Console.ReadLine()!;

            return int.Parse(id);
        }
    }
}