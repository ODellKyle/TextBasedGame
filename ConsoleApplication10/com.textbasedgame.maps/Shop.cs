using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication10.com.textbasedgame.mc;
using ConsoleApplication10.com.textbasedgame.npc;

namespace ConsoleApplication10.com.textbasedgame.maps
{

    /** Shop interface for mc
     * @author Kyle O'Dell
     * @author kodell315@gmail.com
     * @version 1.0.2
     * @since 1.0
     */
    public class Shop
    {
        private string[] stock;
        private int[] stockNum;
        private int[] price;
        private NPC clerk;

        /** Initializes the shop.
         * 
         * @param storyLevel Mcs current level in game determines the stocked items at that time.
         */
        // TODO: shop depends on location, not storyLevel.
        public Shop(int storyLevel)
        {
            clerk = new NPC(storyLevel);
            stock = new string[4];
            stockNum = new int[4];
            price = new int[4];
            stockNum[0] = 5;
            stockNum[1] = 3;
            stockNum[2] = 1;
            stockNum[3] = 99;
            price[0] = 5;
            price[1] = 15;
            price[2] = 999;
            price[3] = 1;

            if (storyLevel > 0 && storyLevel < 2)
            {
                stock[0] = "Rock";
                stock[1] = "Better Rock";
                stock[2] = "Cool Shiny Stone";
                stock[3] = "Tree Bark";
            }
            else if (storyLevel < 4)
            {
                stock[0] = "Medicine";
                stock[1] = "Better Medicine";
                stock[2] = "Knife";
                stock[3] = "Tree Bark";
            }
            else
            {
                stock[0] = "Rock";
                stock[1] = "Better Rock";
                stock[2] = "Cool Shiny Stone";
                stock[3] = "Tree Bark";
            }
        }

        // Displays remaining stock of instance shop.
        public void Stock()
        {
            System.Console.WriteLine("Remaining stock:");
            for (int i = 0; i < stock.Length; i++)
                System.Console.WriteLine(stock[i] + ": " + stockNum[i]);
        }

        // Restocks the shop.
        public void Refill()
        {
            Random rand = new Random();

            stockNum[0] += rand.Next(4) + 1;
            stockNum[1] += rand.Next(3);
            stockNum[2] += rand.Next(1);
            stockNum[3] += rand.Next(99) + 40;
        }

        // TODO: Change thrown exception.
        /** Checks to see if item is out of stock.
         * 
         * @param i The item number from the stock array.
         */
        private void OutOfStock(int i)
        {
            if (stockNum[i] == 0)
                throw new NullReferenceException();
        }

        // TODO: Run by an NPC object
        // TODO: write NPC class for shop owner
        // Purchase interface for the shop
        /** Shop interface for mc.
         * @param sack The mcs inventory sack.
         * @param funds The mcs in-game currency.
         */
        public MC Buy(MC mc)
        {
            string command;
            int cmd;
            System.Console.WriteLine("Welcome! (Note: User can type help at the shop \n"
                                 + "interface for a list of commands.) \n"
                                 + "*Press Enter to continue*");
            System.Console.ReadLine();

            do
            {
                bool flag = false;
                System.Console.WriteLine("\n\n\n\n");
                System.Console.Write("*******************************************************\n"
                                 + "*******************************************************\n"
                                 + "Buy something please...                    Clerk: " + clerk.GetName() + "\n"
                                 + "                                                       \n"
                                 + "       " + stock[0] + " - $" + price[0] + "      " + stock[1] + " - $" + price[1] + "        \n"
                                 + "       " + stock[2] + " - $" + price[2] + "           \n"
                                 + "       " + stock[3] + " - $" + price[3] + "           \n"
                                 + "                                                       \n"
                                 + "                       $" + mc.GetFunds() + "               \n"
                                 + "*******************************************************\n"
                                 + "*******************************************************\n"
                                 + ">> ");
                cmd = 99;
                command = System.Console.ReadLine();

                try
                {
                    cmd = int.Parse(command);
                }
                catch (FormatException e)
                {
                    // TODO: LEARN REGEX (sic)
                    if (command.Equals("rock", StringComparison.InvariantCultureIgnoreCase) || command.Equals("buy rock", StringComparison.InvariantCultureIgnoreCase))
                        cmd = 0;
                    else if (command.Equals("better rock", StringComparison.InvariantCultureIgnoreCase) || command.Equals("buy better rock", StringComparison.InvariantCultureIgnoreCase))
                        cmd = 1;
                    else if (command.Equals("cool shiny stone", StringComparison.InvariantCultureIgnoreCase) || command.Equals("buy cool shiny stone", StringComparison.InvariantCultureIgnoreCase))
                        cmd = 2;
                    else if (command.Equals("tree bark", StringComparison.InvariantCultureIgnoreCase) || command.Equals("buy tree bark", StringComparison.InvariantCultureIgnoreCase))
                        cmd = 3;
                    else if (command.Equals("exit", StringComparison.InvariantCultureIgnoreCase))
                        cmd = 4;
                    else if (command.Equals("help", StringComparison.InvariantCultureIgnoreCase))
                        cmd = 5;
                    else if (command.Equals("inventory", StringComparison.InvariantCultureIgnoreCase) || command.Equals("check inventory", StringComparison.InvariantCultureIgnoreCase))
                        cmd = 6;
                    else
                        cmd = 99;
                }

                if (cmd < stock.Length && cmd >= 0)
                {
                    try
                    {
                        OutOfStock(cmd);
                        mc.SubtractFunds(price[cmd]);
                        mc.sack.Add(stock[cmd]);
                        flag = true;
                        stockNum[cmd]--;
                    }
                    catch (NoFundsException e)
                    {
                        System.Console.WriteLine("(I do not have enough funds...)");
                        System.Console.ReadLine(); // (pause)
                    }
                    catch (NullReferenceException e)
                    {
                        System.Console.WriteLine("That item is sold out!");
                        System.Console.ReadLine(); // (pause)
                    }
                    catch (LimitExceededException e)
                    {
                        System.Console.WriteLine("(My bag is full...)");
                        System.Console.ReadLine(); // (pause)
                    }
                }

                if (flag)
                {
                    System.Console.WriteLine("\n\n\n\n\n\n\n\n");
                    System.Console.Write("*******************************************************\n"
                                     + "*******************************************************\n"
                                     + "Thank you for your purchase D;                         \n"
                                     + "                                                       \n"
                                     + "       Remaining funds:                                \n"
                                     + "                       $" + mc.GetFunds() + "               \n"
                                     + "*******************************************************\n"
                                     + "*******************************************************\n"
                                     + "*Press Enter to continue*");
                    System.Console.ReadLine();
                }
                else if (cmd == 5)
                {
                    Help();
                    System.Console.ReadLine();
                }
                else if (cmd == 6)
                {
                    mc.sack.Inventory();
                    System.Console.ReadLine();
                }
                else if(cmd == 99)
                {
                    clerk.Talk(mc);
                    System.Console.ReadLine();
                }
            } while (cmd != stock.Length);

            return mc;
        }

        // Displays usable commands to the player.
        static void Help()
        {
            System.Console.WriteLine("\nList of commands: (More to be developed)\n"
                             + "\"Buy *item name*\" - buys item if in stock.\n"
                             + "\"*item name*\" - buys item if in stock.\n"
                             + "\"Exit\" - leaves shop.\n"
                             + "\"Inventory\" - displays your inventory.\n"
                             + "(otherwise talks to the NPC)\n\n"
                             + "*Press Enter to continue*");
        }
    }

}
