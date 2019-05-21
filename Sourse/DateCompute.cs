using System;
using System.Windows.Forms;
using System.Drawing;

namespace CalculaterPro {
    class DateCompute : PanelCustom{
        private TextBoxCustom AnswerTextBox = new TextBoxCustom(
            new Point(7, 384), new Size(473, 19), new Padding(7), "AnswerTextBox", "", true, false);
        private LabelCustom 
            SecondLabel = new LabelCustom(
                new Point(7, 233), new Size(30, 22), new Padding(2), ContentAlignment.MiddleCenter, "SecondLabel", "По"),
            FirstLabel = new LabelCustom(
                new Point(7, 90), new Size(82, 22), new Padding(2), ContentAlignment.MiddleCenter, "FirstLabel", "Начиная с"),
            AnswerLabel = new LabelCustom(
                new Point(7, 353), new Size(71, 22), new Padding(2), ContentAlignment.MiddleCenter, "AnswerLabel", "Разница");
        private DateTimeCustom
            SecondDateTime = new DateTimeCustom(
                new Point(7, 264), new Size(473, 26), new Padding(7), "SecondDateTime"),
            FirstDateTime = new DateTimeCustom(
                new Point(7, 122), new Size(473, 26), new Padding(7), "FirstDateTime");
        
        public DateCompute(){
            Controls.Add(AnswerLabel);
            Controls.Add(AnswerTextBox);
            Controls.Add(SecondLabel);
            Controls.Add(FirstLabel);
            Controls.Add(SecondDateTime);
            Controls.Add(FirstDateTime);
            Name = "DateCompute";
            AnswerTextBox.AddColor1();
            SecondDateTime.TextChanged += new EventHandler(SetDateTime);
            FirstDateTime.TextChanged += new EventHandler(SetDateTime);
        }

        private void SetDateTime(object sender, EventArgs e){
            AnswerTextBox.Clear();
            int days = Math.Abs(FirstDateTime.Value.Day - SecondDateTime.Value.Day);
            int months = Math.Abs(FirstDateTime.Value.Month - SecondDateTime.Value.Month);
            int years = Math.Abs(FirstDateTime.Value.Year - SecondDateTime.Value.Year);
            AnswerTextBox.Text = $"в {SetDegree(days, "день", "дня", "дней")}," +
                $" {SetDegree(months, "месяц", "месяца", "месяцев")}, {SetDegree(years, "год", "года", "лет")}";
        }

        private string SetDegree(int number, string unit, string Runit, string enume){
            int inumber = number;
            while (number >= 100)
                inumber /= 10;
            string answer = "";
            if (inumber == 1 || (inumber % 10 == 1 && inumber != 11)) // ед.ч. имен. падеж
                answer = $"{number} {unit}";
            else if ((inumber >= 2 && inumber <= 4) || (inumber % 10 >= 2 && inumber % 10 <= 4 && inumber > 21))
                answer = $"{number} {Runit}"; // ед.ч род. падеж
            else if ((inumber >= 5 && inumber <= 19) || inumber == 0 || inumber % 10 == 0 || (inumber % 10 >= 5 && inumber % 10 <= 9))
                answer = $"{number} {enume}"; // мн.ч. род. падеж
            return answer;
        }
        
        public void ControlKeys(KeyEventArgs e){
            if (e.Alt)
                switch (e.KeyCode){
                    case Keys.Y: SecondDateTime.Value = SecondDateTime.Value.Date.AddYears(1); break;
                    case Keys.H: SecondDateTime.Value = SecondDateTime.Value.Date.AddYears(-1); break;
                    case Keys.T: SecondDateTime.Value = SecondDateTime.Value.Date.AddMonths(1); break;
                    case Keys.G: SecondDateTime.Value = SecondDateTime.Value.Date.AddMonths(-1); break;
                    case Keys.R: SecondDateTime.Value = SecondDateTime.Value.Date.AddDays(1); break;
                    case Keys.F: SecondDateTime.Value = SecondDateTime.Value.Date.AddDays(-1); break;
                    case Keys.Space: SecondDateTime.Value = DateTime.Now; break;
                }
            else
                switch (e.KeyCode){
                    case Keys.Y: FirstDateTime.Value = FirstDateTime.Value.Date.AddYears(1); break;
                    case Keys.H: FirstDateTime.Value = FirstDateTime.Value.Date.AddYears(-1); break;
                    case Keys.T: FirstDateTime.Value = FirstDateTime.Value.Date.AddMonths(1); break;
                    case Keys.G: FirstDateTime.Value = FirstDateTime.Value.Date.AddMonths(-1); break;
                    case Keys.R: FirstDateTime.Value = FirstDateTime.Value.Date.AddDays(1); break;
                    case Keys.F: FirstDateTime.Value = FirstDateTime.Value.Date.AddDays(-1); break;
                    case Keys.Space: FirstDateTime.Value = DateTime.Now; break;
                }
        }
    }
}
