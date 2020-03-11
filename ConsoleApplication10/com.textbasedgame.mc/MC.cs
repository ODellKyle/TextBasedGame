using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication10.com.textbasedgame.mc
{
    // Main character of the game.
    public class MC
    {
        public Sack<string> sack;
        private int funds;
        public int storyLevel;
        public int encounteredBart = 0;

        public MC()
        {
            sack = new Sack<string>();
            funds = 55;
            storyLevel = 1;
        }

        // Getter for player's funds.
        public int GetFunds()
        {
            return funds;
        }

        // Throws NoFundsException if player lacks required funds. Else, subtracts price from funds.
        public void SubtractFunds(int price)
        {
            if (funds - price < 0)
                throw new NoFundsException();

            funds -= price;
        }

        //private class Commands
        //{
        //    private string
        //}
    }

    // Custom exception for when player lacks required in game funds.
    class NoFundsException : Exception
    {
        public NoFundsException() { }
    }
}