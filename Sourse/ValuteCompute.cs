using System;
using System.Windows.Forms;
using System.Drawing;
using System.Xml;
using System.Collections.Generic;

namespace CalculaterPro
{
    class ValuteCompute : PanelCustom
    {
        byte indexF = 0, indexS = 0;
        private List<double> Values = new List<double> { };
        private List<string> Names = new List<string> { };
        private LabelCustom 
            AnswerLabel = new LabelCustom(
                new Point(5, 305), new Size(58, 22), new Padding(0), ContentAlignment.MiddleCenter, "AnswerLabel", "Ответ"),
            DigitLabel = new LabelCustom(
                new Point(5, 113), new Size(54, 22), new Padding(0), ContentAlignment.MiddleCenter, "DigitLabel", "Число"),
            RestartLabel = new LabelCustom(
                new Point(212, 408), new Size(250, 22), new Padding(0), ContentAlignment.MiddleLeft, "RestartLabel", "Не обновлено", 10F);
        private ComboBoxCustom
            AnswerComboBox = new ComboBoxCustom(
                new Point(7, 330), new Size(473, 30), new Padding(0, 7, 7, 7), ComboBoxStyle.DropDownList, FlatStyle.Flat, "AnswerComboBox"){
                BackColor = Color.FromArgb(RedGreenBlue.red, RedGreenBlue.green, RedGreenBlue.blue),
                FormattingEnabled = true,
                DropDownHeight = 150
            },
            DigitComboBox = new ComboBoxCustom(
                new Point(7, 164), new Size(473, 30), new Padding(7), ComboBoxStyle.DropDownList, FlatStyle.Flat, "DigitComboBox"){
                BackColor = Color.FromArgb(RedGreenBlue.red, RedGreenBlue.green, RedGreenBlue.blue),
                FormattingEnabled = true,
                DropDownHeight = 150
            };
        public static TextBoxCustom 
            AnswerTextBox = new TextBoxCustom(
                new Point(7, 368), new Size(473, 19), new Padding(0, 7, 7, 7), "AnswerTextBox", "0", true, false),
            DigitTextBox = new TextBoxCustom(
                new Point(7, 138), new Size(473, 19), new Padding(0, 7, 7, 0), "DigitTextBox", "0", true, false);
        private ButtonCustom ButtonRestart = new ButtonCustom(
            new Point(7, 401), new Size(195, 37), new Padding(7), "ButtonRestart", "Обновить");

        public ValuteCompute(){
            Controls.Add(RestartLabel);
            Controls.Add(AnswerLabel);
            Controls.Add(DigitLabel);
            Controls.Add(AnswerComboBox);
            Controls.Add(DigitComboBox);
            Controls.Add(ButtonRestart);
            Controls.Add(AnswerTextBox);
            Controls.Add(DigitTextBox);
            Name = "ValuteCompute";
            AnswerTextBox.AddColor1();
            DigitTextBox.AddColor1();
            ButtonRestart.AddColor1();
            DigitComboBox.TextChanged += new EventHandler(SetOption);
            AnswerComboBox.TextChanged += new EventHandler(SetOption);
            DigitTextBox.TextChanged += new EventHandler(GetAnswer);
            ButtonRestart.Click += new EventHandler(SetValuteCourse);
        }
        
        private void SetValuteCourse(object sender, EventArgs e){
            Names.Clear(); Values.Clear();
            DigitComboBox.Items.Clear();
            AnswerComboBox.Items.Clear();
            GetValueByParse();
            Names.Insert(21, "Российский рубль");
            Values.Insert(21, 1);
            foreach (var i in Names){
                DigitComboBox.Items.Add(i);
                AnswerComboBox.Items.Add(i);
            }
            DigitComboBox.Text = DigitComboBox.Items[0].ToString();
            AnswerComboBox.Text = AnswerComboBox.Items[1].ToString();
            RestartLabel.Text = "Обновлено " + DateTime.Now.ToString();
        }

        private void GetValueByParse(){
            XmlReader ReaderXml = new XmlTextReader("http://www.cbr.ru/scripts/XML_daily.asp");
            while (ReaderXml.Read())
                if (ReaderXml.NodeType == XmlNodeType.Element)
                    if (ReaderXml.Name == "Valute" && ReaderXml.HasAttributes)
                        while (ReaderXml.MoveToNextAttribute())
                            if (ReaderXml.Name == "ID"){
                                ReaderXml.MoveToElement();
                                XmlDocument ValuteXmlDocument = new XmlDocument();
                                ValuteXmlDocument.LoadXml(ReaderXml.ReadOuterXml());
                                Names.Add(ValuteXmlDocument.SelectSingleNode("Valute/Name").InnerText);
                                Values.Add(Convert.ToDouble(ValuteXmlDocument.SelectSingleNode("Valute/Value").InnerText));
                            }
            ReaderXml.Close();
        }

        private void GetAnswer(object sender, EventArgs e){
            try{
                if (DigitComboBox.Text == AnswerComboBox.Text)
                    AnswerTextBox.Text = DigitTextBox.Text;
                else if (DigitTextBox.Text == "")
                    AnswerTextBox.Text = "";
                else AnswerTextBox.Text = GetMeasure(Convert.ToDouble(DigitTextBox.Text), DigitComboBox.Text, AnswerComboBox.Text);
            }
            catch (OverflowException){
                AnswerTextBox.Text = "слишком большое число";
            }
            catch (Exception ex){
                AnswerTextBox.Text = ex.InnerException.ToString();
            }
        }

        private string GetMeasure(double value, string beginName, string endName){
            double beginValue = 1, endValue = 1;
            foreach (var i in Names)
                if (i == beginName) beginValue = Values[Names.IndexOf(i)];
                else if (i == endName) endValue = Values[Names.IndexOf(i)];
            try {
                return ((value * (1 / endValue)) * beginValue).ToString();
            }
            catch (OverflowException){
                return "слишком большое число";
            }
            catch (Exception ex){
                return ex.InnerException.ToString();
            }
        }

        private void InsertText(string symbol){
            if (DigitTextBox.Text == "0")
                DigitTextBox.Text = symbol;
            else DigitTextBox.Text += symbol;
        }

        private void SetOption(object sender, EventArgs e){
            if (DigitTextBox.Text == "") DigitTextBox.Text = "0";
            GetAnswer(null, null);
            if (DigitComboBox.Text == AnswerComboBox.Text) AnswerTextBox.Text = DigitTextBox.Text;
        }

        private void SetItemInComboBox(char symbol, ComboBox control, ref byte index){
            if (control.Items.Count > 0){
                if (symbol == '+')
                    if (index >= control.Items.Count - 1) index = 1;
                    else index++;
                else if (symbol == '-')
                    if (index == 1) index = (byte)(control.Items.Count - 1);
                    else index--;
                control.Text = control.Items[index].ToString();
            }
        }

        // метод, задействующий клавиатуру
        public void ControlKeys(KeyEventArgs e){
            switch (e.KeyCode){
                case Keys.D0: InsertText("0"); break;
                case Keys.D1: InsertText("1"); break;
                case Keys.D2: InsertText("2"); break;
                case Keys.D3: InsertText("3"); break;
                case Keys.D4: InsertText("4"); break;
                case Keys.D5: InsertText("5"); break;
                case Keys.D6: InsertText("6"); break;
                case Keys.D7: InsertText("7"); break;
                case Keys.D8: InsertText("8"); break;
                case Keys.D9: InsertText("9"); break;
                case Keys.Oemcomma:
                    if (DigitTextBox.Text.IndexOf(',') < 0)
                        DigitTextBox.Text += ",";
                    break;
                case Keys.Back:
                        if (DigitTextBox.Text.ToCharArray().Length <= 1)
                            DigitTextBox.Text = "0";
                        else
                            DigitTextBox.Text = DigitTextBox.Text.Substring(0, DigitTextBox.Text.Length - 1);
                    break;
                case Keys.Delete: DigitTextBox.Clear(); break;
                case Keys.Up: SetItemInComboBox('+', DigitComboBox, ref indexF); break;
                case Keys.Down: SetItemInComboBox('-', DigitComboBox, ref indexF); break;
                case Keys.Right: SetItemInComboBox('+', AnswerComboBox, ref indexS); break;
                case Keys.Left: SetItemInComboBox('-', AnswerComboBox, ref indexS); break;
                case Keys.Space: SetValuteCourse(ButtonRestart, null); break;
            }
        }
    }
}

  