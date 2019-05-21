using System;
using System.Drawing;
using System.Windows.Forms;

namespace CalculaterPro
{
    class EquationABC : PanelCustom {
        public TBLayoutCustom TBLayout = new TBLayoutCustom(new Point(0, 289), new Size(482, 227), new Padding(7), "TBLayout", 3, 6);
        public ButtonCustom Button7 = new ButtonCustom(
            new Point(7, 7), new Size(72, 68), new Padding(7, 7, 0, 0), "Button7", "7");
        public ButtonCustom Button8 = new ButtonCustom(
            new Point(86, 7), new Size(72, 68), new Padding(7, 7, 0, 0), "Button8", "8");
        public ButtonCustom Button9 = new ButtonCustom(
            new Point(165, 7), new Size(72, 68), new Padding(7, 7, 0, 0), "Button9", "9");
        public ButtonCustom ButtonPlus = new ButtonCustom(
            new Point(244, 7), new Size(72, 68), new Padding(7, 7, 0, 0), "ButtonPlus", "+");
        public ButtonCustom ButtonA = new ButtonCustom(
            new Point(323, 7), new Size(72, 68), new Padding(7, 7, 0, 0), "ButtonA", "a");
        public ButtonCustom ButtonEnter = new ButtonCustom(
            new Point(402, 7), new Size(72, 70), new Padding(7, 7, 0, 0), "ButtonEnter", "Enter");
        public ButtonCustom Button4 = new ButtonCustom(
            new Point(7, 82), new Size(72, 68), new Padding(7, 7, 0, 0), "Button4", "4");
        public ButtonCustom Button5 = new ButtonCustom(
            new Point(86, 82), new Size(72, 68), new Padding(7, 7, 0, 0), "Button5", "5");
        public ButtonCustom Button6 = new ButtonCustom(
            new Point(165, 82), new Size(72, 68), new Padding(7, 7, 0, 0), "Button6", "6");
        public ButtonCustom ButtonMinus = new ButtonCustom(
            new Point(244, 82), new Size(72, 68), new Padding(7, 7, 0, 0), "ButtonMinus", "-");
        public ButtonCustom ButtonB = new ButtonCustom(
            new Point(323, 82), new Size(72, 68), new Padding(7, 7, 0, 0), "ButtonB", "b");
        public ButtonCustom ButtonDelete = new ButtonCustom(
            new Point(402, 82), new Size(72, 70), new Padding(7, 7, 0, 0), "ButtonDelete", "Delete");
        public ButtonCustom ButtonPoint = new ButtonCustom(
            new Point(402, 157), new Size(72, 70), new Padding(7, 7, 0, 0), "ButtonPoint", ",");
        public ButtonCustom Button1 = new ButtonCustom(
            new Point(7, 157), new Size(72, 70), new Padding(7, 7, 0, 0), "Button1", "1");
        public ButtonCustom Button2 = new ButtonCustom(
            new Point(86, 157), new Size(72, 70), new Padding(7, 7, 0, 0), "Button2", "2");
        public ButtonCustom Button3 = new ButtonCustom(
            new Point(165, 157), new Size(72, 70), new Padding(7, 7, 0, 0), "Button3", "3");
        public ButtonCustom Button0 = new ButtonCustom(
            new Point(244, 157), new Size(72, 70), new Padding(7, 7, 0, 0), "Button0", "0");
        public ButtonCustom ButtonC = new ButtonCustom(
            new Point(323, 157), new Size(72, 70), new Padding(7, 7, 0, 0), "ButtonC", "c");
        public TextBoxCustom TextArea = new TextBoxCustom(
            new Point(7, 7), new Size(473, 256), new Padding(7), "TextArea", "", true, true);
        public TextBoxCustom TextLine = new TextBoxCustom(
            new Point(7, 270), new Size(473, 19), new Padding(0, 7, 0, 0), "TextLine", "", true, false);

        public EquationABC()
        {
            TextArea.AddColor1();
            TextLine.AddColor1();
            Button0.AddColor1(); Button0.Click += new EventHandler(InsertText);
            Button1.AddColor1(); Button1.Click += new EventHandler(InsertText);
            Button2.AddColor1(); Button2.Click += new EventHandler(InsertText);
            Button3.AddColor1(); Button3.Click += new EventHandler(InsertText);
            Button4.AddColor1(); Button4.Click += new EventHandler(InsertText);
            Button5.AddColor1(); Button5.Click += new EventHandler(InsertText);
            Button6.AddColor1(); Button6.Click += new EventHandler(InsertText);
            Button7.AddColor1(); Button7.Click += new EventHandler(InsertText);
            Button8.AddColor1(); Button8.Click += new EventHandler(InsertText);
            Button9.AddColor1(); Button9.Click += new EventHandler(InsertText);
            ButtonA.AddColor1(); ButtonA.Click += new EventHandler(xsquare);
            ButtonB.AddColor1(); ButtonB.Click += new EventHandler(xsimple);
            ButtonC.AddColor1(); ButtonC.Click += new EventHandler(xnumber);
            ButtonPlus.AddColor1(); ButtonPlus.Click += new EventHandler(InsertSymbol);
            ButtonMinus.AddColor1(); ButtonMinus.Click += new EventHandler(InsertSymbol);
            ButtonEnter.AddColor1(); ButtonEnter.Click += new EventHandler(Enter);
            ButtonDelete.AddColor1(); ButtonDelete.Click += new EventHandler(Delete);
            ButtonPoint.AddColor1(); ButtonPoint.Click += new EventHandler(InsertPoint);

            Controls.Add(TextArea);
            Controls.Add(TextLine);
            Controls.Add(TBLayout);
            Name = "BeginnerView";
            TBLayout.SuspendLayout();
            TBLayout.ResumeLayout(false);

            TBLayout.Controls.AddRange(new Control[] {
                Button7, Button8, Button9, ButtonPlus, ButtonA, ButtonEnter,
                Button4, Button5, Button6, ButtonMinus, ButtonB, ButtonDelete,
                Button1, Button2, Button3, Button0, ButtonC, ButtonPoint
            });
        }

        public void ControlKeys(KeyEventArgs e){
            switch (e.KeyCode){
                case Keys.D0: InsertText(Button0, null); break;
                case Keys.D1: InsertText(Button1, null); break;
                case Keys.D2: InsertText(Button2, null); break;
                case Keys.D3: InsertText(Button3, null); break;
                case Keys.D4: InsertText(Button4, null); break;
                case Keys.D5: InsertText(Button5, null); break;
                case Keys.D6: InsertText(Button6, null); break;
                case Keys.D7: InsertText(Button7, null); break;
                case Keys.D8: InsertText(Button8, null); break;
                case Keys.D9: InsertText(Button9, null); break;
                case Keys.A: xsquare(ButtonA, null); break;
                case Keys.B: xsimple(ButtonB, null); break;
                case Keys.C: xnumber(ButtonC, null); break;
                case Keys.Enter: Enter(ButtonEnter, null); break;
                case Keys.Delete: Delete(ButtonDelete, null); break;
                case Keys.Oemcomma: InsertPoint(ButtonPoint, null); break;
                case Keys.Oemplus: InsertSymbol(ButtonPlus, null); break;
                case Keys.OemMinus: InsertSymbol(ButtonMinus, null); break;
            }
        }

        public void SetControlsToolTip(){
            MainForm.ToolTip.SetToolTip(Button0, "клавиша 0");
            MainForm.ToolTip.SetToolTip(Button1, "клавиша 1");
            MainForm.ToolTip.SetToolTip(Button2, "клавиша 2");
            MainForm.ToolTip.SetToolTip(Button3, "клавиша 3");
            MainForm.ToolTip.SetToolTip(Button4, "клавиша 4");
            MainForm.ToolTip.SetToolTip(Button5, "клавиша 5");
            MainForm.ToolTip.SetToolTip(Button6, "клавиша 6");
            MainForm.ToolTip.SetToolTip(Button7, "клавиша 7");
            MainForm.ToolTip.SetToolTip(Button8, "клавиша 8");
            MainForm.ToolTip.SetToolTip(Button9, "клавиша 9");
            MainForm.ToolTip.SetToolTip(ButtonA, "клавиша A");
            MainForm.ToolTip.SetToolTip(ButtonB, "клавиша B");
            MainForm.ToolTip.SetToolTip(ButtonC, "клавиша C");
            MainForm.ToolTip.SetToolTip(ButtonPoint, "клавиша ,");
            MainForm.ToolTip.SetToolTip(ButtonPlus, "клавиша +");
            MainForm.ToolTip.SetToolTip(ButtonMinus, "клавиша -");
            MainForm.ToolTip.SetToolTip(ButtonEnter, "клавиша Enter");
            MainForm.ToolTip.SetToolTip(ButtonDelete, "клавиша Delete");
        }

        public string numA { set; get; }
        public string numB { set; get; }
        public string numC { set; get; }
        public string reader = "";

        public void InsertText(object sender, EventArgs e){
            reader += ((Button)sender).Text;
            TextLine.Text += ((Button)sender).Text;
        }
        public void InsertPoint(object sender, EventArgs e){
            if (reader.IndexOf(',') < 0 && reader != "") TextLine.Text += ",";
            else TextLine.Text += "";
        }
        public void xsquare(object sender, EventArgs e){
            if (TextLine.Text.IndexOf('a') < 0){
                TextLine.Text += "a";
                if (reader == "") numA = "1";
                else if (reader == "-") numA = "-1";
                else if (reader == "+") numA = "1";
                else numA = reader;
                reader = "";
            }
        }
        public void xsimple(object sender, EventArgs e){
            if (TextLine.Text.IndexOf('b') < 0){
                TextLine.Text += "b";
                if (reader == "") numB = "1";
                else if (reader == "-") numB = "-1";
                else if (reader == "+") numB = "1";
                else numB = reader;
                reader = "";
            }
        }
        public void xnumber(object sender, EventArgs e){
            if (TextLine.Text.IndexOf('c') < 0){
                if (reader == "") numC = "1";
                else if (reader == "-") numC = "-1";
                else if (reader == "+") numC = "1";
                else numC = reader;
                TextLine.Text += "c";
                reader = "";
            }
        }
        public new void Enter(object sender, EventArgs e){
            TextArea.Clear();
            if (TextLine.Text.IndexOf('a') >= 0 && TextLine.Text.IndexOf('b') >= 0){
                if (numC == null || numC == "")
                    numC = "0";
                double argA = Convert.ToDouble(numA),
                    argB = Convert.ToDouble(numB),
                    argC = Convert.ToDouble(numC),
                    D = Math.Sqrt((argB * argB) - 4 * argA * argC),
                    x1 = 0, x2 = 0;
                TextArea.Text += $"{TextLine.Text} = 0;" + Environment.NewLine;
                TextArea.Text += $"D = {argB}^2 - 4 * {argA} * {argC} = √{D * D} = {D};" + Environment.NewLine;
                if (D >= 0){
                    x1 = (-argB + D) / (2 * argA);
                    x2 = (-argB - D) / (2 * argA);
                    TextArea.Text += $"x1 = {x1};" + Environment.NewLine;
                    TextArea.Text += $"x2 = {x2};" + Environment.NewLine;
                    TextArea.Text += $"Выражение в скобках: " + Environment.NewLine;
                    if (argA != 1) TextArea.Text += $"{argA}";
                    TextArea.Text += "(x";
                    if (x1 < 0) TextArea.Text += $" + {-x1}";
                    else TextArea.Text += $" - {x1}";
                    TextArea.Text += ")(x";
                    if (x2 < 0) TextArea.Text += $" + {-x2})";
                    else TextArea.Text += $" - {x2})";
                }
                else TextArea.Text = "Нет корней";
            }
            else TextArea.Text = "Неправильный запрос";
            if (SettingsPage.CheckEventLogger)
                PanelLogBook.InsertVariable("Уравнение ax^2+bx+c", TextLine.Text, TextArea.Text);
            reader = ""; TextLine.Clear();
        }
        public void InsertSymbol(object sender, EventArgs e){
            if (TextLine.Text == "" && ((Button)sender).Text == "-"){
                reader += "-";
                TextLine.Text += "-";
            }
            else if (TextLine.Text != ""){
                if (TextLine.Text[TextLine.Text.Length - 1] != '+' && TextLine.Text[TextLine.Text.Length - 1] != '-'){
                    reader = ((Button)sender).Text;
                    TextLine.Text += ((Button)sender).Text;
                }
            }
        }
        public void Delete(object sender, EventArgs e){
            numA = ""; numB = ""; numC = ""; reader = "";
            TextLine.Text = ""; TextArea.Text = "";
        }
    }
}
