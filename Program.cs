using System;
using FinalPract1;

namespace FinalPract1
{
    class Program
    {
        const int WindowWidth = 84;
        const int WindowHeight = 25;

        static void Main()
        {
            Console.SetWindowSize(WindowWidth, WindowHeight);
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Clear();

            var files = FileRepository.GetMockFiles();
            var renderer = new NcRenderer(WindowWidth, WindowHeight);

            renderer.DrawMenuBar();
            renderer.DrawFrame();
            renderer.DrawCatalogInfo();
            renderer.DrawLeftPanel(files);
            renderer.DrawRightPanel(files);
            renderer.DrawTerminalLine(); // Теперь перед горячими клавишами
            renderer.DrawHotKeys();

            // Обработка пользовательского ввода в терминальной строке
            HandleTerminalInput(renderer);
        }

        static void HandleTerminalInput(NcRenderer renderer)
        {
            string input = "";
            ConsoleKeyInfo keyInfo;

            do
            {
                keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    // Обработка команды
                    if (!string.IsNullOrEmpty(input))
                    {
                        ProcessCommand(input, renderer);
                        input = "";
                        renderer.DrawTerminalLine();
                    }
                }
                else if (keyInfo.Key == ConsoleKey.Backspace)
                {
                    if (input.Length > 0)
                    {
                        input = input.Substring(0, input.Length - 1);
                        UpdateTerminalInput(input);
                    }
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    input += keyInfo.KeyChar;
                    Console.Write(keyInfo.KeyChar);
                }

            } while (keyInfo.Key != ConsoleKey.Escape); // ESC для выхода
        }

        static void UpdateTerminalInput(string input)
        {
            int terminalY = WindowHeight - 3; // Позиция терминальной строки
            Console.SetCursorPosition(6, terminalY);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(input + new string(' ', WindowWidth - 6 - input.Length));
            Console.SetCursorPosition(6 + input.Length, terminalY);
        }

        static void ProcessCommand(string command, NcRenderer renderer)
        {
            // Простая обработка команд
            command = command.Trim().ToLower();

            // Очистка экрана и перерисовка
            if (command == "cls" || command == "clear")
            {
                Console.Clear();
                renderer.DrawMenuBar();
                renderer.DrawFrame();
                renderer.DrawCatalogInfo();
                renderer.DrawLeftPanel(FileRepository.GetMockFiles());
                renderer.DrawRightPanel(FileRepository.GetMockFiles());
                renderer.DrawTerminalLine();
                renderer.DrawHotKeys();
            }
            // Можно добавить другие команды здесь
        }
    }
}