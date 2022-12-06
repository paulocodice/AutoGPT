using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockKing.Data.Domain
{
    public class WorkBlock
    {
        public bool visible { get; private set; } //TODO depends on status of parent planningblock
        public PlanningItem PlanningItem { get; private set; }

        internal void Delete()
        {
            throw new NotImplementedException();
        }
    }
}
