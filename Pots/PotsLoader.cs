using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Pots
{
    public static class PotsLoader
    {
        public static ulong KeySelector(int Pot, int Period)
        {
            return ((ulong)Pot << 32) | (ulong)Period;
        }

        public static XmlSerializer GetSerializer()
        {
            return new XmlSerializer(typeof(List<PotXmlModel>),
                                           new Type[] { typeof(PotXmlModel), typeof(FillerXmlModel) });

        }

        public static void Serialize(string Path, PotPeriodFiller[] Fillers)
        {
            
            var pots = Fillers.GroupBy(o => KeySelector(o.PotKey, o.PeriodKey))
                                        .Select(o => PotXmlModel.LoadFromFillers(o.ToArray()))
                                        .ToList();
            pots.RemoveAll(o => o == null);
            XmlSerializer serializer = GetSerializer();

            using (FileStream fs = new FileStream(Path, FileMode.OpenOrCreate))
            {
                
                serializer.Serialize(fs, pots);
                
            }
        }

        public static PotPeriodFiller[] Deserialize(string Path)
        {
            List<PotXmlModel> pots;

            XmlSerializer serializer = GetSerializer();

            using (FileStream fs = new FileStream(Path, FileMode.OpenOrCreate))
            {
                try
                {
                    pots = (List<PotXmlModel>)serializer.Deserialize(fs);
                    return pots.SelectMany(o => PotXmlModel.ToFillers(o))
                               .Where(o => o != null).ToArray();
                }
                catch { return null; }
            }
        }


    }

    [Serializable]
    public class PotXmlModel
    {
        public string PotName { get; set; }

        public DateTime PeriodTimeStamp { get; set; }

        public FillerXmlModel[] Fillers { get; set; }


        public PotXmlModel() { }

        public static PotPeriodFiller[] ToFillers(PotXmlModel model)
        {
            int pot = -1, period = -1;
            try
            {
                pot = Form1.DataContext.GetTable<PotObject>()
                                           .Where(o => o.PName == model.PotName)
                                           .ToArray()[0].PotKey;

                period = Form1.DataContext.GetTable<PeriodsObject>()
                                              .Where(o => o.PTimeStamp == model.PeriodTimeStamp)
                                              .ToArray()[0].PeriodKey;
            }
            catch { return null; }

            List<PotPeriodFiller> fillers = new List<PotPeriodFiller>();
            foreach(var filler in model.Fillers)
            {
                int fkey = -1;
                try
                {
                    fkey = Form1.DataContext.GetTable<FillersObject>()
                                              .Where(o => o.FName == filler.FillerName)
                                              .ToArray()[0].FillerKey;
                }
                catch { break; }

                PotPeriodFiller potFiller = new PotPeriodFiller();
                potFiller.PotKey = pot;
                potFiller.PeriodKey = period;
                potFiller.FillerKey = fkey;
                potFiller.Quantity = filler.FillerQuantity;

                fillers.Add(potFiller);
            }
            return fillers.ToArray();
        }

        public static PotXmlModel LoadFromFillers(PotPeriodFiller[] PPFillers)
        {
            PotXmlModel pot = new PotXmlModel();
            int potKey = PPFillers[0].PotKey, periodKey = PPFillers[0].PeriodKey;
            foreach (var filler in PPFillers)
            {
                if (potKey != filler.PotKey || periodKey != filler.PeriodKey) 
                    throw new ArgumentException("Fillers should be from one PotPeriod");
            }

            try
            {
                pot.PotName = Form1.DataContext.GetTable<PotObject>()
                                           .Where(o => o.PotKey == potKey)
                                           .ToArray()[0].PName;
                pot.PeriodTimeStamp = Form1.DataContext.GetTable<PeriodsObject>()
                                                       .Where(o => o.PeriodKey == periodKey)
                                                       .ToArray()[0].PTimeStamp;
            }
            catch { return null; }

            pot.Fillers = new FillerXmlModel[PPFillers.Length];
            for (int i = 0; i < pot.Fillers.Length; i++)
            {
                pot.Fillers[i] = new FillerXmlModel();
                pot.Fillers[i].FillerName = Form1.DataContext.GetTable<FillersObject>()
                                             .Where(o => o.FillerKey == PPFillers[i].FillerKey)
                                             .ToArray()[0].FName;
                pot.Fillers[i].FillerQuantity = PPFillers[i].Quantity;
            }
            return pot;
        }
    }

    [Serializable]
    public class FillerXmlModel
    {
        public string FillerName { get; set; }

        public double FillerQuantity { get; set; }

        public FillerXmlModel() { }
    }
}
