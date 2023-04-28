using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockKing.Data.Domain
{
    // every block has to be of one specific type. 
    public enum BlockType { Undetermined = -1, Planning, Work, Break, NotAvailable } 
   
    //This is the base class for all blocks
    public abstract class Block
    {
        public BlockType BlockType { get; private set; }
        public Day Date { get; private set; }
        public int Priority { get; private set; } //TODO 0 being the highest priority , 100 the lowest

        public Block(Day date, int duration, int priority)
        {
            SetDate(date);
            SetPriority(priority);
        }

        public void SetDate (Day date) //TODO check for a valid date that is not in the past
        {
            Date = date;
        }

        public void SetPriority(int priority) //TODO check priority of other blocks in Day to avoid duplicates
        {
            Priority = priority;
        }
    }
}
