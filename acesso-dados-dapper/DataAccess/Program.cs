﻿using System.Data;
using System.Runtime.InteropServices;
using Dapper;
using DataAccess.Models;
using Microsoft.Data.SqlClient;

const string connectionString = "Server=localhost;Database=Balta;User ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=True;";

using (var connection = new SqlConnection(connectionString))
{
    connection.Open();

    using (var command = new SqlCommand())
    {
        // CreateCategory(connection);
        // CreateManyCategories(connection);
        // UpdateCategory(connection);
        // DeleteCategory(connection);
        // ListCategories(connection);
        // GetCategory(connection);
        // ExecuteProcedure(connection);
        // ExecuteReadProcedure(connection);
        // ExecuteScalar(connection);
        // ReadView(connection);
        // OneToOne(connection);
        // OneToMany(connection);
        // QueryMultiple(connection);
        // SelectIn(connection);
        // Like(connection, "backend");
        Transaction(connection);
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

static void GetCategory(SqlConnection connection)
{
    var category = connection.QueryFirstOrDefault<Category>("SELECT Id, Title FROM Category WHERE Id = @Id", new
    {
        Id = new Guid("af3407aa-11ae-4621-a2ef-2028b85507c4")
    });

    Console.WriteLine($"{category.Id} - {category?.Title ?? "Registro não encontrado"}");
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

    Console.WriteLine($"{rows} registros inseridos.");
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

static void DeleteCategory(SqlConnection connection)
{
    var deleteQuery = "DELETE FROM Category WHERE Id = @Id";

    var rows = connection.Execute(deleteQuery, new
    {
        Id = new Guid("43d199ef-1e63-4e4f-95fd-88efda121dd7")
    });

    Console.WriteLine($"{rows} registros deletados.");
}

static void CreateManyCategories(SqlConnection connection)
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

    var category2 = new Category
    {
        Id = Guid.NewGuid(),
        Title = "Categoria nova",
        Url = "categoria-nova",
        Description = "Categoria nova.",
        Order = 9,
        Summary = "Categoria",
        Featured = true
    };

    var insertSql = @"INSERT INTO Category VALUES (@Id, @Title, @Url, @Summary, @Order, @Description, @Featured)";

    var rows = connection.Execute(insertSql, new[] {
        new
        {
            category.Id,
            category.Title,
            category.Url,
            category.Summary,
            category.Order,
            category.Description,
            category.Featured
        },
        new {
            category2.Id,
            category2.Title,
            category2.Url,
            category2.Summary,
            category2.Order,
            category2.Description,
            category2.Featured
        }
    });

    Console.WriteLine($"{rows} registros inseridos.");
}

static void ExecuteProcedure(SqlConnection connection)
{
    var procedure = "spDeleteStudent";
    var pars = new { StudentId = "4167633b-551e-49b4-a61b-af74e49e6cc2" };

    var affectedRows = connection.Execute(procedure, pars, commandType: CommandType.StoredProcedure);

    Console.WriteLine($"{affectedRows} linhas afetadas.");
}

static void ExecuteReadProcedure(SqlConnection connection)
{
    var procedureRead = "spGetCoursesByCategory";
    var pars = new { CategoryId = "af3407aa-11ae-4621-a2ef-2028b85507c4" };

    var courses = connection.Query<Course>(procedureRead, pars, commandType: CommandType.StoredProcedure);

    foreach (var course in courses)
    {
        Console.WriteLine($"{course.Id} - {course.Title}");
    }
}

static void ExecuteScalar(SqlConnection connection)
{
    var category = new Category
    {
        Title = "Amazon AWS",
        Url = "amazon",
        Description = "Categoria destinada a serviços do AWS.",
        Order = 8,
        Summary = "AWS Cloud",
        Featured = false
    };

    var insertSql = @"INSERT INTO Category OUTPUT inserted.Id VALUES (NEWID(), @Title, @Url, @Summary, @Order, @Description, @Featured)";

    var id = connection.ExecuteScalar<Guid>(insertSql, new
    {
        category.Title,
        category.Url,
        category.Summary,
        category.Order,
        category.Description,
        category.Featured
    });

    Console.WriteLine($"A categoria inserida foi: {id}.");
}

static void ReadView(SqlConnection connection)
{
    var sql = @"SELECT * FROM VWCourses";
    var courses = connection.Query<Course>(sql);

    foreach (var course in courses)
    {
        Console.WriteLine($"{course.Id} - {course.Title}");
    }
}

static void OneToOne(SqlConnection connection)
{
    var sql = @"SELECT
                    *
                FROM
                    CareerItem ci
                INNER JOIN 
                    Course c ON ci.CourseId = c.Id";

    var items = connection.Query<CareerItem, Course, CareerItem>(sql, (careerItem, course) =>
    {
        careerItem.Course = course;

        return careerItem;
    }, splitOn: "Id");

    foreach (var item in items)
    {
        Console.WriteLine($"{item.Title} - Curso: {item.Course.Title}");
    }
}

static void OneToMany(SqlConnection connection)
{
    var sql = @"SELECT
                    c.Id,
                    c.Title,
                    ci.CareerId,
                    ci.Title
                FROM
                    Career c
                INNER JOIN
                    CareerItem ci ON c.Id = ci.CareerId
                ORDER BY
                    c.Title";

    var careers = new List<Career>();
    var items = connection.Query<Career, CareerItem, Career>(sql, (career, item) =>
    {
        var car = careers.Where(x => x.Id == career.Id).FirstOrDefault();

        if (car == null)
        {
            car = career;
            car.CareerItems.Add(item);
            careers.Add(car);
        }
        else
        {
            car.CareerItems.Add(item);
        }

        return career;
    }, splitOn: "CareerId");

    foreach (var career in careers)
    {
        Console.WriteLine($"{career.Title}");

        foreach (var item in career.CareerItems)
        {
            Console.WriteLine($" - {item.Title}");
        }
    }
}

static void QueryMultiple(SqlConnection connection)
{
    var query = "SELECT * FROM Category; SELECT * FROM Course";

    using (var multi = connection.QueryMultiple(query))
    {
        var categories = multi.Read<Category>();
        var courses = multi.Read<Course>();

        foreach (var item in categories)
        {
            Console.WriteLine(item.Title);
        }

        foreach (var course in courses)
        {
            Console.WriteLine(course.Title);
        }
    }
}

static void SelectIn(SqlConnection connection)
{
    var query = @"SELECT
                       *
                    FROM
                        Career
                    WHERE
                        Id IN @Id";

    var items = connection.Query<Career>(query, new
    {
        Id = new[]
        {
            "01ae8a85-b4e8-4194-a0f1-1c6190af54cb",
            "e6730d1c-6870-4df3-ae68-438624e04c72"
        }
    });

    foreach (var item in items)
    {
        Console.WriteLine(item.Title);
    }
}

static void Like(SqlConnection connection, string term)
{
    var query = @"SELECT
                       *
                    FROM
                        Course
                    WHERE
                        Title LIKE @exp";

    var items = connection.Query<Course>(query, new
    {
        exp = $"%{term}%"
    });

    foreach (var item in items)
    {
        Console.WriteLine(item.Title);
    }
}

static void Transaction(SqlConnection connection)
{
    var category = new Category
    {
        Id = Guid.NewGuid(),
        Title = "Minha categoria que não quero salvar",
        Url = "amazon",
        Description = "Categoria destinada a serviços do AWS.",
        Order = 8,
        Summary = "AWS Cloud",
        Featured = false
    };

    var insertSql = @"INSERT INTO Category VALUES (@Id, @Title, @Url, @Summary, @Order, @Description, @Featured)";

    using (var transaction = connection.BeginTransaction())
    {
        var rows = connection.Execute(insertSql, new
        {
            category.Id,
            category.Title,
            category.Url,
            category.Summary,
            category.Order,
            category.Description,
            category.Featured
        }, transaction);

        transaction.Commit();
        // transaction.Rollback();

        Console.WriteLine($"{rows} registros inseridos.");
    }
}