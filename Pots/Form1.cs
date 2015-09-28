using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pots
{
    public partial class Form1 : Form
    {
        public static DataContext DataContext { get; set; }
        public FormEditor formEditor = null;
        public enum Fillers { Hg = 1, Water = 2 };

        public Form1()
        {
            InitializeComponent();
            
            string connString = "DataSource=db/Pots.db3;";
            SQLiteConnection connection = new SQLiteConnection(connString);
            DataContext = new DataContext(connection);
            DataContext.ExecuteCommand("PRAGMA foreign_keys=ON;");
            formEditor = new FormEditor();
            diagramView1.OnItemSelect += (obj, index) =>
                {
                    propertyGrid1.SelectedObject = obj;
                };
            buttonRefresh_Click(null, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            formEditor.ShowDialog();
            buttonRefresh_Click(null, null);
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            comboBoxYears.Items.Clear();
            comboBoxYears.Items.AddRange(Form1.DataContext.GetTable<PeriodsObject>()
                     .Select(o => o.PTimeStamp).ToArray().Select(o => o.Year)
                     .OrderBy(o => o).Distinct()
                     .Select(o => new FormEditor.ComboItem(o, o.ToString()))
                     .ToArray());
            if (comboBoxYears.Items.Count > 0) comboBoxYears.SelectedIndex = 0;
            comboBoxYears_SelectedValueChanged(null, null);
        }

        private void comboBoxYears_SelectedValueChanged(object sender, EventArgs e)
        {
            int curYear = (comboBoxYears.SelectedItem as FormEditor.ComboItem).Key;

            var periods = Form1.DataContext.GetTable<PeriodsObject>()
                     .OrderBy(o => o.PTimeStamp).ToArray()
                     .Where(o => o.PTimeStamp.Year == curYear);

            listViewPeriods.Items.Clear();
            foreach (var period in periods)
            {
                ListViewItem item = new ListViewItem();
                item.Tag = period;
                item.Text = period.PTimeStamp.ToShortDateString();
                listViewPeriods.Items.Add(item);
            }
        }

        private void listViewPeriods_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewPeriods.SelectedIndices.Count < 1) return;
            var period = listViewPeriods.SelectedItems[0].Tag as PeriodsObject;
            IPotDraw[] potDraws = Form1.DataContext.GetTable<PotObject>().ToArray()
                             .Select(o => IPotDrawFactory.FromPotPeriod(o.PotKey, period.PeriodKey))
                             .ToArray();
            diagramView1.Items.Clear();
            foreach (var pot in potDraws)
            {
                pot.Ini();
                pot.SetState(DrawState.ImageAccent);
                diagramView1.Items.Add(pot);
            }
            diagramView1.Update();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            PotsLoader.Serialize("1.xml", Form1.DataContext.GetTable<PotPeriodFiller>().ToArray());
        }
    }
}
