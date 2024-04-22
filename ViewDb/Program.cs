using System.Reflection;
using ViewDb;
using ViewDb.Models;

var exit = false;
while (!exit)
{
    var tableNumber = ReceivingData.GetData();
    switch (tableNumber)
    {
        case 0:
        {
            exit = true;
            break;
        }
        case (int)TablesEnum.Categories:
        {
            await GetDataAndPrintAsync<CategoryModel>(QueryTemplates.CategoriesAll);
            break;
        }
        case (int)TablesEnum.Salesman:
        {
            await GetDataAndPrintAsync<SalesmanModel>(QueryTemplates.SalesmanAll);
            break;
        }
        case (int)TablesEnum.Products:
        {
            await GetDataAndPrintAsync<ProductModel>(QueryTemplates.ProductsAll);
            break;
        }

    }
}

static async Task GetDataAndPrintAsync<T>(string sql)
{
    var dataFromDb = await PgRepository.ExecuteAsync<T>(sql);
    PrintTable(dataFromDb);
}


static void PrintTable<T>(IEnumerable<T> rows)
{
    var properties = typeof(T).GetProperties();
    var lengField = 40;

    // Вывод заголовка таблицы
    int x = 0;
    var header = string.Join("| ", properties.Select(p => $"{{{x++},-{lengField}}}"));
    Console.WriteLine(new string('-', properties.Length * lengField));
    Console.WriteLine(header, properties.Select(p => p.Name).ToArray());
    Console.WriteLine(new string('-', properties.Length * lengField));

    // Вывод строк таблицы
    foreach (var row in rows)
    {
        int y = 0;
        var line = string.Join("| ", properties.Select(p => $"{{{y++},-{lengField}}}"));
        Console.WriteLine(line, properties.Select(p => p.GetValue(row)).ToArray());
    }
    Console.WriteLine(new string('-', properties.Length * lengField));
}