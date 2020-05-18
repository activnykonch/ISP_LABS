using System;
using System.IO;

namespace _2048
{
    class Program
    {

        static int score;
        static int bestscore;

        static void Main(string[] args)
        {
            string Path = @"C:\1 kypc\isp\2048\2048\BestScore.txt";
            StreamReader file = new StreamReader(Path);
            bestscore = Convert.ToInt32(file.ReadLine());
            file.Close();
            Console.CursorVisible = false;
            Menu();            
            if (score >= bestscore)
            {
                StreamWriter str = new StreamWriter(Path);
                str.Write(score);
                str.Close();
            }
        }
       static void StartGame(Cell[,] cell)
        {
            bool isGameOn = true;
            while (isGameOn)
            {
                if (score > bestscore) bestscore = score;
                if (Continue(cell))
                {
                    Show(cell);
                    if (Win(cell))
                    {
                        Console.WriteLine("Congratulations! You Win");
                        Console.WriteLine("Press Enter to continue or Press any key to Main Menu");
                        if (Console.ReadKey(true).Key != ConsoleKey.Enter)
                        { 
                            isGameOn = false;
                            Menu();
                        }
                    }
                    else
                    {
                        switch (Console.ReadKey(true).Key)
                        {
                            case ConsoleKey.W: UpMove(cell); break;
                            case ConsoleKey.S: DownMove(cell); break;
                            case ConsoleKey.A: LeftMove(cell); break;
                            case ConsoleKey.D: RightMove(cell); break;
                            case ConsoleKey.Escape: isGameOn = false; Menu(); break;
                            default: break;
                        }
                    }
                }
                else
                {
                    Show(cell);
                    Console.WriteLine();
                    Console.WriteLine("GAME OVER!");
                    if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                    {
                        isGameOn = false;
                        Menu();
                    }
                }
            }
        }
        static void Show(Cell[,] cell)
        {
            for (int x = 0; x < 4; x++)
                for (int y = 0; y < 4; y++)
                {
                    Console.SetCursorPosition(x * 5 + 5, y * 2 + 2);
                    int number = cell[x, y].number;
                    Console.Write(number == 0 ? "      " : number.ToString() + "   ");
                }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Score: {0}",score);
            Console.WriteLine("BestScore: {0}", bestscore);
        }

        static void UpMove(Cell[,] cell)
        {
            bool changes = false;
            bool stop = false;
            for (int k = 0; k < 2; k++)
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 1; j < 4; j++)
                    {
                        if (cell[i, j - 1].number == 0)
                        {
                            cell[i, j - 1].number = cell[i, j].number;
                            cell[i, j].number = 0;
                            if (cell[i, j].number != 0) changes = true;
                            if (j - 2 >= 0 && cell[i, j - 2].number == 0)
                            {
                                cell[i, j - 2].number = cell[i, j - 1].number;
                                cell[i, j - 1].number = 0;
                                if (j - 3 >= 0 && cell[i, j - 3].number == 0)
                                {
                                    cell[i, j - 3].number = cell[i, j - 2].number;
                                    cell[i, j - 2].number = 0;
                                }
                            }
                        }
                    }
                }
                if (!stop)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 1; j < 4; j++)
                        {
                            if (cell[i, j].number == cell[i, j - 1].number)
                            {
                                cell[i, j - 1].number *= 2;
                                score += cell[i, j - 1].number;
                                if (cell[i, j].number != 0) changes = true;
                                cell[i, j].number = 0;
                            }
                        }
                    }
                    stop = true;
                }
            }
            if(changes)Value(cell);
        }
        static void DownMove(Cell[,] cell)
        {
            bool changes = false;
            bool stop = false;
            for (int k = 0; k < 2; k++)
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 2; j >= 0; j--)
                    {
                        if (cell[i, j + 1].number == 0)
                        {
                            cell[i, j + 1].number = cell[i, j].number;
                            if (cell[i, j].number != 0) changes = true;
                            cell[i, j].number = 0;
                            if (j + 2 <= 3 && cell[i, j + 2].number == 0)
                            {
                                cell[i, j + 2].number = cell[i, j + 1].number;
                                cell[i, j + 1].number = 0;
                                if (j + 3 <= 3 && cell[i, j + 3].number == 0)
                                {
                                    cell[i, j + 3].number = cell[i, j + 2].number;
                                    cell[i, j + 2].number = 0;
                                }
                            }
                        }
                    }
                }
                if (!stop)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 2; j >= 0; j--)
                        {
                            if (cell[i, j].number == cell[i, j + 1].number)
                            {
                                cell[i, j + 1].number *= 2;
                                score += cell[i, j + 1].number;
                                if (cell[i, j].number != 0) changes = true;
                                cell[i, j].number = 0;
                            }
                        }
                    }
                    stop = true;
                }
            }
            if (changes) Value(cell);
        }
        static void LeftMove(Cell[,] cell)
        {
            bool changes = false;
            bool stop = false;
            for (int k = 0; k < 2; k++)
            {
                for (int j = 0; j < 4; j++)
                {
                    for (int i = 1; i < 4; i++)
                    {
                        if (cell[i - 1, j].number == 0)
                        {
                            cell[i - 1, j].number = cell[i, j].number;
                            if (cell[i, j].number != 0) changes = true;
                            cell[i, j].number = 0;
                            if (i - 2 >= 0 && cell[i - 2, j].number == 0)
                            {
                                cell[i - 2, j].number = cell[i - 1, j].number;
                                cell[i - 1, j].number = 0;
                                if (i - 3 >= 0 && cell[i - 3, j].number == 0)
                                {
                                    cell[i - 3, j].number = cell[i - 2, j].number;
                                    cell[i - 2, j].number = 0;
                                }
                            }
                        }
                    }
                }
                if (!stop)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        for (int i = 1; i < 4; i++)
                        {
                            if (cell[i, j].number == cell[i - 1, j].number)
                            {
                                cell[i - 1, j].number *= 2;
                                score += cell[i - 1, j].number;
                                if (cell[i, j].number != 0) changes = true;
                                cell[i, j].number = 0;
                            }
                        }
                    }
                    stop = true;
                }
            }
            if (changes) Value(cell);
        }
        static void RightMove(Cell[,] cell)
        {
            bool changes = false;
            bool stop = false;
            for (int k = 0; k < 2; k++)
            {
                for (int j = 0; j < 4; j++)
                {
                    for (int i = 2; i >= 0; i--)
                    {
                        if (cell[i + 1, j].number == 0)
                        {
                            cell[i + 1, j].number = cell[i, j].number;
                            if (cell[i, j].number != 0) changes = true;
                            cell[i, j].number = 0;
                            if (i + 2 <= 3 && cell[i + 2, j].number == 0)
                            {
                                cell[i + 2, j].number = cell[i + 1, j].number;
                                cell[i + 1, j].number = 0;
                                if (i + 3 <= 3 && cell[i + 3, j].number == 0)
                                {
                                    cell[i + 3, j].number = cell[i + 2, j].number;
                                    cell[i + 2, j].number = 0;
                                }
                            }
                        }
                    }
                }
                if (!stop)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        for (int i = 2; i >= 0; i--)
                        {
                            if (cell[i, j].number == cell[i + 1, j].number)
                            {
                                cell[i + 1, j].number *= 2;
                                score += cell[i + 1, j].number;
                                if (cell[i, j].number != 0) changes = true;
                                cell[i, j].number = 0;
                            }
                        }
                    }
                    stop = true;
                }
            }
            if (changes) Value(cell);
        }
        static void Value(Cell[,] cell)
        {
            bool mark = true;
            while (mark)
            {
                Random rnd = new Random();
                int x = rnd.Next(0, 4);
                int y = rnd.Next(0, 4);
                if (cell[x, y].number == 0)
                {
                    cell[x, y].Generate();
                    mark=false;
                }
            }
        }
        
        static int Menu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the 2048 game!");
            Console.WriteLine("Press 1 to start the game");
            Console.WriteLine("Press 2 to reset the best score");
            Console.WriteLine("Press Esc to exit");
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.D1:
                    Console.Clear();
                    score = 0;
                    Cell[,] cell = new Cell[4, 4];
                    for (int x = 0; x < 4; x++)
                        for (int y = 0; y < 4; y++)
                        {
                            cell[x, y] = new Cell();
                        }
                    Value(cell);
                    Value(cell);
                    StartGame(cell);
                    return 0;
                case ConsoleKey.D2:
                    bestscore = 0;
                    return Menu();
                case ConsoleKey.Escape: return 0;
                default:
                    return Menu();
            }
        }
        static bool Continue(Cell[,] cell)
        {
            bool Changes = false;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 1; j < 4; j++)
                {
                    if (cell[i, j].number == cell[i, j - 1].number)
                    {
                        Changes = true;
                    }
                }
            }
            for (int j = 0; j < 4; j++)
            {
                for (int i = 2; i >= 0; i--)
                {
                    if (cell[i, j].number == cell[i + 1, j].number)
                    {
                        Changes = true;
                    }
                }
            }
            for(int i=0; i<4; i++)
                for(int j=0; j<4; j++)
                    if(cell[i,j].number==0) Changes = true;
            return Changes;
        }
        static bool Win(Cell[,] cell)
        {
            bool win=false;
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    if (cell[i, j].number == 2048) win = true;
            return win;
        }

    }
}
