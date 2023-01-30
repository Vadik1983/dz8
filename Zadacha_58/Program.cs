/*Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
Например, даны 2 матрицы:
2 4 | 3 4
3 2 | 3 3
Результирующая матрица будет:
18 20
15 18   */

int m = 0;
int n = 0;
int minValue = 0;
int maxValue = 0;

inputRowsColumns(ref m, ref n, ref minValue, ref maxValue);
int[,] array = GetArray(m, n, minValue, maxValue);
PrintArray(array);
Console.WriteLine();
int[,] array2 = GetArray2(m, n, minValue, maxValue);
PrintArray2(array2);
Console.WriteLine();
int[,] inMultResult = MultArray(array, array2);
PrintMultArray(inMultResult);

//////////////////////////////////////////
///// try/catch  ///////

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

///// матрица №1   /////////////////////

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

///// матрица №2   /////////////////////

int[,] GetArray2(int m, int n, int minValue, int maxValue)
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

void PrintArray2(int[,] inArray2)
{
    for (int i = 0; i < inArray2.GetLength(0); i++)
    {
        for (int j = 0; j < inArray2.GetLength(1); j++)
        {
            Console.Write($"{inArray2[i, j]} ");
        }
        Console.WriteLine();
    }
}

/////  результат умножения  ///////

int[,] MultArray(int[,] inArray, int[,] inarray2)
{
    int[,] multResult = new int[m, n];
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            for (int x = 0; x < m; x++)
            {
                multResult[i, j] += inArray[i, x] * inarray2[x, j];
            }
        }
    }
    return multResult;
}

void PrintMultArray(int[,] inMultResult)
{
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            Console.Write($"{inMultResult[i, j]} ");
        }
        Console.WriteLine();
    }
}