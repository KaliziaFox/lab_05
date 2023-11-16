using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

public class MyDictionary<TKey, TValue> : IEnumerable
{
    public class Elem
    {
        private TKey _key;
        private TValue _value;
        private int _next;
        private int _index;
        private int _capacity;
        public int Capacity { get => _capacity; }
        public Elem(TKey key, TValue value, int capacity = 10000)
        {
            _key = key;
            _value = value;
            _capacity = capacity;
            _index = key.GetHashCode() % Capacity;
            _next = -1;
        }
        public TKey Key { get => _key; }
        public TValue Value { get => _value; }
        public int Next { get => _next; set => _next = value; }
        public int Index { get => _index; }
        public override string ToString() { return Convert.ToString(Value); }
    }
    private static Elem[] _arr;
    private int[] _indexes;
    private int _capacity;
    public MyDictionary(int capacity = 10000)
    {
        _indexes = new int[capacity];
        _capacity = capacity;
        for (int i = 0; i < capacity; ++i)
        {
            _indexes[i] = -1;
        }
    }
    public int[] Indexes { get => _indexes; set => _indexes = value; }
    public static Elem[] Array_of_persons { get => _arr; set => _arr = value; }
    public int Capacity { get => _capacity; }
    public IEnumerator GetEnumerator() => Array_of_persons.GetEnumerator();
    public void Add(Elem person)
    {
        if (Indexes[person.Index] != -1)
        {
            person.Next = Indexes[person.Index];
        }
        if (Array_of_persons == null)
        {
            Indexes[person.Index] = 0;
            Array_of_persons = new Elem[] { person };
        }
        else
        {
            Indexes[person.Index] = Array_of_persons.Length;
            Elem[] copy = Array_of_persons;
            Array.Resize(ref copy, Array_of_persons.Length + 1);
            copy[copy.Length - 1] = person;
            Array_of_persons = copy;
        }
    }
    public TValue[] this[TKey key]
    {
        get
        {
            Elem person = Array_of_persons[Indexes[key.GetHashCode() % Capacity]];
            TValue[] names = { person.Value };
            if (person.Next == -1)
            {
                return names;
            }
            Elem next = Array_of_persons[Array_of_persons[Indexes[key.GetHashCode() % Capacity]].Next];
            while (true)
            {
                TValue[] copy = names;
                Array.Resize(ref copy, names.Length + 1);
                copy[copy.Length - 1] = next.Value;
                names = copy;
                if (next.Next == -1)
                {
                    return names;
                }
                next = Array_of_persons[next.Next];
            }
        }
    }
}
internal class Task3
{
    private static void Main()
    {
        MyDictionary<int, string>.Elem person1 = new(13, "Иванов Пётр");
        Console.WriteLine(person1.Index);
        MyDictionary<int, string>.Elem person2 = new(2, "Андреев Андрей");
        Console.WriteLine(person2.Index);
        MyDictionary<int, string>.Elem person3 = new(13, "Петров Иван");
        Console.WriteLine(person3.Index);
        MyDictionary<int, string> array_of_persons = new();
        array_of_persons.Add(person1);
        array_of_persons.Add(person2);
        array_of_persons.Add(person3);
        foreach (MyDictionary<int, string>.Elem person in array_of_persons)
        {
            Console.WriteLine($"Value = {person.Value} Key = {person.Key} Index = {person.Index} Next = {person.Next}");
        }
        foreach (string val in array_of_persons[2])
        {
            Console.WriteLine(val);
        }
        foreach (string val in array_of_persons[13])
        {
            Console.WriteLine(val);
        }
    }
}