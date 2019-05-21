using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using CalculaterPro.Properties;

namespace CalculaterPro
{
    class SettingsPage : PanelCustom
    {
        public static bool CheckEventLogger = Convert.ToBoolean(Settings.Default["CheckEventTool"]);
        public TableLayoutPanel TBLayout = new TableLayoutPanel();
        public Panel ContentSettings = new Panel();

        public LabelCustom
            BlueLabel = new LabelCustom(
                new Point(339, 246), new Size(68, 19), new Padding(0), ContentAlignment.MiddleCenter, 
                "BlueLabel", "Синий", 10F),
            GreenLabel = new LabelCustom(
                new Point(339, 191), new Size(68, 19), new Padding(0), ContentAlignment.MiddleCenter,
                "GreenLabel", "Зеленый", 10F),
            RedLabel = new LabelCustom(
                new Point(339, 136), new Size(68, 19), new Padding(0), ContentAlignment.MiddleCenter,
                "RedLabel", "Красный", 10F),
            EditColor = new LabelCustom(
                new Point(290, 42), new Size(150, 66), new Padding(7), ContentAlignment.MiddleCenter, "EditColor", "Задаваемый цвет") {
                BorderStyle = BorderStyle.Fixed3D
            },
            ColorDefault = new LabelCustom(
                new Point(37, 42), new Size(150, 66), new Padding(7), ContentAlignment.MiddleCenter, "ColorDefault", "Цвет по умолчанию") {
                BorderStyle = BorderStyle.Fixed3D,
                BackColor = Color.FromArgb(0, 178, 58)
            },
            TitleChangeColor = new LabelCustom(
                new Point(7, 7), new Size(459, 21), new Padding(7), ContentAlignment.MiddleCenter, "TitleChangeColor", "Настройки цвета");
        
        public TrackBarCustom 
            BlueTrackBar = new TrackBarCustom(
                new Point(11, 263), new Size(318, 45), new Padding(7), "BlueTrackBar", RightToLeft.No, 255, 0,
                Convert.ToInt32(Settings.Default["Bblue"]), 1),
            GreenTrackBar = new TrackBarCustom(
                new Point(11, 204), new Size(318, 45), new Padding(7), "GreenTrackBar", RightToLeft.No, 255, 0,
                Convert.ToInt32(Settings.Default["Bgreen"]), 1),
            RedTrackBar = new TrackBarCustom(
                new Point(11, 145), new Size(318, 45), new Padding(7), "RedTrackBar", RightToLeft.No, 255, 0,
                Convert.ToInt32(Settings.Default["Bred"]), 1);
        public CheckCustom
            CheckToolTip = new CheckCustom(new Point(22, 320), new Size(410, 25), "CheckToolTip") {
                BackColor = RedGreenBlue.Color2,
                Text = "Установить подсказки",
                Checked = Convert.ToBoolean(Settings.Default["CheckToolTip"])
            },
            CheckEventLog = new CheckCustom(new Point(22, 350), new Size(410, 25), "CheckEventLog") {
                BackColor = RedGreenBlue.Color2,
                Text = "Сохранять историю операций",
                Checked = CheckEventLogger
            }; 
        public NumericUpCustom 
            BlueTextBox = new NumericUpCustom(
                new Point(336, 265), new Size(100, 19), new Padding(0), new decimal(new int[] { 255, 0, 0, 0 }),
                new decimal(new int[] { 0, 0, 0, 0 }), new decimal(new int[] { Convert.ToInt32(Settings.Default["Bblue"]), 0, 0, 0 }), "BlueTextBox"),
            GreenTextBox = new NumericUpCustom(
                new Point(336, 210), new Size(100, 19), new Padding(0), new decimal(new int[] { 255, 0, 0, 0 }),
                new decimal(new int[] { 0, 0, 0, 0 }), new decimal(new int[] { Convert.ToInt32(Settings.Default["Bgreen"]), 0, 0, 0 }), "GreenTextBox"),
            RedTextBox = new NumericUpCustom(
                new Point(336, 155), new Size(100, 19), new Padding(0), new decimal(new int[] { 255, 0, 0, 0 }),
                new decimal(new int[] { 0, 0, 0, 0 }), new decimal(new int[] { Convert.ToInt32(Settings.Default["Bred"]), 0, 0, 0 }), "RedTextBox");
        public ButtonCustom 
            ButtonAccept = new ButtonCustom(
                new Point(287, 0), new Size(135, 35), new Padding(7, 0, 0, 0), "ButtonAccept", "Установить"),
            ButtonCancel = new ButtonCustom(
                new Point(147, 0), new Size(135, 35), new Padding(7, 0, 0, 0), "ButtonCancel", "Отменa"),
            DefaultButton = new ButtonCustom(
                new Point(7, 0), new Size(133, 35), new Padding(7, 0, 0, 0), "DefaultButton", "По умолчанию");
        
        public SettingsPage()
        {
            SuspendLayout();
            TBLayout.SuspendLayout();
            ContentSettings.SuspendLayout();
            ((ISupportInitialize)(BlueTrackBar)).BeginInit();
            ((ISupportInitialize)(GreenTrackBar)).BeginInit();
            ((ISupportInitialize)(RedTrackBar)).BeginInit();

            Controls.Add(TBLayout);
            Controls.Add(ContentSettings);
            Name = "SettingsPage";

            RedTextBox.AddColor1();
            RedTextBox.ValueChanged += new EventHandler(RedChanged);
            GreenTextBox.AddColor1();
            GreenTextBox.ValueChanged += new EventHandler(GreenChanged);
            BlueTextBox.AddColor1();
            BlueTextBox.ValueChanged += new EventHandler(BlueChanged);
            ButtonAccept.AddColor1();
            ButtonAccept.Click += new EventHandler(AcceptChange);
            ButtonCancel.AddColor1();
            ButtonCancel.Click += new EventHandler(CancelChange);
            DefaultButton.AddColor1();
            DefaultButton.Click += new EventHandler(ChangeDefault);
            BlueTrackBar.Scroll += new EventHandler(BlueTrack_Scroll);
            RedTrackBar.Scroll += new EventHandler(RedTrack_Scroll);
            GreenTrackBar.Scroll += new EventHandler(GreenTrack_Scroll);
            CheckToolTip.CheckedChanged += new EventHandler(SetCheckedToolTip);
            CheckEventLog.CheckedChanged += new EventHandler(SetCheckEventLog);
            DefaultButton.UseVisualStyleBackColor = false;

            // TBLayout
            TBLayout.ColumnCount = 3;
            TBLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            TBLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            TBLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            TBLayout.Controls.Add(ButtonCancel, 1, 0);
            TBLayout.Controls.Add(DefaultButton, 0, 0);
            TBLayout.Controls.Add(ButtonAccept, 2, 0);
            TBLayout.Location = new Point(58, 479);
            TBLayout.Margin = new Padding(0, 0, 0, 7);
            TBLayout.Name = "TBLayout";
            TBLayout.RowCount = 1;
            TBLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            TBLayout.Size = new Size(422, 35);
            TBLayout.TabIndex = 1;
            // 
            // ContentSettings
            ContentSettings.AutoScroll = true;
            ContentSettings.HorizontalScroll.Enabled = false;
            ContentSettings.Controls.Add(BlueTextBox);
            ContentSettings.Controls.Add(GreenTextBox);
            ContentSettings.Controls.Add(RedTextBox);
            ContentSettings.Controls.Add(BlueLabel);
            ContentSettings.Controls.Add(GreenLabel);
            ContentSettings.Controls.Add(RedLabel);
            ContentSettings.Controls.Add(BlueTrackBar);
            ContentSettings.Controls.Add(GreenTrackBar);
            ContentSettings.Controls.Add(RedTrackBar);
            ContentSettings.Controls.Add(EditColor);
            ContentSettings.Controls.Add(ColorDefault);
            ContentSettings.Controls.Add(TitleChangeColor);
            ContentSettings.Controls.Add(CheckToolTip);
            ContentSettings.Controls.Add(CheckEventLog);
            ContentSettings.Location = new Point(7, 7);
            ContentSettings.Margin = new Padding(7);
            ContentSettings.Name = "ContentSettings";
            ContentSettings.Size = new Size(473, 465);
            ContentSettings.TabIndex = 0;
            ContentSettings.BackColor = RedGreenBlue.Color1;

            ResumeLayout(false);
            TBLayout.ResumeLayout(false);
            ContentSettings.ResumeLayout(false);
            ContentSettings.PerformLayout();
            ((ISupportInitialize)(BlueTrackBar)).EndInit();
            ((ISupportInitialize)(GreenTrackBar)).EndInit();
            ((ISupportInitialize)(RedTrackBar)).EndInit();
        }

        private void SetCheckedToolTip(object sender, EventArgs e){
            if (CheckToolTip.Checked == true)
                Settings.Default["CheckToolTip"] = true;
            else Settings.Default["CheckToolTip"] = false;
        }

        private void SetCheckEventLog(object sender, EventArgs e){
            if (CheckEventLog.Checked == true)
                Settings.Default["CheckEventTool"] = true;
            else Settings.Default["CheckEventTool"] = false;
        }

        private void RedChanged(object sender, EventArgs e){
            RedTrackBar.Value = Convert.ToInt32(RedTextBox.Value);
            EditColor.BackColor = Color.FromArgb(RedTrackBar.Value, GreenTrackBar.Value, BlueTrackBar.Value);
        }
        private void GreenChanged(object sender, EventArgs e){
            GreenTrackBar.Value = Convert.ToInt32(GreenTextBox.Value);
            EditColor.BackColor = Color.FromArgb(RedTrackBar.Value, GreenTrackBar.Value, BlueTrackBar.Value);
        }
        private void BlueChanged(object sender, EventArgs e){
            BlueTrackBar.Value = Convert.ToInt32(BlueTextBox.Value);
            EditColor.BackColor = Color.FromArgb(RedTrackBar.Value, GreenTrackBar.Value, BlueTrackBar.Value);
        }
        private void RedTrack_Scroll(object sender, EventArgs e){
            RedTextBox.Value = Convert.ToDecimal(RedTrackBar.Value);
        }
        private void GreenTrack_Scroll(object sender, EventArgs e){
            GreenTextBox.Value = Convert.ToDecimal(GreenTrackBar.Value);
        }
        private void BlueTrack_Scroll(object sender, EventArgs e){
            BlueTextBox.Value = Convert.ToDecimal(BlueTrackBar.Value);
        }
        private void AcceptChange(object sender, EventArgs e){
            Settings.Default["Bred"] = Convert.ToByte(RedTrackBar.Value);
            Settings.Default["Bgreen"] = Convert.ToByte(GreenTrackBar.Value);
            Settings.Default["Bblue"] = Convert.ToByte(BlueTrackBar.Value);
            Settings.Default.Save();
            Application.Restart();
        }
        private void CancelChange(object sender, EventArgs e){
            RedTextBox.Value = Convert.ToInt32(Settings.Default["Bred"]);
            GreenTextBox.Value = Convert.ToInt32(Settings.Default["Bgreen"]);
            BlueTextBox.Value = Convert.ToInt32(Settings.Default["Bblue"]);
            CheckToolTip.Checked = Convert.ToBoolean(Settings.Default["CheckToolTip"]);
            CheckEventLog.Checked = Convert.ToBoolean(Settings.Default["CheckEventTool"]); 
        }

        private void ChangeDefault(object sender, EventArgs e){
            RedTrackBar.Value = 0;
            GreenTrackBar.Value = 128;
            BlueTrackBar.Value = 58;
            CheckToolTip.Checked = false;
            CheckEventLog.Checked = false;
        }

        public void ControlKeys(KeyEventArgs e){
            switch (e.KeyCode){
                case Keys.R: if (RedTextBox.Value != 255) RedTextBox.Value++; break;
                case Keys.F: if (RedTextBox.Value != 0) RedTextBox.Value--; break;
                case Keys.T: if (GreenTextBox.Value != 255) GreenTextBox.Value++; break;
                case Keys.G: if (GreenTextBox.Value != 0) GreenTextBox.Value--; break;
                case Keys.Y: if (BlueTextBox.Value != 255) BlueTextBox.Value++; break;
                case Keys.H: if (BlueTextBox.Value != 0) BlueTextBox.Value--; break;
                case Keys.S: if (CheckToolTip.Checked == true)
                                CheckToolTip.Checked = false;
                            else CheckToolTip.Checked = true; break;
                case Keys.W:
                    if (CheckEventLog.Checked == true)
                        CheckEventLog.Checked = false;
                    else CheckEventLog.Checked = true; break;
                case Keys.D: ChangeDefault(DefaultButton, null); break;
                case Keys.Back: CancelChange(ButtonCancel, null); break;
                case Keys.Enter: AcceptChange(ButtonAccept, null); break;
            }
        }
    }
}
