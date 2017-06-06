using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QueueMgmt.Business.View.Request;

namespace QueueMgmt.Business.Process
{
    internal class TestExecutionWorker : IExecutionWorker
    {

        #region properties
        public Guid BusinessID { get; set; }
        public long ID { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }
        public string Headers { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModeifiedOn { get; set; }
        #endregion

        #region consturctors
        public TestExecutionWorker()
        {
            this.ID = 1;
            this.BusinessID = Guid.Parse("A92DF39B-EEC6-4967-989C-9C3177BE1231");
        }
        #endregion

        public bool Execute(ListView request)
        {
            if (request.ID % 13 != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
