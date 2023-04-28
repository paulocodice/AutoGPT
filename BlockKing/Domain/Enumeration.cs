using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockKing.Data.Domain
{
    /// <summary>
    /// How to plan for a specific object. PLanning should happen between now and duedate
    /// </summary>
    public enum PlanningTiming { CloseToNow, CloseToDuedate, Spread }
    public enum Status { New, Plan, Planned, Done }
}
