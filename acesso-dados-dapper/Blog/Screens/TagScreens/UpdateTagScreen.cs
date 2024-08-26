using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.TagScreens
{
    public static class UpdateTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Atualizar uma tag");
            Console.WriteLine("-----------------");

            Update(ReportData());

            Console.ReadKey();

            MenuTagScreen.Load();
        }

        private static void Update(Tag tag)
        {
            var repository = new Repository<Tag>();

            try
            {
                repository.Update(tag);

                Console.WriteLine("Tag atualizada com sucesso.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível atualizar a tag.");
                Console.WriteLine(ex.Message);
            }
        }

        private static Tag ReportData()
        {
            Console.WriteLine("Informe os dados abaixo, referente a tag que deseja atualizar.");
            Console.Write("Id: ");
            var id = Console.ReadLine()!;

            Console.Write("Nome: ");
            var name = Console.ReadLine()!;

            Console.Write("Slug: ");
            var slug = Console.ReadLine()!;

            return new Tag { Id = int.Parse(id), Name = name, Slug = slug };
        }
    }
}