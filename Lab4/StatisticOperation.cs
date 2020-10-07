using System;
using System.Linq;
namespace Lab4
{
    public static class StatisticOperation
    {
        public static int Sum(Set set)
        {
            int sum = 0;
            for (int i = 0; i < set.plenty.Length; i++)
            {
                sum += set.plenty[i];
            }
            return sum;
        }
        public static int Maxmin(Set set)
        {
            int max = set.plenty[0], min = set.plenty[0];
            for (int i = 1; i < set.plenty.Length; i++)
            {
                if (set.plenty[i] > max) max = set.plenty[i];
                if (set.plenty[i] < min) min = set.plenty[i];
            }
            return max - min;
        }
        public static int Count(Set set)
        {
            return set.plenty.Length;
        }
        public static string After(this string str)
        {
            return str.Replace(" ", ", ");
        }
        public static int Delete(this Set set)
        {
            int[] gg;
            gg=set.plenty.Distinct().ToArray();
            set.plenty = gg;
            return 0;
        }
    }
}
