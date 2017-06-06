using ILogger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueMgmt.Business.Exec.Generic
{
    public class Execution
    {
        #region attributes
        protected List<IExecutionWorker> _ExecutionWorkers = new List<IExecutionWorker>();
        #endregion

        #region constructors
        public Execution(ILog logger, Data.Model.QueueDbContext db)
        {
            this.Logger = logger;
            this.DB = db;

            loadExecutionWorkers();
        }
        #endregion

        #region properties
        public ILogger.ILog Logger { protected get; set; }
        public Data.Model.QueueDbContext DB { protected get; set; }
        #endregion

        public bool Execute(Business.View.Request.ListView request)
        {
            logInfo(string.Format("start Execute of request with ID {0}", request.ID));

            var worker = (from workerItem in this._ExecutionWorkers
                          where workerItem.ViewModel.BusinessID == request.Worker_BusinessID
                          select workerItem).Single();

            bool succeeded = worker.Execute(request);

            logInfo(string.Format("end Execute of request with ID {0} with status {1}", request.ID, succeeded ? "succeeded" : "failed"));

            return succeeded;
        }

        /// <summary>
        /// Load execution workers. We can have many types doing many businesses.
        /// </summary>
        protected virtual void loadExecutionWorkers()
        {
            logInfo("start loadExecutionWorkers");

            this._ExecutionWorkers.Add(new TestExecutionWorker());

            logInfo("end loadExecutionWorkers");
        }

        protected void logInfo(string what)
        {
            this.Logger.Log(ILogger.Priority.Info, this.GetType().ToString(), what, DateTime.Now);
        }
    }
}
