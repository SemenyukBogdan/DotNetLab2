namespace task_3
{
   

class Program
    {
        static void Main()
        {
            var extendedDictionary = new ExtendedDictionary<string, int, string>();

            // Додавання елементів у словник
            extendedDictionary.Add("key1", 100, "value1");
            extendedDictionary.Add("key2", 200, "value2");
            extendedDictionary.Add("key3", 300, "value3");

            // Виведення кількості елементів у словнику
            Console.WriteLine($"Count: {extendedDictionary.Count}");

            // Перевірка наявності елемента за ключем
            Console.WriteLine($"Contains 'key2': {extendedDictionary.ContainsKey("key2")}");

            // Перевірка наявності елемента за значенням
            Console.WriteLine($"Contains (200, 'value2'): {extendedDictionary.ContainsValue(200, "value2")}");

            // Отримання елемента за ключем
            var element = extendedDictionary["key1"];
            Console.WriteLine($"Element 'key1': ({element.Value1}, {element.Value2})");

            // Видалення елемента за ключем
            extendedDictionary.Remove("key2");
            Console.WriteLine($"Count after remove: {extendedDictionary.Count}");

            // Використання foreach для ітерації через словник
            foreach (var elem in extendedDictionary)
            {
                Console.WriteLine($"Key: {elem.Key}, Value1: {elem.Value1}, Value2: {elem.Value2}");
            }
        }
    }

}

