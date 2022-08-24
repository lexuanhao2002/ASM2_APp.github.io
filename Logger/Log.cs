using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Logger
{
    public sealed class Log: Ilog
    {
        private Log()
        {

        }
        public static readonly Lazy<Log> instance = new Lazy<Log>(() => new Log());
        public static Ilog GetInstance
        {
            get
            {
                return instance.Value;
            }
        }
        public void LogException(string message)
        {
            string fileName = string.Format("{0}_{1}.log", "Exeption", DateTime.Now.ToShortDateString());
            string filePath = string.Format(@"{0}\{1}", AppDomain.CurrentDomain.BaseDirectory, fileName);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("------------------------");
            sb.AppendLine(DateTime.Now.ToString());
            sb.AppendLine(message);
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.Write(sb.ToString());
                writer.Flush();
            }
        }
    }
}
