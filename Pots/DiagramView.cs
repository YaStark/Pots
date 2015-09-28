using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pots
{
    public partial class DiagramView : UserControl
    {
        public delegate void OnItemSelectHandler(object obj, int index);
        public event OnItemSelectHandler OnItemSelect;

        List<IPotDraw> pots = new List<IPotDraw>();
        public int TableMaxWidth = 10;
        public int MaxRadius = 100;
        int _padding = 10;

        public List<IPotDraw> Items { get { return pots; } }

        PointF translateMove = new PointF();
        PointF translateMoveOffset = new PointF();
        bool isDragged = false;
        int LastFocused = -1;

        public DiagramView()
        {
            InitializeComponent();
        }

        public new void Update()
        {
            pictureBoxView.Invalidate();
            pictureBoxView.Update();
            base.Update();
        }

        /// <summary>
        /// Draw
        /// </summary>
        private void pictureBoxView_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            float scale = trackBar1.Value * 0.01f;
            e.Graphics.TranslateTransform(translateMove.X, translateMove.Y);
            e.Graphics.ScaleTransform(scale, scale);

            int col = 0, row = 0;
            Rectangle rt = new Rectangle(_padding, _padding, MaxRadius, MaxRadius);
            foreach (var pot in pots)
            {
                rt.Location = new Point((_padding + MaxRadius) * col, (_padding + MaxRadius) * row);
                pot.Draw(e.Graphics, rt);
                col++;
                if (col > TableMaxWidth) 
                {
                    col = 0;
                    row++;
                }
            }
        }

        /// <summary>
        /// Begin drag
        /// </summary>
        private void pictureBoxView_MouseDown(object sender, MouseEventArgs e)
        {
            isDragged = true;
            translateMoveOffset.X = e.X - translateMove.X;
            translateMoveOffset.Y = e.Y - translateMove.Y;
        }

        /// <summary>
        /// Continue drag
        /// </summary>
        private void pictureBoxView_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragged)
            {
                translateMove.X = e.X - translateMoveOffset.X;
                translateMove.Y = e.Y - translateMoveOffset.Y;
            }

            if (LastFocused >= 0) Items[LastFocused].SetState(DrawState.ImageAccent);
            int circle = GetCircleCountByCoordinates(e.X, e.Y);
            if (circle >= 0 && Items.Count > circle)
            {
                Items[circle].SetState(DrawState.TextAccent);
                LastFocused = circle;
            }
            Update();
        }

        /// <summary>
        /// End drag
        /// </summary>
        private void pictureBoxView_MouseUp(object sender, MouseEventArgs e)
        {
            isDragged = false;
        }

        private int GetCircleCountByCoordinates(int X, int Y)
        {
            float scale = trackBar1.Value * 0.01f;
            float x = (X - translateMove.X) / scale;
            float y = (Y - translateMove.Y) / scale;

            int col = (int)x / (_padding + MaxRadius);
            int row = (int)y / (_padding + MaxRadius);

            int mcol = (int)x % (_padding + MaxRadius);
            int mrow = (int)y % (_padding + MaxRadius);
            if (mcol > MaxRadius || mrow > MaxRadius) return -1;

            if (col < 0 || col >= TableMaxWidth) return -1;
            if (row < 0) return -1;
            return row * TableMaxWidth + col;
        }

        /// <summary>
        /// Resize
        /// </summary>
        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            pictureBoxView.Invalidate();
            pictureBoxView.Update();
        }

        /// <summary>
        /// Select item
        /// </summary>
        private void pictureBoxView_MouseClick(object sender, MouseEventArgs e)
        {
            int circle = GetCircleCountByCoordinates(e.X, e.Y);
            if (circle < 0 || circle >= Items.Count) return;
            if (OnItemSelect != null) OnItemSelect(Items[circle], circle);
        }

    }
}
