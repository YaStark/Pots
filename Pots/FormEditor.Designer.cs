namespace Pots
{
    partial class FormEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelTop = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.panelViewTable = new System.Windows.Forms.Panel();
            this.buttonXmlLoad = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.buttonAddPot = new System.Windows.Forms.Button();
            this.groupBoxFillers = new System.Windows.Forms.GroupBox();
            this.comboBoxState = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.pictureBoxPotPreview = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.panelFillersNotEmpty = new System.Windows.Forms.Panel();
            this.comboBoxFillingMethod = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.numericMinutesSpent = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.numericHgCount = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.numericWaterCount = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.checkBoxEmpty = new System.Windows.Forms.CheckBox();
            this.groupBoxTime = new System.Windows.Forms.GroupBox();
            this.buttonPeriodAdd = new System.Windows.Forms.Button();
            this.buttonPeriodEdit = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxPeriodIndex = new System.Windows.Forms.ComboBox();
            this.dateTimeStamp = new System.Windows.Forms.DateTimePicker();
            this.textBoxTimeDesc = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxNewCreated = new System.Windows.Forms.CheckBox();
            this.buttonAddNewPot = new System.Windows.Forms.Button();
            this.textBoxPotDesc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxPotNames = new System.Windows.Forms.ComboBox();
            this.openFileXml = new System.Windows.Forms.OpenFileDialog();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelViewTable.SuspendLayout();
            this.groupBoxFillers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPotPreview)).BeginInit();
            this.panelFillersNotEmpty.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericMinutesSpent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericHgCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericWaterCount)).BeginInit();
            this.groupBoxTime.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.pictureBox1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(774, 67);
            this.panelTop.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::Pots.Properties.Resources._1top1;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(774, 67);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panelBottom
            // 
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 358);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(774, 39);
            this.panelBottom.TabIndex = 1;
            // 
            // panelViewTable
            // 
            this.panelViewTable.AutoScroll = true;
            this.panelViewTable.Controls.Add(this.buttonXmlLoad);
            this.panelViewTable.Controls.Add(this.buttonRemove);
            this.panelViewTable.Controls.Add(this.buttonAddPot);
            this.panelViewTable.Controls.Add(this.groupBoxFillers);
            this.panelViewTable.Controls.Add(this.groupBoxTime);
            this.panelViewTable.Controls.Add(this.groupBox1);
            this.panelViewTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelViewTable.Location = new System.Drawing.Point(0, 67);
            this.panelViewTable.Name = "panelViewTable";
            this.panelViewTable.Size = new System.Drawing.Size(774, 291);
            this.panelViewTable.TabIndex = 3;
            // 
            // buttonXmlLoad
            // 
            this.buttonXmlLoad.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonXmlLoad.Location = new System.Drawing.Point(424, 245);
            this.buttonXmlLoad.Name = "buttonXmlLoad";
            this.buttonXmlLoad.Size = new System.Drawing.Size(107, 36);
            this.buttonXmlLoad.TabIndex = 14;
            this.buttonXmlLoad.Text = "Load from xml";
            this.buttonXmlLoad.UseVisualStyleBackColor = true;
            this.buttonXmlLoad.Click += new System.EventHandler(this.buttonXmlLoad_Click);
            // 
            // buttonRemove
            // 
            this.buttonRemove.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonRemove.Location = new System.Drawing.Point(650, 245);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(107, 36);
            this.buttonRemove.TabIndex = 13;
            this.buttonRemove.Text = "Remove record";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // buttonAddPot
            // 
            this.buttonAddPot.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonAddPot.Location = new System.Drawing.Point(537, 245);
            this.buttonAddPot.Name = "buttonAddPot";
            this.buttonAddPot.Size = new System.Drawing.Size(107, 36);
            this.buttonAddPot.TabIndex = 12;
            this.buttonAddPot.Text = "Add/Edit pot";
            this.buttonAddPot.UseVisualStyleBackColor = true;
            this.buttonAddPot.Click += new System.EventHandler(this.buttonAddPot_Click);
            // 
            // groupBoxFillers
            // 
            this.groupBoxFillers.Controls.Add(this.comboBoxState);
            this.groupBoxFillers.Controls.Add(this.label12);
            this.groupBoxFillers.Controls.Add(this.pictureBoxPotPreview);
            this.groupBoxFillers.Controls.Add(this.label10);
            this.groupBoxFillers.Controls.Add(this.panelFillersNotEmpty);
            this.groupBoxFillers.Controls.Add(this.checkBoxEmpty);
            this.groupBoxFillers.Location = new System.Drawing.Point(314, 7);
            this.groupBoxFillers.Name = "groupBoxFillers";
            this.groupBoxFillers.Size = new System.Drawing.Size(457, 232);
            this.groupBoxFillers.TabIndex = 2;
            this.groupBoxFillers.TabStop = false;
            this.groupBoxFillers.Text = "Fillers";
            // 
            // comboBoxState
            // 
            this.comboBoxState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxState.FormattingEnabled = true;
            this.comboBoxState.Location = new System.Drawing.Point(308, 73);
            this.comboBoxState.Name = "comboBoxState";
            this.comboBoxState.Size = new System.Drawing.Size(130, 21);
            this.comboBoxState.TabIndex = 11;
            this.comboBoxState.SelectedValueChanged += new System.EventHandler(this.UpdateViewData);
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(187, 72);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(115, 20);
            this.label12.TabIndex = 3;
            this.label12.Text = "State";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBoxPotPreview
            // 
            this.pictureBoxPotPreview.Location = new System.Drawing.Point(6, 50);
            this.pictureBoxPotPreview.Name = "pictureBoxPotPreview";
            this.pictureBoxPotPreview.Size = new System.Drawing.Size(169, 169);
            this.pictureBoxPotPreview.TabIndex = 8;
            this.pictureBoxPotPreview.TabStop = false;
            this.pictureBoxPotPreview.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxPotPreview_Paint);
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(6, 17);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(161, 20);
            this.label10.TabIndex = 3;
            this.label10.Text = "Preview";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelFillersNotEmpty
            // 
            this.panelFillersNotEmpty.Controls.Add(this.comboBoxFillingMethod);
            this.panelFillersNotEmpty.Controls.Add(this.label13);
            this.panelFillersNotEmpty.Controls.Add(this.numericMinutesSpent);
            this.panelFillersNotEmpty.Controls.Add(this.label9);
            this.panelFillersNotEmpty.Controls.Add(this.numericHgCount);
            this.panelFillersNotEmpty.Controls.Add(this.label8);
            this.panelFillersNotEmpty.Controls.Add(this.numericWaterCount);
            this.panelFillersNotEmpty.Controls.Add(this.label7);
            this.panelFillersNotEmpty.Location = new System.Drawing.Point(181, 100);
            this.panelFillersNotEmpty.Name = "panelFillersNotEmpty";
            this.panelFillersNotEmpty.Size = new System.Drawing.Size(270, 119);
            this.panelFillersNotEmpty.TabIndex = 1;
            // 
            // comboBoxFillingMethod
            // 
            this.comboBoxFillingMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFillingMethod.FormattingEnabled = true;
            this.comboBoxFillingMethod.Location = new System.Drawing.Point(127, 82);
            this.comboBoxFillingMethod.Name = "comboBoxFillingMethod";
            this.comboBoxFillingMethod.Size = new System.Drawing.Size(130, 21);
            this.comboBoxFillingMethod.TabIndex = 10;
            this.comboBoxFillingMethod.SelectedValueChanged += new System.EventHandler(this.UpdateViewData);
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(6, 81);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(115, 20);
            this.label13.TabIndex = 4;
            this.label13.Text = "Filling method";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numericMinutesSpent
            // 
            this.numericMinutesSpent.DecimalPlaces = 3;
            this.numericMinutesSpent.Location = new System.Drawing.Point(127, 58);
            this.numericMinutesSpent.Maximum = new decimal(new int[] {
            -159383552,
            46653770,
            5421,
            0});
            this.numericMinutesSpent.Name = "numericMinutesSpent";
            this.numericMinutesSpent.Size = new System.Drawing.Size(130, 20);
            this.numericMinutesSpent.TabIndex = 7;
            this.numericMinutesSpent.ValueChanged += new System.EventHandler(this.UpdateViewData);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(3, 56);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(120, 20);
            this.label9.TabIndex = 6;
            this.label9.Text = "Minutes spent";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numericHgCount
            // 
            this.numericHgCount.DecimalPlaces = 3;
            this.numericHgCount.Location = new System.Drawing.Point(127, 32);
            this.numericHgCount.Maximum = new decimal(new int[] {
            -159383552,
            46653770,
            5421,
            0});
            this.numericHgCount.Name = "numericHgCount";
            this.numericHgCount.Size = new System.Drawing.Size(130, 20);
            this.numericHgCount.TabIndex = 5;
            this.numericHgCount.ValueChanged += new System.EventHandler(this.UpdateViewData);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(3, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(118, 20);
            this.label8.TabIndex = 4;
            this.label8.Text = "Hg count";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numericWaterCount
            // 
            this.numericWaterCount.DecimalPlaces = 3;
            this.numericWaterCount.Location = new System.Drawing.Point(127, 6);
            this.numericWaterCount.Maximum = new decimal(new int[] {
            -159383552,
            46653770,
            5421,
            0});
            this.numericWaterCount.Name = "numericWaterCount";
            this.numericWaterCount.Size = new System.Drawing.Size(130, 20);
            this.numericWaterCount.TabIndex = 3;
            this.numericWaterCount.ValueChanged += new System.EventHandler(this.UpdateViewData);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(3, 4);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 20);
            this.label7.TabIndex = 2;
            this.label7.Text = "Water count";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // checkBoxEmpty
            // 
            this.checkBoxEmpty.AutoSize = true;
            this.checkBoxEmpty.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxEmpty.Location = new System.Drawing.Point(383, 43);
            this.checkBoxEmpty.Name = "checkBoxEmpty";
            this.checkBoxEmpty.Size = new System.Drawing.Size(55, 17);
            this.checkBoxEmpty.TabIndex = 0;
            this.checkBoxEmpty.Text = "Empty";
            this.checkBoxEmpty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxEmpty.UseVisualStyleBackColor = true;
            this.checkBoxEmpty.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // groupBoxTime
            // 
            this.groupBoxTime.Controls.Add(this.buttonPeriodAdd);
            this.groupBoxTime.Controls.Add(this.buttonPeriodEdit);
            this.groupBoxTime.Controls.Add(this.label6);
            this.groupBoxTime.Controls.Add(this.comboBoxPeriodIndex);
            this.groupBoxTime.Controls.Add(this.dateTimeStamp);
            this.groupBoxTime.Controls.Add(this.textBoxTimeDesc);
            this.groupBoxTime.Controls.Add(this.label4);
            this.groupBoxTime.Controls.Add(this.label5);
            this.groupBoxTime.Location = new System.Drawing.Point(8, 149);
            this.groupBoxTime.Name = "groupBoxTime";
            this.groupBoxTime.Size = new System.Drawing.Size(300, 136);
            this.groupBoxTime.TabIndex = 1;
            this.groupBoxTime.TabStop = false;
            this.groupBoxTime.Text = "Period";
            // 
            // buttonPeriodAdd
            // 
            this.buttonPeriodAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonPeriodAdd.Location = new System.Drawing.Point(148, 100);
            this.buttonPeriodAdd.Name = "buttonPeriodAdd";
            this.buttonPeriodAdd.Size = new System.Drawing.Size(70, 23);
            this.buttonPeriodAdd.TabIndex = 12;
            this.buttonPeriodAdd.Text = "Add";
            this.buttonPeriodAdd.UseVisualStyleBackColor = true;
            this.buttonPeriodAdd.Click += new System.EventHandler(this.buttonPeriodAdd_Click);
            // 
            // buttonPeriodEdit
            // 
            this.buttonPeriodEdit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonPeriodEdit.Location = new System.Drawing.Point(222, 100);
            this.buttonPeriodEdit.Name = "buttonPeriodEdit";
            this.buttonPeriodEdit.Size = new System.Drawing.Size(70, 23);
            this.buttonPeriodEdit.TabIndex = 11;
            this.buttonPeriodEdit.Text = "Edit";
            this.buttonPeriodEdit.UseVisualStyleBackColor = true;
            this.buttonPeriodEdit.Click += new System.EventHandler(this.buttonAddPeriod_Click);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(10, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "Period";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBoxPeriodIndex
            // 
            this.comboBoxPeriodIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPeriodIndex.FormattingEnabled = true;
            this.comboBoxPeriodIndex.Location = new System.Drawing.Point(62, 16);
            this.comboBoxPeriodIndex.Name = "comboBoxPeriodIndex";
            this.comboBoxPeriodIndex.Size = new System.Drawing.Size(77, 21);
            this.comboBoxPeriodIndex.TabIndex = 9;
            this.comboBoxPeriodIndex.SelectedValueChanged += new System.EventHandler(this.comboBox1_SelectedValueChanged);
            // 
            // dateTimeStamp
            // 
            this.dateTimeStamp.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeStamp.Location = new System.Drawing.Point(202, 15);
            this.dateTimeStamp.Name = "dateTimeStamp";
            this.dateTimeStamp.Size = new System.Drawing.Size(77, 20);
            this.dateTimeStamp.TabIndex = 2;
            // 
            // textBoxTimeDesc
            // 
            this.textBoxTimeDesc.Location = new System.Drawing.Point(94, 43);
            this.textBoxTimeDesc.Multiline = true;
            this.textBoxTimeDesc.Name = "textBoxTimeDesc";
            this.textBoxTimeDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxTimeDesc.Size = new System.Drawing.Size(196, 51);
            this.textBoxTimeDesc.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(6, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Description";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(145, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "Date";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxNewCreated);
            this.groupBox1.Controls.Add(this.buttonAddNewPot);
            this.groupBox1.Controls.Add(this.textBoxPotDesc);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBoxPotNames);
            this.groupBox1.Location = new System.Drawing.Point(8, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(300, 136);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pot";
            // 
            // checkBoxNewCreated
            // 
            this.checkBoxNewCreated.AutoSize = true;
            this.checkBoxNewCreated.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxNewCreated.Location = new System.Drawing.Point(22, 104);
            this.checkBoxNewCreated.Name = "checkBoxNewCreated";
            this.checkBoxNewCreated.Size = new System.Drawing.Size(87, 17);
            this.checkBoxNewCreated.TabIndex = 5;
            this.checkBoxNewCreated.Text = "New created";
            this.checkBoxNewCreated.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxNewCreated.UseVisualStyleBackColor = true;
            this.checkBoxNewCreated.CheckedChanged += new System.EventHandler(this.checkBoxNewCreated_CheckedChanged);
            // 
            // buttonAddNewPot
            // 
            this.buttonAddNewPot.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonAddNewPot.Location = new System.Drawing.Point(222, 100);
            this.buttonAddNewPot.Name = "buttonAddNewPot";
            this.buttonAddNewPot.Size = new System.Drawing.Size(70, 23);
            this.buttonAddNewPot.TabIndex = 4;
            this.buttonAddNewPot.Text = "Add/Edit";
            this.buttonAddNewPot.UseVisualStyleBackColor = true;
            this.buttonAddNewPot.Click += new System.EventHandler(this.buttonAddNewPot_Click);
            // 
            // textBoxPotDesc
            // 
            this.textBoxPotDesc.Location = new System.Drawing.Point(94, 43);
            this.textBoxPotDesc.Multiline = true;
            this.textBoxPotDesc.Name = "textBoxPotDesc";
            this.textBoxPotDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxPotDesc.Size = new System.Drawing.Size(198, 51);
            this.textBoxPotDesc.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Description";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Pot name";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBoxPotNames
            // 
            this.comboBoxPotNames.FormattingEnabled = true;
            this.comboBoxPotNames.Location = new System.Drawing.Point(94, 17);
            this.comboBoxPotNames.Name = "comboBoxPotNames";
            this.comboBoxPotNames.Size = new System.Drawing.Size(198, 21);
            this.comboBoxPotNames.TabIndex = 0;
            this.comboBoxPotNames.SelectedIndexChanged += new System.EventHandler(this.comboBoxPotNames_SelectedIndexChanged);
            // 
            // openFileXml
            // 
            this.openFileXml.FileName = "openFileDialog1";
            this.openFileXml.Filter = "XML document|*.xml";
            // 
            // FormEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 397);
            this.Controls.Add(this.panelViewTable);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormEditor";
            this.Text = "Edit database data";
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelViewTable.ResumeLayout(false);
            this.groupBoxFillers.ResumeLayout(false);
            this.groupBoxFillers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPotPreview)).EndInit();
            this.panelFillersNotEmpty.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericMinutesSpent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericHgCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericWaterCount)).EndInit();
            this.groupBoxTime.ResumeLayout(false);
            this.groupBoxTime.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelViewTable;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxPotNames;
        private System.Windows.Forms.TextBox textBoxPotDesc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonAddNewPot;
        private System.Windows.Forms.GroupBox groupBoxTime;
        private System.Windows.Forms.TextBox textBoxTimeDesc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimeStamp;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxPeriodIndex;
        private System.Windows.Forms.Button buttonPeriodEdit;
        private System.Windows.Forms.GroupBox groupBoxFillers;
        private System.Windows.Forms.CheckBox checkBoxEmpty;
        private System.Windows.Forms.Panel panelFillersNotEmpty;
        private System.Windows.Forms.NumericUpDown numericWaterCount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericMinutesSpent;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numericHgCount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBoxPotPreview;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox checkBoxNewCreated;
        private System.Windows.Forms.ComboBox comboBoxState;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox comboBoxFillingMethod;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button buttonAddPot;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.Button buttonXmlLoad;
        private System.Windows.Forms.OpenFileDialog openFileXml;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonPeriodAdd;
    }
}