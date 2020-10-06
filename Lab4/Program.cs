using System;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            Set s1 = new Set(new int[6]{1, 5, 3, 54, 4, 43});
            Set s2 = new Set(new int[6] {10, 5, 33, 7, 2, 82});
            Set q1 = new Set(new int[6] { 1, 2, 3, 4, 5, 6 });
            Set q2 = new Set(new int[3] { 2, 3, 4});
            for (int i = 0; i < s1.plenty.Length; i++)
            {
                Console.WriteLine($"{s1.plenty[i]}");
            }
            Console.WriteLine("Прибавили в конец массива");
            s1 = s1 + 2;
            for (int i = 0; i < s1.plenty.Length; i++)
            {
                Console.WriteLine($"{s1.plenty[i]}");
            }
            Console.WriteLine("Объединение");
            Set s3 = s1 + s2;
            for (int i = 0; i < s3.plenty.Length; i++)
            {
                Console.WriteLine($"{s3.plenty[i]}");
            }
            Console.WriteLine("Пересечение");
            Set s4 = s1 * s2;
            for (int i = 0; i < s4.plenty.Length; i++)
            {
                Console.WriteLine($"{s4.plenty[i]}");
            }
            Console.WriteLine($"Мощность множества {s1.plenty.Length}");
            Console.WriteLine($"Подмно множества {q1-q2}");
        }
    }
    class Set
    {
        public int[] plenty;
        public int this[int index]
        {
            get
            {
                return plenty[index];
            }
            set
            {
                plenty[index] = value;
            }
        }
        public Set(int[] values)
        {
            plenty = values;
        }
        public static Set operator +(Set set, int value)
        {
            int l = set.plenty.Length;
            Array.Resize(ref set.plenty, ++l);
            set.plenty[--l] = value;
            return set;
        }
        public static Set operator +(Set s1, Set s2)
        {
            int[] z = new int[s1.plenty.Length + s2.plenty.Length];
            s1.plenty.CopyTo(z, 0);
            s2.plenty.CopyTo(z, s1.plenty.Length);
            return new Set(z);
        }
        public static Set operator *(Set s1, Set s2)
        {
            int len = 0, ind = 0;
            foreach(int w1 in s1.plenty)
            {
                foreach(int w2 in s2.plenty)
                {
                    if (w1 == w2)
                    {
                        len++;
                    }
                }
            }
            int[] z = new int[len];
            foreach (int w1 in s1.plenty)
            {
                foreach (int w2 in s2.plenty)
                {
                    if (w1 == w2)
                    {
                        z[ind] = w1;
                        ind++;
                    }
                }
            }
            return new Set(z);
        }
        public static bool operator -(Set s1, Set s2)
        {
            int buf = 0;
            for (int i = 0; i < s1.plenty.Length; i++)
            {
                for (int j = 0; j < s2.plenty.Length; j++)
                {
                    if (s1.plenty[i]== s2.plenty[j])
                    {
                        buf++;
                    }
                }
            }
            if (buf == s2.plenty.Length)
                return true;
            else
                return false;
        }
    }
}
