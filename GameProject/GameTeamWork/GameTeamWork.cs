using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

public class GameTeamWork
{
    //1.Structure "Object" contains four variables - coordinates, color, and its symbols.
    struct Object
    {
        public int x;
        public int y;
        public ConsoleColor color;
        public char symbol;
    }

    public static void Main()
    {

        //2.Draw playfield
        int playfieldWidth = 9;
        Console.BufferHeight = Console.WindowHeight = 30;//This is the size of the console window height.
        Console.BufferWidth = Console.WindowWidth = 40;//size of window width.                              
        Console.BackgroundColor = ConsoleColor.DarkRed;//color of playfield

        //3.Make object
        Object userObject = new Object();
        userObject.x = 2;
        userObject.y = Console.WindowHeight - 1;
        userObject.symbol = '@';
        userObject.color = ConsoleColor.Black;

        //Random randomGenerator = new Random();
        //List<Object> objects = new List<Object>();

        //We will insert all in while-loop
        while (true)
        {
            //4.Move our object
            while (Console.KeyAvailable)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                if (pressedKey.Key == ConsoleKey.LeftArrow)
                {
                    if (userObject.x - 1 > 0)
                    {
                        userObject.x--;
                    }
                }
                else if (pressedKey.Key == ConsoleKey.RightArrow)
                {
                    if (userObject.x + 1 < playfieldWidth)
                    {
                        userObject.x++;
                    }
                }
            }

            //6.Check for other object are hitting

            //7.Clear the console with 
            Console.Clear();

            //8.print our object
            PrintOnPosition(userObject.x, userObject.y, userObject.symbol, userObject.color);



            //9.Draw info
            //10.Slow down program
            Thread.Sleep(500);

        }

      
    }
    //Method which print object 
    static  void PrintOnPosition(int x, int y, char symbol, ConsoleColor color = ConsoleColor.Black)
    {
        //Console.SetCursorPosition move our cursor in place of what we write.
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = color;
        Console.WriteLine(symbol);
    }
}

      
  

