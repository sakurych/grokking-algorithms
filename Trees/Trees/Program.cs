namespace Trees
{
    internal class Program
    {
        public static Dictionary<string, string[]> file_system = new Dictionary<string, string[]>();

        static void Main(string[] args)
        {
            file_system.Add("first.folder", new string[] { "second.folder", "third.folder", "first.pict" });
            file_system.Add("second.folder", new string[] { "fourth.folder", "third.folder", "second.pict" });
            file_system.Add("third.folder", new string[] { "fifth.folder", "third.pict" });
            file_system.Add("fourth.folder", new string[] { });
            file_system.Add("fifth.folder", new string[] { "fourth.pict" });

            var queue = new Queue<string>(file_system["first.folder"]);
            Console.WriteLine("BreadthFirstSearch");
            BreadthFirstSearch(queue);
            Console.WriteLine("DeepFirstSerch");
            DeepFirstSerch(queue);
        }

        static void BreadthFirstSearch(Queue<string> queue)
        {
            while (queue.Count > 0)
            {
                var item = queue.Dequeue();
                if (item.EndsWith("pict"))
                    Console.WriteLine(item);
                else
                    foreach (var name in file_system[item])
                        queue.Enqueue(name);
            }
        }

        static void DeepFirstSerch(Queue<string> queue)
        {
            while (queue.Count > 0)
            {
                if (queue.Count == 0)
                    return;

                var item = queue.Dequeue();
                if (item.EndsWith("pict"))
                    Console.WriteLine(item);
                else
                    DeepFirstSerch(new Queue<string>(file_system[item]));
            }
        }
    }
}
