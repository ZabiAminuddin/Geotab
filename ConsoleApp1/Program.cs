using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsoleApp1
{
    class Program
    {
        static string[] results = new string[50];
        static char key;
        static Tuple<string, string> names;
        static ConsolePrinter printer = new ConsolePrinter();

        static void Main(string[] args)
        {
            //Getting instructions to begin the application  
            if (GetInstructions())
            {
                while (true)
                {
                    printer.Value("Press c to get Categories").ToString();
                    printer.Value("Press r to get Random jokes").ToString();
                    printer.Value("Press q to Quit").ToString();
                    
                    GetEnteredKey(Console.ReadKey());
                    //Categories
                    if (key == 'c')
                    {
                        getCategories();
                        PrintResults();
                    }
                    //Random Jokes
                    if (key == 'r')
                    {
                        RandomJokesImpl();
                    }
                    //Quit
                    if (key == 'q')
                    {
                        Environment.Exit(0);
                    } 
                    
                    names = null;
                }
            }

        }

        //This method is used to check if Enter is pressed to continue
        private static Boolean GetInstructions(){
            printer.Value("Please Press Enter to get instructions.").ToString();
            var KP = Console.ReadKey();
             if (!(KP.Key == ConsoleKey.Enter))
            {
                Console. WriteLine();
                GetInstructions();
            } 
             return true;
        }
        //Implementation for Random Jokes
        private static void RandomJokesImpl()
        {
            Console. WriteLine("If any key other than y is pressed, by default n will be selected ");
            printer.Value("Want to use a random name? y/n").ToString();
            
            GetEnteredKey(Console.ReadKey());
            if (key == 'y')
                GetNames();
            printer.Value("Want to specify a category? y/n").ToString();
            GetEnteredKey(Console.ReadKey());
            
            if (key == 'y')
            {
                ProcessNumberOfJokesandCategory();
            }
            else
            {
                ProcessNumberOfJokesWithOutCategory();
            }
        }
        //Processing jokes with category
        private static void ProcessNumberOfJokesandCategory()
        {
            int n = 0;
            try {
                printer.Value("How many jokes do you want? (1-9)").ToString();
               
                Int32.TryParse(Console.ReadLine(), out n);
            } catch (FormatException)
            {
                printer.Value("Please enter number of jokes in Range 1 to 9").ToString();
                ProcessNumberOfJokesandCategory();
            }
            
            if (!(Enumerable.Range(1,9).Contains(n))) {
                printer.Value("Please enter number of jokes in Range 1 to 9").ToString();
                ProcessNumberOfJokesandCategory();
            }
            getCategories();
            GetCategoryVal(n);
        }

         private static void GetCategoryVal(int n){
            PrintResults();
            printer.Value("Enter a category from list ").ToString();
            string catgry = Console.ReadLine();
            if(!String.IsNullOrEmpty(catgry) &&CheckCategory(catgry)) {
                GetNumberOfJokes(catgry, n);
            } else {
                GetCategoryVal(n);
            }
        }

        private static Boolean CheckCategory(string category){
            foreach (var item in results){
              if (item.Contains(category)){
                 return true;
              }
            }
            return false;
                
        }

        private static void GetNumberOfJokes(string category,int n)
        {
            for(int i=0; i<n;i++) {
                GetRandomJokes(category, n);
                PrintResults(i+1);
                Console. WriteLine();
            }
            
        }

         private static void ProcessNumberOfJokesWithOutCategory()
        {
            int n = 0;
            try {
                printer.Value("How many jokes do you want? (1-9)").ToString();
                Int32.TryParse(Console.ReadLine(), out n);
            } catch (FormatException)
            {
                printer.Value("Please enter number of jokes in Range 1 to 9").ToString();
                ProcessNumberOfJokesWithOutCategory();
            }
            if (Enumerable.Range(1,9).Contains(n)) {
                GetNumberOfJokes(null,n);
            } else {
                printer.Value("Please enter number of jokes in Range 1 to 9").ToString();
                ProcessNumberOfJokesWithOutCategory();
            }
        }

         private static void PrintResults()
        {
            printer.Value("[" + string.Join(",", results) + "]").ToString();
        }

        private static void PrintResults(int n)
        {
            printer.Value( n + ": " + string.Join(",", results)).ToString();
        }

        private static void GetEnteredKey(ConsoleKeyInfo consoleKeyInfo)
        {
            switch (consoleKeyInfo.Key)
            {
                case ConsoleKey.C:
                    key = 'c';
                    break;
                case ConsoleKey.D0:
                    key = '0';
                    break;
                case ConsoleKey.D1:
                    key = '1';
                    break;
                case ConsoleKey.D3:
                    key = '3';
                    break;
                case ConsoleKey.D4:
                    key = '4';
                    break;
                case ConsoleKey.D5:
                    key = '5';
                    break;
                case ConsoleKey.D6:
                    key = '6';
                    break;
                case ConsoleKey.D7:
                    key = '7';
                    break;
                case ConsoleKey.D8:
                    key = '8';
                    break;
                case ConsoleKey.D9:
                    key = '9';
                    break;
                case ConsoleKey.R:
                    key = 'r';
                    break;
                case ConsoleKey.Y:
                    key = 'y';
                    break;
                case ConsoleKey.Q:
                    key = 'q';
                    break;
                default:
                    key = 'n';
                    break;
            }
            Console. WriteLine();
        }

        private static void GetRandomJokes(string category, int number)
        {
            new JsonFeed("https://api.chucknorris.io", number);
            results = JsonFeed.GetRandomJokes(names?.Item1, names?.Item2, category);
        }

        private static void getCategories()
        {
            new JsonFeed("https://api.chucknorris.io", 0);
            results = JsonFeed.GetCategories();
        }

        private static void GetNames()
        {
            new JsonFeed("https://www.names.privserv.com/api/", 0);
            dynamic result = JsonFeed.Getnames();
            names = Tuple.Create(result.name.ToString(), result.surname.ToString());
        }
    }
}
