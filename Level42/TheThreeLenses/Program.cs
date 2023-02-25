Console.Title = "The Three Lenses";


int[] numbers = { 1, 9, 2, 8, 3, 7, 4, 6, 5 };

IEnumerable<int> numbers_proc = ProceduralMethod(numbers);
IEnumerable<int> numbers_keyword = KeywordBasedMethod(numbers);
IEnumerable<int> numbers_methodcall =MethodCallBasedMethod(numbers);

Console.WriteLine("Procedural:");
foreach(int number in numbers_proc) Console.WriteLine(number);
Console.WriteLine("Keyword:");
foreach(int number in numbers_keyword) Console.WriteLine(number);
Console.WriteLine("Method call:");
foreach(int number in numbers_methodcall) Console.WriteLine(number);

IEnumerable<int> ProceduralMethod(int[] numbers)
{
    Array.Sort(numbers);
    List<int> result = new List<int>();
    foreach (int num in numbers)
        if (num % 2 == 0) result.Add(num * 2);
    return result;
}

IEnumerable<int> KeywordBasedMethod(int[] numbers)
{
    return from num in numbers where num % 2 == 0 orderby num select num * 2;
}

IEnumerable<int> MethodCallBasedMethod(int[] numbers)
{
    return numbers.Where(num => num % 2 == 0).OrderBy(num => num).Select(num => num * 2);
}