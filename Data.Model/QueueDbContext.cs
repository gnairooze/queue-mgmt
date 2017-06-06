using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueMgmt.Data.Model
{
    public class QueueDbContext:DbContext
    {
        public QueueDbContext() : base("QueueDB")
        { }

        public DbSet<Request> Request { get; set; }
        public DbSet<OperationSettings> OperationSettings { get; set; }
        public DbSet<Worker> Worker { get; set; }
    }
}
