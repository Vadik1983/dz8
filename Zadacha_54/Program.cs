﻿/* Задача 54: Задайте двумерный массив. Напишите программу,
которая упорядочит по убыванию элементы каждой строки двумерного массива.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
В итоге получается вот такой массив:
7 4 2 1
9 5 3 2
8 4 4 2   */

int rows = 0;
int columns = 0;
int min = 0;
int max = 0;

inputRowsColumns(ref rows, ref columns);
inputMinMax(ref min, ref max);
int[,] array = GetRandomArray(rows, columns, min, max);
PrintArray(array);
Console.WriteLine();
//GetStructurArray(array);
PrintStructurArray(array);
/////////////////////////////////////////////

void inputRowsColumns(ref int rows, ref int columns)
{
    try
    {
        Console.Write($"Введите количество строк: ");
        rows = int.Parse(Console.ReadLine() ?? "");
        Console.Write($"Введите количество столбцов: ");
        columns = int.Parse(Console.ReadLine() ?? "");
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

int[,] GetRandomArray(int rows, int columns, int min, int max)
{
    int[,] result = new int [rows,  columns];
    var rnd = new Random();
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        { 
            result[i,j] = rnd.Next((int)min, (int)max);
        }
    }
    return result;
}

void PrintArray(int[,] inArray)
{
    for(int i = 0; i < inArray.GetLength(0); i++)
    { 
        for(int j = 0; j < inArray.GetLength(1); j++)
        {
            Console.Write($"{inArray[i,j]}  ");
        }
        Console.WriteLine();
    }
}



/*int[,] GetStructurArray(int[,] array)
{
    int[,] result = new int [rows,  columns];
    for (int i = 0; i < rows - 1; i++)
    {
        for (int j = 0; j < columns - 1; j++)
        { 
             if(array[i,j] < array[i + 1, j + 1])
                {
                    int temp = array[i,j];
                    array[i,j] = array[i + 1, j + 1];
                    array[i + 1, j + 1] = temp;
                }
        }
    }
    return result;
}*/
void PrintStructurArray(int[,] inArray)
{
    int j = 0;
    int i = 0;
    
    for(i = 0; i < columns; i++)
    { 
        for(j = 0; j < rows; j++)
        {
            if(( inArray[i,j]< inArray[i + 1, j]) &&  i < rows)
                {
                    int temp = inArray[i,j];
                    inArray[i,j] = inArray[i + 1, j];
                    inArray[i + 1, j] = temp;
                    
                }
            Console.Write($"{inArray[i,j]}  ");
        }
        Console.WriteLine();
    }
}