using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockKing.Data.Domain
{
    public enum BlockType { Undetermined = -1, Planning, Work, Break, NotAvailable } // per block a type with specific properties and methods
   
    public abstract class Block
    {
        public BlockType BlockType { get; private set; }
        public Day Date { get; private set; }
        public int Priority { get; private set; }

        public Block(Day date, int duration, int priority)
        {
            SetDate(date);
            SetPriority(priority);
        }

        public void SetDate (Day date)
        {
            Date = date;
        }

        public void SetPriority(int priority) //TODO check priority of other blocks in Day to avaid doubling priorities
        {
            Priority = priority;
        }
    }
}
