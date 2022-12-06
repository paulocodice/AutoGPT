using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockKing.Data.Domain
{
    public class PlanningItem :IDbEntity
    {
        public int Id { get; set; }
        public PlanningBlock PlanningBlock { get; private set; }
        public string Descrition { get; private set; }
        public Status Status { get; private set; }
        public PlanningTiming
        public WorkBlock? WorkBlock { get; private set; }

        /// <summary>
        /// New empty planning item for EF, do not use otherwise
        /// </summary>
        public PlanningItem() : this(new(),"")
        {
        }

        /// <summary>
        /// Create an item for <paramref name="planningBlock"/> After planning this item has a 1 to 1 relation with a workblock
        /// </summary>
        /// <param name="planningBlock"></param>
        /// <param name="description"></param>
        public PlanningItem(PlanningBlock planningBlock, string description)
        {
            PlanningBlock= planningBlock;
            Status = Status.New;
            SetDescription(description);
        }

        /// <summary>
        /// Change the description of the item to <paramref name="description"/>
        /// </summary>
        /// <param name="description"></param>
        public void SetDescription(string description) 
        { 
            description = description.Trim();
        }

        /// <summary>
        /// Set the status of this item to 'plan' and remove the PlanningBlock associated to it
        /// </summary>
        public void Replan()
        {
            Status = Status.Plan;
            WorkBlock?.Delete(); // needed for EF? where to delete this ?
            WorkBlock = null;
        }

        /// <summary>
        /// Set <paramref name="workblock"/> for this item, and mark as planned
        /// </summary>
        /// <param name="workblock"></param>
        public void PlanWork(WorkBlock workblock)
        {
            WorkBlock = workblock;
            Status = Status.Planned;
            WorkDone()
        }

        /// <summary>
        /// Mark  this item, and its workitem as done. Only effective if <paramref name="Status"/> is set to <see cref="Status.Planned"/> first
        /// </summary>
        /// <returns><see cref="bool"/> set to <see langword="true"/> if succesfull, set to <see langword="false"/> if unsuccessfull </returns>
        public bool  WorkDone()
        {
            if (PlanningBlock != null
                && Status == Status.Planned
                && PlanningBlock.Status != Status.Done)
            {
                return PlanningBlock.SetStatus(Status.Done);
            }
            else return false;
        }
    }
}
