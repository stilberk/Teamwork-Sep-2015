using System;
using System.Collections.Generic;
using System.Threading;

public class GameTeamWork
{
    //1.Structure "Object" contains four variables - coordinates, color, and its symbols.
    class Object
    {
        public int x;
        public int y;
        public ConsoleColor color;
        public string symbol;
        public Object(int x, int y , string symbol, ConsoleColor color = ConsoleColor.Green)
        {
            this.x = x;
            this.y = y;
            this.symbol = symbol;
            this.color = color;
        }
    }

    public static void Main()
    {
        int livesCount = 6;
        //2.Draw playfield
        int playfieldWidth = 9;
        Console.BufferHeight = Console.WindowHeight = 30;//This is the size of the console window height.
        Console.BufferWidth = Console.WindowWidth = 40;//size of window width.                              
        Console.BackgroundColor = ConsoleColor.Black;//color of playfield
               
        //3.Make object
        int x = 2;
        int y = Console.WindowHeight - 1;
        string symbol = "@";
        ConsoleColor color = ConsoleColor.DarkRed;
        Object userObject = new Object(x,y,symbol,color);

        List<Object> objects = new List<Object>();
        Random randomGenerator = new Random();
        while (true)
        {
            bool hit = false;
            int chance = randomGenerator.Next(0, 100);
            if (chance < 50)
            {      
                int xx = randomGenerator.Next(0, playfieldWidth);
                Object newObject = new Object(xx, 0, "$", ConsoleColor.Green);
                objects.Add(newObject);
            }

            //4.Move our object
            while (Console.KeyAvailable)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }
                if (pressedKey.Key == ConsoleKey.LeftArrow)
                {
                    if (userObject.x > 0)
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
            //Struct was converted to Class , so now we can change (y) easily!
            for (int i = 0; i < objects.Count; i++)
            {
                if (objects[i].y < Console.WindowHeight)
                {
                    objects[i].y = objects[i].y + 1;
                }
            }
            // Check for HIT!!!
            if (objects.Count > 0)
            {
                if (objects[0].y == userObject.y && objects[0].x == userObject.x)
                {
                    livesCount--;
                }
            }
            //7.Clear the console with 
            Console.Clear();
            //Print other object
            foreach (Object element in objects)
            {
                PrintOnPosition(element.x, element.y, element.symbol, element.color);
            }
            //8.print our object
            PrintOnPosition(userObject.x, userObject.y, userObject.symbol, userObject.color);
            //printing userObject lives

            PrintOnPosition(15, 25, "Lives:" + livesCount.ToString(), ConsoleColor.DarkRed);
            //Print board for the field
            PrintTheSideBoard();
            //remove objects which are outside the field
            if (objects.Count > 0)
            {
                if (objects[0].y == Console.WindowHeight - 1)
                {
                    objects.RemoveAt(0);
                }
            }
            //9.Draw info
            //10.Slow down program
            Thread.Sleep(300);
        }
    }

    private static void PrintTheSideBoard()
    {
        for (int i = 0; i < Console.WindowHeight; i++)
        {
            PrintOnPosition(9, i, "|", ConsoleColor.White);
        }
    }

    //Method which print object 
    static void PrintOnPosition(int x, int y, string symbol, ConsoleColor color = ConsoleColor.Green)
    {
        //Console.SetCursorPosition move our cursor in place of what we write.
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = color;
        Console.Write(symbol);
    }
}