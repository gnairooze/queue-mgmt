using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueMgmt.Business.Process
{
    internal class ExecutionWorker
    {
        #region constructors
        public ExecutionWorker()
        {

        }
        #endregion

        #region properties
        public long ID { get; set; }
        public Guid BusinessID { get; set; }
        public string Name { get; set; }
        #endregion

        public bool Execute(Business.View.Request.ListView request)
        {
            return true;
        }
    }
}
