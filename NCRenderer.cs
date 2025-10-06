using System;
using System.Collections.Generic;

namespace FinalPract1
{
    class NcRenderer
    {
        private readonly int WindowWidth;
        private readonly int WindowHeight;

        public NcRenderer(int width, int height)
        {
            WindowWidth = width;
            WindowHeight = height;

            // Устанавливаем синий фон по умолчанию для всего интерфейса
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Clear();
        }

        // Универсальный метод вывода ячейки таблицы (с позиционированием и цветами).
        private void WriteCell(int x, int y, string text, int width,
                               ConsoleColor fg = ConsoleColor.White,
                               ConsoleColor? bg = null)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = fg;
            Console.BackgroundColor = bg ?? ConsoleColor.DarkBlue;
            Console.Write(text.PadRight(width));
        }

        // Рисует строку "Каталог" с датой и временем (нижняя часть панелей).
        private void WriteCatalogLine(int x, int y, string date, string time,
                                      int nameWidth = 15, int sizeWidth = 10)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            WriteCell(x, y, "..", nameWidth, ConsoleColor.Cyan);
            WriteCell(x + nameWidth, y, ">Каталог<", sizeWidth);
            Console.SetCursorPosition(x + nameWidth + sizeWidth, y);
            Console.Write(date + " " + time);
        }

        // Верхнее меню
        public void DrawMenuBar()
        {
            Console.SetCursorPosition(0, 0);
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.ForegroundColor = ConsoleColor.Black;

            string menu = " Левая       Файл        Диск        Команды        Правая ";
            Console.Write(menu.PadRight(WindowWidth));

            Console.SetCursorPosition(WindowWidth - 6, 0);
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.Write(" 8 30 ");

            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.DarkBlue;
        }

        // Отрисовка рамок, заголовков и внутренних разделителей панелей.
        public void DrawFrame()
        {
            int top = 1;
            int bottom = WindowHeight - 4; // Убираем отступ - терминальная строка сразу под рамкой
            int middleX = WindowWidth / 2 - 1;

            Console.ForegroundColor = ConsoleColor.Cyan;

            // Верхняя граница обеих панелей
            Console.SetCursorPosition(0, top);
            Console.Write("╔" + new string('═', middleX - 1) + "╦" +
                          new string('═', WindowWidth - middleX - 2) + "╗");

            Console.SetCursorPosition(WindowWidth / 4 - 3, top);
            Console.Write(@"C:\NC");

            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(WindowWidth - WindowWidth / 3 + 3, top);
            Console.Write(@"C:\NC");

            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Cyan;

            // Вертикальные линии рамок
            for (int y = top + 1; y < bottom; y++)
            {
                Console.SetCursorPosition(0, y); Console.Write("║");
                Console.SetCursorPosition(middleX, y); Console.Write("║");
                Console.SetCursorPosition(WindowWidth - 1, y); Console.Write("║");
            }

            // Линия-разделитель над строкой "Каталог"
            int catalogLineY = bottom - 1;
            Console.SetCursorPosition(0, catalogLineY - 1);
            Console.Write("╠" + new string('═', middleX - 1) + "╬" +
                          new string('═', WindowWidth - middleX - 2) + "╣");

            // Нижняя граница
            Console.SetCursorPosition(0, bottom);
            Console.Write("╚" + new string('═', middleX - 1) + "╩" +
                          new string('═', WindowWidth - middleX - 2) + "╝");

            Console.SetCursorPosition(2, top + 1);
            Console.Write("C:↓ Имя".PadRight(14) + "Имя".PadRight(13) + "Имя".PadRight(11));

            // Внутренние разделители в левой панели
            int colWidth = (WindowWidth / 2 - 2) / 3;
            for (int c = 1; c <= 2; c++)
            {
                for (int y = top + 1; y < catalogLineY - 1; y++)
                {
                    Console.SetCursorPosition(1 + colWidth * c, y);
                    Console.Write("║");
                }
                Console.SetCursorPosition(1 + colWidth * c, top); Console.Write("╦");
                Console.SetCursorPosition(1 + colWidth * c, catalogLineY - 1); Console.Write("╩");
            }

            int startX = middleX + 1;
            Console.SetCursorPosition(startX + 1, top + 1);
            Console.Write("C:↓ Имя".PadRight(13) + "Размер".PadRight(11) +
                          "Дата".PadRight(11) + "Время");

            // Внутренние разделители в правой панели
            int[] colPositions = { 13, 24, 35 };
            foreach (int offset in colPositions)
            {
                if (startX + offset < WindowWidth - 1)
                {
                    for (int y = top + 1; y < catalogLineY - 1; y++)
                    {
                        Console.SetCursorPosition(startX + offset, y);
                        Console.Write("║");
                    }
                    Console.SetCursorPosition(startX + offset, top); Console.Write("╦");
                    Console.SetCursorPosition(startX + offset, catalogLineY - 1); Console.Write("╩");
                }
            }
        }

        // Отрисовка содержимого левой панели (3 колонки).
        public void DrawLeftPanel(List<FileItem> files)
        {
            int colWidth = (WindowWidth / 2 - 2) / 3;
            int startX = 1, startY = 3;
            int row = 0, col = 0;

            int catalogLineY = WindowHeight - 5; // Учитываем терминальную строку и горячие клавиши
            files.Sort((a, b) => a.Name.CompareTo(b.Name));

            foreach (var f in files)
            {
                if (startY + row >= catalogLineY - 1) break;

                string name = ShortenName(f.Name, colWidth - 1);
                Console.SetCursorPosition(startX + col * colWidth + 1, startY + row);
                Console.ForegroundColor = f.IsDirectory ? ConsoleColor.Cyan : ConsoleColor.Gray;

                // Для третьего столбца добавляем пробел слева для смещения
                if (col == 2)
                {
                    Console.Write(" " + name.PadRight(colWidth - 2));
                }
                else
                {
                    Console.Write(name.PadRight(colWidth - 1));
                }

                col++;
                if (col == 3) { col = 0; row++; }
            }
        }

        // Отрисовка содержимого правой панели (имя/размер/дата/время).
        public void DrawRightPanel(List<FileItem> files)
        {
            int middleX = WindowWidth / 2 - 1;
            int startX = middleX + 1;
            int startY = 3, row = 0;

            // Смещения колонок относительно правой рамки
            int[] colOffsets = { 13, 24, 35 };

            int namePos = startX + 1, nameWidth = colOffsets[0] - 1;
            int sizePos = startX + colOffsets[0] + 1, sizeWidth = colOffsets[1] - colOffsets[0] - 1;
            int datePos = startX + colOffsets[1] + 1, dateWidth = colOffsets[2] - colOffsets[1] - 1;
            int timePos = startX + colOffsets[2] + 1, timeWidth = WindowWidth - 2 - timePos + 1;

            int catalogLineY = WindowHeight - 5; // Учитываем терминальную строку и горячие клавиши
            int maxRow = (catalogLineY - 1) - startY + 1;

            WriteCell(namePos, startY + row, "..", nameWidth, ConsoleColor.Black, ConsoleColor.Cyan);
            WriteCell(sizePos, startY + row, ">Каталог<", sizeWidth, ConsoleColor.Black, ConsoleColor.Cyan);
            WriteCell(datePos, startY + row, "01.01.95", dateWidth, ConsoleColor.Black, ConsoleColor.Cyan);
            WriteCell(timePos, startY + row, "00:00", timeWidth, ConsoleColor.Black, ConsoleColor.Cyan);
            row++;

            // Обычные файлы
            foreach (var f in files)
            {
                if (row >= maxRow - 1) break;

                string name = ShortenName(f.Name, nameWidth);
                string size = f.IsDirectory ? ">Каталог<" : f.Size.ToString();
                string date = f.DateModified.ToString("dd.MM.yy");
                string time = f.DateModified.ToString("HH:mm");

                WriteCell(namePos, startY + row, name, nameWidth, f.IsDirectory ? ConsoleColor.Cyan : ConsoleColor.White);
                WriteCell(sizePos, startY + row, size, sizeWidth);
                WriteCell(datePos, startY + row, date, dateWidth);
                WriteCell(timePos, startY + row, time, timeWidth);
                row++;
            }
        }

        public void DrawCatalogInfo()
        {
            string catalogDate = "01.01.95";
            string catalogTime = "00:00";
            int catalogRow = WindowHeight - 4; // Учитываем терминальную строку и горячие клавиши

            WriteCatalogLine(1, catalogRow - 1, catalogDate, catalogTime);
            WriteCatalogLine(WindowWidth / 2, catalogRow - 1, catalogDate, catalogTime);
        }

        // Отрисовка терминальной строки ввода (перед горячими клавишами)
        public void DrawTerminalLine()
        {
            int terminalY = WindowHeight - 3;

            Console.SetCursorPosition(0, terminalY);
            Console.BackgroundColor = ConsoleColor.Black; // Черный фон как у горячих клавиш
            Console.ForegroundColor = ConsoleColor.White;

            // Приглашение командной строки
            Console.Write("C:\\NC>");

            // Очищаем остальную часть строки
            Console.Write(new string(' ', WindowWidth - 6));

            // Устанавливаем курсор после приглашения для ввода
            Console.SetCursorPosition(6, terminalY);
        }

        // Нижняя строка с горячими клавишами.
        public void DrawHotKeys()
        {
            Console.SetCursorPosition(0, WindowHeight - 2);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkCyan;

            string keys = "1Помощь  2Вызов  3Чтение  4Правка  5Копия  6Новый  7Новкат  8Удал-е  9Меню  10Выход";
            Console.Write(keys.PadRight(WindowWidth));

            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.DarkBlue;
        }

        // Сокращение длинных имён файлов
        public string ShortenName(string name, int maxLen)
        {
            // Разделяем имя и расширение
            string namePart = name;
            string extPart = "";
            int extIndex = name.LastIndexOf('.');

            if (extIndex > 0)
            {
                namePart = name.Substring(0, extIndex);
                extPart = name.Substring(extIndex + 1); // без точки
            }

            // Если имя слишком длинное, сокращаем его
            if (namePart.Length + extPart.Length + 1 > maxLen) // +1 для пробела
            {
                int availableForName = maxLen - extPart.Length - 2; // -2 для пробела и тильды
                if (availableForName > 0)
                {
                    if (namePart.Length > availableForName)
                    {
                        namePart = namePart.Substring(0, availableForName) + "~";
                    }
                }
                else
                {
                    // Если места совсем мало
                    namePart = namePart.Substring(0, Math.Min(3, namePart.Length)) + "~";
                    extPart = extPart.Length > 3 ? extPart.Substring(0, 3) : extPart;
                }
            }

            // Выравниваем: имя слева, расширение справа
            int totalSpaces = maxLen - namePart.Length - extPart.Length - 1; // -1 для пробела
            if (totalSpaces > 0)
            {
                return namePart + new string(' ', totalSpaces) + " " + extPart;
            }
            else
            {
                return namePart + " " + extPart;
            }
        }
    }
}