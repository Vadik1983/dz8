/* Задача 56: Задайте прямоугольный двумерный массив. 
Напишите программу, которая будет находить строку с наименьшей суммой элементов.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
5 2 6 7
Программа считает сумму элементов в каждой строке
и выдаёт номер строки с наименьшей суммой элементов: 1 строка*/
int m = 0;
int n = 0;
int minValue = 0;
int maxValue = 0;

inputRowsColumns(ref m, ref n, ref minValue, ref maxValue);
int[,] array = GetArray(m, n, minValue, maxValue);
PrintArray(array);
Console.WriteLine();
SumNumberRovs(array);

////////////////////////////////
void inputRowsColumns(ref int m, ref int n, ref int minValue, ref int maxValue)
{
    try
    {
        Console.Write($"Введите количество строк: ");
        m = int.Parse(Console.ReadLine() ?? "");
        Console.Write($"Введите количество столбцов: ");
        n = int.Parse(Console.ReadLine() ?? "");
        Console.Write($"Введите минимальное значение: ");
        minValue = int.Parse(Console.ReadLine() ?? "");
        Console.Write($"Введите максимальное значение: ");
        maxValue = int.Parse(Console.ReadLine() ?? "");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Ошибка ввода!", ex);
    }
}
///
int[,] GetArray(int m, int n, int minValue, int maxValue)
{
    int[,] result = new int[m, n];
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            result[i, j] = new Random().Next(minValue, maxValue + 1);
        }
    }
    return result;
}
///
void PrintArray(int[,] inArray)
{
    for (int i = 0; i < inArray.GetLength(0); i++)
    {
        for (int j = 0; j < inArray.GetLength(1); j++)
        {
            Console.Write($"{inArray[i, j]} ");
        }
        Console.WriteLine();
    }
}

/* Я загнал всё ввычисление в один метод, в который включил ещё пару методов.
 Немного неуклюже, но работает для любого количества строк и члюбых чисел.
 Работает, а дальше можно доработать!)))*/

void SumNumberRovs(int[,] inArray)
{
    {
        int min = 0;
        int max = 100;
        int[] newArray = GetSumArray(m, min, max);
        Console.WriteLine($"[{String.Join(", ", newArray)}]");

        int[] GetSumArray(int m, int min, int max)
        {
            int[] result = new int[m];

            for (int i = 0; i < m; i++)
            {
                Sum(result);
                void Sum(int[] result)
                {
                    for (int j = 0; j < n; j++)
                    {
                        result[i] += inArray[i, j];
                    }
                }
            }
            return result;
        }
        MinRow(newArray);
        void MinRow(int[] newArray)
        {
            int min = 0;
            for (int i = 0; i < m - 1; i++)
            {

                min = newArray[i];
                if (min < newArray[i + 1])
                    min = newArray[i];
                else
                    min = newArray[i + 1];
            }

            int index = Array.IndexOf(newArray, min);
            Console.WriteLine($"Строка с минимальной суммой {min} = {index}");
        }
    }
}