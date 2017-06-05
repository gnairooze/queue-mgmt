using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueMgmt.Business.Process
{
    internal interface IExecutionWorker
    {

        #region properties
        long ID { get; set; }
        Guid BusinessID { get; set; }
        string Name { get; set; }
        #endregion

        bool Execute(Business.View.Request.ListView request);
    }
}
