using System.Buffers;

namespace Recursion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 2, 2, 5, 6, 7, 6 };
            var temp = new int[arr.Length - 1];
            Array.Copy(arr, 1, temp, 0, temp.Length);
            var sum = arr[0] + Sum(temp);
            Console.WriteLine(sum);
            Console.WriteLine(FindMax(new List<int> { 1, 2, 2, 2, 5, 6, 7, 6 }));
            Console.ReadKey();
        }

        static int Sum(int[] arr)
        {
            if (arr.Length == 1)
            {  
                return arr[0]; 
            }
            else
            {
                var temp = new int[arr.Length - 1];
                Array.Copy(arr, 1, temp, 0, temp.Length);
                return arr[0] + Sum(temp);
            }
        }

        static int FindMax(List<int> list)
        {
            if (list.Count == 1)
            {  
                return list[0];
            }
            else
            {
                return list.FirstOrDefault() > FindMax(list.Skip(1).ToList()) ? list.FirstOrDefault() : FindMax(list.Skip(1).ToList());
            }
        }
    }
}
