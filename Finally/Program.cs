using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finally
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentCatalog cb6part = new StudentCatalog()
            {
                Name = "C# Coding Bootcamp 6 Part-time"
            };

            cb6part.Add(new Student("George", 12));

            cb6part.Remove(new Student("Nick", 5));

            var maria = new Student("Maria", 20);
            try
            {
                maria["C#"] = 10;
                Console.WriteLine(maria["Python"]);
            }
            catch (StudentNotEnrolledException snre)
            {
                snre.Student[snre.Lesson] = 0;
            }
        }

        static void PrintList<T>(List<T> list)
        {
            try
            {
                foreach (var item in list)
                {
                    Console.WriteLine(item);
                    list.Remove(item);
                }
            }
            catch (ArgumentException)
            {
                // do whatever we can
                Console.WriteLine($"An exception occurred, list count: {list.Count}");
            }
            finally
            {
                Console.WriteLine("I'm in finally!");
            }
        }

    }
}
