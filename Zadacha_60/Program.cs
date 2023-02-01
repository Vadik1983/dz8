/*Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел.
Напишите программу, которая будет построчно выводить массив,
 добавляя индексы каждого элемента.
Массив размером 2 x 2 x 2
66(0,0,0) 25(0,1,0)
34(1,0,0) 41(1,1,0)
27(0,0,1) 90(0,1,1)
26(1,0,1) 55(1,1,1)  */

int rows = 0;
int columns = 0;
int depth = 0;
int min = 0;
int max = 0;

inputRowsColumns(ref rows, ref columns, ref depth);
inputMinMax(ref min, ref max);
int[,,] array = GetRandomArray(rows, columns, depth, min, max);
PrintArray(array);

/////////////////////////////////////////////

void inputRowsColumns(ref int rows, ref int columns, ref int depth)
{
    try
    {
        Console.Write($"Введите количество строк: ");
        rows = int.Parse(Console.ReadLine() ?? "");
        Console.Write($"Введите количество столбцов: ");
        columns = int.Parse(Console.ReadLine() ?? "");
        Console.Write($"Введите глубину массива: ");
        depth = int.Parse(Console.ReadLine() ?? "");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Ошибка ввода!", ex);
    }
}

void inputMinMax(ref int min, ref int max)
{
    try
    {
        Console.Write($"Введите минимальное значение: ");
        min = int.Parse(Console.ReadLine() ?? "");
        Console.Write($"Введите максимальное значение: ");
        max = int.Parse(Console.ReadLine() ?? "");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Ошибка ввода!", ex);
    }
}

int[,,] GetRandomArray(int rows, int columns, int depth, int min, int max)
{
    int[,,] result = new int[rows, columns, depth];
    var rnd = new Random();
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            for (int x = 0; x < depth; x++)
            {
                result[i, j, x] = rnd.Next((int)min, (int)max);
            }
        }
    }
    return result;
}

void PrintArray(int[,,] inArray)
{
    for (int i = 0; i < inArray.GetLength(0); i++)
    {
        for (int j = 0; j < inArray.GetLength(1); j++)
        {
            for (int x = 0; x < inArray.GetLength(2); x++)
            {
                Console.Write($"{inArray[i, j, x]} ({i}{j},{x})");
            }
            Console.WriteLine();
        }
    }
}
