# Лабораторна робота №2

**Тема:** Використання методів розширень та узагальнень у C#

**Мета роботи:** Навчитися використовувати методи розширення та узагальнення у мові програмування C#.

**Виділений час:** 12 годин (4 години лабораторних робіт та 8 годин самостійної роботи)

---

## Структура проєкту

```
DotNetLab2/
├── lab 2 netcore.sln          # Solution файл
├── task 2/                     # Завдання 2: Методи розширення
│   ├── second task.cs         # Реалізація методів розширення
│   └── task 2.csproj          # Проєкт
└── task 3/                     # Завдання 3: Узагальнений словник
    ├── ExtendedDictionary.cs           # Клас розширеного словника
    ├── ExtendedDictionaryElement.cs    # Клас елемента словника
    ├── Program.cs                      # Демонстраційний код
    └── task 3.csproj                   # Проєкт
```

---

## Завдання 2: Методи розширення

### Вимоги

Реалізовано методи розширення:

#### Для класу `String`:
- **`Reverse()`** - інвертування рядка
- **`CountOccurrences(char character)`** - підрахунок кількості входжень заданого символа у рядок

#### Для одновимірних масивів:
- **`CountOccurrences<T>(T value)`** - метод, що визначає скільки разів зустрічається задане значення у масиві
  - Метод працює для одновимірних масивів усіх типів
  - Використано узагальнення та обмеження `where T : IEquatable<T>`
- **`GetUniqueElements<T>()`** - метод, що повертає новий масив такого ж типу і формує його з унікальних елементів (видаляє повтори)

### Структура коду

```csharp
// Методи розширення для String
public static class StringExtensions
{
    public static string Reverse(this string str)
    public static int CountOccurrences(this string str, char character)
}

// Методи розширення для масивів
public static class ArrayExtensions
{
    public static int CountOccurrences<T>(this T[] array, T value) where T : IEquatable<T>
    public static T[] GetUniqueElements<T>(this T[] array) where T : IEquatable<T>
}
```

### Приклади використання

```csharp
// Робота з рядками
string example = "hello world";
string reversed = example.Reverse();                    // "dlrow olleh"
int count = example.CountOccurrences('l');               // 3

// Робота з масивами
int[] numbers = { 1, 2, 3, 4, 2, 5, 2, 6, 3, 2 };
int occurrences = numbers.CountOccurrences(2);           // 4
int[] unique = numbers.GetUniqueElements();             // [1, 2, 3, 4, 5, 6]
```

---

## Завдання 3: Узагальнений словник

### Вимоги

Реалізовано узагальнений клас для зберігання "розширеного словника" (для ключа передбачається два значення).

#### Клас `ExtendedDictionaryElement<T, U, V>`
- `T` - тип даних ключа
- `U` - тип даних першого значення
- `V` - тип даних другого значення

**Властивості:**
- `Key` - ключ елемента
- `Value1` - перше значення
- `Value2` - друге значення

#### Клас `ExtendedDictionary<T, U, V>`

**Операції:**
- ✅ `Add(T key, U value1, V value2)` - додавання елемента у словник
- ✅ `Remove(T key)` - видалення елемента з словника за заданим ключем
- ✅ `ContainsKey(T key)` - перевірка наявності елемента із заданим ключем
- ✅ `ContainsValue(U value1, V value2)` - перевірка наявності елемента із заданими значеннями (обидва значення)
- ✅ `ContainsValue1(U value1)` - перевірка наявності елемента із заданим першим значенням
- ✅ `ContainsValue2(V value2)` - перевірка наявності елемента із заданим другим значенням
- ✅ `this[T key]` - повернення елемента за заданим ключем (реалізовано операцію індексування)
- ✅ `Count` - властивість, що повертає кількість елементів
- ✅ Підтримка `foreach` - словник можна використовувати у циклах `foreach`

### Структура коду

```csharp
// Клас елемента словника
public class ExtendedDictionaryElement<T, U, V>
{
    public T Key { get; }
    public U Value1 { get; }
    public V Value2 { get; }
}

// Клас розширеного словника
public class ExtendedDictionary<T, U, V> : IEnumerable<ExtendedDictionaryElement<T, U, V>> 
    where T : notnull
{
    // Реалізація всіх необхідних методів та властивостей
}
```

### Приклади використання

```csharp
// Створення словника
var dict = new ExtendedDictionary<string, int, string>();

// Додавання елементів
dict.Add("key1", 100, "value1");
dict.Add("key2", 200, "value2");
dict.Add("key3", 300, "value3");

// Перевірка кількості
Console.WriteLine(dict.Count);  // 3

// Перевірка наявності за ключем
bool exists = dict.ContainsKey("key2");  // true

// Перевірка наявності за значеннями
bool hasBoth = dict.ContainsValue(200, "value2");  // true
bool hasValue1 = dict.ContainsValue1(200);         // true
bool hasValue2 = dict.ContainsValue2("value2");    // true

// Отримання елемента за ключем
var element = dict["key1"];
Console.WriteLine($"{element.Value1}, {element.Value2}");  // 100, value1

// Видалення елемента
dict.Remove("key2");

// Ітерація через словник
foreach (var elem in dict)
{
    Console.WriteLine($"Key: {elem.Key}, Value1: {elem.Value1}, Value2: {elem.Value2}");
}
```

---

## Вимоги до середовища

- **.NET SDK 8.0** або новіша версія
- **Visual Studio 2022** або **Visual Studio Code** (опціонально)
- **Windows**, **Linux** або **macOS**

---

## Інструкції з запуску

### 1. Клонування репозиторію

```bash
git clone <repository-url>
cd DotNetLab2
```

### 2. Відновлення залежностей

```powershell
# З кореневої директорії solution
dotnet restore
```

### 3. Компіляція проєктів

```powershell
# Компіляція всього solution
dotnet build

# Або окремо кожен проєкт
cd "task 2"
dotnet build

cd "../task 3"
dotnet build
```

### 4. Запуск програм

```powershell
# Запуск завдання 2
cd "task 2"
dotnet run

# Запуск завдання 3
cd "../task 3"
dotnet run
```

### 5. Запуск через Visual Studio

1. Відкрийте `lab 2 netcore.sln` у Visual Studio
2. Виберіть проєкт (`task 2` або `task 3`) як стартовий
3. Натисніть `F5` або `Ctrl+F5` для запуску

---

## Очікуваний результат виконання

### Завдання 2

```
Reversed: dlrow olleh
Occurrences of 'l': 3
Occurrences of 2: 4
Unique elements: 1, 2, 3, 4, 5, 6
```

### Завдання 3

```
Count: 3
Contains 'key2': True
Contains (200, 'value2'): True
Contains Value1 = 200: True
Contains Value1 = 999: False
Contains Value2 = 'value2': True
Contains Value2 = 'nonexistent': False
Element 'key1': (100, value1)
Count after remove: 2
Key: key1, Value1: 100, Value2: value1
Key: key3, Value1: 300, Value2: value3
```

---

## Технічні деталі

### Використані технології та концепції

- **Методи розширення (Extension Methods)** - додавання функціональності до існуючих типів
- **Узагальнення (Generics)** - створення типобезпечних класів та методів
- **Обмеження узагальнень (Generic Constraints)** - `where T : IEquatable<T>`, `where T : notnull`
- **Індексатори (Indexers)** - доступ до елементів за допомогою синтаксису масивів
- **Ітератори (IEnumerable)** - підтримка циклу `foreach`
- **Nullable Reference Types** - обробка можливих null значень

### Особливості реалізації

- Використано `EqualityComparer<T>.Default` для безпечного порівняння значень
- Додано обмеження `where T : notnull` для ключів словника
- Методи розширення для масивів використовують обмеження `where T : IEquatable<T>`
- Реалізовано повну підтримку `IEnumerable<T>` для використання у циклах `foreach`

---

Семенюк Богдан ВТ22-2


