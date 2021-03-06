﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueMgmt.Business.Exec.Generic
{
    public class ExecutionCompletedEventArgs : EventArgs
    {
        #region properties
        public Business.View.Request.ListView Request { get; set; }
        public IExecutionWorker Worker { get; set; }
        public bool Succeeded { get; set; }
        #endregion
    }
}
