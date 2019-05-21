using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace CalculaterPro
{
    class ConverterDigits : PanelCustom {
        Dictionary<string, int> RomeArabDigits = new Dictionary<string, int>{
                { "MMM", 3000 }, { "MM", 2000 }, { "M", 1000 }, { "CM", 900 }, { "DCCC", 800 }, { "DCC", 700 },
                { "DC", 600 }, { "D", 500 }, { "CD", 400 }, { "CCC", 300 }, { "CC", 200 }, { "C", 100 },
                { "XC", 90 }, { "LXXX", 80 }, { "LXX", 70 }, { "LX", 60 }, { "L", 50}, { "XL", 40 },
                { "XXX", 30 } , { "XX", 20 }, { "X", 10 }, { "IX", 9 }, { "VIII", 8 }, { "VII", 7},
                { "VI", 6 }, { "V", 5 }, { "IV", 4 }, { "III", 3 }, { "II", 2}, { "I", 1 }
        };
        public TBLayoutCustom TBLayout = new TBLayoutCustom(
            new Point(0, 262), new Size(480, 254), new Padding(7), "TBLayout", 4, 5);

        public ButtonCustom
            Button7 = new ButtonCustom(
                new Point(7, 7), new Size(90, 56), new Padding(7, 7, 0, 0), "Button7", "7"),
            Button8 = new ButtonCustom(
                new Point(94, 7), new Size(90, 56), new Padding(7, 7, 0, 0), "Button8", "8"),
            Button9 = new ButtonCustom(
                new Point(181, 7), new Size(90, 56), new Padding(7, 7, 0, 0), "Button9", "9"),
            ButtonD = new ButtonCustom(
                new Point(268, 7), new Size(90, 56), new Padding(7, 7, 0, 0), "ButtonD", "D"),
            ButtonEnter = new ButtonCustom(
                new Point(355, 7), new Size(140, 56), new Padding(7, 7, 0, 0), "ButtonEnter", "Enter", 10F),
            Button4 = new ButtonCustom(
                new Point(7, 70), new Size(90, 56), new Padding(7, 7, 0, 0), "Button4", "4"),
            Button5 = new ButtonCustom(
                new Point(94, 70), new Size(90, 56), new Padding(7, 7, 0, 0), "Button5", "5"),
            Button6 = new ButtonCustom(
                new Point(181, 70), new Size(90, 56), new Padding(7, 7, 0, 0), "Button6", "6"),
            ButtonC = new ButtonCustom(
                new Point(268, 70), new Size(90, 56), new Padding(7, 7, 0, 0), "ButtonC", "C"),
            ButtonBackspace = new ButtonCustom(
                new Point(355, 70), new Size(140, 56), new Padding(7, 7, 0, 0), "ButtonBackspace", "Backspace", 10F),
            Button1 = new ButtonCustom(
                new Point(7, 133), new Size(90, 56), new Padding(7, 7, 0, 0), "Button1", "1"),
            Button2 = new ButtonCustom(
                new Point(94, 133), new Size(90, 56), new Padding(7, 7, 0, 0), "Button2", "2"),
            Button3 = new ButtonCustom(
                new Point(181, 133), new Size(90, 56), new Padding(7, 7, 0, 0), "Button3", "3"),
            ButtonL = new ButtonCustom(
                new Point(268, 133), new Size(90, 56), new Padding(7, 7, 0, 0), "ButtonL", "L"),
            ButtonDelete = new ButtonCustom(
                new Point(355, 133), new Size(140, 56), new Padding(7, 7, 0, 0), "ButtonDelete", "Delete", 10F),
            ButtonM = new ButtonCustom(
                new Point(355, 196), new Size(140, 56), new Padding(7, 7, 0, 0), "ButtonM", "M"),
            ButtonX = new ButtonCustom(
                new Point(268, 196), new Size(90, 56), new Padding(7, 7, 0, 0), "ButtonX", "X"),
            ButtonV = new ButtonCustom(
                new Point(181, 196), new Size(90, 56), new Padding(7, 7, 0, 0), "ButtonV", "V"),
            ButtonI = new ButtonCustom(
                new Point(94, 196), new Size(90, 56), new Padding(7, 7, 0, 0), "ButtonI", "I"),
            Button0 = new ButtonCustom(
                new Point(7, 196), new Size(90, 56), new Padding(7, 7, 0, 0), "Button0", "0");
        public static TextBoxCustom
            TextArea = new TextBoxCustom(
                new Point(7, 7), new Size(473, 229), new Padding(7), "TextArea", "", true, true),
            TextLine = new TextBoxCustom(
                new Point(7, 243), new Size(473, 19), new Padding(7, 0, 7, 0), "TextLine", "", true, false);

        public ConverterDigits()
        {
            TBLayout.SuspendLayout();
            Controls.Add(TBLayout);
            Controls.Add(TextArea);
            Controls.Add(TextLine);
            Name = "ConverterDigits";

            Button7.AddColor1(); Button7.Click += new EventHandler(InsertText);
            Button8.AddColor1(); Button8.Click += new EventHandler(InsertText);
            Button9.AddColor1(); Button9.Click += new EventHandler(InsertText);
            ButtonBackspace.AddColor1(); ButtonBackspace.Click += new EventHandler(Backspace);
            ButtonC.AddColor1(); ButtonC.Click += new EventHandler(InsertText);
            ButtonD.AddColor1(); ButtonD.Click += new EventHandler(InsertText);
            ButtonDelete.AddColor1(); ButtonDelete.Click += new EventHandler(Delete);
            ButtonEnter.AddColor1(); ButtonEnter.Click += new EventHandler(GetAnswer);
            ButtonI.AddColor1(); ButtonI.Click += new EventHandler(InsertText);
            ButtonL.AddColor1(); ButtonL.Click += new EventHandler(InsertText);
            ButtonM.AddColor1(); ButtonM.Click += new EventHandler(InsertText);
            ButtonV.AddColor1(); ButtonV.Click += new EventHandler(InsertText);
            ButtonX.AddColor1(); ButtonX.Click += new EventHandler(InsertText);
            Button0.AddColor1(); Button0.Click += new EventHandler(InsertText);
            Button1.AddColor1(); Button1.Click += new EventHandler(InsertText);
            Button2.AddColor1(); Button2.Click += new EventHandler(InsertText);
            Button3.AddColor1(); Button3.Click += new EventHandler(InsertText);
            Button4.AddColor1(); Button4.Click += new EventHandler(InsertText);
            Button5.AddColor1(); Button5.Click += new EventHandler(InsertText);
            Button6.AddColor1(); Button6.Click += new EventHandler(InsertText);
            TextArea.AddColor1();
            TextLine.AddColor1();

            TBLayout.Controls.AddRange(new Control[] {
                      Button7, Button8, Button9, ButtonD, ButtonEnter,
                      Button4, Button5, Button6, ButtonC, ButtonBackspace,
                      Button1, Button2, Button3, ButtonL, ButtonDelete,
                      Button0, ButtonI, ButtonV, ButtonX, ButtonM
            });
            ResumeLayout(false);
            PerformLayout();
            TBLayout.ResumeLayout(false);
        }

        private void InsertText(object sender, EventArgs e) {
            TextLine.Text += ((Button)sender).Text;
        }
        private void Delete(object sender, EventArgs e) {
            TextLine.Text = "";
        }
        private void Backspace(object sender, EventArgs e){
            try{
                TextLine.Text = TextLine.Text.Substring(0, TextLine.Text.Length - 1);
            }
            catch (ArgumentOutOfRangeException){
                TextLine.Text = "";
            }
        }

        private void GetAnswer(object sender, EventArgs e){
            int c = 0; string answer = "";
            foreach (var i in TextLine.Text)
                foreach (var h in new char[] { 'M', 'D', 'C', 'L', 'X', 'V', 'I' })
                    if (i == h) c += 1;
            if (c == TextLine.Text.Length)
                answer = GetFromRomeToArab(TextLine.Text);
            else if (c == 0)
                answer = GetFromArabToRome(TextLine.Text);
            else
                answer = "Неправильный запрос";
            TextArea.Text = answer;
            if (SettingsPage.CheckEventLogger)
                PanelLogBook.InsertVariable("Конвертер чисел", TextLine.Text, TextArea.Text);
        }

        private string GetFromRomeToArab(string number){
            int answer = 0;
            foreach (var i in RomeArabDigits.Keys)
                if (number.IndexOf(i) >= 0){
                    answer += RomeArabDigits[i];
                    number = number.Replace(i, "");
                }
            return answer.ToString();
        }

        private string GetFromArabToRome(string number){
            string answer = "";
            foreach (var i in RomeArabDigits.Keys)
                if (int.Parse(number) >= RomeArabDigits[i]){
                    answer += i;
                    number = (int.Parse(number) - RomeArabDigits[i]).ToString();
                }
            return answer;
        }

        public void ControlKeys(KeyEventArgs e){
            Dictionary<Keys, char> pairs = new Dictionary<Keys, char>{
                [Keys.D0] = '0', [Keys.D1] = '1', [Keys.D2] = '2', [Keys.D3] = '3', [Keys.D4] = '4',
                [Keys.D5] = '6', [Keys.D6] = '7', [Keys.D7] = '7', [Keys.D8] = '8', [Keys.D9] = '9',
                [Keys.I] = 'I', [Keys.V] = 'V', [Keys.X] = 'X', [Keys.L] = 'L', [Keys.C] = 'C',
                [Keys.D] = 'D', [Keys.M] = 'M'
            };
            switch (e.KeyCode){
                case Keys.Enter: GetAnswer(ButtonEnter, null); break;
                case Keys.Back: Backspace(ButtonBackspace, null); break;
                case Keys.Delete: Delete(ButtonDelete, null); break;
            }
            string symbol = "";
            foreach (var i in pairs.Keys)
                if (e.KeyCode == i) symbol = pairs[i].ToString();
            TextLine.Text += symbol;
        }

        public void SetControlsToolTip(){
            foreach (Button i in TBLayout.Controls)
                MainForm.ToolTip.SetToolTip(i, "Клавиша " + i.Text);
            MainForm.ToolTip.SetToolTip(ButtonEnter, "Клавиша Enter");
            MainForm.ToolTip.SetToolTip(ButtonBackspace, "Клавиша Backspace");
            MainForm.ToolTip.SetToolTip(ButtonDelete, "Клавиша Delete");
            MainForm.ToolTip.SetToolTip(TextArea, "Текстовая область для ответа");
            MainForm.ToolTip.SetToolTip(TextLine, "Текстовая область для запроса");
        }
    }
}
