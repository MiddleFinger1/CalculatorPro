using System;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;

namespace CalculaterPro
{
    class NumberSystem : PanelCustom {
        public static TextBoxCustom TextLine = new TextBoxCustom(
            new Point(7, 231), new Size(473, 19), new Padding(7), "TextLine", "", true, false);
        public TextBoxCustom TextArea = new TextBoxCustom(
            new Point(7, 7), new Size(473, 217), new Padding(7), "TextArea", "", true, true);

        public NumericUpCustom Numeric2 = new NumericUpCustom(
            new Point(241, 258), new Size(239, 22), new Padding(0), new decimal(new int[] { 36, 0, 0, 0 }), 
            new decimal(new int[] { 2, 0, 0, 0 }), new decimal(new int[] { 2, 0, 0, 0 }), "Numeric2");
        public NumericUpCustom Numeric1 = new NumericUpCustom(
            new Point(7, 258), new Size(227, 22), new Padding(0), new decimal(new int[] { 36, 0, 0, 0 }),
            new decimal(new int[] { 2, 0, 0, 0 }), new decimal(new int[] { 2, 0, 0, 0 }), "Numeric2");
        public TBLayoutCustom TBLayout = new TBLayoutCustom(
            new Point(7, 280), new Size(473, 236), new Padding(0, 0, 0, 7), "TBLayout", 4, 5);

        public ButtonCustom Button7 = new ButtonCustom(
            new Point(0, 7), new Size(71, 52), new Padding(0, 7, 7, 0), "Button7", "7");
        public ButtonCustom Button8 = new ButtonCustom(
            new Point(78, 7), new Size(71, 52), new Padding(0, 7, 7, 0), "Button8", "8");
        public ButtonCustom Button9 = new ButtonCustom(
            new Point(156, 7), new Size(71, 52), new Padding(0, 7, 7, 0), "Button9", "9");
        public ButtonCustom ButtonF = new ButtonCustom(
            new Point(234, 7), new Size(71, 52), new Padding(0, 7, 7, 0), "ButtonF", "F");
        public ButtonCustom ButtonEnter = new ButtonCustom(
            new Point(312, 7), new Size(161, 51), new Padding(0, 7, 0, 0), "ButtonEnter", "Enter");
        public ButtonCustom Button4 = new ButtonCustom(
            new Point(0, 66), new Size(71, 51), new Padding(0, 7, 7, 0), "Button4", "4");
        public ButtonCustom Button5 = new ButtonCustom(
            new Point(78, 66), new Size(71, 51), new Padding(0, 7, 7, 0), "Button5", "5");
        public ButtonCustom Button6 = new ButtonCustom(
            new Point(156, 66), new Size(71, 51), new Padding(0, 7, 7, 0), "Button6", "6");
        public ButtonCustom ButtonE = new ButtonCustom(
            new Point(234, 66), new Size(71, 51), new Padding(0, 7, 7, 0), "ButtonE", "E");
        public ButtonCustom ButtonBackspace = new ButtonCustom(
            new Point(312, 66), new Size(161, 51), new Padding(0, 7, 0, 0), "ButtonBackspace", "Backspace");
        public ButtonCustom Button1 = new ButtonCustom(
            new Point(0, 125), new Size(71, 51), new Padding(0, 7, 7, 0), "Button1", "1");
        public ButtonCustom Button2 = new ButtonCustom(
            new Point(78, 125), new Size(71, 51), new Padding(0, 7, 7, 0), "Button2", "2");
        public ButtonCustom Button3 = new ButtonCustom(
            new Point(156, 125), new Size(71, 51), new Padding(0, 7, 7, 0), "Button3", "3");
        public ButtonCustom ButtonD = new ButtonCustom(
            new Point(234, 125), new Size(71, 51), new Padding(0, 7, 7, 0), "ButtonD", "D");
        public ButtonCustom ButtonDelete = new ButtonCustom(
            new Point(312, 125), new Size(161, 51), new Padding(0, 7, 0, 0), "ButtonDelete", "Delete");
        public ButtonCustom Button0 = new ButtonCustom(
            new Point(0, 184), new Size(71, 52), new Padding(0, 7, 7, 0), "Button0", "0");
        public ButtonCustom ButtonA = new ButtonCustom(
            new Point(78, 184), new Size(71, 52), new Padding(0, 7, 7, 0), "ButtonA", "A");
        public ButtonCustom ButtonB = new ButtonCustom(
            new Point(156, 184), new Size(71, 52), new Padding(0, 7, 7, 0), "ButtonB", "B");
        public ButtonCustom ButtonC = new ButtonCustom(
            new Point(234, 184), new Size(71, 52), new Padding(0, 7, 7, 0), "ButtonC", "C");
        public ButtonCustom ButtonPoint = new ButtonCustom(
            new Point(312, 184), new Size(161, 52), new Padding(0, 7, 0, 0), "ButtonPoint", ",");

        public NumberSystem(){
            TextLine.AddColor1(); TextArea.AddColor1();
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
            ButtonA.Click += new EventHandler(InsertText);
            ButtonB.Click += new EventHandler(InsertText);
            ButtonC.Click += new EventHandler(InsertText);
            ButtonD.Click += new EventHandler(InsertText);
            ButtonE.Click += new EventHandler(InsertText); 
            ButtonF.Click += new EventHandler(InsertText);
            ButtonEnter.Click += new EventHandler(Enter);
            Numeric1.AddColor1(); Numeric2.AddColor1();
            ButtonBackspace.Click += new EventHandler(Backspace);
            ButtonDelete.Click += new EventHandler(Delete);
            ButtonPoint.Click += new EventHandler(InsertPoint);

            ResumeLayout(false);
            PerformLayout();
            TBLayout.ResumeLayout(false);
            ((ISupportInitialize)(Numeric2)).EndInit();
            ((ISupportInitialize)(Numeric1)).EndInit();
            SuspendLayout();
            TBLayout.SuspendLayout();
            
            // NumberSystem
            Controls.Add(TBLayout);
            Controls.Add(Numeric2);
            Controls.Add(Numeric1);
            Controls.Add(TextLine);
            Controls.Add(TextArea);
            Name = "NumberSystem";
            
            TBLayout.Controls.AddRange(new Control[] {
                Button7, Button8, Button9, ButtonF, ButtonEnter,
                Button4, Button5, Button6, ButtonE, ButtonBackspace,
                Button1, Button2, Button3, ButtonD, ButtonDelete,
                Button0, ButtonA, ButtonB, ButtonC, ButtonPoint
            });

            foreach (ButtonCustom i in TBLayout.Controls)
                i.AddColor1();
        }

        private void InsertText(object sender, EventArgs e){
            TextLine.Text += ((Button)sender).Text;
        }
        private void Backspace(object sender, EventArgs e){
            try{
                TextLine.Text = TextLine.Text.Substring(0, TextLine.Text.Length - 1);
            }
            catch (ArgumentOutOfRangeException){
                TextLine.Text = "";
            }
        }
        private void Delete(object sender, EventArgs e){
            TextLine.Text = "";
        }
        private void InsertPoint(object sender, EventArgs e){
            if (TextLine.Text.IndexOf(',') < 0 && TextLine.Text != "")
                TextLine.Text += ((Button)sender).Text;
            else TextLine.Text += "";
        }
        private new void Enter(object sender, EventArgs e){
            TextArea.Clear();
            string answer = "";
            if (TextLine.Text != ""){
                if (initilize_string(TextLine.Text, Convert.ToInt32(Numeric1.Value)) == true){
                    try{
                        if (Numeric1.Value == 10 && Numeric2.Value != 10)
                            answer = numsysPoint1(TextLine.Text, Convert.ToInt32(Numeric2.Value));
                        else if (Numeric2.Value == 10 && Numeric1.Value != 10)
                            answer = numsysPoing2(TextLine.Text, Convert.ToInt32(Numeric1.Value));
                        else if (Numeric1.Value != Numeric2.Value){
                            answer = numsysPoing2(TextLine.Text, Convert.ToInt32(Numeric1.Value));
                            answer = numsysPoint1(answer, Convert.ToInt32(Numeric2.Value));
                        }
                        else { TextArea.Text = "Один и тот же тип счисления"; return; }
                        TextArea.Text = $"Ответ: {TextLine.Text}({Numeric1.Value}) = {answer}({Numeric2.Value})";
                        if (SettingsPage.CheckEventLogger)
                            PanelLogBook.InsertVariable("Система счислений", $"{TextLine.Text}({Numeric1.Value})", $"{answer}({Numeric2.Value})");
                    }
                    catch (OverflowException){
                        TextArea.Text = "Слишком большое число!";
                    }
                    catch (Exception ex){
                        MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else TextArea.Text = "Неправильный запрос!";
            }
            else TextArea.Text = "Заполните строку!";
        }

        public static Dictionary<string, string> dictionary = new Dictionary<string, string> {
            {",", "-1"}, {"0", "0"}, {"1", "1"}, {"2", "2"}, {"3", "3"}, {"4", "4"},
            {"5", "5"}, {"6", "6"}, {"7", "7"}, {"8", "8"}, {"9", "9"}, {"A", "10"},
            {"B", "11"}, {"C", "12"}, {"D", "13"}, {"E", "14"}, {"F", "15"}, {"G", "16"},
            {"H", "17"}, {"I", "18"}, {"J", "19"}, {"K", "20"}, {"L", "21"}, {"M", "22"},
            {"N", "23"}, {"O", "24"}, {"P", "25"}, {"Q", "26"}, {"R", "27"}, {"S", "28"},
            {"T", "29"}, {"U", "30"}, {"V", "31"}, {"W", "32"}, {"X", "33"}, {"Y", "34"}, {"Z", "35"}};

        public static bool initilize_string(string number, int variable){
            int index = 0;
            foreach (var i in number)
                foreach (var h in dictionary.Keys)
                    if (Convert.ToString(i) == h)
                        if (Convert.ToInt32(dictionary[h]) < variable)
                            index++;
            return index == number.Length;}

        public static string numsysPoint1(string number, int variable){
            string answer = "", answer1 = "", answer2 = "";
            ArrayList list1 = new ArrayList();
            if (number.IndexOf(',') >= 0){
                string[] numberList = number.Split(',');
                long number1 = Convert.ToInt64(numberList[0]);
                double number2 = Convert.ToDouble($"0,{numberList[1]}");
                if (number1 >= variable){
                    while (number1 >= variable){
                        list1.Add(Convert.ToString(number1 % variable));
                        number1 = Convert.ToInt32(number1 / variable);}
                    list1.Add(Convert.ToString(number1)); list1.Reverse();
                    foreach (var i in list1)
                        foreach (var h in dictionary.Keys)
                            if (Convert.ToString(i) == dictionary[h])
                                answer1 += h;}
                else foreach (var h in dictionary.Keys)
                        if (number1 == Convert.ToInt32(dictionary[h]))
                            answer1 = h;
                while (number2 < 1){
                    number2 *= variable;
                    int num = (int)(number2);
                    foreach (var h in dictionary.Keys)
                        if (num == Convert.ToInt32(dictionary[h]))
                            answer2 += h;
                    if ((int)(number2) >= 1)
                        number2 -= num;
                    if (answer2.Length >= 7)
                        break;}
                answer = answer1 + "," + answer2;}
            else try {
                    long number1 = Convert.ToInt64(number);
                    if (number1 >= variable){
                        while (number1 >= variable){
                            list1.Add(Convert.ToString(number1 % variable));
                            number1 = Convert.ToInt32(number1 / variable);}
                        list1.Add(Convert.ToString(number1)); list1.Reverse();
                        foreach (var i in list1)
                            foreach (var h in dictionary.Keys)
                                if (Convert.ToString(i) == dictionary[h])
                                    answer += h;}
                    else foreach (var h in dictionary.Keys)
                            if (number1 == Convert.ToInt32(dictionary[h]))
                                answer = h;}
                catch (OverflowException){
                    answer = "0";}
            return Convert.ToString(answer);}

        public static string numsysPoing2(string number, int variable){
            double answer = 0, answer1 = 0, answer2 = 0;
            if (number.IndexOf(',') >= 0){
                string[] num1 = number.Split(',');
                string number1 = num1[0], number2 = num1[1]; int index = number1.Length;
                foreach (var i in number1){
                    index--;
                    foreach (var h in dictionary.Keys)
                        if (Convert.ToString(i) == h)
                            answer1 += Convert.ToInt32(dictionary[h]) * Math.Pow(variable, index);}
                foreach (var i in number2){
                    index--;
                    foreach (var h in dictionary.Keys)
                        if (Convert.ToString(i) == h)
                            answer2 += Convert.ToInt32(dictionary[h]) * Math.Pow(variable, index);}
                answer = answer1 + answer2;}
            else {
                int index = number.Length;
                foreach (var i in number){
                    index--;
                    foreach (var h in dictionary.Keys)
                        if (Convert.ToString(i) == h)
                            answer += Convert.ToInt32(dictionary[h]) * Math.Pow(variable, index);}}
            return Convert.ToString(answer);}

        public void SetControlsToolTip(){
            MainForm.ToolTip.SetToolTip(Button0, "Клавиша 0");
            MainForm.ToolTip.SetToolTip(Button1, "Клавиша 1");
            MainForm.ToolTip.SetToolTip(Button2, "Клавиша 2");
            MainForm.ToolTip.SetToolTip(Button3, "Клавиша 3");
            MainForm.ToolTip.SetToolTip(Button4, "Клавиша 4");
            MainForm.ToolTip.SetToolTip(Button5, "Клавиша 5");
            MainForm.ToolTip.SetToolTip(Button6, "Клавиша 6");
            MainForm.ToolTip.SetToolTip(Button7, "Клавиша 7");
            MainForm.ToolTip.SetToolTip(Button8, "Клавиша 8");
            MainForm.ToolTip.SetToolTip(Button9, "Клавиша 9");
            MainForm.ToolTip.SetToolTip(ButtonA, "Клавиша A");
            MainForm.ToolTip.SetToolTip(ButtonB, "Клавиша B");
            MainForm.ToolTip.SetToolTip(ButtonC, "Клавиша C");
            MainForm.ToolTip.SetToolTip(ButtonD, "Клавиша D");
            MainForm.ToolTip.SetToolTip(ButtonE, "Клавиша E");
            MainForm.ToolTip.SetToolTip(ButtonF, "Клавиша F");
            MainForm.ToolTip.SetToolTip(ButtonEnter, "Клавиша Enter");
            MainForm.ToolTip.SetToolTip(ButtonBackspace, "Клавиша Backspace");
            MainForm.ToolTip.SetToolTip(ButtonDelete, "Клавиша Delete");
            MainForm.ToolTip.SetToolTip(ButtonPoint, "Клавиша \',\'");
            MainForm.ToolTip.SetToolTip(Numeric1, "Для прокрутки стрелка вверх/вниз");
            MainForm.ToolTip.SetToolTip(Numeric2, "Для прокрутки стрекла влево/вправо");
            MainForm.ToolTip.SetToolTip(TextLine, "Используйте клавиатуру для ввода нужных символов");
        }

        public void ControlKeys(KeyEventArgs e){
            string symbol = "";
            Dictionary<Keys, char> keys = new Dictionary<Keys, char>{ 
             [Keys.D0] = '0', [Keys.D1] = '1', [Keys.D2] = '2', [Keys.D3] = '3', 
             [Keys.D4] = '4', [Keys.D5] = '5', [Keys.D6] = '6', [Keys.D7] = '7', 
             [Keys.D8] = '8', [Keys.D9] = '9', [Keys.A] = 'A', [Keys.B] = 'B', 
             [Keys.C] = 'C', [Keys.D] = 'D', [Keys.E] = 'E', [Keys.F] = 'F', 
             [Keys.G] = 'G', [Keys.H] = 'H', [Keys.I] = 'I', [Keys.J] = 'J', 
             [Keys.K] = 'K', [Keys.L] = 'L', [Keys.M] = 'M', [Keys.N] = 'N', 
             [Keys.O] = 'O', [Keys.P] = 'P', [Keys.Q] = 'Q', [Keys.R] = 'R', 
             [Keys.S] = 'S', [Keys.T] = 'T', [Keys.U] = 'U', [Keys.V] = 'V', 
             [Keys.W] = 'W', [Keys.X] = 'X', [Keys.Y] = 'Y', [Keys.Z] = 'Z', 
            };
            switch (e.KeyCode){
                case Keys.Enter: Enter(ButtonEnter, null); break;
                case Keys.Back: Backspace(ButtonBackspace, null); break;
                case Keys.Delete: Delete(ButtonDelete, null); break;
                case Keys.Oemcomma: InsertPoint(ButtonPoint, null); break;
                case Keys.Up: try { Numeric1.Value++; }
                    catch (ArgumentOutOfRangeException){
                        break; }
                    break;
                case Keys.Down:
                    try{ Numeric1.Value--; }
                    catch (ArgumentOutOfRangeException){
                        break; }
                    break;
                case Keys.Left:
                    try { Numeric2.Value--; }
                    catch (ArgumentOutOfRangeException){
                        break; }
                    break;
                case Keys.Right:
                    try { Numeric2.Value++; }
                    catch (ArgumentOutOfRangeException){
                        break; }
                    break;
            }
            foreach (var i in keys.Keys)
                if (e.KeyCode == i) symbol = keys[i].ToString();
            TextLine.Text += symbol;
        }
    }
}
