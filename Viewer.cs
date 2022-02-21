using System;
using System.IO;
using System.Text.RegularExpressions;

namespace HtmlEditor
{
    public static class Viewer
    {
        // method responsible for displaying view mode to read files
        public static void Show(string text)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine("View Mode");
            Console.WriteLine("----------------");
            Replace(text);
            Console.WriteLine("----------------");
            Console.ReadKey();
            Menu.Show();
        }

        // method responsible for displaying the text inside the html tag
        static void Replace(string text)
        {
            var strong = new Regex(@"<\s*strong[^>]*>(.*?)<\s*/\s*strong>");
            var words = text.Split(' ');
            for (var i = 0; i < words.Length; i++)
            {
                if (strong.IsMatch(words[i]))
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(
                        words[i].Substring(
                            words[i].IndexOf('>') + 1,
                            ((words[i].LastIndexOf('<') - 1) - words[i].IndexOf('>'))
                        )
                    );
                    Console.Write(" ");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(words[i]);
                    Console.Write(" ");
                }
            }
        }

        // method responsible for openning the file
        public static void OpenFile()
        {
            Console.Clear();
            Console.WriteLine("Which file path? ");
            var path = Console.ReadLine();

            using (var file = new StreamReader(path))
            {
                string text = file.ReadToEnd();
                Console.WriteLine(text);
                Show(text);
            }
        }
    }
}