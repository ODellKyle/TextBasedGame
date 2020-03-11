using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication10.com.textbasedgame.mc
{
    public class Sack<Item>
    {
        private Node head;
        private Node last;
        private int size;      // Number of items in sack
        private int limit = 5; // Inventory capacity

        class Node
        {
            public Node next;
            public Node prev;
            public Item item;
            public Node(Item item)
            {
                this.item = item;
            }
        }

        /**
         * 
         * @return Number of items in sack.
         */
        public int Size()
        {
            return size;
        }

        /** Adds a new item to the top of the sack.
         * 
         * @param item Item that will be added to the sack.
         * @return Always returns true.
         */
        public bool Add(Item item)
        {
            if (size == limit)
                throw new LimitExceededException();

            Node node = new Node(item);

            if (size == 0)
                head = last = node;
            else
            {
                last.next = node;
                node.prev = last;
                last = node;
            }

            size++;

            return true;
        }

        /**
         * 
         * @param index Element number.
         * @return Returns indexed item.
         */
        public Item Get(int index)
        {
           if (index < 0 || index >= size)
                throw new IndexOutOfRangeException();

            Node ptr = head;
            for (int i = 0; i < index; i++)
                ptr = ptr.next;

            return ptr.item;
        }

        // Removes and returns item from the sack.
        // Reduces sack size by one.
        public Item Remove(int index)
        {
            if (index < 0 || index >= size)
                throw new IndexOutOfRangeException();

            Item removedItem;
            if (index == 0)
            {
                removedItem = head.item;
                if (size == 1)
                    head = last = null;
                else
                {
                    head = head.next;
                    head.prev = null;
                }
            }
            else if (index == size - 1)
            {
                removedItem = last.item;
                last = last.prev;
                last.next = null;
            }
            else
            {
                Node ptr = head;
                for (int i = 0; i < index; i++)
                    ptr = ptr.next;
                removedItem = ptr.item;
                ptr.next.prev = ptr.prev;
                ptr.prev.next = ptr.next;
            }

            --size;

            return removedItem;
        }

        // TODO:
        // public bool Contains(Object o){}

        // TODO:
        // public bool Remove(Object o){}
        
            /*
        public Item Remove(Object o)
        {
             Item removedItem = null;
               
             if(!Contains(o))
             {
                 System.Console.WriteLine("This item is not in your inventory.");
             }
             else
             {
                 bool flag = true;
                 if(head.item.equals(o))
                 {
                      removedItem = Remove(0);
                 }
                 else if(last.item.equals(o))
                 {
                     removedItem = Remove(size - 1);
                 }
                 else
                 {
                     Node ptr = head;
                     flag = false;
                     while(ptr != null && !flag)
                     {
                         if(ptr.item.equals(o))
                         {
                             removedItem = ptr.item;
                             ptr.prev.next = ptr.next;
                             ptr.next.prev = ptr.prev;
                             --size;
                             flag = true;
                         }
                     }//end loop
                 }//end else
             }//end outer else
             
             return removedItem;
         }//end function
         */

        

        // Upgrades mcs sack by five slots.
        public void SackUpgrade()
        {
            limit += 5;
        }

        // Mcs inventory
        public void Inventory()
        {
            System.Console.WriteLine("\nContents of sack:");
            System.Console.WriteLine("# of items: " + size);
            for (int i = 0; i < this.Size(); i++)
            {
                System.Console.WriteLine(this.Get(i));
            }

            System.Console.WriteLine("*Press Enter to continue*");
        }
    }

    // Custom exception: thrown if limit of of sack's inventory is exceeded.
    class LimitExceededException : Exception
    {
        public LimitExceededException()
        {
        }
    }
}
