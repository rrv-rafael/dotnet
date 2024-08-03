using Dapper;
using DataAccess.Models;
using Microsoft.Data.SqlClient;

const string connectionString = "Server=localhost,1433;Database=Balta;User ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=True;";

using (var connection = new SqlConnection(connectionString))
{
    connection.Open();

    using (var command = new SqlCommand())
    {
        UpdateCategory(connection);
        ListCategories(connection);
        // CreateCategory(connection);
    }
}

static void ListCategories(SqlConnection connection)
{
    var categories = connection.Query<Category>("SELECT Id, Title FROM Category");

    foreach (var item in categories)
    {
        Console.WriteLine($"{item.Id} - {item.Title}");
    }
}

static void CreateCategory(SqlConnection connection)
{
    var category = new Category
    {
        Id = Guid.NewGuid(),
        Title = "Amazon AWS",
        Url = "amazon",
        Description = "Categoria destinada a serviços do AWS.",
        Order = 8,
        Summary = "AWS Cloud",
        Featured = false
    };

    var insertSql = @"INSERT INTO Category VALUES (@Id, @Title, @Url, @Summary, @Order, @Description, @Featured)";

    var rows = connection.Execute(insertSql, new
    {
        category.Id,
        category.Title,
        category.Url,
        category.Summary,
        category.Order,
        category.Description,
        category.Featured
    });

    Console.WriteLine($"{rows} linhas inseridas.");
}

static void UpdateCategory(SqlConnection connection)
{
    var updateQuery = "UPDATE Category SET Title = @Title WHERE Id = @Id";

    var rows = connection.Execute(updateQuery, new
    {
        Id = new Guid("af3407aa-11ae-4621-a2ef-2028b85507c4"),
        Title = "Frontend 2024"
    });

    Console.WriteLine($"{rows} registros atualizados.");
}