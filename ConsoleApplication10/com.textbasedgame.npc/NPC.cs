using ConsoleApplication10.com.textbasedgame.mc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication10.com.textbasedgame.npc
{
    public class NPC
    {
        private string name;

        public NPC(int storyLevel)
        {
            if (storyLevel > 0 || storyLevel < 3)
                name = "Bart";
            else
                name = "Bart";
        }

        public string GetName()
        {
            return name;
        }

        public MC Talk(MC mc)
        {
            if (this.name.Equals("Bart"))
            {
                if (mc.encounteredBart == 0)
                {
                    System.Console.WriteLine("\nBart:\n"
                                     + "You must be new around here, certainly don't look \nfamiliar... \n\n"
                                     + "Well, if you didn't know already, you can always type \n"
                                     + "\"help\" to be given a list of commands.\n"
                                     + "*Press Enter to continue*");
                    mc.encounteredBart++;
                }
                else
                {
                    System.Console.WriteLine("\nBart:\n"
                                     + "Hey! You should come check out my other shop on the other \n"
                                     + "side of town! That is, when the path is finally clear... \n"
                                     + "*Press Enter to continue*");
                }
            }

            return mc;
        }
    }
}
