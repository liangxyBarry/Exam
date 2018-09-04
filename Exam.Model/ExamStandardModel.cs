using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Model
{
    public class ExamStandardModel
    {
        public string Standard { get; set; }

        public int Code { get; set; }

        public string Text { get; set; }
    }

    public class ExamResultModel
    {
        public string Result { get; set; }

        public string Risk { get; set; }

        public string Advice { get; set; }
    }
}
