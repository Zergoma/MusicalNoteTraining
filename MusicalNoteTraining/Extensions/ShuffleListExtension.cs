using System;
using System.Collections.Generic;
using System.Text;

namespace MusicalNoteTraining.Extensions
{
    public static class ShuffleListExtension
    {
        private static Random rng = Random.Shared;

        public static void ShuffleIt<T>(this List<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
