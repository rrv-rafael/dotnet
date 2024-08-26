using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.TagScreens
{
    public static class CreateTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Criar nova tag");
            Console.WriteLine("--------------");

            Create(ReportData());

            Console.ReadKey();

            MenuTagScreen.Load();
        }

        private static void Create(Tag tag)
        {
            var repository = new Repository<Tag>();

            try
            {
                repository.Create(tag);

                Console.WriteLine("Tag criada com sucesso.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível salvar a tag.");
                Console.WriteLine(ex.Message);
            }
        }

        private static Tag ReportData()
        {
            Console.WriteLine("Informe os dados abaixo.");
            Console.Write("Nome: ");
            var name = Console.ReadLine()!;

            Console.Write("Slug: ");
            var slug = Console.ReadLine()!;

            return new Tag { Name = name, Slug = slug };
        }
    }
}