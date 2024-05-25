namespace lab_2_netcore
{
    public static class StringExtensions
    {
        // Метод для інвертування рядка
        public static string Reverse(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return str;
            }

            char[] charArray = str.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        // Метод для підрахунку кількості входжень заданого символа
        public static int CountOccurrences(this string str, char character)
        {
            if (string.IsNullOrEmpty(str))
            {
                return 0;
            }

            int count = 0;
            foreach (char c in str)
            {
                if (c == character)
                {
                    count++;
                }
            }

            return count;
        }




    }


    public static class ArrayExtensions
    {
        // Метод для підрахунку кількості входжень заданого значення
        public static int CountOccurrences<T>(this T[] array, T value) where T : IEquatable<T>
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            int count = 0;
            foreach (var item in array)
            {
                if (item.Equals(value))
                {
                    count++;
                }
            }

            return count;
        }

        // Метод для отримання масиву унікальних елементів
        public static T[] GetUniqueElements<T>(this T[] array) where T : IEquatable<T>
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            HashSet<T> uniqueElements = new HashSet<T>(array);
            return uniqueElements.ToArray();
        }
    }

    internal class Program
    {
       


        static void demonstrationStringExtension()
        {
            ///// Код демонстрації методів класу розширення рядка
            string example = "hello world";

            // Використання методу для інвертування рядка
            string reversed = example.Reverse();
            Console.WriteLine("Reversed: " + reversed);  // Output: "dlrow olleh"

            // Використання методу для підрахунку кількості входжень символа 'l'
            int count = example.CountOccurrences('l');
            Console.WriteLine("Occurrences of 'l': " + count);  // Output: 3
        }

        static void demonstrationMethodsArrays()
        {
            /////Код демонстрації методів класу розширення рядка
            int[] numbers = { 1, 2, 3, 4, 2, 5, 2, 6, 3, 2 };

            // Використання методу для підрахунку кількості входжень значення 2
            int count = numbers.CountOccurrences(2);
            Console.WriteLine("Occurrences of 2: " + count);  // Output: 4

            // Використання методу для отримання масиву унікальних елементів
            int[] uniqueNumbers = numbers.GetUniqueElements();
            Console.WriteLine("Unique elements: " + string.Join(", ", uniqueNumbers));  // Output: 1, 2, 3, 4, 5, 6
        }
        static void Main(string[] args)
        {
            demonstrationStringExtension();

            demonstrationMethodsArrays();

           

        }
    }
}
