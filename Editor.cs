using System;
using System.Text;
using System.IO;

namespace HtmlEditor
{
    public static class Editor
    {
        // method responsible for displaying edit mode
        public static void Show()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine("Editor Mode");
            Console.WriteLine("----------------");
            Start();
        }
        //method responsible for starting new file creation
        static void Start()
        {
            var file = new StringBuilder();

            do
            {
                file.Append(Console.ReadLine());
                file.Append(Environment.NewLine);
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);
            Console.WriteLine("----------------");
            ToSave(file.ToString());
        }

        //responsible method to decide the file will be saved
        static void ToSave(string text)
        {
            Console.WriteLine("do you want to save this file? (y/n): ");
            var option = Console.ReadLine().ToLower();
            switch (option)
            {
                case "y": Saving(text); break;
                case "n": Viewer.Show(text); break;
                default: Console.Clear(); ToSave(text); break;
            }
        }

        // responsible method to save the file
        static void Saving(string text)
        {
            Console.Clear();
            Console.WriteLine("Which path to save the file? ");
            var path = Console.ReadLine();

            using (var file = new StreamWriter(path))
            {
                file.Write(text);
            }
            Console.WriteLine($"file {path} saved successfully");
            Console.ReadKey();
            Menu.Show();
        }
    }
}