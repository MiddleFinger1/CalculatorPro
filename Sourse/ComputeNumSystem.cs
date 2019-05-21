using System;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

namespace CalculaterPro {
    class ComputeNumSystem : PanelCustom{
        private char symbol = 'n';
        public TBLayoutCustom TBLayout = new TBLayoutCustom(
            new Point(0, 111), new Size(480, 54), new Padding(0), "TBLayout", 1, 4);
        public NumericUpCustom
            AnswerNumeric = new NumericUpCustom(
                new Point(7, 299), new Size(233, 22), new Padding(7), new decimal(new int[] { 36, 0, 0, 0 }),
                new decimal(new int[] { 2, 0, 0, 0 }), new decimal(new int[] { 2, 0, 0, 0 }), "AnswerNumeric"){
                BackColor = RedGreenBlue.Color1
            },
            SecondNumeric = new NumericUpCustom(
                new Point(7, 204), new Size(233, 22), new Padding(0), new decimal(new int[] { 36, 0, 0, 0 }),
                new decimal(new int[] { 2, 0, 0, 0 }), new decimal(new int[] { 2, 0, 0, 0 }), "SecondNumeric"){
                BackColor = RedGreenBlue.Color1
            },
            FirstNumeric = new NumericUpCustom(
                new Point(7, 39), new Size(233, 22), new Padding(0), new decimal(new int[] { 36, 0, 0, 0 }), 
                new decimal(new int[] { 2, 0, 0, 0 }), new decimal(new int[] { 2, 0, 0, 0 }), "FirstNumeric"){
                BackColor = RedGreenBlue.Color1
            };
        public TextBoxCustom
            AnswerTextBox = new TextBoxCustom(
                new Point(7, 381), new Size(473, 135), new Padding(7, 0, 7, 7), "AnswerText", "", true, true){
                BackColor = RedGreenBlue.Color1
            };
        public TextBoxCustom
            FirstTextBox = new TextBoxCustom(new Point(7, 68), new Size(473, 19), new Padding(7), "FirstTextBox", ""){   
                BackColor = RedGreenBlue.Color1
            },
            SecondTextBox = new TextBoxCustom(new Point(7, 233), new Size(473, 19), new Padding(7), "SecondTextBox", ""){
                BackColor = RedGreenBlue.Color1
            };
        public LabelCustom
            SecondLabel = new LabelCustom(
                new Point(247, 203), new Size(233, 23), new Padding(0), ContentAlignment.MiddleCenter, "SecondLabel", "- Второе число") {
                    BackColor = RedGreenBlue.Color1
            },
            FirstLabel = new LabelCustom(
                new Point(247, 39), new Size(233, 23), new Padding(0), ContentAlignment.MiddleCenter, "FirstLabel", "- Первое число"){
                    BackColor = RedGreenBlue.Color1
            },
            LabelAnswer = new LabelCustom(
                new Point(247, 299), new Size(233, 23), new Padding(0), ContentAlignment.MiddleCenter, "LabelAnswer", "- Число-ответ"){
                    BackColor = RedGreenBlue.Color1
                };
        public ButtonCustom 
            ButtonPlus = new ButtonCustom(
                new Point(7, 7), new Size(113, 47), new Padding(7, 7, 0, 0), "ButtonPlus", "+"),
            ButtonMinus = new ButtonCustom(
                new Point(127, 7), new Size(113, 47), new Padding(7, 7, 0, 0), "ButtonMinus", "-"),
            ButtonDevide = new ButtonCustom(
                new Point(247, 7), new Size(113, 47), new Padding(7, 7, 0, 0), "ButtonDevide", "/"),
            ButtonMultiple = new ButtonCustom(
                new Point(367, 7), new Size(113, 47), new Padding(7, 7, 0, 0), "ButtonMultiple", "*"),
            ButtonAnswer = new ButtonCustom(
                new Point(7, 328), new Size(473, 47), new Padding(0), "ButtonAnswer", "Enter");

        public ComputeNumSystem(){
            ((ISupportInitialize)(FirstNumeric)).BeginInit();
            TBLayout.SuspendLayout();
            ((ISupportInitialize)(SecondNumeric)).BeginInit();
            ((ISupportInitialize)(AnswerNumeric)).BeginInit();
            SuspendLayout();
            TBLayout.SuspendLayout();

            Controls.Add(ButtonAnswer);
            Controls.Add(FirstNumeric);
            Controls.Add(FirstLabel);
            Controls.Add(FirstTextBox);
            Controls.Add(TBLayout);
            Controls.Add(SecondNumeric);
            Controls.Add(SecondLabel);
            Controls.Add(SecondTextBox);
            Controls.Add(LabelAnswer);
            Controls.Add(AnswerNumeric);
            Controls.Add(AnswerTextBox);
            Name = "ComputeNumSystem";

            ButtonAnswer.AddColor1(); ButtonAnswer.Click += new EventHandler(EnterAnswer);
            ButtonPlus.AddColor1(); ButtonPlus.Click += new EventHandler(InsertSymbol);
            ButtonMinus.AddColor1(); ButtonMinus.Click += new EventHandler(InsertSymbol);
            ButtonDevide.AddColor1(); ButtonDevide.Click += new EventHandler(InsertSymbol);
            ButtonMultiple.AddColor1(); ButtonMultiple.Click += new EventHandler(InsertSymbol);

            TBLayout.Controls.AddRange(new Control[] { ButtonPlus, ButtonMinus, ButtonDevide, ButtonMultiple});
            ((ISupportInitialize)(FirstNumeric)).EndInit();
            TBLayout.ResumeLayout(false);
            ((ISupportInitialize)(SecondNumeric)).EndInit();
            ((ISupportInitialize)(AnswerNumeric)).EndInit();
        }
        private void InsertSymbol(object sender, EventArgs e){
            foreach (Button i in TBLayout.Controls) i.BackColor = RedGreenBlue.Color1;
            if (symbol != Convert.ToChar(((Button)sender).Text) || symbol == 'n'){
                symbol = Convert.ToChar(((Button)sender).Text);
                ((Button)sender).BackColor = RedGreenBlue.Color3;
            }
            else symbol = 'n';
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
             [Keys.W] = 'W', [Keys.X] = 'X', [Keys.Y] = 'Y', [Keys.Z] = 'Z'
            };
            switch (e.KeyCode){
                case Keys.Oemplus: InsertSymbol(ButtonPlus, null); break;
                case Keys.OemMinus: InsertSymbol(ButtonMinus, null); break;
                case Keys.Multiply: InsertSymbol(ButtonMultiple, null); break;
                case Keys.Divide: InsertSymbol(ButtonDevide, null); break;
                case Keys.Enter: EnterAnswer(ButtonAnswer, null); break;
                case Keys.PageUp: if (AnswerNumeric.Value != 36) AnswerNumeric.Value++; break;
                case Keys.PageDown: if (AnswerNumeric.Value != 2) AnswerNumeric.Value--; break;
            }
            if (e.Alt){
                foreach (var i in keys.Keys)
                    if (e.KeyCode == i) symbol = keys[i].ToString();
                SecondTextBox.Text += symbol;
                if (e.KeyCode == Keys.Up && SecondNumeric.Value != 36)
                    SecondNumeric.Value++;
                else if (e.KeyCode == Keys.Down && SecondNumeric.Value != 2)
                    SecondNumeric.Value--;
                else if (e.KeyCode == Keys.Back && SecondTextBox.Text != "")
                    SecondTextBox.Text = SecondTextBox.Text.Substring(0, SecondTextBox.Text.Length - 1);
                else if (e.KeyCode == Keys.Delete)
                    SecondTextBox.Clear();
            }
            else{
                foreach (var i in keys.Keys)
                    if (e.KeyCode == i) symbol = keys[i].ToString();
                FirstTextBox.Text += symbol;
                if (e.KeyCode == Keys.Up && FirstNumeric.Value != 36)
                    FirstNumeric.Value++;
                else if (e.KeyCode == Keys.Down && FirstNumeric.Value != 2)
                    FirstNumeric.Value--;
                else if (e.KeyCode == Keys.Back && FirstTextBox.Text != "")
                    FirstTextBox.Text = FirstTextBox.Text.Substring(0, FirstTextBox.Text.Length - 1);
                else if (e.KeyCode == Keys.Delete)
                    FirstTextBox.Clear();
            }
        }

        private void EnterAnswer(object sender, EventArgs e){
            AnswerTextBox.Clear(); string answer = "";
            if (FirstTextBox.Text != "" && SecondTextBox.Text != ""){
                bool boolean1 = NumberSystem.initilize_string(FirstTextBox.Text, Convert.ToInt32(FirstNumeric.Value));
                bool boolean2 = NumberSystem.initilize_string(SecondTextBox.Text, Convert.ToInt32(SecondNumeric.Value));
                if (boolean1 == true && boolean2 == true){
                    if (symbol != 'n'){
                        try {
                            string var1 = NumberSystem.numsysPoing2(FirstTextBox.Text, Convert.ToInt32(FirstNumeric.Value));
                            string var2 = NumberSystem.numsysPoing2(SecondTextBox.Text, Convert.ToInt32(SecondNumeric.Value));
                            switch (symbol){
                                case '+':
                                    answer = (Convert.ToInt32(var1) + Convert.ToInt32(var2)).ToString(); break;
                                case '-':
                                    answer = (Convert.ToInt32(var1) - Convert.ToInt32(var2)).ToString(); break;
                                case '/':
                                    answer = (Convert.ToInt32(var1) / Convert.ToInt32(var2)).ToString(); break;
                                case '*':
                                    answer = (Convert.ToInt32(var1) * Convert.ToInt32(var2)).ToString(); break;
                            }
                            answer = NumberSystem.numsysPoint1(answer, Convert.ToInt32(AnswerNumeric.Value));
                            AnswerTextBox.Text += $"{FirstTextBox.Text}({FirstNumeric.Text}) {symbol} {SecondTextBox.Text}({SecondNumeric.Value}) = {answer}({AnswerNumeric.Value})";
                            if (SettingsPage.CheckEventLogger)
                                PanelLogBook.InsertVariable("Вычисление СС", $"{FirstTextBox.Text}({FirstNumeric.Text}) {symbol} {SecondTextBox.Text}({SecondNumeric.Value})", $"{answer} ({AnswerNumeric.Value})");
                        }
                        catch (OverflowException ex){
                            MessageBox.Show("Ошибка", ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        catch (Exception ex){
                            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else AnswerTextBox.Text += "Какую операцию должна выполнить программа!";
                }
                else if (boolean1 == false || boolean2 == false) AnswerTextBox.Text += "Неправильный запрос!";
            }
            else AnswerTextBox.Text += "Заполните все поля!";
        }
    }
}
