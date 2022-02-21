using System;

namespace HtmlEditor
{
    class Menu
    {
        // method responsible for displaying full menu
        public static void Show()
        {
            DrawScreen();
            WriteOptions();

            var option = short.Parse(Console.ReadLine());
            HandlerOptionMenu(option);
        }

        // Responsible method draw rows and columns on screen
        static void DrawScreen()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Black;
            Columns();
            Lines();
            Columns();
        }

        // responsible method display options
        static void WriteOptions()
        {
            Console.SetCursorPosition(3, 1);
            Console.WriteLine("Html Editor: ");
            Console.SetCursorPosition(3, 3);
            Console.WriteLine("==================");
            Console.SetCursorPosition(3, 4);
            Console.WriteLine("Select an option");
            Console.SetCursorPosition(3, 6);
            Console.WriteLine("1 - New File");
            Console.SetCursorPosition(3, 7);
            Console.WriteLine("2 - Open a File");
            Console.SetCursorPosition(3, 9);
            Console.WriteLine("0 - Exit");
            Console.SetCursorPosition(3, 10);
            Console.Write("Your option: ");

        }

        // method responsible for creating columns
        static void Columns()
        {
            Console.Write("+");
            for (int i = 0; i <= 38; i++)
                Console.Write("-");
            Console.Write("+");
            Console.Write("\n");
        }

        //method responsible for creating lines
        static void Lines()
        {
            for (int lines = 0; lines <= 10; lines++)
            {
                Console.Write("|");
                for (int i = 0; i <= 38; i++)
                    Console.Write(" ");
                Console.Write("|");
                Console.Write("\n");
            }
        }

        // method responsible for redirecting to selected option
        static void HandlerOptionMenu(short option)
        {
            switch (option)
            {
                case 1: Editor.Show(); break;
                case 2: Viewer.OpenFile(); break;
                case 0:
                    {
                        Console.Clear(); Console.WriteLine("Closing program"); Environment.Exit(0); break;
                    }
                default: Show(); break;
            }
        }
    }
}