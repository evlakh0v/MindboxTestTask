using Microsoft.Data.SqlClient;

namespace Request;

sealed class Program  
{
    private static async Task Main() 
    { 
        /*
            В тексте задания не была указана структура базы данных, поэтому я создал свою, её можно посмотреть 
        в файле DBStructure.png(находится в той же директории, что и этот файл).
        */
        
        // SQL запрос для выбора всех пар "Имя продукта - Имя категории".
         const string request = "SELECT products.name, categories.name " +
                                "FROM products " +
                                "LEFT JOIN product_categories ON product_categories.product_id = products.id " +
                                "LEFT JOIN categories ON product_categories.category_id = categories.id;";

        /*
            Следующий код предназанчен для отправки запроса на MS SQL сервер и вывода результата запроса в консоль.
        P.S. не стал его удалять, вдруг он будет вам чем-то полезен.
        */
         
        const string connectionString = "Server=localhost;Database=master;User=sa;Password=MS@sqlpassword;Encrypt=False;";

        using var connection = new SqlConnection(connectionString);
        await connection.OpenAsync();
        
        var command = new SqlCommand(request, connection);
        using var reader = await command.ExecuteReaderAsync();
        
        while (await reader.ReadAsync()) 
        {
            Console.WriteLine($"{reader[0]} {reader[1]}");
        }
    }
}
