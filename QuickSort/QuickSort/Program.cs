namespace QuickSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var arr = Quiksort(new int[] { 9, 5, 2, 8, 3, 7, 4, 6, 1 });
            foreach (int i in arr)
                Console.WriteLine(i);
            Console.ReadKey();
        }

        static int[] Quiksort(int[] arr)
        {
            if (arr.Length < 2)
            {
                return arr;
            }
            else
            {
                var pivot = arr[0];
                var less = arr.Skip(1).Where(i => i < pivot);
                var greater = arr.Skip(1).Where(i => i > pivot);

                return (Quiksort(less.ToArray()).Concat(new int[] { arr[0] }).Concat(Quiksort(greater.ToArray()).ToArray())).ToArray();
            }
        }
    }
}
