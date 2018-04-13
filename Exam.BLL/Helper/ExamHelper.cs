using Exam.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.BLL.Helper
{
    public class ExamHelper
    {
        public static string GetExamSettings(string name)
        {
            string filePath = GlobalVars.SettingDir + "\\" + name + ".json";
            return File.ReadAllText(filePath);
        }

        public static ExamStandardModel GetCurrentStandard(float value, List<ExamStandardModel> standards)
        {
            var ret = standards.FirstOrDefault(s => IsStandardMatch(value, s.Standard));
            if (ret == null)
            {
                throw new Exception("没有找到符合的标准");
            }
            return ret;
        }

        private static bool IsStandardMatch(float val, string standard)
        {
            if(standard.Contains("-"))
            {
                string[] stVals = standard.Split('-');
                string minStr = stVals[0].Trim();
                string maxStr = stVals[1].Trim();
                float min = float.Parse(minStr);
                float max = float.Parse(maxStr);
                return val >= min && val <= max;
            }
            else if(standard.Contains("<"))
            {
                string maxStr = standard.Trim('<').Trim();
                float max = float.Parse(maxStr);
                return val < max;
            }
            else if (standard.Contains(">"))
            {
                string minStr = standard.Trim('>').Trim();
                float min = float.Parse(minStr);
                return val > min;
            }
            else
            {
                throw new Exception("标准配置文件不正确: " + standard);
            }
        }
    }
}
