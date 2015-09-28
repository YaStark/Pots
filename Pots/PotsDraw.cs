using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pots
{
    public class PotDraw
    {

        /// <summary>
        /// Класс для реализации вывода текста
        /// </summary>
        sealed class TextDraw
        {
            public string Text { get; set; }

            public float Angle { get; set; }

            public float Resize { get; set; }

            public StringFormat Format
            {
                get
                {
                    StringFormat format = new StringFormat();
                    float _angle = Angle + 22.5f;
                        // Vertical
                    if (_angle > 0 && _angle < 135) format.LineAlignment = StringAlignment.Far;
                    else if (_angle > 180 && _angle < 315) format.LineAlignment = StringAlignment.Near;
                    else format.LineAlignment = StringAlignment.Center;
                        // Horizontal
                    if (_angle > 90 && _angle < 225) format.Alignment = StringAlignment.Far;
                    else if ((_angle > 270 && _angle < 360) ||
                                (_angle >= 0  && _angle < 45)) format.Alignment = StringAlignment.Near;
                    else format.Alignment = StringAlignment.Center;

                    return format;
                }
            }

            public TextDraw(string text, float angle, float resize = 1)
            {
                Text = text;
                Angle = angle;
                Resize = resize;
            }
        }

        /// <summary>
        /// Класс для реализации отрисовки слайсов
        /// </summary>
        sealed class SliceDraw
        {
            public Color Color { get; set; }

            public float Part { get; set; }

            public SliceDraw(Color color, float part)
            {
                Color = color;
                Part = part;
            }

            public static SliceDraw[] Enumerate(SliceDraw[] Slices)
            {
                List<SliceDraw> slices = new List<SliceDraw>();
                SliceDraw[] _slices = Slices.OrderBy(slice => slice.Part).ToArray();
                float begin = _slices.Sum(slice => slice.Part) * 180 + 45;

                slices.Add(new SliceDraw(_slices[0].Color, begin));
                foreach (var slice in _slices)
                {
                    begin -= slice.Part * 360;
                    slices.Add(new SliceDraw(slice.Color, begin));
                }
                return slices.ToArray();
            }
        }

        public Color FillColor { get; set; }

        public Color LineColor { get; set; }

        public static Font Font { get; set; }

        public DrawState DrawState { get; set; }

        List<TextDraw> _text = new List<TextDraw>();
        List<SliceDraw> _slices = new List<SliceDraw>();

        static PotDraw()
        {
            Font = new Font("Arial", 10);
        }

        public PotDraw()
        {
            FillColor = Color.LightGreen;
            LineColor = Color.Black;
        }

        /// <summary>
        /// Добавляет текстовые данные на график, исходя из следующих данных: параметр Angle
        /// показывает положение текста вокруг центра диаграммы, отступая от него на расстояние
        /// внутреннего круга, и выравнивая текст в соответствии с этим.
        /// </summary>
        public void AddInfo(string Text, float Angle, float Resize = 1)
        {
            _text.Add(new TextDraw(Text, Angle, Resize));
        }

        /// <summary>
        /// Добавляет вырезки на график, сортируя их от меньшего к большему и поворачивая на 45
        /// градусов центром тяжести
        /// </summary>
        public void AddSlice(Color SliceColor, float Part)
        {
            _slices.Add(new SliceDraw(SliceColor, Part));
        }

        public void Draw(Graphics g, PointF Center, float Radius)
        {
            float innRad = Radius * 0.1f;
            RectangleF innerCircleBounds = new RectangleF(Center.X - innRad, Center.Y - innRad,
                                                          innRad * 2, innRad * 2);
            Rectangle outerCircleBounds = new Rectangle((int)(Center.X - Radius), (int)(Center.Y - Radius),
                                                          (int)Radius * 2, (int)Radius * 2);
            SolidBrush lineBrush = new SolidBrush(LineColor);
            Pen linePen = new Pen(LineColor);
            SolidBrush textBrush = new SolidBrush(LineColor);
            Color transparentLine = Color.FromArgb(192, LineColor);

            switch (DrawState)
            {
                case DrawState.ImageAccent:
                    textBrush = new SolidBrush(transparentLine);
                    break;

                case DrawState.TextAccent:
                    linePen = new Pen(transparentLine);
                    lineBrush = new SolidBrush(transparentLine);
                    break;

                default:
                    break;
            }

                // Fill outer ellipse
            g.FillEllipse(new SolidBrush(FillColor), outerCircleBounds);

                // Fill slices
            if (_slices.Count > 0 && outerCircleBounds.Width > 0)
            {
                SliceDraw[] slices = SliceDraw.Enumerate(_slices.ToArray());
                if (slices.Length > 0)
                {
                    float _angle = slices[0].Part;
                    for (int i = 1; i < slices.Length; i++)
                    {
                        g.FillPie(new SolidBrush(slices[i].Color), outerCircleBounds, -_angle, _angle - slices[i].Part);
                        g.DrawPie(linePen, outerCircleBounds, -_angle, _angle - slices[i].Part);
                        _angle = slices[i].Part;
                    }
                }
            }
                // Fill bounds
            g.DrawEllipse(new Pen(LineColor), outerCircleBounds);
            g.FillEllipse(lineBrush, innerCircleBounds);

                // Draw text
            foreach (var item in _text)
            {
                float dx = Center.X + innRad * 1.2f * (float)Math.Cos(( - item.Angle) * Math.PI / 180);
                float dy = Center.Y + innRad * 1.2f * (float)Math.Sin(( - item.Angle) * Math.PI / 180);
                var font = new System.Drawing.Font(Font.FontFamily, Font.Size * item.Resize);
                g.DrawString(item.Text, font, textBrush, new PointF(dx, dy), item.Format);
            }

        }
    }
}
