using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data.Linq;

namespace Pots
{
    public partial class FormEditor : Form
    {
        public class ComboItem
        {
            public int Key;
            public String Value;

            public ComboItem(int key, string value)
            {
                Key = key; Value = value;
            }

            public override string ToString()
            {
                return Value;
            }
        }

        public IPotDraw Preview;

        FillersObject _fillerHG = FillersObject.Load(1);
        
        FillersObject _fillerWater = FillersObject.Load(2);

        public PotObject Pot { get; set; }

        public PeriodsObject Period { get; set; }

        public PotPeriod PotPeriodRelation { get; set; }

        public PotPeriodAvailable PotPeriodAvailableRelation { get; set; }

        public PotPeriodFiller PotPeriodWaterFiller { get; set; }

        public PotPeriodFiller PotPeriodHgFiller { get; set; }

        public FormEditor()
        {
            InitializeComponent();

            LoadDataPots();
            LoadDataTime();

            #region Fill constant data

            comboBoxState.Items.AddRange(
                        Form1.DataContext.GetTable<StatesObject>()
                                .Select(o => new ComboItem(o.StateKey, o.SName))
                                            .ToArray());
            comboBoxState.SelectedIndex = 0;
            comboBoxFillingMethod.Items.AddRange(
                        Form1.DataContext.GetTable<MethodsObject>()
                                .Select(o => new ComboItem(o.MethodKey, o.MName))
                                            .ToArray());
            comboBoxFillingMethod.SelectedIndex = 0;

            #endregion

            RelationsLoadOptions();
        }

        #region Pot handlers

        void LoadDataPots()
        {
            comboBoxPotNames.Items.Clear();
            comboBoxPotNames.Items.AddRange(
                        Form1.DataContext.GetTable<PotObject>()
                                    .Select(o => new ComboItem(o.PotKey, o.PName))
                                         .ToArray());
            if (comboBoxPotNames.Items.Count > 0)
            {
                comboBoxPotNames.SelectedIndex = 0;
                comboBoxPotNames_SelectedIndexChanged(null, null);
            }
        }

        private void buttonAddNewPot_Click(object sender, EventArgs e)
        {
            Pot = new PotObject()
            {
                PName = comboBoxPotNames.Text,
                PDescription = textBoxPotDesc.Text
            };
            if (comboBoxPotNames.SelectedItem != null)
            {
                Pot.PotKey = (comboBoxPotNames.SelectedItem as ComboItem).Key;
                Pot.Save(true);
            }
            else Pot.Save(false);
            LoadDataPots();
        }

        private void comboBoxPotNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboItem item = comboBoxPotNames.SelectedItem as ComboItem;
            if (item == null) return;

            Pot = PotObject.Load(item.Key);
            textBoxPotDesc.Text = Pot.PDescription;
            RelationsLoadOptions();
        }

        #endregion

        #region Period handlers

        /// <summary>   Period changed   </summary>
        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            int key = (comboBoxPeriodIndex.SelectedItem as ComboItem).Key;
            Period = PeriodsObject.Load(key);
            dateTimeStamp.Value = Period.PTimeStamp;
            textBoxTimeDesc.Text = Period.PDescription;
            RelationsLoadOptions();                 
        }


        /// <summary>
        /// Period edit
        /// </summary>
        private void buttonAddPeriod_Click(object sender, EventArgs e)
        {
            Period = PeriodsObject.Load((comboBoxPeriodIndex.SelectedItem as ComboItem).Key);
            Period.PTimeStamp = dateTimeStamp.Value;
            Period.PDescription = textBoxTimeDesc.Text;
            Period.Save(true);
        }

        void LoadDataTime()
        {
            comboBoxPeriodIndex.Items.Clear();
            var table = Form1.DataContext.GetTable<PeriodsObject>().ToArray();
            comboBoxPeriodIndex.Items.AddRange(table
                                    .Select(o => new ComboItem(o.PeriodKey, o.PeriodKey.ToString()))
                                            .ToArray());
            if (comboBoxPeriodIndex.Items.Count > 0)
            {
                comboBoxPeriodIndex.SelectedIndex = 0;
                comboBox1_SelectedValueChanged(null, null);
            }
        }

        #endregion

        /// <summary>
        /// Select item by text in input comboBox
        /// </summary>
        private void ComboSelect(ComboBox comboBox, string ItemValue)
        {
            foreach (var item in comboBox.Items)
            {
                var comboItem = item as ComboItem;
                if (comboItem == null) return;
                if (comboItem.Value == ItemValue)
                {
                    comboBox.SelectedItem = item;
                    return;
                }
            }
        }

        void RelationsLoadOptions()
        {
            if (Pot == null || Period == null) return;
            int pot = Pot.PotKey;
            int period = Period.PeriodKey;

            ResetControls();

                    // PotPeriod
            PotPeriodRelation = PotPeriod.Load(pot, period);
            if (PotPeriodRelation != null)
            {
                checkBoxNewCreated.Checked = !PotPeriodRelation.Availability;
            }
            else PotPeriodRelation = new PotPeriod() { PotKey = pot, PeriodKey = period };
                
                    // PotPeriodAvailable
            PotPeriodAvailableRelation = PotPeriodAvailable.Load(pot, period);
            if (PotPeriodAvailableRelation != null)
            {
                var method = MethodsObject.Load(PotPeriodAvailableRelation.MethodKey);
                if (method != null) ComboSelect(comboBoxFillingMethod, method.MName);

                var state = StatesObject.Load(PotPeriodAvailableRelation.StateKey);
                if (state != null) ComboSelect(comboBoxState, state.SName);

                checkBoxEmpty.Checked = PotPeriodAvailableRelation.Empty;

                numericMinutesSpent.Value = (decimal)PotPeriodAvailableRelation.MinutesSpent;
            }
            else PotPeriodAvailableRelation = new PotPeriodAvailable() { PotKey = pot, PeriodKey = period };

                    // Fillers
            PotPeriodWaterFiller = PotPeriodFiller.Load(pot, period, (int)_fillerWater.FillerKey);
            if (PotPeriodWaterFiller != null)
            {
                numericWaterCount.Value = (decimal)PotPeriodWaterFiller.Quantity;
            }
            else PotPeriodWaterFiller = new PotPeriodFiller()
            {
                PotKey = pot,
                PeriodKey = period,
                FillerKey = (int)_fillerWater.FillerKey
            };
            PotPeriodHgFiller = PotPeriodFiller.Load(pot, period, (int)_fillerHG.FillerKey);
            if (PotPeriodHgFiller != null)
            {
                numericHgCount.Value = (decimal)PotPeriodHgFiller.Quantity;
            }
            else PotPeriodHgFiller = new PotPeriodFiller()
            {
                PotKey = pot,
                PeriodKey = period,
                FillerKey = (int)_fillerHG.FillerKey
            };

            UpdatePreviewIni();
        }

        void ResetControls()
        {
            numericHgCount.Value = 0;
            numericWaterCount.Value = 0;
            numericMinutesSpent.Value = 0;
            checkBoxEmpty.Checked = false;
            checkBoxNewCreated.Checked = false;
        }

        private void UpdatePreviewIni()
        {
            if (Pot == null) return;
            float minSpent = (float)numericMinutesSpent.Value;
            float hg = (float)numericHgCount.Value;
            float water = (float)numericWaterCount.Value;

            if (checkBoxNewCreated.Checked)
            {
                var pot = new AbstractPot();
                pot.Name = Pot.PName;
                Preview = pot;
            }
            else if (checkBoxEmpty.Checked || minSpent == 0)
            {
                var pot = new EmptyPot();
                pot.Name = Pot.PName;
                Preview = pot;
            }
            else if (hg == 0)
            {
                var pot = new WateredPot();
                pot.WaterCount = water;
                pot.MinutesSpent = minSpent;
                pot.Name = Pot.PName;
                pot.State = comboBoxState.SelectedValue as String;
                pot.FillingMethod = (comboBoxFillingMethod.SelectedItem as ComboItem).Value;
                Preview = pot;
            }
            else
            {
                var pot = new HgPot();
                pot.WaterCount = water;
                pot.MinutesSpent = minSpent;
                pot.Name = Pot.PName;
                pot.State = comboBoxState.SelectedValue as String;
                pot.FillingMethod = (comboBoxFillingMethod.SelectedItem as ComboItem).Value;
                pot.HgCount = hg;
                Preview = pot;
            }
            Preview.Ini();

            pictureBoxPotPreview.Invalidate();
            pictureBoxPotPreview.Update();
        }

        /// <summary>   CheckBox Empty    </summary>
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            panelFillersNotEmpty.Enabled = !checkBoxEmpty.Checked;
            UpdatePreviewIni();
        }


        private void pictureBoxPotPreview_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            if(Preview != null) Preview.Draw(e.Graphics, 
                          new Rectangle(0, 0, pictureBoxPotPreview.Width - 5, pictureBoxPotPreview.Height - 5));
        }

        private void checkBoxNewCreated_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxFillers.Enabled = !checkBoxNewCreated.Checked;
            UpdatePreviewIni();
        }

        private void UpdateViewData(object sender, EventArgs e)
        {
            UpdatePreviewIni();
        }

        /// <summary>
        /// Loading all data from page to add new pot into databse
        /// </summary>
        private void buttonAddPot_Click(object sender, EventArgs e)
        {
            float minSpent = (float)numericMinutesSpent.Value;
            float hg = (float)numericHgCount.Value;
            float water = (float)numericWaterCount.Value;

                // Already exist?
            PotPeriodRelation.Availability = !checkBoxNewCreated.Checked;
            if (!PotPeriodRelation.Save(false))
            {
                if (MessageBox.Show(
                    String.Format("Record for '{0} : {1}' already exists. Modify?", Pot.PName, Period.PeriodKey),
                    "Confirm modify operation", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    PotPeriodRelation.Save(true);
                    PotPeriodAvailableRelation.Delete();
                    PotPeriodHgFiller.Delete();
                    PotPeriodWaterFiller.Delete();
                }
                else return;
            }
            if (!PotPeriodRelation.Availability) return;

            bool emptyByValue = (minSpent == 0) || ((water == 0) && (hg == 0));
            PotPeriodAvailableRelation.Empty = checkBoxEmpty.Checked || emptyByValue;
            PotPeriodAvailableRelation.StateKey = (int)(comboBoxState.SelectedItem as ComboItem).Key;
            if (!PotPeriodAvailableRelation.Empty)
            {
                PotPeriodAvailableRelation.MethodKey = (int)(comboBoxFillingMethod.SelectedItem as ComboItem).Key;
                PotPeriodAvailableRelation.MinutesSpent = minSpent;
            }
            if (!PotPeriodAvailableRelation.Save(false))
            {
                MessageBox.Show(String.Format("Record for pot '{0}' : {1} int table {2} already exists",
                                Pot.PName, Period.PeriodKey, "PotPeriodAvailable"));
                return;
            }
            if (PotPeriodAvailableRelation.Empty) return;

            PotPeriodWaterFiller.Quantity = water;
            if (!PotPeriodWaterFiller.Save(false))
            {
                MessageBox.Show(String.Format("Record for pot '{0}' : {1} : '{2}' int table {3} already exists",
                                Pot.PName, Period.PeriodKey, "water", "PotPeriodFiller"));
                return;
            }
            if (hg == 0) return;

            PotPeriodHgFiller.Quantity = hg;
            if (!PotPeriodHgFiller.Save(false))
            {
                MessageBox.Show(String.Format("Record for pot '{0}' : {1} : '{2}' int table {3} already exists",
                                Pot.PName, Period.PeriodKey, "hg", "PotPeriodFiller"));
                return;
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (PotPeriodRelation != null) PotPeriodRelation.Delete();
            if (PotPeriodAvailableRelation != null) PotPeriodAvailableRelation.Delete();
            if (PotPeriodWaterFiller != null) PotPeriodWaterFiller.Delete();
            if (PotPeriodHgFiller != null) PotPeriodHgFiller.Delete();

            LoadDataPots();
        }

        /// <summary>
        /// Add new period
        /// </summary>
        private void buttonPeriodAdd_Click(object sender, EventArgs e)
        {
            Period = new PeriodsObject()
            {
                PTimeStamp = dateTimeStamp.Value,
                PDescription = textBoxTimeDesc.Text
            };
            if (Period.Save(false)) LoadDataTime();
        }

        private void buttonXmlLoad_Click(object sender, EventArgs e)
        {
            if (openFileXml.ShowDialog() == DialogResult.OK)
            {
                PotPeriodFiller[] fillers = PotsLoader.Deserialize(openFileXml.FileName);
                int fcount = fillers == null ? 0 : fillers.Length;
                int floaded = 0;
                if (fillers != null)
                {
                    foreach (var filler in fillers) if(filler.Save(true)) floaded++;
                }
                MessageBox.Show(String.Format("{0}:{1}{2}/{3} elements loaded",
                                openFileXml.FileName, Environment.NewLine, floaded, fcount));
            }
        }
    }
}
