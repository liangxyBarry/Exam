using Exam.BLL;
using Exam.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Examination.Controllers
{
    [Authorize]
    public class ExamController : ApiController
    {

        private ExamResultModel GetResultModel(string result, string risk, string advice)
        {
            return new ExamResultModel() { Advice = advice, Result = result, Risk = risk };
        }

        public object ExamBloodPressure(float highVal, float lowVal, float heartRate,string clientId, string result, string risk, string advice)
        {
            // var examRet = ExamBLL.ExamBloodPressure(highVal, lowVal);
            var examRet = GetResultModel(result, risk, advice);
            ExamBLL.SaveBloodPressure(highVal, lowVal, heartRate, clientId, examRet);
            return new { Result = true };
        }


        public object ExamBloodSugar(float value, string clientId, int status, string result, string risk, string advice)
        {
            //var examRet = ExamBLL.ExamBloodSugar(value, status);
            var examRet = GetResultModel(result, risk, advice);
            ExamBLL.SaveBloodSugar(value, status, clientId, examRet);
            return new { Result = true };
        }


        public object ExamBloodFat(float value, string clientId, string result, string risk, string advice)
        {
            //var examRet = ExamBLL.SimpleExam("bloodfat", value);
            var examRet = GetResultModel(result, risk, advice);
            ExamBLL.SaveBloodFat(value, clientId, examRet);
            return new { Result = true };
        }

        public object ExamBloodOxy(float value, float bpm, float pi, string clientId, string result, string risk, string advice)
        {
            //var oxyRet = ExamBLL.SimpleExam("bloodoxy", value);
            //var bmpRet = ExamBLL.SimpleExam("bmp", value);
            //var examRet = new { Oxy = oxyRet, BMP = bmpRet };
            var examRet = GetResultModel(result, risk, advice);
            ExamBLL.SaveBloodOxy(value, bpm, pi, clientId, examRet);
            return new { Result = true };
        }

        public object ExamUricAcid(float value, int sex, string clientId, string result, string risk, string advice)
        {
            //var examRet = ExamBLL.ExamUricAcid(value, sex);
            var examRet = GetResultModel(result, risk, advice);
            ExamBLL.SaveUricAcid(value, sex, clientId, examRet);
            return new { Result = true };
        }

        public object ExamTemperature(float value, string clientId, string result, string risk, string advice)
        {
            //var examRet = ExamBLL.SimpleExam("temperature", value);
            var examRet = GetResultModel(result, risk, advice);
            ExamBLL.SaveTemperature(value, clientId, examRet);
            return new { Result = true };
        }

        [HttpPost]
        public object ExamCardiogram(string value, string clientId, string result,string risk,string advice)
        {
            var examRet = GetResultModel(result, risk, advice);
            ExamBLL.SaveCardiogram(value, clientId, examRet);
            return new { Result = true };
        }

        public object ExamBody(string weightsum, string BMI, string fatRate, string muscle, 
            string moisture, string boneMass, string subcutaneousFat, string BMR, string proteinRate, string physicalAge, string weightScore,
            string clientId, string result, string risk, string advice
            )
        {
            var examRet = GetResultModel(result, risk, advice);
            ExamBLL.SaveBody(weightsum, BMI, fatRate, muscle,
            moisture, boneMass, subcutaneousFat, BMR, proteinRate, physicalAge, weightScore,
            clientId, examRet);
            return new { Result = true };
        }

        [HttpPost]
        public List<object> ViewHistory(string name, string clientId, DateTime fromDate, DateTime endDate)
        {
            return ExamBLL.ViewHistory(name, clientId, fromDate, endDate);
        }

        [HttpPost]
        public object GetAllExamResult(string clientId, int pageNum, int pageSize)
        {
            return ExamBLL.GetAllExamResult(clientId, pageNum, pageSize);
        }
    }
}
