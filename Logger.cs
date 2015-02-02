using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DSBuffTool
{
    public class Logger
    {
        public string LogFileName { get; set; }

        public Logger()
        {
            LogFileName = "C:\\Temp\\DSBuffTool_log.txt";
        }

        public Logger(string fileName)
        {
            LogFileName = fileName;
            using (StreamWriter logWriter = new StreamWriter(LogFileName, false))
            {
                logWriter.Write("{0}: {1}", "INFO", "DaySim Buffering Tool Log Started");
                logWriter.WriteLine(": {0} @ {1}", DateTime.Now.ToLongDateString(), DateTime.Now.ToLongTimeString());
            }
        }

        public void log(string logMsg, string msgType = "INFO")
        {
            using (StreamWriter logWriter = new StreamWriter(LogFileName,true))
            {
                logWriter.Write("{0}: {1}", msgType, logMsg);
                logWriter.WriteLine(": {0} @ {1}", DateTime.Now.ToLongDateString(), DateTime.Now.ToLongTimeString());
                Console.Write("{0}: {1}", msgType, logMsg);
                Console.WriteLine(": {0} @ {1}", DateTime.Now.ToLongDateString(), DateTime.Now.ToLongTimeString());
            }

        }

    }
}
