using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueMgmt.Business.View.Request
{
    public class ListView
    {
        #region attributes
        protected byte _Status = 0;
        #endregion

        #region constructors
        public ListView()
        {

        }

        public ListView(Data.Model.Request request)
        {
            this.BusinessID = request.BusinessID;
            this.CreatedOn = request.CreatedOn;
            this.Data = request.Data;
            this.ID = request.ID;
            this.ModifiedOn = request.ModifiedOn;
            this.NextRetryOn = request.NextRetryOn;
            this.Operation = request.Operation;
            this.QueueID = request.QueueID;
            this.ReferenceName = request.ReferenceName;
            this.ReferenceValue = request.ReferenceValue;
            this.RemainingRetrials = request.RemainingRetrials;
            this._Status = request.Status;
        }
        #endregion

        #region properties
        public long ID { get; set; }
        public Guid BusinessID { get; set; }
        public string Operation { get; set; }
        public string ReferenceName { get; set; }
        public string ReferenceValue { get; set; }
        public string Data { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public BusinessVault.RequestStatus Status
        {
            get
            {
                return (BusinessVault.RequestStatus)this._Status;
            }
            set
            {
                this._Status = (byte)value;
            }
        }
        public int RemainingRetrials { get; set; }
        public DateTime? NextRetryOn { get; set; }
        public int QueueID { get; set; }
        #endregion
    }

}
