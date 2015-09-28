using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pots
{
    public enum DrawState { Normal, TextAccent, ImageAccent }

    public interface IPotDraw
    {
        void SetState(DrawState DrawState);

        void Draw(Graphics g, Rectangle Bounds, bool CanOverflow = false);

        void Ini();
    }

    public static class IPotDrawFactory
    {
        public static IPotDraw FromPotPeriod(int Pot, int Period)
        {
            // Null Pot

            PotObject pot = PotObject.Load(Pot);
            if (pot == null) return new NullPot();
            Pot = pot.PotKey;
            PotPeriod potPeriod = PotPeriod.Load(Pot, Period); 
            if(potPeriod == null) return new NullPot();

            // Abstract Pot

            var apot = new AbstractPot();
            apot.Name = pot.PName;
            if (!potPeriod.Availability) return apot;
            PotPeriodAvailable avail = PotPeriodAvailable.Load(Pot, Period);
            if (avail == null) return apot;

            // Empty Pot
            
            var epot = new EmptyPot(apot);
            var state = StatesObject.Load(avail.StateKey);
            if (state != null) epot.State = state.SName;
            if (avail.Empty || avail.MinutesSpent == 0) return epot;
            PotPeriodFiller fWater = PotPeriodFiller.Load(Pot, Period, (int)Form1.Fillers.Water);
            PotPeriodFiller fHg = PotPeriodFiller.Load(Pot, Period, (int)Form1.Fillers.Hg);
            if (fWater == null && fHg == null) return epot;

            // Watered Pot

            var wpot = new WateredPot(apot);
            wpot.MinutesSpent = (float)avail.MinutesSpent;
            if(state != null) wpot.State = state.SName;            
            var method = MethodsObject.Load(avail.MethodKey);
            if(method != null) wpot.FillingMethod = method.MName;

            if (fWater != null) wpot.WaterCount = (float)fWater.Quantity;
            else wpot.WaterCount = 0;
            if (fHg == null) return wpot;
    
            // Hg Pot

            var hgpot = new HgPot(wpot);
            hgpot.HgCount = (float)fHg.Quantity;
            return hgpot;
        }
    }
}
