using System.Text.RegularExpressions;


class Regulars
{
    static void Main(string[] args)
    {
        string[] input = File.ReadAllLines(@"text.txt");
        Dictionary<Regex, int> regexDict = new Dictionary<Regex, int> {
            { new Regex(@"^a$"), 1 }, // a
            { new Regex(@"^a{6}$"), 2 }, // aaaaaa
            { new Regex(@"^a aa a$"), 3 }, // a aa a
            { new Regex(@"^[A-Za-z0-9]{5,}[^aaaaaa]$"), 4 }, // Не менее 5-ти алфавитно-цифровых символов
            { new Regex(@"^[a-zA-Z0-9._-]+@[a-zA-Z0-9._-]+\.[a-zA-Z0-9_-]+$"), 5 }, // email
            { new Regex(@"^(?:[уУ][лЛ]\.\s+)?([а-яА-ЯёЁ]+(\-[а-яА-ЯёЁ]+)?)\,?\s+(?:[дД]\.\s+)?(\d+(?:[\-\/]\d+)?)$"), 6 } // Ул.строка д.число/число
        };

        foreach (var kvp in regexDict)
        {
            var regex = kvp.Key;
            var number = kvp.Value;
            for (int i = 0; i < input.Length; i++)
            {
                if (regex.IsMatch(input[i]))
                {
                    Console.WriteLine($"{number}) {input[i]}");
                }
            }
        }

        // добавляем ручной ввод адреса
        Console.WriteLine("Введите адрес:");
        string address = Console.ReadLine();

        // создаем экземпляр Regex для адреса
        Regex addressRegex = new Regex(@"^(?:[уУ][лЛ]\.\s+)?([а-яА-ЯёЁ]+(\-[а-яА-ЯёЁ]+)?)\,?\s+(?:[дД]\.\s+)?(\d+(?:[\-\/]\d+)?)$");

        // применяем регулярное выражение к введенной строке
        Match match = addressRegex.Match(address);
        if (match.Success)
        {
            // получаем отдельно название улицы и номер дома
            string streetName = match.Groups[1].Value;
            string houseNumber = match.Groups[3].Value;
            Console.WriteLine($"Название улицы: {streetName}");
            Console.WriteLine($"Номер дома: {houseNumber}");
        }
        else
        {
            Console.WriteLine("Адрес не соответствует шаблону.");
        }
    }
}







