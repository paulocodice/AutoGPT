using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockKing.Data.Domain
{
    public class PlanningBlock : Block, IDbEntity // todo: set blocktype to planning
    {
        public int Id { get; private set; }
        /// <summary>
        /// How to plan for this block in time
        /// </summary>
        public PlanningTiming Timing { get; private set; }

        /// <summary>
        /// Status of the planning
        /// </summary>
        public Status Status {get; private set; }
        
        /// <summary>
        /// Subject to plan for
        /// </summary>
        public Subject Subject { get; private set; }

        /// <summary>
        /// Description of what is planned
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        ///  Items to be planned for this subject
        /// </summary>
        public SortedList<int, PlanningItem> items{ get; private set; }


        public PlanningBlock(Day date, int priority) : base(date, priority)
        {
        }

        internal bool SetStatus(Status done)
        {
            return true;
        }
    }
}
