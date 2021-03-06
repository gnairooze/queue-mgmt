﻿using ILogger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueMgmt.Business.Process
{
    internal class ExecFactory
    {
        #region constructors
        public ExecFactory(ILog logger, Data.Model.QueueDbContext db)
        {
            this.Logger = logger;
            this.DB = db;
        }
        #endregion

        #region properties
        public ILogger.ILog Logger { private get; set; }
        public Data.Model.QueueDbContext DB { private get; set; }
        #endregion

        public Exec.Generic.Execution GetExecution(Vault.ExecType executionType)
        {
            Exec.Generic.Execution exec = null;

            switch (executionType)
            {
                case Vault.ExecType.Generic:
                    exec = new Exec.Generic.Execution(this.Logger, this.DB);
                    break;
                default:
                    exec = new Exec.Generic.Execution(this.Logger, this.DB);
                    break;
            }

            return exec;
        }
    }
}
