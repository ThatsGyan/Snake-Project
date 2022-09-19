using System;
using System.Threading;

namespace SnakeProject
{
    internal class Snake
    {
        int height = 20;
        int width = 40;

        int[] X = new int[50];
        int[] Y = new int[50];

        int fruitM;
        int fruitN;

        int parts = 3;

        ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
        char key = 'w';

        Random rnd = new Random();

        public Snake()
        {
            X[0] = 10;
            Y[0] = 10;
            Console.CursorVisible = false;
            fruitM = rnd.Next(2, (width - 2));
            fruitN = rnd.Next(2, (height - 2));
        }
        public void WriteBoard()
        {
            Console.Clear();
            for (int i = 1; i <= (width + 2); i++)
            {
                Console.SetCursorPosition(i, 1);
                Console.Write("-");
            }
            for (int i = 1; i <= (width + 2); i++)
            {
                Console.SetCursorPosition(i, (height + 2));
                Console.Write("-");
            }
            for (int i = 1; i <= (height + 1); i++)
            {
                Console.SetCursorPosition(1, i);
                Console.Write("-");
            }
            for (int i = 1; i <= (height + 1); i++)
            {
                Console.SetCursorPosition((width + 2), i);
                Console.Write("-");
            }

        }
        public void Input()
        {
            if (Console.KeyAvailable)
            {
                keyInfo = Console.ReadKey(true);
                key = keyInfo.KeyChar;
            }
        }
        public void WritePoint(int x, int y)
        {
            try
            {
                Console.SetCursorPosition(x, y);
                Console.Write("*");
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine("Game over!");
            }
        }

        public void Logic()
        {
            if (X[0] == fruitM)
            {
                if (X[0] == fruitN)
                {
                    parts++;
                    fruitM = rnd.Next(2, (width - 2));
                    fruitN = rnd.Next(2, (height - 2));
                }
            }

            for (int i = parts; i > 1; i--)
            {
                X[i - 1] = X[i - 2];
                Y[i - 1] = Y[i - 2];
            }
            switch (key)
            {
                case 'w':
                    Y[0]--;
                    break;
                case 's':
                    Y[0]++;
                    break;
                case 'd':
                    X[0]++;
                    break;
                case 'a':
                    X[0]--;
                    break;
            }
            for (int i = 0; i <= (parts - 1); i++)
            {
                WritePoint(X[i], Y[i]);
                WritePoint(fruitM, fruitN);
            }
            Thread.Sleep(1500);
        }
        static void Main(string[] args)
        {
            Snake snake = new Snake();
            while (true)
            {
                snake.WriteBoard();
                snake.Input();
                snake.Logic();
            }

        }
    }
}