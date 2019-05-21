using System;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using CalculaterPro.Properties;

namespace CalculaterPro
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing){
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }
        
        private Panel
             WindowPanel = new Panel(),
             MainPanel = new Panel(),
             OtherWindow = new Panel(),
             ViewsPanel = new Panel(),
             NavigatorPanel = new Panel();
        private Button
            ButtonEquationABC = new ButtonCustom(
                new Point(7, 330), new Size(256, 45), new Padding(0, 0, 0, 3), "ButtonEquationABC", "7) Уравнение ax^2+bx+c", 10F){
                Image = Resources.equation,
                ImageAlign = ContentAlignment.MiddleRight,
                TextAlign = ContentAlignment.MiddleLeft
            },
            ButtonDateCompute = new ButtonCustom(
                new Point(7, 282), new Size(256, 45), new Padding(0, 0, 0, 3), "ButtonDateCompute", "6) Вычисление дат", 10F){
                    Image = Resources.DataCompute,
                    ImageAlign = ContentAlignment.MiddleRight,
                    Padding = new Padding(0, 0, 5, 0),
                    TextAlign = ContentAlignment.MiddleLeft
            },
            ButtonValuteCompute = new ButtonCustom(
                new Point(7, 234), new Size(256, 45), new Padding(0, 0, 0, 3), "ButtonValuteCompute", "5) Валютные счисления", 10F){
                    Image = Resources.ValuteMoney,
                    ImageAlign = ContentAlignment.MiddleRight,
                    Padding = new Padding(0, 0, 5, 0),
                    TextAlign = ContentAlignment.MiddleLeft
            },
            ButtonComputeSystem = new ButtonCustom(
                new Point(7, 186), new Size(256, 45), new Padding(0, 0, 0, 3), "ButtonComputeSystem", "4) Вычисление СС", 10F){
                    Image = Resources.ComputeNumberSystem,
                    ImageAlign = ContentAlignment.MiddleRight,
                    Padding = new Padding(0, 0, 5, 0),
                    TextAlign = ContentAlignment.MiddleLeft
            },
            ButtonEngineerCalculater = new ButtonCustom(
                new Point(7, 90), new Size(256, 45), new Padding(0, 0, 0, 3), "ButtonSimpleCalculater", "2) Инженерный калькулятор", 10F){
                    Image = Resources.UniversalCalculater,
                    ImageAlign = ContentAlignment.MiddleRight,
                    TextAlign = ContentAlignment.MiddleLeft
            },
            ButtonSimpleCalculater = new ButtonCustom(
                new Point(7, 42), new Size(256, 45), new Padding(0, 0, 0, 3), "ButtonSimpleCalculater", "1) Обычный калькулятор", 10F){
                    Image = Resources.SimpleCalculater,
                    ImageAlign = ContentAlignment.MiddleRight,
                    TextAlign = ContentAlignment.MiddleLeft
            },
            ButtonNumberSystem = new ButtonCustom(
                new Point(7, 138), new Size(256, 45), new Padding(0, 0, 0, 3), "ButtonNumberSystem", "3) Система счисления", 10F){
                    Image = Resources.NumberSystem,
                    ImageAlign = ContentAlignment.MiddleRight,
                    Padding = new Padding(0, 0, 5, 0),
                    TextAlign = ContentAlignment.MiddleLeft
            },
            ButtonSystemMeasure = new ButtonCustom(
                new Point(7, 426), new Size(256, 45), new Padding(0, 0, 0, 3), "ButtonSystemMeasure", "9) Система измерений", 10F){
                    Image = Resources.SystemMeasure,
                    ImageAlign = ContentAlignment.MiddleRight,
                    Padding = new Padding(0, 0, 5, 0),
                    TextAlign = ContentAlignment.MiddleLeft
            },
            ButtonConverterDigits = new ButtonCustom(
                new Point(7, 378), new Size(256, 45), new Padding(0, 0, 0, 3), "ButtonConverterDigits", "8) Конвертер чисел", 10F){
                    Image = Resources.ConvertDigits,
                    ImageAlign = ContentAlignment.MiddleRight,
                    Padding = new Padding(0, 0, 5, 0),
                    TextAlign = ContentAlignment.MiddleLeft
            },
            ButtonCodeMath = new ButtonCustom(
                new Point(7, 474), new Size(256, 45), new Padding(0, 0, 0, 3), "ButtonCodeMath", "10) MathScript", 10F){
                    Image = Resources.MathScript,
                    ImageAlign = ContentAlignment.MiddleRight,
                    Padding = new Padding(0, 0, 5, 0),
                    TextAlign = ContentAlignment.MiddleLeft
            },
            ExitButton = new ButtonCustom(new Point(454, 0), new Size(40, 34), new Padding(0), "ExitButton", ""){
                Image = Resources.ExitPicture40x30_1_,
                BackColor = RedGreenBlue.Color3,
                Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)))
            },
            RestartButton = new ButtonCustom(new Point(414, 0), new Size(40, 34), new Padding(0), "RestartButton", ""){
                Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right))),
                BackColor = RedGreenBlue.Color3,
                Image = Resources.ReStart
            },
            MinimizedButton = new ButtonCustom(new Point(374, 0), new Size(40, 34), new Padding(0), "MinimizedButton", ""){
                Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right))),
                BackColor = RedGreenBlue.Color3,
                Image = Resources.MinPicture40x30
            },
            ButtonConstant = new ButtonCustom(new Point(374, 0), new Size(40, 36), new Padding(0), "ButtonConstant", ""){
                Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right))),
                BackColor = RedGreenBlue.Color1,
                Image = Resources.Constant
            },
            ButtonSettings = new ButtonCustom(new Point(414, 0), new Size(40, 36), new Padding(0), "ButtonSettings", ""){
                Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right))),
                Image = Resources.Settings1
            },
            ButtonViews = new ButtonCustom(new Point(454, 0), new Size(40, 36), new Padding(0), "ButtonViews", ""){
                Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right))),
                Image = Resources.ViewsPanel
            },
            ReviewButton = new ButtonCustom(new Point(294, 0), new Size(40, 36), new Padding(0), "ReviewButton", ""){
                Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right))),
                Image = Resources.tooltip
            },
            ButtonLogbook = new ButtonCustom(new Point(334, 0), new Size(40, 36), new Padding(0), "ButtonLogbook", ""){
                    Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right))),
                    Image = Resources.logbook
            };
        private Label
            TitleWindow = new LabelCustom(
                new Point(47, 0), new Size(110, 34), new Padding(0), ContentAlignment.MiddleCenter, "TitleWindow", "CalculatorPro"),
            NavigatorTitle = new LabelCustom(
                new Point(47, 3), new Size(247, 30), new Padding(0), ContentAlignment.MiddleLeft, "NavigatorTitle", "") {
                Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)))
            },
            OtherWindowTitle = new LabelCustom(
                new Point(-203, 3), new Size(202, 30), new Padding(0), ContentAlignment.MiddleLeft, "OtherWindowTitle", "") {
                Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)))
            },
            LabelPanelViews = new LabelCustom(
                new Point(7, 7), new Size(256, 28), new Padding(7), ContentAlignment.MiddleCenter, "LabelPanelViews", "Вкладки"){
                BackColor = RedGreenBlue.Color2
            };
        private PictureBox
            IconWindow = new PictureCustom(
                new Point(7, 3), new Size(40, 30), new Padding(0), PictureBoxSizeMode.CenterImage, "IconWindow"){
                Image = Resources.IconForProgram
            },
            NavigatorIcon = new PictureCustom(
                new Point(7, 3), new Size(40, 30), new Padding(0), PictureBoxSizeMode.CenterImage, "NavigatorIcon"){
                Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right))),
                Image = Resources.BeginnerPage
            },
            OtherWindowIcon = new PictureCustom(
                new Point(-243, 3), new Size(40, 30), new Padding(0), PictureBoxSizeMode.CenterImage, "OtherWindowIcon"){
                Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)))
            };
        
        private void InitializeComponent()
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(MainForm));
            WindowPanel.SuspendLayout();
            ((ISupportInitialize)(IconWindow)).BeginInit();
            NavigatorPanel.SuspendLayout();
            ((ISupportInitialize)(OtherWindowIcon)).BeginInit();
            ((ISupportInitialize)(NavigatorIcon)).BeginInit();
            ViewsPanel.SuspendLayout();
            SuspendLayout();

            // WindowPanel
            WindowPanel.BackColor = RedGreenBlue.Color3;
            WindowPanel.Controls.Add(IconWindow);
            WindowPanel.Controls.Add(MinimizedButton);
            WindowPanel.Controls.Add(RestartButton);
            WindowPanel.Controls.Add(ExitButton);
            WindowPanel.Controls.Add(TitleWindow);
            WindowPanel.Dock = DockStyle.Top;
            WindowPanel.Location = new Point(0, 0);
            WindowPanel.Margin = new Padding(0);
            WindowPanel.Name = "WindowPanel";
            WindowPanel.Size = new Size(500, 34);
            WindowPanel.TabIndex = 0;
            WindowPanel.MouseDown += new MouseEventHandler(MainWindow_Down);
            WindowPanel.MouseMove += new MouseEventHandler(MainWindow_Move);

            MinimizedButton.Click += new EventHandler(MainWindow_Minimized);
            RestartButton.Click += new EventHandler(MainWindow_Restart);
            ExitButton.Click += new EventHandler(MainWindow_Exit);
            ButtonConstant.Click += new EventHandler(OpenOtherWindow2);
            ButtonCodeMath.Click += new EventHandler(OpenCodingMathRequest);
            ButtonEquationABC.Click += new EventHandler(OpenEquationABC);
            ButtonConverterDigits.Click += new EventHandler(OpenConvertDigits);
            ButtonNumberSystem.Click += new EventHandler(NumberSystem_Click);
            ButtonSystemMeasure.Click += new EventHandler(OpenSystemMeasure);
            ButtonSimpleCalculater.Click += new EventHandler(OpenSimpleCalculater);
            ButtonDateCompute.Click += new EventHandler(OpenDateCompute);
            ButtonValuteCompute.Click += new EventHandler(OpenValuteCompute);
            ButtonComputeSystem.Click += new EventHandler(OpenComputeNumSystem);
            ButtonEngineerCalculater.Click += new EventHandler(OpenEngineerCalculater);
            ButtonLogbook.Click += new EventHandler(OpenOtherWindow1);
            ReviewButton.Click += new EventHandler(OpenReview_Click);
            ButtonViews.Click += new EventHandler(ViewsPanel_Click);
            ButtonSettings.Click += new EventHandler(OpenSettingsPage);
            
            // MainPanel
            MainPanel.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Right)));
            MainPanel.BackColor = RedGreenBlue.Color2;
            MainPanel.Location = new Point(7, 70);
            MainPanel.Margin = new Padding(0);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new Size(487, 523);
            MainPanel.TabIndex = 0;
            
            // NavigatorPanel
            NavigatorPanel.Controls.Add(OtherWindowTitle);
            NavigatorPanel.Controls.Add(OtherWindowIcon);
            NavigatorPanel.Controls.Add(NavigatorIcon);
            NavigatorPanel.Controls.Add(NavigatorTitle);
            NavigatorPanel.Controls.Add(ButtonLogbook);
            NavigatorPanel.Controls.Add(ReviewButton);
            NavigatorPanel.Controls.Add(ButtonViews);
            NavigatorPanel.Controls.Add(ButtonSettings);
            NavigatorPanel.Controls.Add(ButtonConstant);
            NavigatorPanel.Dock = DockStyle.Top;
            NavigatorPanel.Location = new Point(0, 34);
            NavigatorPanel.Margin = new Padding(0);
            NavigatorPanel.Name = "NavigatorPanel";
            NavigatorPanel.Size = new Size(500, 36);
            NavigatorPanel.TabIndex = 0;
            
            // OtherWindow
            OtherWindow.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left)));
            OtherWindow.BackColor = RedGreenBlue.Color2;
            OtherWindow.Location = new Point(7, 70);
            OtherWindow.Margin = new Padding(0);
            OtherWindow.Name = "OtherWindow";
            OtherWindow.Size = new Size(242, 523);
            OtherWindow.TabIndex = 0;
            
            // ViewsPanel
            ViewsPanel.BackColor = RedGreenBlue.Color3;
            ViewsPanel.Controls.Add(ButtonCodeMath);
            ViewsPanel.Controls.Add(LabelPanelViews);
            ViewsPanel.Controls.Add(ButtonSystemMeasure);
            ViewsPanel.Controls.Add(ButtonConverterDigits);
            ViewsPanel.Controls.Add(ButtonEquationABC);
            ViewsPanel.Controls.Add(ButtonSimpleCalculater);
            ViewsPanel.Controls.Add(ButtonDateCompute);
            ViewsPanel.Controls.Add(ButtonValuteCompute);
            ViewsPanel.Controls.Add(ButtonComputeSystem);
            ViewsPanel.Controls.Add(ButtonNumberSystem);
            ViewsPanel.Controls.Add(ButtonEngineerCalculater);
            ViewsPanel.Dock = DockStyle.Right;
            ViewsPanel.Location = new Point(500, 70);
            ViewsPanel.Margin = new Padding(0);
            ViewsPanel.MaximumSize = new Size(270, 530);
            ViewsPanel.Name = "ViewsPanel";
            ViewsPanel.Size = new Size(0, 530);
            ViewsPanel.TabIndex = 0;
            
            // MainForm
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = RedGreenBlue.Color1;
            ClientSize = new Size(500, 600);
            Controls.Add(ViewsPanel);
            Controls.Add(MainPanel);
            Controls.Add(NavigatorPanel);
            Controls.Add(WindowPanel);
            Controls.Add(OtherWindow);
            Font = new Font("Ubuntu Light", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            ForeColor = SystemColors.Control;
            FormBorderStyle = FormBorderStyle.None;
            Icon = ((Icon)(resources.GetObject("$this.Icon")));
            Margin = new Padding(4, 5, 4, 5);
            MaximumSize = new Size(750, 600);
            MinimumSize = new Size(500, 600);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            FormClosed += new FormClosedEventHandler(MainWindow_Closed);
            Load += new EventHandler(MainWindow_Load);
            KeyDown += new KeyEventHandler(MainWindow_KeyDown);
            WindowPanel.ResumeLayout(false);
            ((ISupportInitialize)(IconWindow)).EndInit();
            NavigatorPanel.ResumeLayout(false);
            ((ISupportInitialize)(OtherWindowIcon)).EndInit();
            ((ISupportInitialize)(NavigatorIcon)).EndInit();
            ViewsPanel.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}

