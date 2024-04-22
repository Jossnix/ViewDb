namespace ViewDb;

public static class ReceivingData
{
    public static int GetData()
    {
        var number = 0;
        var correctInput = false;
        while (!correctInput)
        {
            PrintTablesWithNumber();
            Console.WriteLine($"\nВведите номер таблицы для просмотра или 0 для выхода:");
            string input = Console.ReadLine();
            if (!Int32.TryParse(input, out number))
            {
                Console.WriteLine(
                    $"Введено некорректное значение: `{input}` не соответствующее int.\n");
                continue;
            }
            
            if(!Enum.IsDefined(typeof(TablesEnum), number))
            {
                Console.WriteLine($"Введённое число не соответствует предложенным вариантам.\n");
                continue;
            }

            correctInput = true;
        }

        return number;
    }

    private static void PrintTablesWithNumber()
    {
        var values = Enum.GetValues(typeof(TablesEnum));

        foreach (TablesEnum table in values)
        {
            if((int)table != 0)
            {
                Console.WriteLine("{0} {1}", (int)table, Enum.GetName(typeof(TablesEnum), table));
            }
        }
    }
}