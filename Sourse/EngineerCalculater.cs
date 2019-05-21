using System;
using System.Windows.Forms;
using System.Drawing;

namespace CalculaterPro
{
    class EngineerCalculater : PanelCustom
    {
        bool position = true;
        string Request = "";
        public static TextBoxCustom
            TextArea = new TextBoxCustom(
                new Point(7, 7), new Size(473, 172), new Padding(7, 7, 7, 0), "TextArea", "", true, true),
            TextLine = new TextBoxCustom(
                new Point(7, 186), new Size(473, 19), new Padding(7), "TextLine", "", true, false);
        public TBLayoutCustom TBLayout = new TBLayoutCustom(
            new Point(0, 206), new Size(480, 310), new Padding(0, 0, 7, 7), "TBLayout", 7, 5);
        private ButtonCustom
            ButtonPlus = new ButtonCustom(new Point(), new Size(96, 45), new Padding(7, 7, 0, 0), "", "+", 12F),
            ButtonMinus = new ButtonCustom(new Point(), new Size(96, 45), new Padding(7, 7, 0, 0), "", "-", 12F),
            ButtonDevide = new ButtonCustom(new Point(), new Size(96, 45), new Padding(7, 7, 0, 0), "", "/", 10F),
            ButtonMultiple = new ButtonCustom(new Point(), new Size(96, 45), new Padding(7, 7, 0, 0), "", "*", 12F),
            ButtonEqual = new ButtonCustom(new Point(), new Size(96, 45), new Padding(7, 7, 0, 0), "", "=", 10F),
            Button0 = new ButtonCustom(new Point(), new Size(96, 45), new Padding(7, 7, 0, 0), "", "0", 10F),
            Button1 = new ButtonCustom(new Point(), new Size(96, 45), new Padding(7, 7, 0, 0), "", "1", 10F),
            Button2 = new ButtonCustom(new Point(), new Size(96, 45), new Padding(7, 7, 0, 0), "", "2", 10F),
            Button3 = new ButtonCustom(new Point(), new Size(96, 45), new Padding(7, 7, 0, 0), "", "3", 10F),
            Button4 = new ButtonCustom(new Point(), new Size(96, 45), new Padding(7, 7, 0, 0), "", "4", 10F),
            Button5 = new ButtonCustom(new Point(), new Size(96, 45), new Padding(7, 7, 0, 0), "", "5", 10F),
            Button6 = new ButtonCustom(new Point(), new Size(96, 45), new Padding(7, 7, 0, 0), "", "6", 10F),
            Button7 = new ButtonCustom(new Point(), new Size(96, 45), new Padding(7, 7, 0, 0), "", "7", 10F),
            Button8 = new ButtonCustom(new Point(), new Size(96, 45), new Padding(7, 7, 0, 0), "", "8", 10F),
            Button9 = new ButtonCustom(new Point(), new Size(96, 45), new Padding(7, 7, 0, 0), "", "9", 10F),
            ButtonFactorial = new ButtonCustom(new Point(), new Size(96, 45), new Padding(7, 7, 0, 0), "", "!n", 10F),
            ButtonAbsolute = new ButtonCustom(new Point(), new Size(96, 45), new Padding(7, 7, 0, 0), "", "±", 12F),
            ButtonRightHook = new ButtonCustom(new Point(), new Size(96, 45), new Padding(7, 7, 0, 0), "", "(", 10F),
            ButtonLeftHook = new ButtonCustom(new Point(), new Size(96, 45), new Padding(7, 7, 0, 0), "", ")", 10F),
            ButtonPoint = new ButtonCustom(new Point(), new Size(96, 45), new Padding(7, 7, 0, 0), "", ".", 10F),
            ButtonChanePos = new ButtonCustom(new Point(), new Size(96, 45), new Padding(7, 7, 0, 0), "", "↑", 12F),
            ButtonDeleteAll = new ButtonCustom(new Point(), new Size(96, 45), new Padding(7, 7, 0, 0), "", "CE", 10F),
            ButtonDelete = new ButtonCustom(new Point(), new Size(96, 45), new Padding(7, 7, 0, 0), "", "C", 10F),
            ButtonBackspace = new ButtonCustom(new Point(), new Size(96, 45), new Padding(7, 7, 0, 0), "", "B", 10F),
            ButtonPi = new ButtonCustom(new Point(), new Size(96, 45), new Padding(7, 7, 0, 0), "", "∏", 12F),
            ButtonSquare = new ButtonCustom(new Point(), new Size(96, 45), new Padding(7, 7, 0, 0), "", "X^2", 10F),
            ButtonPower = new ButtonCustom(new Point(), new Size(96, 45), new Padding(7, 7, 0, 0), "", "^", 10F),
            ButtonSinus = new ButtonCustom(new Point(), new Size(96, 45), new Padding(7, 7, 0, 0), "", "Sin", 10F),
            ButtonCosinus = new ButtonCustom(new Point(), new Size(96, 45), new Padding(7, 7, 0, 0), "", "Cos", 10F),
            ButtonTan = new ButtonCustom(new Point(), new Size(96, 45), new Padding(7, 7, 0, 0), "", "Tan", 10F),
            ButtonRoot = new ButtonCustom(new Point(), new Size(96, 45), new Padding(7, 7, 0, 0), "", "√", 12F),
            Button10Power = new ButtonCustom(new Point(), new Size(96, 45), new Padding(7, 7, 0, 0), "", "10^X", 10F),
            ButtonLog = new ButtonCustom(new Point(), new Size(96, 45), new Padding(7, 7, 0, 0), "", "Log", 10F),
            ButtonExp = new ButtonCustom(new Point(), new Size(96, 45), new Padding(7, 7, 0, 0), "", "Exp", 10F),
            ButtonMod = new ButtonCustom(new Point(), new Size(96, 45), new Padding(7, 7, 0, 0), "", "%", 10F),
            ButtonCube = new ButtonCustom(new Point(), new Size(96, 45), new Padding(7, 7, 0, 0), "", "X^3", 10F),
            ButtonRootY = new ButtonCustom(new Point(), new Size(96, 45), new Padding(7, 7, 0, 0), "", "Y√X", 10F),
            ButtonSinus1 = new ButtonCustom(new Point(), new Size(96, 45), new Padding(7, 7, 0, 0), "", "Sin^-1", 10F),
            ButtonCosinus1 = new ButtonCustom(new Point(), new Size(96, 45), new Padding(7, 7, 0, 0), "", "Cos^-1", 10F),
            ButtonTag1 = new ButtonCustom(new Point(), new Size(96, 45), new Padding(7, 7, 0, 0), "", "Tan^-1", 10F),
            Button1DevideX = new ButtonCustom(new Point(), new Size(96, 45), new Padding(7, 7, 0, 0), "", "1/X", 10F),
            ButtonExponent = new ButtonCustom(new Point(), new Size(96, 45), new Padding(7, 7, 0, 0), "", "E^X", 10F),
            ButtonLn = new ButtonCustom(new Point(), new Size(96, 45), new Padding(7, 7, 0, 0), "", "Ln", 10F),
            ButtonDMS = new ButtonCustom(new Point(), new Size(96, 45), new Padding(7, 7, 0, 0), "", "Dms", 10F),
            ButtonDeg = new ButtonCustom(new Point(), new Size(96, 45), new Padding(7, 7, 0, 0), "", "Deg", 10F);

        public EngineerCalculater(){
            Controls.Add(TextArea);
            Controls.Add(TextLine);
            Controls.Add(TBLayout);
            Name = "EngineerCalculater";
            TextArea.AddColor1();
            TextLine.AddColor1();
            TBLayout.Controls.AddRange(new Control[] {
                ButtonSquare, ButtonPower, ButtonSinus, ButtonCosinus, ButtonTan,
                ButtonRoot, Button10Power, ButtonLog, ButtonExp, ButtonMod,
                ButtonChanePos, ButtonDeleteAll, ButtonDelete, ButtonBackspace, ButtonDevide,
                ButtonPi, Button7, Button8, Button9, ButtonMultiple,
                ButtonFactorial, Button4, Button5, Button6, ButtonMinus,
                ButtonAbsolute, Button1, Button2, Button3, ButtonPlus,
                ButtonRightHook, ButtonLeftHook, Button0, ButtonPoint, ButtonEqual
            });
            foreach (var i in TBLayout.Controls)
                ((ButtonCustom)(i)).AddColor1();
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

            ButtonPlus.Click += new EventHandler(InsertOperation);
            ButtonMinus.Click += new EventHandler(InsertOperation);
            ButtonDevide.Click += new EventHandler(InsertOperation);
            ButtonMultiple.Click += new EventHandler(InsertOperation);
            ButtonMod.Click += new EventHandler(InsertOperation);

            ButtonPoint.Click += new EventHandler(InsertPoint);
            ButtonBackspace.Click += new EventHandler(Backspace);
            ButtonDelete.Click += new EventHandler(Delete);
            ButtonDeleteAll.Click += new EventHandler(DeleteAll);
            
            ButtonEqual.Click += new EventHandler(GetAnswer);
            ButtonChanePos.Click += new EventHandler(ChangePosButtons);

            ButtonPower.Click += new EventHandler(InsertOperation);

        }

        private void InsertDegree(){
            if (string.IsNullOrEmpty(TextLine.Text) && TextLine.Text != "0")
                TextArea.Text = "(" + TextArea.Text + ")^";
        }

        private void ChangePosButtons(object sender, EventArgs e){
            TBLayout.Controls.Clear();
            if (position == true){
                position = false;
                TBLayout.Controls.AddRange(new Control[]{
                    ButtonCube, ButtonRootY, ButtonSinus1, ButtonCosinus1, ButtonTag1,
                    Button1DevideX, ButtonExponent, ButtonLn, ButtonDMS, ButtonDeg,
                    ButtonChanePos, ButtonDeleteAll, ButtonDelete, ButtonBackspace, ButtonDevide,
                    ButtonPi, Button7, Button8, Button9, ButtonMultiple,
                    ButtonFactorial, Button4, Button5, Button6, ButtonMinus,
                    ButtonAbsolute, Button1, Button2, Button3, ButtonPlus,
                    ButtonRightHook, ButtonLeftHook, Button0, ButtonPoint, ButtonEqual
                });
                ButtonChanePos.BackColor = RedGreenBlue.Color3;
            } else {
                position = true;
                TBLayout.Controls.AddRange(new Control[]{
                    ButtonSquare, ButtonPower, ButtonSinus, ButtonCosinus, ButtonTan,
                    ButtonRoot, Button10Power, ButtonLog, ButtonExp, ButtonMod,
                    ButtonChanePos, ButtonDeleteAll, ButtonDelete, ButtonBackspace, ButtonDevide,
                    ButtonPi, Button7, Button8, Button9, ButtonMultiple,
                    ButtonFactorial, Button4, Button5, Button6, ButtonMinus,
                    ButtonAbsolute, Button1, Button2, Button3, ButtonPlus,
                    ButtonRightHook, ButtonLeftHook, Button0, ButtonPoint, ButtonEqual
                });
                ButtonChanePos.BackColor = RedGreenBlue.Color1;
            }
            foreach (var i in TBLayout.Controls)
                if (i != ButtonChanePos)
                    ((ButtonCustom)(i)).AddColor1();
        }

        private void InsertText(object sender, EventArgs e){
            string line = TextLine.Text;
            string area = TextArea.Text;
            if (line == "0" && area.IndexOfAny(new char[] { '+', '-', '/', '*', '^', '%' }) < 0){
                TextArea.Text = ((Button)sender).Text;
                TextLine.Text = ((Button)sender).Text;
            }
            else {
                TextLine.Text += ((Button)sender).Text;
                TextArea.Text += ((Button)sender).Text;
            }
        }

        private void GetAnswer(object sender, EventArgs e){
            string answer = "", error = "";
            foreach (var i in TextArea.Text)
                switch (i)
                {
                    case '^': Request += "**"; break;
                    case ',': Request += ','; break;
                    case '0':
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                        Request += i; break;
                }
            Evaluate.Eval(new string[] { "print " + Request }, out answer, out error);
            if (answer != "" && error == "")
                TextArea.Text = answer.Replace("\n", "");
            else if (answer == "" && error != "")
                TextArea.Text = error;
        }

        private void Backspace(object sender, EventArgs e){
            if (TextArea.Text.ToCharArray().Length <= 1)
            {
                TextLine.Text = "0";
                TextArea.Text = "0";
            }
            else {
                TextLine.Text = TextLine.Text.Substring(0, TextLine.Text.Length - 1);
                TextArea.Text = TextArea.Text.Substring(0, TextArea.Text.Length - 1);
            }
        }

        private void InsertOperation(object sender, EventArgs e){
            string Line = TextLine.Text;
            string Area = TextArea.Text;
            if (Line != ""){
                TextLine.Text = "";
                TextArea.Text += ((Button)sender).Text;
            }
            else if (Line == "" && Area.IndexOfAny(new char[] { '+', '-', '/', '*', '^', '%'}) < 0){
                TextArea.Text += ((Button)sender).Text;
            }
        }

        private void InsertPoint(object sender, EventArgs e){
            string Line = TextLine.Text;
            string area = TextArea.Text;
            if (Line == ""){
                TextLine.Text += "0.";
                TextArea.Text += "0.";
            }
            else if (Line == "" && area.IndexOfAny(new char[] { '+', '-', '/', '*', '^', '%'}) < 0){
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

        private void DeleteAll(object sender, EventArgs e){
            TextLine.Text = "";
            TextArea.Clear();
        }
        private void Delete(object sender, EventArgs e){
            TextArea.Text = TextArea.Text.Substring(0, TextArea.Text.Length - TextLine.Text.Length);
            TextLine.Text = "";
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
            }
        }
    }
}
