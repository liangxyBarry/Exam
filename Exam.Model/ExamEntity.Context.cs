﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Exam.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ExaminationEntities : DbContext
    {
        public ExaminationEntities()
            : base("name=ExaminationEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BloodFat> BloodFat { get; set; }
        public virtual DbSet<BloodOxy> BloodOxy { get; set; }
        public virtual DbSet<Cardiogram> Cardiogram { get; set; }
        public virtual DbSet<Temperature> Temperature { get; set; }
        public virtual DbSet<UricAcid> UricAcid { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<BloodPressure> BloodPressure { get; set; }
        public virtual DbSet<Token> Token { get; set; }
        public virtual DbSet<BloodSugar> BloodSugar { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Body> Body { get; set; }
    }
}
