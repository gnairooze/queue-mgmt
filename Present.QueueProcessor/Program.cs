using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueMgmt.Present.QueueProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            Business.Process.Queue queue = new Business.Process.Queue(QueueProcessor.Properties.Settings.Default.QueueID,
               QueueProcessor.Properties.Settings.Default.TopCount,
               new ConsoleLogger.SimpleLogger(),
               Business.Process.Vault.ExecType.Generic);

            queue.Run();

            Console.WriteLine("Press any key to exit ...");
            Console.Read();
        }
    }
}
