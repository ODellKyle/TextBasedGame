using ConsoleApplication10.com.textbasedgame.maps;
using ConsoleApplication10.com.textbasedgame.mc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication10
{
    class MainGame
    {
        static void Main(string[] args)
        {
            // TODO: Run file for save/load

            // Run either main game, or demo
            MainGame game = new MainGame();
            //game.Run();
            game.Demo();
        }

        void Run()
        {
            MC mc = new MC();


        }

        // TODO: add remove command.
        // TODO: Create a commands class with command methods based on environment.
        void Demo()
        {
            MC mc = new MC();

            // Shop interaction:
            Shop shop = new Shop(mc.storyLevel);
            shop.Buy(mc);

            // Tests inventory.
            mc.sack.Inventory();
            System.Console.WriteLine();

            // Tests shops stock.
            shop.Stock();
            System.Console.ReadLine();
        }
    }
}