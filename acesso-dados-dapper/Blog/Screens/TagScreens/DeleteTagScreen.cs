using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.TagScreens
{
    public static class DeleteTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Excluir uma tag");
            Console.WriteLine("---------------");

            Delete(ReportData());

            Console.ReadKey();

            MenuTagScreen.Load();
        }

        private static void Delete(int id)
        {
            var repository = new Repository<Tag>();

            try
            {
                repository.Delete(id);

                Console.WriteLine("Tag excluída com sucesso.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível excluir a tag.");
                Console.WriteLine(ex.Message);
            }
        }

        private static int ReportData()
        {
            Console.WriteLine("Informe abaixo o id referente a tag que deseja excluir.");
            Console.Write("Id: ");
            var id = Console.ReadLine()!;

            return int.Parse(id);
        }
    }
}