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

        public object ExamBloodPressure(dynamic obj)
        {
            float highVal = obj.highVal;
            float lowVal = obj.lowVal;
            float heartRate = obj.heartRate;
            string clientId = obj.clientId;
            string result = obj.result;
            string risk = obj.risk;
            string advice = obj.advice;
            // var examRet = ExamBLL.ExamBloodPressure(highVal, lowVal);
            var examRet = GetResultModel(result, risk, advice);
            ExamBLL.SaveBloodPressure(highVal, lowVal, heartRate, clientId, examRet);
            return new { Result = true };
        }


        public object ExamBloodSugar(dynamic obj)
        {
            float value = obj.value;
            string clientId = obj.clientId;
            int status = obj.status;
            string result = obj.result;
            string risk = obj.risk;
            string advice = obj.advice;
            var examRet = GetResultModel(result, risk, advice);
            ExamBLL.SaveBloodSugar(value, status, clientId, examRet);
            return new { Result = true };
        }


        public object ExamBloodFat(dynamic obj)
        {
            float value = obj.value;
            string clientId = obj.clientId;
            string result = obj.result;
            string risk = obj.risk;
            string advice = obj.advice;
            //var examRet = ExamBLL.SimpleExam("bloodfat", value);
            var examRet = GetResultModel(result, risk, advice);
            ExamBLL.SaveBloodFat(value, clientId, examRet);
            return new { Result = true };
        }

        public object ExamBloodOxy(dynamic obj)
        {
            float value = obj.value;
            float bpm = obj.bpm;
            float pi = obj.pi;
            string clientId = obj.clientId;
            string result = obj.result;
            string risk = obj.risk;
            string advice = obj.advice;
            var examRet = GetResultModel(result, risk, advice);
            ExamBLL.SaveBloodOxy(value, bpm, pi, clientId, examRet);
            return new { Result = true };
        }

        public object ExamUricAcid(dynamic obj)
        {
            float value = obj.value;
            int sex = obj.sex;
            string clientId = obj.clientId;
            string result = obj.result;
            string risk = obj.risk;
            string advice = obj.advice;
            var examRet = GetResultModel(result, risk, advice);
            ExamBLL.SaveUricAcid(value, sex, clientId, examRet);
            return new { Result = true };
        }

        public object ExamTemperature(dynamic obj)
        {
            float value = obj.value;
            string clientId = obj.clientId;
            string result = obj.result;
            string risk = obj.risk;
            string advice = obj.advice;
            var examRet = GetResultModel(result, risk, advice);
            ExamBLL.SaveTemperature(value, clientId, examRet);
            return new { Result = true };
        }

        [HttpPost]
        public object ExamCardiogram(dynamic obj)
        {
            string value = String.Join(",", obj.value);
            string clientId = obj.clientId;
            string result = obj.result;
            string risk = obj.risk;
            string advice = obj.advice;
            var examRet = GetResultModel(result, risk, advice);
            ExamBLL.SaveCardiogram(value, clientId, examRet);
            return new { Result = true };
        }

        public object ExamBody(
            dynamic obj
            )
        {
            string weightsum = obj.weightsum;
            string BMI = obj.BMI;
            string fatRate = obj.fatRate;
            string muscle = obj.muscle;
            string moisture = obj.moisture;
            string boneMass = obj.boneMass;
            string subcutaneousFat = obj.subcutaneousFat;
            string BMR = obj.BMR;
            string proteinRate = obj.proteinRate;
            string physicalAge = obj.physicalAge;
            string weightScore = obj.weightScore;
            string clientId = obj.clientId;
            string result = obj.result;
            string risk = obj.risk;
            string advice = obj.advice;
            var examRet = GetResultModel(result, risk, advice);
            ExamBLL.SaveBody(weightsum, BMI, fatRate, muscle,
            moisture, boneMass, subcutaneousFat, BMR, proteinRate, physicalAge, weightScore,
            clientId, examRet);
            return new { Result = true };
        }

        [HttpPost]
        public List<object> ViewHistory(dynamic obj)
        {
            string name = obj.name;
            string clientId = obj.clientId;
            DateTime fromDate = obj.fromDate;
            DateTime endDate = obj.endDate;
            return ExamBLL.ViewHistory(name, clientId, fromDate, endDate);
        }

        [HttpPost]
        public object GetAllExamResult(dynamic obj)
        {
            string clientId = obj.clientId;
            int pageNum = obj.pageNum;
            int pageSize = obj.pageSize;
            return ExamBLL.GetAllExamResult(clientId, pageNum, pageSize);
        }
    }
}
