namespace Blog.Screens.TagScreens
{
    public static class MenuTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Gestão de tags");
            Console.WriteLine("--------------");
            Console.WriteLine("O que deseja fazer?\n");
            Console.WriteLine("1 - Listar tags");
            Console.WriteLine("2 - Cadastrar tags");
            Console.WriteLine("3 - Atualizar tags");
            Console.WriteLine("4 - Excluir tags\n\n");

            Console.Write("Informe a opção desejada: ");
            var option = Console.ReadLine()!;

            switch (option)
            {
                case "1":
                    ListTagScreen.Load();
                    break;
                case "2":
                    CreateTagScreen.Load();
                    break;
                case "3":
                    UpdateTagScreen.Load();
                    break;
                case "4":
                    DeleteTagScreen.Load();
                    break;
                default:
                    Load();
                    break;
            }
        }
    }
}