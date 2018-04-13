using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Exam.BLL.Helper
{
    public class LogHelper
    {
        private static readonly ILog _log = LogManager.GetLogger("MAIN");
        private static readonly ILog _sysErrorLog = LogManager.GetLogger("SYS_ERROR");

        private static object errorLockObj2 = new object();
        public static void SystemError(string info)
        {
            lock (errorLockObj2)
            {
                _sysErrorLog.ErrorFormat(info);
            }
        }


        private static object errorLockObj = new object();
        public static void SystemError(string info, Exception exception)
        {
            lock (errorLockObj)
            {
                _sysErrorLog.Error(info, exception);
            }
        }

        public static void InfoFormat(string message, params object[] args)
        {
           
            _log.InfoFormat(message, args);
        }
    }
}
