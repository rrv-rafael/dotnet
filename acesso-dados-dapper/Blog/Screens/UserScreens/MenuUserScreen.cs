namespace Blog.Screens.UserScreens
{
    public static class MenuUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Gestão de usuários");
            Console.WriteLine("--------------");
            Console.WriteLine("O que deseja fazer?\n");
            Console.WriteLine("1 - Listar usuários");
            Console.WriteLine("2 - Cadastrar usuário");
            Console.WriteLine("3 - Atualizar usuário");
            Console.WriteLine("4 - Excluir usuário\n\n");

            Console.Write("Informe a opção desejada: ");
            var option = Console.ReadLine()!;

            switch (option)
            {
                case "1":
                    ListUserScreen.Load();
                    break;
                case "2":
                    CreateUserScreen.Load();
                    break;
                case "3":
                    UpdateUserScreen.Load();
                    break;
                case "4":
                    DeleteUserScreen.Load();
                    break;
                default:
                    Load();
                    break;
            }
        }
    }
}