using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CalculaterPro.Properties;
using System.Diagnostics;
using System.Data.SqlClient;

namespace CalculaterPro
{
    public partial class MainForm : Form
    {
        public static SqlConnection SqlConnection;
        public static byte index = Convert.ToByte(Settings.Default["IndexView"]);
        public static ToolTipCustom ToolTip = new ToolTipCustom();
        SimpleCalculater SimpleCalculater = new SimpleCalculater();
        NumberSystem NumberSystem = new NumberSystem();
        EquationABC EquationABC = new EquationABC();
        CodingMathRequest CodingMathRequest = new CodingMathRequest();
        SettingsPage SettingsPage = new SettingsPage();
        ConverterDigits ConverterDigits = new ConverterDigits();
        ComputeNumSystem ComputeNumSystem = new ComputeNumSystem();
        SystemMeasure SystemMeasure = new SystemMeasure();
        ValuteCompute ValuteCompute = new ValuteCompute();
        EngineerCalculater EngineerCalculater = new EngineerCalculater();
        DateCompute DateCompute = new DateCompute();

        PanelLogBook PanelLogBook = new PanelLogBook();
        WinConstant WinConstant = new WinConstant();
        
        public MainForm(){
            ConnectToDB();
            InitializeComponent();
            SetControlsKeyDown(SimpleCalculater);
            SetControlsKeyDown(SimpleCalculater.TBLayout);
            SetControlsKeyDown(EngineerCalculater);
            SetControlsKeyDown(EngineerCalculater.TBLayout);
            SetControlsKeyDown(NumberSystem);
            SetControlsKeyDown(NumberSystem.TBLayout);
            SetControlsKeyDown(ComputeNumSystem);
            SetControlsKeyDown(ComputeNumSystem.TBLayout);
            SetControlsKeyDown(EquationABC);
            SetControlsKeyDown(EquationABC.TBLayout);
            SetControlsKeyDown(ConverterDigits);
            SetControlsKeyDown(ConverterDigits.TBLayout);
            SetControlsKeyDown(SettingsPage);
            SetControlsKeyDown(SettingsPage.TBLayout);
            SetControlsKeyDown(SettingsPage.ContentSettings);
            SetControlsKeyDown(SystemMeasure);
            SetControlsKeyDown(CodingMathRequest);
            SetControlsKeyDown(CodingMathRequest.TBLayout);
            SetControlsKeyDown(PanelLogBook);
            SetControlsKeyDown(PanelLogBook.PanelShowsText);
            SetControlsKeyDown(WinConstant);
            SetControlsKeyDown(WinConstant.PanelButtons);
            SetControlsKeyDown(ViewsPanel);
            SetControlsKeyDown(ValuteCompute);
            SetControlsKeyDown(WindowPanel);
            SetControlsKeyDown(NavigatorPanel);
            PanelLogBook.PanelShowsText.ControlAdded += new ControlEventHandler(delegate (object sender, ControlEventArgs e) {
                ((Panel)sender).Controls[((Panel)sender).Controls.Count - 1].KeyDown += new KeyEventHandler(MainWindow_KeyDown);
                foreach (TextBox i in ((Panel)sender).Controls)
                    if (((Panel)sender).Controls.Count > 4){
                        i.Width = 195; ((Panel)sender).AutoScroll = true; }
                    else { i.Width = 214; ((Panel)sender).AutoScroll = false; }
            });
        }

        private void SetControlsKeyDown(Control Parent){
            foreach (var i in Parent.Controls)
                ((Control)i).KeyDown += new KeyEventHandler(MainWindow_KeyDown);
        }

        public void WinSetToolTip() {
            ToolTip.SetToolTip(ExitButton, "Закрыть");
            ToolTip.SetToolTip(MinimizedButton, "Свернуть");
            ToolTip.SetToolTip(RestartButton, "Обновить");
            ToolTip.SetToolTip(ButtonSettings, "Настройки");
            ToolTip.SetToolTip(ButtonViews, "Меню");
            ToolTip.SetToolTip(ReviewButton, "О программе");
            ToolTip.SetToolTip(ButtonConstant, "Окно констант");
            ToolTip.SetToolTip(ButtonLogbook, "Журнал операций");

            NumberSystem.SetControlsToolTip();
            SimpleCalculater.SetControlsToolTip();
            EquationABC.SetControlsToolTip();
            PanelLogBook.SetControlsToolTip();
            CodingMathRequest.SetControlsToolTip();
            ConverterDigits.SetControlsToolTip();
        }

        #region код для взаимодействия с главным окном
        private int x = 0; private int y = 0;
        private void MainWindow_Down(object sender, MouseEventArgs e){
            x = e.X; y = e.Y;
        }
        private void MainWindow_Move(object sender, MouseEventArgs e){
            if (e.Button == MouseButtons.Left)
                Location = new Point(Location.X + (e.X - x), Location.Y + (e.Y - y));
        }
        private void MainWindow_Restart(object sender, EventArgs e){
            Application.Restart();
        }
        private void MainWindow_Load(object sender, EventArgs e){
            if (Convert.ToBoolean(Settings.Default["CheckToolTip"]) == true)
                WinSetToolTip();
            switch (Convert.ToInt16(Settings.Default["IndexView"])){
                case 1: OpenSimpleCalculater(ButtonSimpleCalculater, null); break;
                case 2: OpenEngineerCalculater(ButtonEngineerCalculater, null); break;
                case 3: NumberSystem_Click(ButtonNumberSystem, null); break;
                case 4: OpenComputeNumSystem(ButtonComputeSystem, null); break;
                case 5: OpenValuteCompute(ButtonValuteCompute, null); break;
                case 6: OpenDateCompute(ButtonDateCompute, null); break;
                case 7: OpenEquationABC(ButtonEquationABC, null); break;
                case 8: OpenConvertDigits(ButtonConverterDigits, null); break;
                case 9: OpenSystemMeasure(ButtonSystemMeasure, null); break;
                case 10: OpenCodingMathRequest(ButtonCodeMath, null); break;
                case 11: OpenSettingsPage(ButtonSettings, null); break;
            }
            OtherWindow.Controls.Add(PanelLogBook);
        }

        public async static void ConnectToDB(){ 
            string Sourse = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\MainDateBase.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection = new SqlConnection(Sourse);
            await SqlConnection.OpenAsync();
        }

        private void MainWindow_Exit(object sender, EventArgs e){
            Close();
        }
        private void MainWindow_Minimized(object sender, EventArgs e){
            WindowState = FormWindowState.Minimized;
        }
        private void MainWindow_Closed(object sender, FormClosedEventArgs e){
            Settings.Default.Save();
            if (SqlConnection != null && SqlConnection.State != ConnectionState.Closed)
                SqlConnection.Close();
        }
        private void MainWindow_KeyDown(object sender, KeyEventArgs e){
            if (e.Control){ // работа с учетом использования сочитания клавиш с Control
                switch (e.KeyCode){
                    case Keys.D0: OpenSimpleCalculater(ButtonSimpleCalculater, null); break; // обычный калькулятор
                    case Keys.D1: OpenSimpleCalculater(ButtonSimpleCalculater, null); break; // инженерный калькулятор
                    case Keys.D2: NumberSystem_Click(ButtonNumberSystem, null); break;       // система счислений
                    case Keys.D3: OpenComputeNumSystem(ButtonComputeSystem, null); break;    // калькулятор систем счислений
                    case Keys.D4: OpenValuteCompute(ButtonValuteCompute, null); break;       // валютные счисления 
                    case Keys.D5: OpenDateCompute(ButtonDateCompute, null); break;           // счисление дат
                    case Keys.D6: OpenEquationABC(ButtonEquationABC, null); break;           // уравнение ax^2 + bx + c
                    case Keys.D7: OpenConvertDigits(ButtonConverterDigits, null); break;     // конвертер чисел
                    case Keys.D8: OpenSystemMeasure(ButtonSystemMeasure, null); break;       // система измерений
                    case Keys.D9: OpenCodingMathRequest(ButtonCodeMath, null); break;        // mathscript
                    case Keys.Up: ChangeViewByIndex('+'); break;                             // переключение вкладок стрелкой вверх
                    case Keys.Down: ChangeViewByIndex('-'); break;                           // переключение вкладок стрелкой вниз
                }
                if (index == 10) CodingMathRequest.ControlKeys(e);                           // работа с "MathScript"
                return;
            }
            if (e.Shift){ // работа с учетом использования Shift
                if (OtherWindow.Controls.Contains(WinConstant))
                    WinConstant.ControlKeys(e);
                else if (OtherWindow.Controls.Contains(PanelLogBook))
                    PanelLogBook.ControlKeys(e);
                return;
            }
            // взаимодействие с вкладками индивидуально
            if (!e.Control && !e.Shift) {
                switch (e.KeyCode){
                    case Keys.Escape: ViewsPanel_Click(ButtonViews, null); break;           // Esc     для открытия меню вкладок
                    case Keys.F1: OpenOtherWindow1(ButtonLogbook, null); break;             // F1      для открытия журнала операций
                    case Keys.F2: OpenOtherWindow2(ButtonConstant, null); break;            // F2      для открытия окна констант
                    case Keys.F5: MainWindow_Restart(RestartButton, null); break;           // F5      для перезагрузки приложения
                    case Keys.F6: OpenSettingsPage(ButtonSettings, null); break;            // F6      для открытия меню настроек
                    case Keys.F10: OpenReview_Click(ReviewButton, null); break;             // F10     для открытия html-документа
                    case Keys.F11: MainWindow_Minimized(MinimizedButton, null); break;      // F11     для сворачивания окна
                    case Keys.F12: MainWindow_Exit(ExitButton, null); break;                // F12     для закрытия окна
                }
                switch (index) {
                    case 1: SimpleCalculater.ControlKeys(e); break;     // работа с вкладкой "обычный калькулятор"
                    case 2: EngineerCalculater.ControlKeys(e) ; break;  // работа с вкладкой "Инженерный калькулятор"
                    case 3: NumberSystem.ControlKeys(e); break;         // работа с вкладкой "Система счислений"
                    case 4: ComputeNumSystem.ControlKeys(e); break;
                    case 5: ValuteCompute.ControlKeys(e); break;        // работа с вкладкой "валютные счисления"
                    case 6: DateCompute.ControlKeys(e); break;
                    case 7: EquationABC.ControlKeys(e); break;          // работа с "уравнением abc"
                    case 8: ConverterDigits.ControlKeys(e); break;      // работа с "конвертер чисел"
                    case 9: SystemMeasure.ControlKeys(e); break;        // работа с вкладкой "Система измерений"
                    case 11: SettingsPage.ControlKeys(e); break;
                }
                return;
            }
        }
        #endregion

        private void OpenReview_Click(object sender, EventArgs e){
            Process.Start(@"Review.html");
        }

        private void OpenOtherWindow1(object sender, EventArgs e){
            OpenView(PanelLogBook, "Журнал операций", Resources.logbook);
        }
        private void OpenOtherWindow2(object sender, EventArgs e){
            OpenView(WinConstant, "Окно констант", Resources.Constant);
        }

        private void ViewsPanel_Click(object sender, EventArgs e){
            if (ViewsPanel.Width == 0) 
                ViewsPanel.Width = 270;
            else ViewsPanel.Width = 0;
        }
        private void OpenSimpleCalculater(object sender, EventArgs e){
            OpenView(SimpleCalculater, ((Control)sender).Text, Resources.SimpleCalculater, 1);
        }
        private void OpenEngineerCalculater(object sender, EventArgs e){
            OpenView(EngineerCalculater, ((Control)sender).Text, Resources.UniversalCalculater, 2);
        }
        private void NumberSystem_Click(object sender, EventArgs e){
            OpenView(NumberSystem, ((Control)sender).Text, Resources.NumberSystem, 3);
        }
        private void OpenComputeNumSystem(object sender, EventArgs e){
            OpenView(ComputeNumSystem, ((Control)sender).Text, Resources.ComputeNumberSystem, 4);
        }
        private void OpenValuteCompute(object sender, EventArgs e){
            OpenView(ValuteCompute, ((Control)sender).Text, Resources.ValuteMoney, 5);
        }
        private void OpenDateCompute(object sender, EventArgs e){
            OpenView(DateCompute, ((Control)sender).Text, Resources.DataCompute, 6);
        }
        private void OpenEquationABC(object sender, EventArgs e){
            OpenView(EquationABC, ((Control)sender).Text, Resources.equation, 7);
        }
        private void OpenConvertDigits(object sender, EventArgs e){
            OpenView(ConverterDigits, ((Control)sender).Text, Resources.ConvertDigits, 8);
        }
        private void OpenSystemMeasure(object sender, EventArgs e){
            OpenView(SystemMeasure, ((Control)sender).Text, Resources.SystemMeasure, 9);
        }
        private void OpenCodingMathRequest(object sender, EventArgs e){
            OpenView(CodingMathRequest, ((Control)sender).Text, Resources.MathScript, 10);
        }
        private void OpenSettingsPage(object sender, EventArgs e){
            OpenView(SettingsPage, "Настройки", Resources.Settings1, 11);
        }

        private void OpenView(Control Panel, string title, Image image, byte index1){
            if (MainPanel.Controls.Count >= 1)
                MainPanel.Controls.RemoveAt(0);
            ViewsPanel.Width = 0;
            MainPanel.Controls.Add(Panel);
            NavigatorTitle.Text = title;
            NavigatorIcon.Image = image;
            Settings.Default["IndexView"] = index1;
            index = index1; 
        }

        private void OpenView(Control Panel, string title, Image image){
            if (Size == MinimumSize || !OtherWindow.Controls.Contains(Panel)){
                Size = MaximumSize;
                if (OtherWindow.Controls.Count >= 1)
                    OtherWindow.Controls.RemoveAt(0);
                OtherWindow.Controls.Add(Panel);
                if (Panel is WinConstant)
                    WinConstant.SelectingItems();
                else if (Panel is PanelLogBook)
                    PanelLogBook.SelectingItems();
                OtherWindowTitle.Text = title;
                OtherWindowIcon.Image = image;
            }
            else if (OtherWindow.Controls.Contains(Panel)) Size = MinimumSize; 
        }

        private void ChangeViewByIndex(char symbol){
            if (symbol == '+')
                if (index >= 10) index = 1;
                else index++;
            else if (symbol == '-')
                if (index == 1) index = 10;
                else index--;
            switch (index){
                case 1: OpenSimpleCalculater(ButtonSimpleCalculater, null); break;
                case 2: OpenEngineerCalculater(ButtonEngineerCalculater, null); break;
                case 3: NumberSystem_Click(ButtonNumberSystem, null); break;
                case 4: OpenComputeNumSystem(ButtonComputeSystem, null); break;
                case 5: OpenValuteCompute(ButtonValuteCompute, null); break;
                case 6: OpenDateCompute(ButtonDateCompute, null); break;
                case 7: OpenEquationABC(ButtonEquationABC, null); break;
                case 8: OpenConvertDigits(ButtonConverterDigits, null); break;
                case 9: OpenSystemMeasure(ButtonSystemMeasure, null); break;
                case 10: OpenCodingMathRequest(ButtonCodeMath, null); break;
            }
        }
    }
}
