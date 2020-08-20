using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            IBook book = new DiskBook("Nazar`s Grade Book");
            book.GradeAdded += OnGradeAdded;

            EnterGrades(book);

            Stats stats = book.GetStats();
            Console.WriteLine($"For the book named {book.Name}");
            Console.WriteLine($"The lowest grade is {stats.Low}");
            Console.WriteLine($"The highest grade is {stats.High}");
            Console.WriteLine($"The avarage grade is: {stats.Avarage:N1}");
            Console.WriteLine($"The letter grade is: {stats.Letter}");

            static void OnGradeAdded(object sender, EventArgs e)
            {
                Console.WriteLine("The grade was added");
            }
        }

        private static void EnterGrades(IBook book)
        {
            while (true)
            {
                Console.WriteLine("Enter a grade or q to quit: ");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }

                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                    book.AddGrade('A');
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("");
                }
            }
        }
    }
}
