using Exam.BLL.Helper;
using Exam.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.BLL
{
    public class ExamBLL
    {
        //public static ExamResultModel SimpleExam(string settingName, float value)
        //{
        //    string settings = ExamHelper.GetExamSettings(settingName);
        //    var standards = JsonConvert.DeserializeObject<List<ExamResultModel>>(settings);
        //    ExamResultModel st = ExamHelper.GetCurrentStandard(value, standards);
        //    return st;
        //}


        //public static ExamResultModel ExamBloodPressure(float highVal, float lowVal)
        //{
        //    string settings = ExamHelper.GetExamSettings("bloodpressure");
        //    var standards = JsonConvert.DeserializeObject<List<List<ExamResultModel>>>(settings);
        //    List<ExamResultModel> highStandards = standards[0];
        //    List<ExamResultModel> lowStandards = standards[1];
        //    ExamResultModel highSt = ExamHelper.GetCurrentStandard(highVal, highStandards);
        //    ExamResultModel lowSt = ExamHelper.GetCurrentStandard(lowVal, lowStandards);
        //    if (highSt.Code > lowSt.Code)
        //    {
        //        return highSt;
        //    }
        //    else
        //    {
        //        return lowSt;
        //    }
        //}

        public static void SaveBloodPressure(float highVal, float lowVal, float heartRate, string clientId, ExamResultModel examRet)
        {
            using (var ctx = new ExaminationEntities())
            {
                var model = new BloodPressure();
                model.ID = Guid.NewGuid();
                model.ExamDate = DateTime.Now;
                model.HighPressure = highVal;
                model.LowPressure = lowVal;
                model.HeartRate = heartRate;
                model.ClientID = Guid.Parse(clientId);
                model.ExamRet = JsonConvert.SerializeObject(examRet);
                ctx.BloodPressure.Add(model);
                ctx.SaveChanges();
            }
        }

        //public static ExamResultModel ExamBloodSugar(float value, bool isAfterMeal)
        //{
        //    string settings = ExamHelper.GetExamSettings("bloodsugar");
        //    var allSts = JsonConvert.DeserializeObject<List<List<ExamResultModel>>>(settings);
        //    List<ExamResultModel> standards = isAfterMeal ? allSts[1] : allSts[0];
        //    ExamResultModel st = ExamHelper.GetCurrentStandard(value, standards);
        //    return st;
        //}

        public static void SaveBloodSugar(float value, int status, string clientId, ExamResultModel examRet)
        {
            using (var ctx = new ExaminationEntities())
            {
                var model = new BloodSugar();
                model.ID = Guid.NewGuid();
                model.ExamDate = DateTime.Now;
                model.BloodSugar1 = value;
                model.Meal = status;
                model.ClientID =clientId.ToGuid();
                model.ExamRet = JsonConvert.SerializeObject(examRet);
                ctx.BloodSugar.Add(model);
                ctx.SaveChanges();
            }
        }


        public static void SaveBloodFat(float val, string clientId, ExamResultModel examRet)
        {
            using (var ctx = new ExaminationEntities())
            {
                var model = new BloodFat();
                model.ID = Guid.NewGuid();
                model.ExamDate = DateTime.Now;
                model.BloodFat1 = val;
                model.ClientID = clientId.ToGuid();
                model.ExamRet = JsonConvert.SerializeObject(examRet);
                ctx.BloodFat.Add(model);
                ctx.SaveChanges();
            }
        }

        public static void SaveBloodOxy(float val, float bpm, float pi, string clientId, object examRet)
        {
            using (var ctx = new ExaminationEntities())
            {
                var model = new BloodOxy();
                model.ID = Guid.NewGuid();
                model.ExamDate = DateTime.Now;
                model.BloodOxy1 = val;
                model.BPM = bpm;
                model.PI = pi;
                model.ClientID = clientId.ToGuid();
                model.ExamRet = JsonConvert.SerializeObject(examRet);
                ctx.BloodOxy.Add(model);
                ctx.SaveChanges();
            }
        }

        //public static ExamResultModel ExamUricAcid(float val, int sex)
        //{
        //    string settings = ExamHelper.GetExamSettings("uricacid");
        //    var allSts = JsonConvert.DeserializeObject<List<List<ExamResultModel>>>(settings);
        //    List<ExamResultModel> standards = sex == 0 ? allSts[0] : allSts[1];
        //    ExamResultModel st = ExamHelper.GetCurrentStandard(val, standards);
        //    return st;
        //}

        public static void SaveUricAcid(float val, int sex, string clientId, ExamResultModel examRet)
        {
            using (var ctx = new ExaminationEntities())
            {
                var model = new UricAcid();
                model.ID = Guid.NewGuid();
                model.ExamDate = DateTime.Now;
                model.Sex=sex;
                model.UricAcid1 = val;
                model.ClientID = clientId.ToGuid();
                model.ExamRet = JsonConvert.SerializeObject(examRet);
                ctx.UricAcid.Add(model);
                ctx.SaveChanges();
            }
        }

        public static void SaveTemperature(float val, string clientId, ExamResultModel examRet)
        {
            using (var ctx = new ExaminationEntities())
            {
                var model = new Temperature();
                model.ID = Guid.NewGuid();
                model.ExamDate = DateTime.Now;
                model.Temperature1 = val;
                model.ClientID = clientId.ToGuid();
                model.ExamRet = JsonConvert.SerializeObject(examRet);
                ctx.Temperature.Add(model);
                ctx.SaveChanges();
            }
        }

        public static void SaveCardiogram(string val, string clientId)
        {
            using (var ctx = new ExaminationEntities())
            {
                var model = new Cardiogram();
                model.ID = Guid.NewGuid();
                model.ExamDate = DateTime.Now;
                model.Cardiogram1 = val;
                model.ClientID = clientId.ToGuid();
                model.ExamRet = val;
                ctx.Cardiogram.Add(model);
                ctx.SaveChanges();
            }
        }

        public static void SaveBody(string weightsum, string BMI, string fatRate, string muscle,
            string moisture, string boneMass, string subcutaneousFat, string BMR, string proteinRate, string physicalAge, string weightScore,
            string clientId, ExamResultModel examRet)
        {

        }

    }
}
