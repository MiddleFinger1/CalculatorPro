using System;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.Scripting.Hosting;
using IronPython.Hosting;

namespace CalculaterPro
{
    class SimpleCalculater : PanelCustom
    {
        public static TextBoxCustom 
            TextLine = new TextBoxCustom(
                new Point(7, 190), new Size(473, 19), new Padding(0), "TextLine", "", true, false),
            TextArea = new TextBoxCustom(
                new Point(7, 7), new Size(473, 176), new Padding(0), "TextArea", "", true, true);

        public TBLayoutCustom TBLayout = new TBLayoutCustom(
            new Point(0, 209), new Size(480, 307), new Padding(0), "TBLayout", 6, 4);

        public ButtonCustom ButtonPersent = new ButtonCustom(
            new Point(7, 7), new Size(113, 44), new Padding(7, 7, 0, 0), "ButtonPersent", "%");
        public ButtonCustom ButtonRoot = new ButtonCustom(
            new Point(127, 7), new Size(113, 44), new Padding(7, 7, 0, 0), "ButtonRoot", "√");
        public ButtonCustom ButtonSquare = new ButtonCustom(
            new Point(247, 7), new Size(113, 44), new Padding(7, 7, 0, 0), "ButtonSquare", "x^2");
        public ButtonCustom Button1Devider = new ButtonCustom(
            new Point(367, 7), new Size(113, 44), new Padding(7, 7, 0, 0), "Button1Devider", "1/x");
        public ButtonCustom ButtonDevide = new ButtonCustom(
            new Point(367, 58), new Size(113, 44), new Padding(7, 7, 0, 0), "ButtonDevide", "/");
        public ButtonCustom ButtonBackspace = new ButtonCustom(
            new Point(247, 58), new Size(113, 44), new Padding(7, 7, 0, 0), "ButtonBackspace", "Backspace");
        public ButtonCustom ButtonC = new ButtonCustom(
            new Point(127, 58), new Size(113, 44), new Padding(7, 7, 0, 0), "ButtonC", "C");
        public ButtonCustom ButtonCE = new ButtonCustom(
            new Point(7, 58), new Size(113, 44), new Padding(7, 7, 0, 0), "ButtonCE", "CE");
        public ButtonCustom ButtonMultiple = new ButtonCustom(
            new Point(367, 109), new Size(113, 44), new Padding(7, 7, 0, 0), "ButtonMultiple", "*");
        public ButtonCustom Button9 = new ButtonCustom(
            new Point(247, 109), new Size(113, 44), new Padding(7, 7, 0, 0), "Button9", "9");
        public ButtonCustom Button8 = new ButtonCustom(
            new Point(127, 109), new Size(113, 44), new Padding(7, 7, 0, 0), "Button8", "8");
        public ButtonCustom ButtonMinus = new ButtonCustom(
            new Point(367, 160), new Size(113, 44), new Padding(7, 7, 0, 0), "ButtonMinus", "-");
        public ButtonCustom ButtonPlus = new ButtonCustom(
            new Point(367, 211), new Size(113, 44), new Padding(7, 7, 0, 0), "ButtonPlus", "+");
        public ButtonCustom Button6 = new ButtonCustom(
            new Point(247, 160), new Size(113, 44), new Padding(7, 7, 0, 0), "Button6", "6");
        public ButtonCustom Button7 = new ButtonCustom(
            new Point(7, 109), new Size(113, 44), new Padding(7, 7, 0, 0), "Button7", "7");
        public ButtonCustom Button5 = new ButtonCustom(
            new Point(127, 160), new Size(113, 44), new Padding(7, 7, 0, 0), "Button5", "5");
        public ButtonCustom Button3 = new ButtonCustom(
            new Point(247, 211), new Size(113, 44), new Padding(7, 7, 0, 0), "Button3", "3");
        public ButtonCustom ButtonEnter = new ButtonCustom(
            new Point(367, 262), new Size(113, 45), new Padding(7, 7, 0, 0), "ButtonEnter", "=");
        public ButtonCustom Button4 = new ButtonCustom(
            new Point(7, 160), new Size(113, 44), new Padding(7, 7, 0, 0), "Button4", "4");
        public ButtonCustom Button2 = new ButtonCustom(
            new Point(127, 211), new Size(113, 44), new Padding(7, 7, 0, 0), "Button2", "2");
        public ButtonCustom ButtonPoint = new ButtonCustom(
            new Point(247, 262), new Size(113, 45), new Padding(7, 7, 0, 0), "ButtonPoint", ".");
        public ButtonCustom Button1 = new ButtonCustom(
            new Point(7, 211), new Size(113, 44), new Padding(7, 7, 0, 0), "Button1", "1");
        public ButtonCustom Button0 = new ButtonCustom(
            new Point(127, 262), new Size(113, 45), new Padding(7, 7, 0, 0), "Button0", "0");
        public ButtonCustom ButtonPlMin = new ButtonCustom(
            new Point(7, 262), new Size(113, 45), new Padding(7, 7, 0, 0), "ButtonPlMin", "∓");
        
        public SimpleCalculater() {
            TextArea.AddColor1();
            TextLine.AddColor1();
            Button0.Click += new EventHandler(InsertText);
            Button1.Click += new EventHandler(InsertText);
            Button2.Click += new EventHandler(InsertText);
            Button3.Click += new EventHandler(InsertText);
            Button4.Click += new EventHandler(InsertText);
            Button5.Click += new EventHandler(InsertText);
            Button6.Click += new EventHandler(InsertText);
            Button7.Click += new EventHandler(InsertText);
            Button8.Click += new EventHandler(InsertText);
            Button9.Click += new EventHandler(InsertText);
            ButtonDevide.Click += new EventHandler(InsertOperation);
            ButtonMultiple.Click += new EventHandler(InsertOperation);
            ButtonPlus.Click += new EventHandler(InsertOperation);
            ButtonMinus.Click += new EventHandler(InsertOperation);
            Button1Devider.Click += new EventHandler(Insert1Devide);
            ButtonRoot.Click += new EventHandler(InsertRoot);
            ButtonSquare.Click += new EventHandler(InsertSquare);
            ButtonC.Click += new EventHandler(Delete);
            ButtonCE.Click += new EventHandler(Delete1);
            ButtonEnter.Click += new EventHandler(GetAnswer);
            ButtonBackspace.Click += new EventHandler(Backspace);
            ButtonPersent.Click += new EventHandler(InsertOperation);
            ButtonPoint.Click += new EventHandler(InsertPoint);
            ButtonPlMin.Click += new EventHandler(InsertAbs);
            
            Controls.Add(TBLayout);
            Controls.Add(TextLine);
            Controls.Add(TextArea);
            Name = "SimpleCalculater";
            TBLayout.SuspendLayout();
            TBLayout.ResumeLayout(false);

            TBLayout.Controls.AddRange(new Control[] {
                ButtonPersent, ButtonRoot, ButtonSquare, Button1Devider,
                ButtonCE, ButtonC, ButtonBackspace, ButtonDevide,
                Button7, Button8, Button9, ButtonMultiple,
                Button4, Button5, Button6, ButtonMinus,
                Button1, Button2, Button3, ButtonPlus,
                ButtonPlMin, Button0, ButtonPoint, ButtonEnter
            });

            foreach (ButtonCustom i in TBLayout.Controls)
                i.AddColor1();
        }

        private void InsertAbs(object sender, EventArgs e){
            if (!string.IsNullOrEmpty(TextArea.Text))
                TextArea.Text = $"-1*({TextArea.Text})";
        }

        private void Insert1Devide(object sender, EventArgs e){
            if (!string.IsNullOrEmpty(TextArea.Text))
                TextArea.Text =  $"1/({TextArea.Text})";
        }

        private void InsertRoot(object sender, EventArgs e){
            if (!string.IsNullOrEmpty(TextArea.Text))
                TextArea.Text = $"({TextArea.Text})^0.5";
        }

        private void InsertSquare(object sender, EventArgs e){
            if (!string.IsNullOrEmpty(TextArea.Text))
                TextArea.Text = $"({TextArea.Text})^2";
        }

        private void InsertText(object sender, EventArgs e){
            string line = TextLine.Text;
            string area = TextArea.Text;
            if (line == "" && area.IndexOfAny(new char[] { '+', '-', '/', '*', '^', '%' }) < 0){
                TextArea.Clear();
                TextLine.Text = "";
            }
            if (area.EndsWith(")") == true) return;
            TextLine.Text += ((Button)sender).Text;
            TextArea.Text += ((Button)sender).Text;
        }

        private void Backspace(object sender, EventArgs e){
            try{
                TextLine.Text = TextLine.Text.Substring(0, TextLine.Text.Length - 1);
                TextArea.Text = TextArea.Text.Substring(0, TextArea.Text.Length - 1);
            }
            catch (ArgumentOutOfRangeException){
                TextLine.Text = "";
            }
        }
        private void InsertOperation(object sender, EventArgs e){
            string Line = TextLine.Text;
            string Area = TextArea.Text;
            
            if (!(Area.IndexOfAny(new char[] { '+', '-', '/', '*', '^', '%' }) == Area.Length - 1))
                if (Line != "" && !(Area.IndexOfAny(new char[] { '+', '-', '/', '*', '^', '%' }) == Area.Length - 1)){
                    TextLine.Text = "";
                    TextArea.Text += ((Button)sender).Text;
                }
                else if (Line == "" && Area == "" && ((Control)sender).Text == "-"){
                    TextArea.Text += ((Button)sender).Text;
                    TextLine.Text += ((Button)sender).Text;
                }
                else if (Line == "" && Area.IndexOfAny(new char[] { '+', '/', '*', '^', '%' }) < 0 && !(Area.IndexOf('-') > 0))
                    TextArea.Text += ((Button)sender).Text;
        }
        private void InsertPoint(object sender, EventArgs e){
            string Line = TextLine.Text;
            string area = TextArea.Text;
            if (Line == ""){
                TextLine.Text += "0.";
                TextArea.Text += "0.";
            }
            else if (Line == "" && area.IndexOfAny(new char[] { '+', '-', '/', '*', '^', '%' }) < 0){
                TextArea.Clear();
                TextLine.Text += ".";
                TextArea.Text += ".";
            }
            else if (Line.IndexOf(',') >= 0){
                TextLine.Text += "";
                TextArea.Text += "";
            }
            else{
                TextLine.Text += ".";
                TextArea.Text += ".";
            }
        }
        private void Delete1(object sender, EventArgs e){
            TextLine.Clear();
            TextArea.Clear();
        }
        private void Delete(object sender, EventArgs e){
            TextArea.Text = TextArea.Text.Substring(0, TextArea.Text.Length - TextLine.Text.Length);
            TextLine.Clear();
        }

        private void GetAnswer(object sender, EventArgs e){
            TextLine.Clear();
            ScriptEngine ScriptEngine = Python.CreateEngine();
            ScriptScope ScriptScope = ScriptEngine.CreateScope();
            string request = SetFloatNumbers(TextArea.Text);
            ScriptEngine.Execute("function = " + request + Environment.NewLine + "print function", ScriptScope);
            dynamic answer = ScriptScope.GetVariable("function");
            if (SettingsPage.CheckEventLogger)
                PanelLogBook.InsertVariable("Обычный калькулятор", TextArea.Text, Convert.ToString(answer));
            TextArea.Text = Convert.ToString(answer);
        }

        private string ChangeOparate(string request){
            string answer = "";
            foreach (var i in request)
                switch (i){
                    case '^': answer += "**"; break;
                    case ',': answer += '.'; break;
                    default: answer += i; break;
                }
            return answer;
        }

        private string SetFloatNumbers(string request){
            string reader = "", answer = "";
            foreach (var i in request){
                foreach (var h in new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '.', ','})
                    if (i == h)
                        reader += i;
                foreach (var h in new char[] { '+', '-', '/', '*', '^', '%' })
                    if (i == h){
                        answer += $"float({reader}){i}";
                        reader = "";
                    }
            }
            if (!string.IsNullOrEmpty(reader))
                answer += $"float({reader})";
            return ChangeOparate(answer);
        }

        public void SetControlsToolTip(){
            foreach (ButtonCustom i in TBLayout.Controls)
                switch (i.Name){
                    case "ButtonCE": MainForm.ToolTip.SetToolTip(i, "Клавиша Alt-Delete"); break;
                    case "ButtonRoot": MainForm.ToolTip.SetToolTip(i, "Клавиша R"); break;
                    case "ButtonPersent": MainForm.ToolTip.SetToolTip(i, "Клавиша P"); break;
                    case "Button1Devider": MainForm.ToolTip.SetToolTip(i, "Клавиша D"); break;
                    case "ButtonPlMin": MainForm.ToolTip.SetToolTip(i, "Клавиша A"); break;
                    case "ButtonSquare": MainForm.ToolTip.SetToolTip(i, "Клавиша S"); break;
                    default:
                        MainForm.ToolTip.SetToolTip(i, $"Клавиша {i.Text}"); break;
                }
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
                case Keys.Back: Backspace(ButtonBackspace, null); break;
                case Keys.Delete: Delete(ButtonC, null); break;
                case Keys.Oemcomma: InsertPoint(ButtonPoint, null); break;
                case Keys.P: InsertOperation(ButtonPersent, null); break;
                case Keys.OemMinus: InsertOperation(ButtonMinus, null); break;
                case Keys.Oemplus: InsertOperation(ButtonPlus, null); break;
                case Keys.Multiply: InsertOperation(ButtonMultiple, null); break;
                case Keys.Divide: InsertOperation(ButtonDevide, null); break;
                case Keys.R: InsertRoot(ButtonRoot, null); break;
                case Keys.D: Insert1Devide(Button1Devider, null); break;
                case Keys.S: InsertSquare(ButtonSquare, null); break;
                case Keys.A: InsertAbs(ButtonPlMin, null); break;
            }
            if (e.Alt && e.KeyCode == Keys.Delete)
                Delete1(ButtonCE, null);
        }
    }
}
