using Exam.BLL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Examination.Controllers
{
    public class ExamController : ApiController
    {
        public object ExamBloodPressure(float highVal, float lowVal, string clientId)
        {
            var examRet = ExamBLL.ExamBloodPressure(highVal, lowVal);
            ExamBLL.SaveBloodPressure(highVal, lowVal, clientId, examRet);
            return examRet;
        }


        public object ExamBloodSugar(float value, string clientId, bool isAfterMeal = false)
        {
            var examRet = ExamBLL.ExamBloodSugar(value, isAfterMeal);
            ExamBLL.SaveBloodSugar(value, isAfterMeal, clientId, examRet);
            return examRet;
        }


        public object ExamBloodFat(float value, string clientId)
        {
            var examRet = ExamBLL.SimpleExam("bloodfat", value);
            ExamBLL.SaveBloodFat(value, clientId, examRet);
            return examRet;
        }

        public object ExamBloodOxy(float value, float bpm, float pi, string clientId)
        {
            var oxyRet = ExamBLL.SimpleExam("bloodoxy", value);
            var bmpRet = ExamBLL.SimpleExam("bmp", value);
            var examRet = new { Oxy = oxyRet, BMP = bmpRet };
            ExamBLL.SaveBloodOxy(value, bpm, pi, clientId, examRet);
            return examRet; 
        }

        public object ExamUricAcid(float value, int sex, string clientId )
        {
            var examRet = ExamBLL.ExamUricAcid(value, sex);
            ExamBLL.SaveUricAcid(value, sex, clientId, examRet);
            return examRet;
        }

        public object ExamTemperature(float value, string clientId)
        {
            var examRet = ExamBLL.SimpleExam("temperature", value);
            ExamBLL.SaveTemperature(value, clientId, examRet);
            return examRet;
        }

        public object ExamCardiogram(string value, string clientId)
        {
            ExamBLL.SaveCardiogram(value, clientId);
            return value;
        }
    }
}
