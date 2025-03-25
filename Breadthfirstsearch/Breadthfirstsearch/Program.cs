using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Xml.Linq;

namespace Breadthfirstsearch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var hash_table = new Hashtable(); /// Лучше использовать Dictionary, чтобы определить тип value.
            hash_table.Add("Вы", new string[] { "Алиса", "Боб", "Клэр" });
            hash_table.Add("Боб", new string[] { "Анунж", "Пегги" });
            hash_table.Add("Алиса", new string[] { "Пегги" });
            hash_table.Add("Клэр", new string[] { "Том", "Джонни" });
            hash_table.Add("Анунж", new string[] { });
            hash_table.Add("Пегги", new string[] { });
            hash_table.Add("Том", new string[] { });
            hash_table.Add("Джонни", new string[] { });

            Console.WriteLine(SearchSeller(hash_table));
        }

        static string SearchSeller(Hashtable table)
        {
            var search_queue = new Queue<string>();
            var searched = new List<string>();
            var counter = 1;
            foreach (var name in table["Вы"] as IEnumerable<string>)
            {
                search_queue.Enqueue(name);
                searched.Add(name);

            }

            while (search_queue.Count > 0)
            {
                var person = search_queue.Dequeue();
                if (PersonIsSeller(person))
                    return person;
                else
                    foreach (var name in table[person] as IEnumerable<string>)
                    {
                        if (searched.Contains(name))
                            continue;

                        search_queue.Enqueue(name);
                        searched.Add(name);
                    }
            }

            return "Нет Seller";
        }

        static bool PersonIsSeller(string person)
        {
            return person.EndsWith("Seller");
        }
    }
}
