using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pots
{
    public class AbstractPot : IPotDraw
    {
        /// <summary>
        /// DebitCalc method
        /// </summary>
        public static float GetDebit(float Production, float MinutesSpent)
        {
            return Production / MinutesSpent * 24;                 // According to task
        }

        /// <summary>
        /// Object for drawing
        /// </summary>
        protected PotDraw potDraw = new PotDraw();

        /// <summary>
        /// Pot's name
        /// </summary>
        public string Name { get; set; }
        
        public void Draw(Graphics g, Rectangle Bounds, bool CanOverflow = false)
        {
            float radius = Bounds.Width * 0.5f;
            potDraw.Draw(g, new PointF(Bounds.X + radius, Bounds.Y + radius), radius);
        }

        public void Ini()
        {
            potDraw.AddInfo(Name, -15);
            potDraw.FillColor = Color.Transparent;
            potDraw.LineColor = Color.Gray;
        }

        public void SetState(DrawState DrawState)
        {
            potDraw.DrawState = DrawState;
        }
    }

    public class NullPot : AbstractPot, IPotDraw
    {
        public new void Draw(Graphics g, Rectangle Bounds, bool CanOverflow = false)
        {
            float radius = Bounds.Width * 0.5f;
            potDraw.Draw(g, new PointF(Bounds.X + radius, Bounds.Y + radius), radius);
        }

        public new void Ini()
        {
            potDraw.FillColor = Color.Transparent;
            potDraw.LineColor = Color.LightGray;
        }
    }

    public class EmptyPot : AbstractPot, IPotDraw
    {
        public string State { get; set; }

        public EmptyPot() { }

        public EmptyPot(AbstractPot pot)
        {
            Name = pot.Name;
        }

        public new void Draw(Graphics g, Rectangle Bounds, bool CanOverflow = false)
        {
            float radius = Bounds.Width * 0.5f;
            potDraw.Draw(g, new PointF(Bounds.X + radius, Bounds.Y + radius), radius);
        }

        public new void Ini()
        {
            potDraw.AddInfo(Name, -15);
            potDraw.FillColor = Color.LightGray;
        }
    }

    public class WateredPot : AbstractPot, IPotDraw
    {
        public float WaterCount { get; set; }

        public string FillingMethod { get; set; }

        public string State { get; set; }

        public float MinutesSpent { get; set; }

        protected float DebitWater { get { return AbstractPot.GetDebit(WaterCount, MinutesSpent); } }

        public WateredPot(AbstractPot pot)
        {
            Name = pot.Name;
        }

        public WateredPot(WateredPot pot) : this(pot as AbstractPot)
        {
            WaterCount = pot.WaterCount;
            FillingMethod = pot.FillingMethod;
            State = pot.State;
            MinutesSpent = pot.MinutesSpent;
        }
        
        public WateredPot()
        {

        }

        public new void Ini()
        {
            potDraw.AddInfo(Name, -15);
            potDraw.AddInfo(String.Format("{0:0.0}", DebitWater), 90, 0.9f);
            potDraw.FillColor = Color.LightGreen;
        }

        public new void Draw(Graphics g, Rectangle Bounds, bool CanOverflow = false)
        {
            float radius = (float)(0.6 * Math.Sqrt(DebitWater));                      // According to task
            if (!CanOverflow && radius > Bounds.Width / 2) radius = Bounds.Width / 2;
            potDraw.Draw(g, new PointF(Bounds.X + Bounds.Width / 2, Bounds.Y + Bounds.Height / 2), radius);
        }
    }

    public class HgPot : WateredPot, IPotDraw
    {
        public float HgCount { get; set; }

        protected float Waterity { get { return WaterCount / (WaterCount + HgCount) * 100; } }

        protected float DebitHg { get { return AbstractPot.GetDebit(HgCount, MinutesSpent); } }

        public HgPot(WateredPot pot)
            : base(pot as WateredPot)
        {

        }

        public HgPot() { }

        public new void Ini()
        {
            potDraw.AddInfo(Name, -15);
            potDraw.AddInfo(FillingMethod, 290, 0.9f);
            potDraw.AddInfo(String.Format("{0:0}%", Waterity), 190, 0.8f);
            potDraw.AddInfo(String.Format("{0:0.0}/{1:0.0}", DebitHg, DebitWater + DebitHg), 100, 0.8f);
            potDraw.AddSlice(Color.Khaki, (100 - Waterity) * 0.01f);
            potDraw.FillColor = Color.LightSteelBlue;
        }

        public new void Draw(Graphics g, Rectangle Bounds, bool CanOverflow = false)
        {
            float radius = (float)(0.9 * Math.Sqrt(DebitWater + DebitHg));  // According to task
            if (!CanOverflow && radius > Bounds.Width / 2) radius = Bounds.Width / 2;
            potDraw.Draw(g, new PointF(Bounds.X + Bounds.Width / 2, Bounds.Y + Bounds.Height / 2), radius);
        }
    }
}
