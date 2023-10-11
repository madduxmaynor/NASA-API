using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

internal class Galaga
{
    static int playerX;
    static int playerY;

    static List<Enemy> enemies;
    static List<Bullet> bullets;
    static int score;
    static int level;
    static bool isGameRunning;

    public static void Run()
    {
        Console.WindowHeight = 30;
        Console.WindowWidth = 50;
        Console.BufferHeight = 30;
        Console.BufferWidth = 50;
        Console.CursorVisible = false;
         

        Console.WriteLine("Press Enter to Start the Game");
        Console.ReadLine();

        enemies = new List<Enemy>();
        bullets = new List<Bullet>();
        playerX = Console.WindowWidth / 2;
        playerY = Console.WindowHeight - 1;
        score = 0;
        level = 1;
        isGameRunning = true;

        

        Task.Run(() => MoveEnemies());
        Task.Run(() => ShootBullets());
        while (isGameRunning)
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(intercept: true).Key;
                if (key == ConsoleKey.Spacebar)
                {
                    bullets.Add(new Bullet { X = playerX, Y = playerY - 1 });
                }
                else if (key == ConsoleKey.LeftArrow && playerX > 0)
                {
                    playerX--;
                }
                else if (key == ConsoleKey.RightArrow && playerX < Console.WindowWidth - 1)
                {
                    playerX++;
                }
            }
            Console.Clear();
            DrawPlayer();
            DrawEnemies();
            DrawBullets();
            DraScore();
            Thread.Sleep(16);
        }

        Console.Clear();
        Console.WriteLine("Game Over!");
        Console.WriteLine($"Your Score: {score}");
    }

    static void DrawPlayer()
    {
        Console.SetCursorPosition(playerX, playerY);
        Console.Write("+");
    }

    static void DrawEnemies()
    {
        foreach (Enemy enemy in enemies)
        {
            Console.SetCursorPosition(enemy.X, enemy.Y);
            Console.Write("{_}");
        }
    }


    static void DraScore()
    {
        Console.SetCursorPosition(2, 2);
        Console.Write($"Score: {score}");
    }


    static void DrawBullets()
    {
        foreach (var bullet in bullets)
        {
            Console.SetCursorPosition(bullet.X, bullet.Y);
            Console.Write("^");
        }
    }
    

    static async Task ShootBullets()
    {
        while (isGameRunning)
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(intercept: true).Key;
                if (key == ConsoleKey.Spacebar)
                {
                    bullets.Add(new Bullet { X = playerX, Y = playerY - 1 });
                }
            }

            var newBullets = new List<Bullet>();
            var hitEnemies = new List<Enemy>();

            foreach (var bullet in bullets)
            {
                int newX = bullet.X;
                int newY = bullet.Y - 1;

                if (newY >= 0)
                {
                    newBullets.Add(new Bullet { X = newX, Y = newY });

                    foreach (var enemy in enemies)
                    {
                        if (newX == enemy.X && newY == enemy.Y)
                        {
                            hitEnemies.Add(enemy);
                            score++;
                        }
                    }
                }
            }

            bullets = newBullets;

            foreach (var hitEnemy in hitEnemies)
            {
                enemies.Remove(hitEnemy);
            }

            await Task.Delay(50);
        }
    }
    static async Task MoveEnemies()
    {
        int delay = 100 - (level * 5);
        int maxDelay = 20;

        while (isGameRunning)
        {
            var newEnemies = new List<Enemy>();

            foreach (var enemy in enemies)
            {
                int newX = enemy.X;
                int newY = enemy.Y + 1;

                if (newY < Console.WindowHeight)
                {
                    newEnemies.Add(new Enemy { X = newX, Y = newY });
                }
                else
                {
                    score++;
                }
            }

            enemies = newEnemies;

            if (score % 10 == 0)
            {
                level++;
                enemies.Add(new Enemy { X = new Random().Next(0, Console.WindowWidth), Y = 0 });
            }

            if (score > 20)
            {
                delay = maxDelay;
            }

            await Task.Delay(delay);
        }
    }
    class Enemy
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    class Bullet
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}