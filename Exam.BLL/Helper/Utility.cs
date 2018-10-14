using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.BLL.Helper
{
    public static class Utility
    {
        public static void SetObjectValueWithSamePropName(object src, object target, List<string> ignoreProps)
        {
            if (src == null)
            {
                return;
            }
            var srcProps = src.GetType().GetProperties();
            Type targetType = target.GetType();
            foreach (var srcProp in srcProps)
            {
                if (!srcProp.CanRead)
                {
                    continue;
                }
                if(ignoreProps.Contains(srcProp.Name))
                {
                    continue;
                }

                var targetProp = targetType.GetProperty(srcProp.Name);
                if (targetProp == null || !targetProp.CanWrite)
                {
                    continue;
                }
                object value = srcProp.GetValue(src);
                try
                {

                    targetProp.SetValue(target, value);
                }
                catch
                {
                    LogHelper.InfoFormat("SetObjectValueWithSamePropName failed to set the prop {0} of {1}, value {2}", srcProp.Name, targetType.Name, (value ?? "").ToString());
                }
            }
        }

        public static Guid ToGuid(this string val)
        {
            return Guid.Parse(val);
        }
    }
}
