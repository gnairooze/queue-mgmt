using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QueueMgmt.Business.View.Request;

namespace QueueMgmt.Business.Process
{
    public class Queue
    {
        #region attributes
        protected List<Business.View.OperationSettings.ListView> _OperationsSettings;
        protected IQueryable<Business.View.Request.ListView> _Requests;

        static Data.Model.QueueDbContext db = new Data.Model.QueueDbContext();
        static Execution exec = new Execution();
        #endregion

        #region constructors
        public Queue(int queueID, int topCount)
        {
            loadOperationsSettings();

            this.QueueID = queueID;
        }
        #endregion

        #region properties
        public int QueueID { get; set; }
        public int TopCount { get; set; }
        #endregion

        public void Run()
        {
            loadRequests();
            startProcessing();
        }

        private void startProcessing()
        {
            foreach (var request in this._Requests)
            {
                bool succeeded = exec.Execute(request);
                updateRequestStatus(request, succeeded);
            }
        }

        private bool updateRequestStatus(ListView request, bool succeeded)
        {
            Business.View.OperationSettings.ListView operationSettings = this._OperationsSettings.Single(o => o.Operation == request.Operation);

            request.RemainingRetrials--;

            if (succeeded)
            {
                request.Status = View.BusinessVault.RequestStatus.Succeeded;
            }
            else
            {
                if(request.RemainingRetrials <= 0)
                {
                    request.Status = View.BusinessVault.RequestStatus.Failed;
                    request.NextRetryOn = null;
                }
                else
                {
                    request.Status = View.BusinessVault.RequestStatus.Retrying;
                    request.NextRetryOn = DateTime.Now.AddSeconds(operationSettings.RetrialDelay);
                }
            }

            Data.Model.Request dataModel = Queue.db.Request.Single(r => r.ID == request.ID);

            if(dataModel.ModifiedOn != request.ModifiedOn)
            {
                //TODO: log that the request changed during the processing
                return false;
            }

            request.CopyDataTo(dataModel);
            dataModel.ModifiedOn = DateTime.Now;

            Queue.db.SaveChanges();

            return true;
            
        }

        private void loadRequests()
        {
            DateTime runDate = DateTime.Now;
            this._Requests = (from dataModel in Queue.db.Request
                        where dataModel.QueueID == this.QueueID
                        && 
                        (
                            dataModel.Status == (byte)Business.View.BusinessVault.RequestStatus.NotProcessed 
                            || 
                            (
                                dataModel.Status == (byte)Business.View.BusinessVault.RequestStatus.Retrying
                                &&
                                dataModel.NextRetryOn <= runDate
                            )
                         )
                        orderby dataModel.ID
                        select new Business.View.Request.ListView(dataModel)).Take(this.TopCount);
        }

        private void loadOperationsSettings()
        {
            var query = from dataModel in Queue.db.OperationSettings
                        select new Business.View.OperationSettings.ListView(dataModel);

            _OperationsSettings = query.ToList();
        }
    }
}
