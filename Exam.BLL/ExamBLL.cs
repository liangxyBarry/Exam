using Exam.BLL.Helper;
using Exam.Model;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public static void SaveCardiogram(string val, string clientId, ExamResultModel examRet)
        {
            using (var ctx = new ExaminationEntities())
            {
                var model = new Cardiogram();
                model.ID = Guid.NewGuid();
                model.ExamDate = DateTime.Now;
                model.Cardiogram1 = val;
                model.ClientID = clientId.ToGuid();
                model.ExamRet = JsonConvert.SerializeObject(examRet);
                ctx.Cardiogram.Add(model);
                ctx.SaveChanges();
            }
        }

        public static void SaveBody(string weightsum, string BMI, string fatRate, string muscle,
            string moisture, string boneMass, string subcutaneousFat, string BMR, string proteinRate, string physicalAge, string weightScore,
            string clientId, ExamResultModel examRet)
        {
            using (var ctx = new ExaminationEntities())
            {
                var model = new Body();
                model.ID = Guid.NewGuid();
                model.ExamDate = DateTime.Now;
                model.WeightSum = weightsum;
                model.ClientID = clientId.ToGuid();
                model.BMI = BMI;
                model.FatRate = fatRate;
                model.Muscle = muscle;
                model.Moisture = moisture;
                model.BoneMass = boneMass;
                model.SubcutaneousFat = subcutaneousFat;
                model.BMR = BMR;
                model.ProteinRate = proteinRate;
                model.PhysicalAge = physicalAge;
                model.WeightScore = weightScore;
                model.ExamRet = JsonConvert.SerializeObject(examRet);
                ctx.Body.Add(model);
                ctx.SaveChanges();
            }
        }

        public static List<object> ViewHistory(string tableName, string clientId, DateTime fromDate, DateTime endDate)
        {
            using (var ctx = new ExaminationEntities())
            {
                Type ctxType = ctx.GetType();
                var tblProp = ctxType.GetProperty(tableName);
                object tblObj = tblProp.GetValue(ctx, null);
                var dbRecords = GetExistRecord(tblObj, "ClientID", clientId);
                IEnumerable records = dbRecords as IEnumerable;
                List<object> ret = new List<object>();
                foreach (object item in records)
                {
                    DateTime examDate = GetExamDate(item);
                    if(examDate<=endDate&& examDate >= fromDate)
                    {
                        ret.Add(item);
                    }
                }
                return ret;
            }
        }

        private static DateTime GetExamDate(object obj)
        {
            Type t = obj.GetType();
            DateTime? val = (DateTime?)t.GetProperty("ExamDate").GetValue(obj, null);
            return val.Value;
        }

        public static object GetExistRecord(object tableObj, string keyName, string keyVal)
        {
            Type type = tableObj.GetType();
            var methods = typeof(Queryable).GetMethods();
            var firstOrDefaultMethod = methods.FirstOrDefault(m => m.Name == "Where" && m.GetParameters().Count() == 2);
            var entityType = type.GetGenericArguments().First();
            var keyProp = entityType.GetProperty(keyName);
            Guid key = Guid.Empty;
            Guid.TryParse(keyVal, out key);
            ParameterExpression parameter = Expression.Parameter(entityType, keyName);
            MemberExpression property = Expression.Property(parameter, keyName);
            ConstantExpression rightSide = Expression.Constant(key, keyProp.PropertyType);
            BinaryExpression operation = Expression.Equal(property, rightSide);
            Type delegateType = typeof(Func<,>).MakeGenericType(entityType, typeof(bool));
            LambdaExpression predicate = Expression.Lambda(delegateType, operation, parameter);
            var method = firstOrDefaultMethod.MakeGenericMethod(entityType);
            return method.Invoke(null, new object[] { tableObj, predicate });
        }

        public static object GetAllExamResult(string clientId)
        {
            Guid clientIdGuid = clientId.ToGuid();
            using (var ctx = new ExaminationEntities())
            {
                var bloodFat = ctx.BloodFat.Where(b=>b.ClientID==clientIdGuid).ToList();
                var bloodOxy = ctx.BloodOxy.Where(b => b.ClientID == clientIdGuid).ToList();
                var bloodPressure = ctx.BloodPressure.Where(b => b.ClientID == clientIdGuid).ToList();
                var bloodSugar = ctx.BloodSugar.Where(b => b.ClientID == clientIdGuid).ToList();
                var body = ctx.Body.Where(b => b.ClientID == clientIdGuid).ToList();
                var cardiogram = ctx.Cardiogram.Where(b => b.ClientID == clientIdGuid).ToList();
                var temperature = ctx.Temperature.Where(b => b.ClientID == clientIdGuid).ToList();
                var uricAcid = ctx.UricAcid.Where(b => b.ClientID == clientIdGuid).ToList();
                return new { bloodFat, bloodOxy, bloodPressure, bloodSugar , body, cardiogram, temperature , uricAcid };
            }
        }

    }
}
