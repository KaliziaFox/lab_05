//using System;
//using System.Drawing;
//using System.Net.NetworkInformation;
//using System.Numerics;

//public class MyMatrix
//{
//    private int[,] _matrix;
//    private int _rows, _cols;

//    public MyMatrix(int rows, int cols, int first_value, int last_value)
//    {
//        _rows = rows;
//        _cols = cols;
//        _matrix = new int[rows, cols];
//        Random random = new Random();

//        for (int i = 0; i < rows; i++)
//        {
//            for (int j = 0; j < cols; j++)
//            {
//                _matrix[i, j] = random.Next(first_value, last_value);
//            }
//        }
//    }

//    public int Rows { get => _rows; set => _rows = value; }
//    public int Cols { get => _cols; set => _cols = value; }
//    public int[,] Matrix { get => _matrix; set => _matrix = value; }
//    public int this[int index1, int index2] { get => Matrix[index1, index2]; set => Matrix[index1, index2] = value; }

//    public void Fill(int first_value, int last_value)
//    {
//        Random random = new Random();
//        for (int i = 0; i < this.Rows; i++)
//        {
//            for (int j = 0; j < this.Cols; j++)
//            {
//                this.Matrix[i, j] = random.Next(first_value, last_value);
//            }
//        }
//    }

//    public MyMatrix ChangeSize(int rows, int cols, int first_value, int last_value)
//    {
//        MyMatrix result = new MyMatrix(rows, cols, first_value, last_value);
//        for (int i = 0; i < Math.Min(rows, this.Rows); ++i)
//        {
//            for (int j = 0; j < Math.Min(cols, this.Cols); ++j)
//            {
//                result[i, j] = this[i, j];
//            }
//        }
//        return result;
//    }

//    public void ShowPartialy(int unic_rows1, int unic_colls1, int unic_rows2, int unic_colls2)
//    {
//        if (unic_rows1 > unic_rows2) (unic_rows1, unic_rows2) = (unic_rows2, unic_rows1);
//        if (unic_colls1 > unic_colls2) (unic_colls1, unic_colls2) = (unic_colls2, unic_colls1);
//        for (int i = unic_rows1 - 1; i < unic_rows2; ++i)
//        {
//            for (int j = unic_colls1 - 1; j < unic_colls2; ++j)
//            {
//                Console.Write($"{Matrix[i, j]} ");
//            }
//            Console.WriteLine();
//        }
//        Console.WriteLine();
//    }
//    public void Show()
//    {
//        for (int i = 0; i < this.Rows; i++)
//        {
//            for (int j = 0; j < this.Cols; j++)
//            {
//                Console.Write(this.Matrix[i, j] + " ");
//            }
//            Console.WriteLine();
//        }
//        Console.WriteLine();
//    }
//}

//public class program
//{
//    static void Main(string[] args)
//    {
//        Console.WriteLine("Введите количество столбцов матрицы:");
//        int cols = int.Parse(Console.ReadLine());
//        Console.WriteLine("Введите количество строк матрицы: ");
//        int rows = int.Parse(Console.ReadLine());
//        Console.WriteLine("Введите минимальное значение:");
//        int first_value = int.Parse(Console.ReadLine());
//        Console.WriteLine("Введите максимальное значение:");
//        int last_value = int.Parse(Console.ReadLine());
//        MyMatrix matrix = new MyMatrix(rows, cols, first_value, last_value);
//        Console.WriteLine("Исходная матрица:");
//        matrix.Show();
//        Console.WriteLine("Метод Fill:");
//        matrix.Fill(first_value, last_value);
//        matrix.Show();

//        Console.WriteLine("Введите новое количество строк матрицы:");
//        int new_rows = int.Parse(Console.ReadLine());
//        Console.WriteLine("Введите новое количество столбцов матрицы:");
//        int new_cols = int.Parse(Console.ReadLine());
//        Console.WriteLine("Метод ChangeSize:");
//        matrix = matrix.ChangeSize(new_rows, new_cols, first_value, last_value);
//        matrix.Show();

//        Console.WriteLine("Введите первую строку матрицы для вывода:");
//        int unic_rows1 = int.Parse(Console.ReadLine());
//        Console.WriteLine("Введите последнюю строку матрицы для вывода:");
//        int unic_rows2 = int.Parse(Console.ReadLine());
//        Console.WriteLine("Введите первый столбец матрицы для вывода:");
//        int unic_colls1 = int.Parse(Console.ReadLine());
//        Console.WriteLine("Введите последний столбец матрицы для вывода:");
//        int unic_colls2 = int.Parse(Console.ReadLine());
//        Console.WriteLine("Метод ShowPartialy:");
//        matrix.ShowPartialy(unic_rows1, unic_colls1, unic_rows2, unic_colls2);
//    }
//}