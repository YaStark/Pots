using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pots
{
    public class BaseData
    {
        public static int GetNextKey<T>(Expression<Func<T, int>> Condition) where T : class
        {
            try
            {
                return Form1.DataContext.GetTable<T>().Max(Condition) + 1;
            }
            catch
            {
                return 0;
            }
        }

        public static bool Save<T>(T obj, bool Modify) where T : class
        {
            try
            {
                if (!Modify && !Form1.DataContext.GetTable<T>().Contains(obj))
                    Form1.DataContext.GetTable<T>().InsertOnSubmit(obj);
                Form1.DataContext.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool Delete<T>(T obj) where T : class
        {
            try
            {
                if (!Form1.DataContext.GetTable<T>().Contains(obj))
                    Form1.DataContext.GetTable<T>().Attach(obj);
                Form1.DataContext.GetTable<T>().DeleteOnSubmit(obj);
                Form1.DataContext.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static T Load<T>(Expression<Func<T, bool>> Condition) where T : class
        {
            var _periods = Form1.DataContext.GetTable<T>().Where(Condition).ToArray();
            if (_periods.Length > 0) return _periods[0];
            return null;
        }
    }

    [Table(Name = "States")]
    public class StatesObject
    {
        [Column(IsPrimaryKey = true)]
        public int StateKey { get; set; }

        [Column]
        public string SName { get; set; }

        [Column(CanBeNull = true)]
        public string SDescription { get; set; }

        public bool Save(bool Modify)
        {
            if (!Modify) this.StateKey = BaseData.GetNextKey<StatesObject>(o => o.StateKey);
            return BaseData.Save<StatesObject>(this, Modify);
        }

        public bool Delete()
        {
            return BaseData.Delete<StatesObject>(this);
            //return BaseData.Delete<StatesObject>(new StatesObject() { StateKey = StateKey });
        }

        public static StatesObject Load(int Key)
        {
            return BaseData.Load<StatesObject>(o => o.StateKey == Key);
        }
    }

    [Table(Name = "Periods")]
    public class PeriodsObject
    {
        [Column(IsPrimaryKey = true)]
        public int PeriodKey { get; set; }

        [Column]
        public DateTime PTimeStamp { get; set; }

        [Column(CanBeNull = true)]
        public string PDescription { get; set; }

        public bool Save(bool Modify)
        {
            if (!Modify) this.PeriodKey = BaseData.GetNextKey<PeriodsObject>(o => o.PeriodKey);
            return BaseData.Save<PeriodsObject>(this, Modify);
        }

        public bool Delete()
        {
            return BaseData.Delete<PeriodsObject>(this);
            //return BaseData.Delete<PeriodsObject>(new PeriodsObject() { PeriodKey = PeriodKey });
        }

        public static PeriodsObject Load(int Key)
        {
            return BaseData.Load<PeriodsObject>(o => o.PeriodKey == Key);
        }
    }

    [Table(Name = "Methods")]
    public class MethodsObject
    {
        [Column(IsPrimaryKey = true)]
        public int MethodKey { get; set; }

        [Column]
        public string MName { get; set; }

        [Column(CanBeNull = true)]
        public string MDescription { get; set; }

        public bool Save(bool Modify)
        {
            if (!Modify) this.MethodKey = BaseData.GetNextKey<MethodsObject>(o => o.MethodKey);
            return BaseData.Save<MethodsObject>(this, Modify);
        }

        public bool Delete()
        {
            return BaseData.Delete<MethodsObject>(this);
            //return BaseData.Delete<MethodsObject>(new MethodsObject() { MethodKey = MethodKey });
        }

        public static MethodsObject Load(int Key)
        {
            return BaseData.Load<MethodsObject>(o => o.MethodKey == Key);
        }
    }

    [Table(Name = "Fillers")]
    public class FillersObject
    {
        [Column(IsPrimaryKey = true)]
        public int FillerKey { get; set; }

        [Column]
        public string FName { get; set; }

        [Column(CanBeNull = true)]
        public string FDescription { get; set; }

        public bool Save(bool Modify)
        {
            if (!Modify) this.FillerKey = BaseData.GetNextKey<FillersObject>(o => o.FillerKey);
            return BaseData.Save<FillersObject>(this, Modify);
        }

        public bool Delete()
        {
            return BaseData.Delete<FillersObject>(this);
            //return BaseData.Delete<FillersObject>(new FillersObject() { FillerKey = FillerKey });
        }

        public static FillersObject Load(int Key)
        {
            return BaseData.Load<FillersObject>(o => o.FillerKey == Key);
        }
    }

    [Table(Name="Pots")]
    public class PotObject
    {
        [Column(IsPrimaryKey = true)]
        public int PotKey { get; set; }
        
        [Column]
        public string PName { get; set; }

        [Column(CanBeNull = true)]
        public string PDescription { get; set; }

        public bool Save(bool Modify)
        {
            if (!Modify) this.PotKey = BaseData.GetNextKey<PotObject>(o => o.PotKey);
            return BaseData.Save<PotObject>(this, Modify);
        }

        public bool Delete()
        {
            return BaseData.Delete<PotObject>(this);
            //return BaseData.Delete<PotObject>(new PotObject() { PotKey = PotKey });
        }

        public static PotObject Load(int Key)
        {
            return BaseData.Load<PotObject>(o => o.PotKey == Key);
        }
    }

    [Table]
    public class PotPeriod
    {
        [Column(IsPrimaryKey=true)]
        public int PotKey { get; set; }

        [Column(IsPrimaryKey = true)]
        public int PeriodKey { get; set; }

        [Column]
        public bool Availability { get; set; }

        public bool Save(bool Modify)
        {
            return BaseData.Save<PotPeriod>(this, Modify);
        }

        public bool Delete()
        {
            return BaseData.Delete<PotPeriod>(this);
            //return BaseData.Delete<PotPeriod>(new PotPeriod() { PeriodKey = PeriodKey, PotKey = PotKey });
        }

        public static PotPeriod Load(int Pot, int Period)
        {
            return BaseData.Load<PotPeriod>(o => o.PotKey == Pot && o.PeriodKey == Period);
        }
    }

    [Table]
    public class PotPeriodFiller
    {
        [Column(IsPrimaryKey = true)]
        public int PotKey { get; set; }

        [Column(IsPrimaryKey = true)]
        public int PeriodKey { get; set; }

        [Column(IsPrimaryKey = true)]
        public int FillerKey { get; set; }

        [Column]
        public double Quantity { get; set; }

        public bool Save(bool Modify)
        {
            return BaseData.Save<PotPeriodFiller>(this, Modify);
        }

        public bool Delete()
        {
            return BaseData.Delete<PotPeriodFiller>(this);
                //new PotPeriodFiller() { PotKey = PotKey, PeriodKey = PeriodKey, FillerKey = FillerKey });
        }

        public static PotPeriodFiller Load(int Pot, int Period, int Filler)
        {
            return BaseData.Load<PotPeriodFiller>(
                o => o.PotKey == Pot && o.PeriodKey == Period && o.FillerKey == Filler);
        }
    }

    [Table]
    public class PotPeriodAvailable
    {
        [Column(IsPrimaryKey = true)]
        public int PotKey { get; set; }

        [Column(IsPrimaryKey = true)]
        public int PeriodKey { get; set; }

        [Column]
        public bool Empty { get; set; }

        [Column]
        public int MethodKey { get; set; }
        
        [Column]
        public int StateKey { get; set; }

        [Column]
        public double MinutesSpent { get; set; }

        public bool Save(bool Modify)
        {
            return BaseData.Save<PotPeriodAvailable>(this, Modify);
        }

        public bool Delete()
        {
            return BaseData.Delete<PotPeriodAvailable>(this);
            //return BaseData.Delete<PotPeriodAvailable>(
            //    new PotPeriodAvailable() { PotKey = PotKey, PeriodKey = PeriodKey });
        }

        public static PotPeriodAvailable Load(int? Pot, int? Period)
        {
            if (Pot == null || Period == null) return null;
            return BaseData.Load<PotPeriodAvailable>(
                o => o.PotKey == Pot && o.PeriodKey == Period);
        }
    }
}
