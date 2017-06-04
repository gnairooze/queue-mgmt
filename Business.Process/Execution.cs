using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QueueMgmt.Business.View.Request;

namespace QueueMgmt.Business.Process
{
    internal class Execution
    {
        #region attributes
        protected List<ExecutionWorker> _ExecutionWorkers = new List<ExecutionWorker>();
        #endregion

        #region constructors
        public Execution()
        {
            loadExecutionWorkers();
        }

        public bool Execute(Business.View.Request.ListView request)
        {
            var worker = (from workerItem in this._ExecutionWorkers
                          where workerItem.BusinessID == request.Worker_BusinessID
                          select workerItem).Single();

            return worker.Execute(request);
        }

        /// <summary>
        /// Load execution workers. We can have many types doing many businesses.
        /// </summary>
        protected void loadExecutionWorkers()
        {
            this._ExecutionWorkers.Add(new ExecutionWorker());
        }
        #endregion
    }
}
