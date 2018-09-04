using Exam.BLL.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;

namespace Examination.App_Start
{
    public class WebApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        //重写基类的异常处理方法
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            LogHelper.SystemError("", actionExecutedContext.Exception);
            base.OnException(actionExecutedContext);
        }
    }
}