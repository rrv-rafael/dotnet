using System.ComponentModel.Design;
using Blog.Models;
using Blog.Repositories;
using Blog.Screens.TagScreens;
using Blog.Screens.UserScreens;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog;

class Program
{
    static void Main(string[] args)
    {
        Database.Connection.Open();

        Load();

        Console.ReadKey();
        Database.Connection.Close();
        // Menu();
        // var connection = new SqlConnection(CONNECTION_STRING);
        // connection.Open();
        // CreateUser(connection);
        // UpdateUser(connection);
        // DeleteUser(connection);
        // DeleteUserById(connection, 1003);
        // ReadUsers(connection);
        // ReadUsersWithRoles(connection);
        // ReadRoles(connection);
        // ReadTags(connection);
        // ReadCategories(connection);
        // connection.Close();
    }

    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Meu Blog");
        Console.WriteLine("--------");
        Console.WriteLine("O que deseja fazer?\n");
        Console.WriteLine("1 - Gestão de usuário");
        Console.WriteLine("2 - Gestão de perfil");
        Console.WriteLine("3 - Gestão de categoria");
        Console.WriteLine("4 - Gestão de tag");
        Console.WriteLine("5 - Vincular perfil/usuário");
        Console.WriteLine("6 - Vincular post/tag");
        Console.WriteLine("7 - Relatórios\n\n");

        Console.Write("Informe a opção desejada: ");
        var option = Console.ReadLine();

        switch (option)
        {
            case "1":
                MenuUserScreen.Load();
                break;
            case "4":
                MenuTagScreen.Load();
                break;
            default:
                Load();
                break;
        }
    }
    //     public static void Menu()
    //     {
    //         Console.WriteLine("****** Blog ******");

    //         Console.WriteLine("Qual operação deseja realizar?");

    //         Console.WriteLine("1 - Cadastrar Usuário");
    //         Console.WriteLine("2 - Cadastrar Perfil");
    //         Console.WriteLine("3 - Cadastrar Categoria");
    //         Console.WriteLine("4 - Cadastrar Tag");
    //         Console.WriteLine("5 - Cadastrar Post");
    //         Console.WriteLine("6 - Vincular um Usuário a um Perfil");
    //         Console.WriteLine("7 - Vincular um Post a uma Tag");
    //         Console.WriteLine("8 - Listar Usuários");
    //         Console.WriteLine("9 - Listar Categorias com quantidade de Posts");
    //         Console.WriteLine("10 - Listar Tags com quantidade de Posts");
    //         Console.WriteLine("11 - Listar Posts de uma Categoria");
    //         Console.WriteLine("12 - Listar todos os Posts com sua Categoria");
    //         Console.WriteLine("13 - Listar os Posts com suas Tags");
    //         Console.WriteLine("0 - Sair");

    //         Console.WriteLine("*************************");
    //         Console.WriteLine("Informe a opção desejada: ");
    //         var option = Console.ReadLine();

    //         switch (option)
    //         {
    //             case "1":
    //                 RegisterUser();
    //                 break;
    //             case "2":
    //                 RegisterRole();
    //                 break;
    //             case "3":
    //                 RegisterCategory();
    //                 break;
    //             case "4":
    //                 RegisterTag();
    //                 break;
    //             case "5":
    //                 RegisterPost();
    //                 break;
    //             case "12":
    //                 ReadCategoriesWithPosts();
    //                 break;
    //             case "0":
    //                 Environment.Exit(0);
    //                 break;
    //             default:
    //                 Console.WriteLine("Opção inválida. Digite novamente.");
    //                 break;
    //         }

    //         Menu();
    //     }

    //     public static void RegisterUser()
    //     {
    //         var user = new User();

    //         Console.WriteLine("Para cadastrar o Usuário, informe os dados conforme abaixo.");

    //         try
    //         {
    //             user.Name = ReadNonEmptyInput("Nome");
    //             user.Email = ReadNonEmptyInput("E-mail");
    //             user.PasswordHash = ReadNonEmptyInput("PassworHash");
    //             user.Bio = ReadNonEmptyInput("Bio");
    //             user.Image = ReadNonEmptyInput("Image");
    //             user.Slug = ReadNonEmptyInput("Slug");

    //             using var connection = new SqlConnection(CONNECTION_STRING);
    //             connection.Open();

    //             var repository = new Repository<User>(connection);

    //             var idCreated = repository.Create(user);

    //             if (idCreated > 0)
    //             {
    //                 var userCreated = repository.Get(idCreated);

    //                 Console.WriteLine($"{userCreated.Name} cadastrado com sucesso!");
    //             }
    //         }
    //         catch (IOException e)
    //         {
    //             Console.WriteLine($"Erro de I/O: {e.Message}");
    //         }
    //         catch (Exception e)
    //         {
    //             Console.WriteLine($"Erro inesperado: {e.Message}");
    //         }
    //     }

    //     public static void RegisterRole()
    //     {
    //         var role = new Role();

    //         Console.WriteLine("Para cadastrar o Perfil, informe os dados conforme abaixo.");

    //         try
    //         {
    //             role.Name = ReadNonEmptyInput("Nome");
    //             role.Slug = ReadNonEmptyInput("Slug");

    //             using var connection = new SqlConnection(CONNECTION_STRING);
    //             connection.Open();

    //             var repository = new Repository<Role>(connection);

    //             var idCreated = repository.Create(role);

    //             if (idCreated > 0)
    //             {
    //                 var roleCreated = repository.Get(idCreated);

    //                 Console.WriteLine("Perfil cadastrado com sucesso!");
    //             }
    //         }
    //         catch (IOException e)
    //         {
    //             Console.WriteLine($"Erro de I/O: {e.Message}");
    //         }
    //         catch (Exception e)
    //         {
    //             Console.WriteLine($"Erro inesperado: {e.Message}");
    //         }
    //     }

    //     public static void RegisterCategory()
    //     {
    //         var category = new Category();

    //         Console.WriteLine("Para cadastrar a categoria, informe os dados conforme abaixo.");

    //         try
    //         {
    //             category.Name = ReadNonEmptyInput("Nome");
    //             category.Slug = ReadNonEmptyInput("Slug");

    //             using var connection = new SqlConnection(CONNECTION_STRING);
    //             connection.Open();

    //             var repository = new Repository<Category>(connection);

    //             var idCreated = repository.Create(category);

    //             if (idCreated > 0)
    //             {
    //                 var categoryCreated = repository.Get(idCreated);

    //                 Console.WriteLine("Categoria cadastrada com sucesso!");
    //             }
    //         }
    //         catch (IOException e)
    //         {
    //             Console.WriteLine($"Erro de I/O: {e.Message}");
    //         }
    //         catch (Exception e)
    //         {
    //             Console.WriteLine($"Erro inesperado: {e.Message}");
    //         }
    //     }

    //     public static void RegisterTag()
    //     {
    //         var tag = new Tag();

    //         Console.WriteLine("Para cadastrar a Tag, informe os dados conforme abaixo.");

    //         try
    //         {
    //             tag.Name = ReadNonEmptyInput("Nome");
    //             tag.Slug = ReadNonEmptyInput("Slug");

    //             using var connection = new SqlConnection(CONNECTION_STRING);
    //             connection.Open();

    //             var repository = new Repository<Tag>(connection);

    //             var idCreated = repository.Create(tag);

    //             if (idCreated > 0)
    //             {
    //                 var tagCreated = repository.Get(idCreated);

    //                 Console.WriteLine("Tag cadastrada com sucesso!");
    //             }
    //         }
    //         catch (IOException e)
    //         {
    //             Console.WriteLine($"Erro de I/O: {e.Message}");
    //         }
    //         catch (Exception e)
    //         {
    //             Console.WriteLine($"Erro inesperado: {e.Message}");
    //         }
    //     }

    //     public static void RegisterPost()
    //     {
    //         var post = new Post();

    //         Console.WriteLine("Para cadastrar seu Post, informe os dados conforme abaixo.");

    //         try
    //         {
    //             using var connection = new SqlConnection(CONNECTION_STRING);
    //             connection.Open();

    //             var categoryRepository = new CategoryRepository(connection);
    //             var userRepository = new UserRepository(connection);

    //             var slugCategory = ReadNonEmptyInput("Slug da Categoria");
    //             post.CategoryId = categoryRepository.Get(slugCategory);

    //             var email = ReadNonEmptyInput("E-mail");
    //             post.AuthorId = userRepository.Get(email);

    //             post.Title = ReadNonEmptyInput("Título");
    //             post.Summary = ReadNonEmptyInput("Sumário");
    //             post.Body = ReadNonEmptyInput("Corpo");
    //             post.Slug = ReadNonEmptyInput("Slug");
    //             post.CreateDate = DateTime.Now;
    //             post.LastUpdateDate = DateTime.Now;

    //             var repository = new Repository<Post>(connection);

    //             var idCreated = repository.Create(post);

    //             if (idCreated > 0)
    //             {
    //                 var postCreated = repository.Get(idCreated);

    //                 Console.WriteLine("Post cadastrado com sucesso!");
    //             }
    //         }
    //         catch (IOException e)
    //         {
    //             Console.WriteLine($"Erro de I/O: {e.Message}");
    //         }
    //         catch (Exception e)
    //         {
    //             Console.WriteLine($"Erro inesperado: {e.Message}");
    //         }
    //     }

    //     private static string ReadNonEmptyInput(string fieldName)
    //     {
    //         Console.Write($"{fieldName}: ");
    //         string? input;

    //         while (string.IsNullOrEmpty(input = Console.ReadLine()))
    //         {
    //             Console.Write($"O campo {fieldName} não pode ser vazio. \nPor favor, digite novamente: ");
    //         }

    //         return input;
    //     }

    //     public static void ReadUsers(SqlConnection connection)
    //     {
    //         var repository = new Repository<User>(connection);
    //         var users = repository.Get();

    //         foreach (var user in users)
    //         {
    //             Console.WriteLine(user.Name);
    //         }
    //     }

    //     public static void ReadUsersWithRoles(SqlConnection connection)
    //     {
    //         var repository = new UserRepository(connection);
    //         var users = repository.GetWithRoles();

    //         foreach (var user in users)
    //         {
    //             Console.WriteLine(user.Name);

    //             foreach (var role in user.Roles)
    //             {
    //                 Console.WriteLine($" - {role.Name}");
    //             }
    //         }
    //     }

    //     public static void ReadCategoriesWithPosts()
    //     {
    //         using var connection = new SqlConnection(CONNECTION_STRING);
    //         connection.Open();

    //         var repository = new PostRepository(connection);
    //         var categories = repository.GetWithCategory();

    //         foreach (var category in categories)
    //         {
    //             Console.WriteLine(category.Name);

    //             foreach (var post in category.Posts)
    //             {
    //                 Console.WriteLine($" - {post.Title}");
    //             }
    //         }
    //     }

    //     public static void ReadRoles(SqlConnection connection)
    //     {
    //         var repository = new Repository<Role>(connection);
    //         var roles = repository.Get();

    //         foreach (var role in roles)
    //         {
    //             Console.WriteLine(role.Name);
    //         }
    //     }

    //     public static void ReadTags(SqlConnection connection)
    //     {
    //         var repository = new Repository<Tag>(connection);
    //         var tags = repository.Get();

    //         foreach (var tag in tags)
    //         {
    //             Console.WriteLine(tag.Name);
    //         }
    //     }

    //     public static void ReadCategories(SqlConnection connection)
    //     {
    //         var repository = new Repository<Category>(connection);
    //         var categories = repository.Get();

    //         foreach (var category in categories)
    //         {
    //             Console.WriteLine(category.Name);
    //         }
    //     }

    //     public static void UpdateUser(SqlConnection connection)
    //     {
    //         var repository = new Repository<User>(connection);

    //         var user = new User
    //         {
    //             Id = 1002,
    //             Name = "Rafael Rodrigues Vitor",
    //             Email = "rafael.vitor@balta.io",
    //             PasswordHash = "HASH",
    //             Bio = "Aluno do Balta, estudando Dapper.",
    //             Image = "https://",
    //             Slug = "rafael-vitor"
    //         };

    //         var updateSuccess = repository.Update(user);

    //         if (updateSuccess)
    //         {
    //             Console.WriteLine("Update realizado com sucesso.");
    //         }
    //     }

    //     public static void DeleteUser(SqlConnection connection)
    //     {
    //         var repository = new Repository<User>(connection);

    //         var user = new User
    //         {
    //             Id = 1002,
    //             Name = "Rafael Rodrigues Vitor",
    //             Email = "rafael.vitor@balta.io",
    //             PasswordHash = "HASH",
    //             Bio = "Aluno do Balta, estudando Dapper.",
    //             Image = "https://",
    //             Slug = "rafael-vitor"
    //         };

    //         var deleteSuccess = repository.Delete(user);

    //         if (deleteSuccess)
    //         {
    //             Console.WriteLine("Exclusão realizada com sucesso.");
    //         }
    //     }

    //     public static void DeleteUserById(SqlConnection connection, long id)
    //     {
    //         var repository = new Repository<User>(connection);

    //         var deleteSuccess = repository.Delete(id);

    //         if (deleteSuccess)
    //         {
    //             Console.WriteLine("Exclusão realizada com sucesso.");
    //         }
    //     }
}