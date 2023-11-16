using System.Collections;
using System;
public class MyList<T>:IEnumerable<T>
{
    public T[]? _list;
    public MyList() { }
    public T[] List { get => _list; set => _list = value; }

    //метод добавления элемента
    public void Add(T value)
    {
        if (this.List != null)
        {
            T[] array = this.List;
            Array.Resize(ref array, this.List.Length + 1);
            array[array.Length - 1] = value;
            this.List = array;
        }
        else
        {
            this.List = new T[] { value };
        }
    }
    //индексатор для получения значения элемента по указанному индексу
    public T this[int index] { get => this.List[index]; }

    //свойство только для чтения для получения общего количества элементов
    public int Count
    {
        get
        {
            if (this.List == null)
            {
                return 0;
            }
            return this.List.Length;
        }
    }

    //поддержка блока инициализации


    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
        return (IEnumerator<T>)this.List.GetEnumerator();
    }
}
public class program
{
    static void Main(string[] args)
    {
        MyList<int> my_array = new MyList<int>() { 1,2,3,4,5,6,7};
        Console.WriteLine("Проверка количества элементов в пустом массиве: ");
        Console.WriteLine(my_array.Count);
        my_array.Add(8);
        my_array.Add(12);
        Console.WriteLine("Проверка метода Add: ");
        foreach (int i in my_array)
        {
            Console.WriteLine(i);
        }
        my_array.Add(32);
        Console.WriteLine("Проверка метода Count: ");
        Console.WriteLine(my_array.Count);
        my_array.Add(41);
        Console.WriteLine("Вывод всего массива: ");
        Console.WriteLine($"{my_array[0]} {my_array[2]} {my_array[3]}");
    }
}