using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace CalculaterPro
{
    class SystemMeasure : PanelCustom
    {
        byte indexC = 0, indexF = 0, indexS = 0;
        public static TextBoxCustom 
            AnswerTextBox = new TextBoxCustom(
                new Point(7, 365), new Size(473, 19), new Padding(0), "AnswerTextBox", "0", true, false){
                BackColor = Color.FromArgb(RedGreenBlue.red, RedGreenBlue.green, RedGreenBlue.blue)
            },
            DigitTextBox = new TextBoxCustom(
                new Point(7, 156), new Size(473, 19), new Padding(0), "DigitTextBox", "0", true, false){
                BackColor = Color.FromArgb(RedGreenBlue.red, RedGreenBlue.green, RedGreenBlue.blue),
            };
        public ComboBoxCustom
            AnswerComboBox = new ComboBoxCustom(
                new Point(7, 328), new Size(473, 30), new Padding(7), ComboBoxStyle.DropDownList, FlatStyle.Flat, "AnswerComboBox") {
                BackColor = Color.FromArgb(RedGreenBlue.red, RedGreenBlue.green, RedGreenBlue.blue),
                FormattingEnabled = true,
                DropDownHeight = 150
            },
            DigitComboBox = new ComboBoxCustom(
                new Point(7, 182), new Size(473, 30), new Padding(7), ComboBoxStyle.DropDownList, FlatStyle.Flat, "DigitComboBox"){
                BackColor = Color.FromArgb(RedGreenBlue.red, RedGreenBlue.green, RedGreenBlue.blue),
                FormattingEnabled = true,
                DropDownHeight = 150
            },
            CategoryComboBox = new ComboBoxCustom(
                new Point(7, 7), new Size(473, 30), new Padding(7), ComboBoxStyle.DropDownList, FlatStyle.Flat, "CategoryComboBox"){
                BackColor = Color.FromArgb(RedGreenBlue.red, RedGreenBlue.green, RedGreenBlue.blue),
                FormattingEnabled = true,
                DropDownHeight = 150
            };
        public LabelCustom
            AnswerLabel = new LabelCustom(
                new Point(7, 299), new Size(58, 22), new Padding(0), ContentAlignment.MiddleCenter, "AnswerLabel", "Ответ"),
            DigitLabel = new LabelCustom(
                new Point(7, 127), new Size(58, 22), new Padding(0), ContentAlignment.MiddleCenter, "DigitLabel", "Число");
        
        public SystemMeasure(){
            Controls.Add(CategoryComboBox);
            Controls.Add(AnswerTextBox);
            Controls.Add(AnswerComboBox);
            Controls.Add(DigitTextBox);
            Controls.Add(DigitComboBox);
            Controls.Add(AnswerLabel);
            Controls.Add(DigitLabel);
            Name = "ComputeNumSystem";

            CategoryComboBox.Items.AddRange(CategoryList);
            CategoryComboBox.Text = "Длина";
            CategoryComboBox.TextChanged += new EventHandler(SetCategory);

            foreach (var i in CategoryParametres.Length.Keys){
                DigitComboBox.Items.Add(i);
                AnswerComboBox.Items.Add(i);
            }
            DigitComboBox.Text = "метр";
            AnswerComboBox.Text = "сантиметр";

            DigitTextBox.TextChanged += new EventHandler(GetAnswer);
            DigitComboBox.TextChanged += new EventHandler(SetOption);
            AnswerComboBox.TextChanged += new EventHandler(SetOption);
        }

        private string[] CategoryList = new string[] {
            "Длина", "Площадь", "Объем", "Вес", "Энергия", "Температура", "Скорость", "Время", "Данные"
        };

        private void SetCategory(object sender, EventArgs e){
            DigitComboBox.Items.Clear();
            AnswerComboBox.Items.Clear();
            switch (CategoryComboBox.Text){
                case "Длина": SetBeginnerStyle(CategoryParametres.Length, "метр", "сантиметр"); break;
                case "Площадь": SetBeginnerStyle(CategoryParametres.Square, "кв.метр", "кв.сантиметр"); break;
                case "Вес": SetBeginnerStyle(CategoryParametres.Weight, "килограмм", "грамм"); break;
                case "Объем": SetBeginnerStyle(CategoryParametres.Volume, "куб.метр", "литр"); break;
                case "Время": SetBeginnerStyle(CategoryParametres.Time, "минута", "секунда"); break;
                case "Данные": SetBeginnerStyle(CategoryParametres.Data, "бит", "байт"); break;
                case "Скорость": SetBeginnerStyle(CategoryParametres.Speed, "метр/секунда", "километр/час"); break;
                case "Энергия": SetBeginnerStyle(CategoryParametres.Energy, "джоуль", "килоджоуль"); break;
                case "Температура":
                    DigitComboBox.Items.AddRange(new string[] { "Цельсия", "Фаренгейт", "Кельвин", "Реомюр" });
                    AnswerComboBox.Items.AddRange(new string[] { "Цельсия", "Фаренгейт", "Кельвин", "Реомюр" });
                    DigitComboBox.Text = "Цельсия";
                    AnswerComboBox.Text = "Фаренгейт";
                    break;
            }
        }

        private void SetBeginnerStyle(Dictionary<string, double> dictionary, string begin, string following){
            foreach (var i in dictionary.Keys){
                DigitComboBox.Items.Add(i);
                AnswerComboBox.Items.Add(i);
            }
            DigitComboBox.Text = begin;
            AnswerComboBox.Text = following;
        }

        private void SetOption(object sender, EventArgs e){
            if (DigitTextBox.Text == "") DigitTextBox.Text = "0";
            GetAnswer(null, null);
            if (DigitComboBox.Text == AnswerComboBox.Text) AnswerTextBox.Text = DigitTextBox.Text;
        }

        private string GetTemperture(double value, string begin, string end){
            try{
                string answer = "";
                if (begin == "Цельсия" && end == "Фаренгейт")
                    answer = ((9 / 5) * value + 32).ToString();
                else if (begin == "Фаренгейт" && end == "Цельсия")
                    answer = (0.55555555555 * (value - 32)).ToString();
                else if (begin == "Реомюр" && end == "Цельсия")
                    answer = (0.8 * value).ToString();
                else if (begin == "Кельвин" && end == "Цельсия")
                    answer = (value - 273.15).ToString();
                else if (begin == "Цельсия" && end == "Кельвин")
                    answer = (value + 273.15).ToString();
                else if (begin == "Кельвин" && end == "Фаренгейт")
                    answer = (value * 1.8 - 459.67).ToString();
                else if (begin == "Фаренгейт" && end == "Кельвин")
                    answer = ((value + 459.67) / 1.8).ToString();
                else if (begin == "Цельсия" && end == "Реомюр")
                    answer = (1.25 * value).ToString();
                else if (begin == "Реомюр" && end == "Фаренгейт")
                    answer = (0.55555555555 * ((1.25 * value) - 32)).ToString();
                else if (begin == "Кельвин" && end == "Реомюр")
                    answer = ((value - 273.15) * 1.25).ToString();
                else if (begin == "Фаренгейт" && end == "Реомюр")
                    answer = ((0.55555555555 * (value - 32)) * 1.25).ToString();
                else if (begin == "Реомюр" && end == "Кельвин")
                    answer = ((0.8 * value) + 273.15).ToString();
                return answer;
            }
            catch (OverflowException){
                return "Слишком большое число";
            }
            catch (Exception ex){
                return ex.Message.ToString();
            }
        }

        private string GetMeasure(double value, Dictionary<string, double> Parametres, string BeginMeasure, string EndMeasure){
            double beginvalue = 0, endvalue = 0;
            foreach (var i in Parametres.Keys)
                if (i == BeginMeasure)
                    beginvalue = Parametres[i];
                else if (i == EndMeasure)
                    endvalue = Parametres[i];
            try{
                return (value * (1 / endvalue) * beginvalue).ToString();
            }
            catch (OverflowException){
                return "слишком большое число";
            }
            catch (Exception ex){
                return ex.InnerException.ToString();
            }
        }

        // метод для получения ответа
        private void GetAnswer(object sender, EventArgs e){
            try {
                if (DigitComboBox.Text == AnswerComboBox.Text)
                    AnswerTextBox.Text = DigitTextBox.Text;
                else if (DigitTextBox.Text == "")
                    AnswerTextBox.Text = "";
                else{
                    switch (CategoryComboBox.Text) {
                        case "Длина": AnswerTextBox.Text = GetMeasure(Convert.ToDouble(DigitTextBox.Text), CategoryParametres.Length, DigitComboBox.Text, AnswerComboBox.Text); break;
                        case "Площадь": AnswerTextBox.Text = GetMeasure(Convert.ToDouble(DigitTextBox.Text), CategoryParametres.Square, DigitComboBox.Text, AnswerComboBox.Text); break;
                        case "Вес": AnswerTextBox.Text = GetMeasure(Convert.ToDouble(DigitTextBox.Text), CategoryParametres.Square, DigitComboBox.Text, AnswerComboBox.Text); break;
                        case "Объем": AnswerTextBox.Text = GetMeasure(Convert.ToDouble(DigitTextBox.Text), CategoryParametres.Volume, DigitComboBox.Text, AnswerComboBox.Text); break;
                        case "Время": AnswerTextBox.Text = GetMeasure(Convert.ToDouble(DigitTextBox.Text), CategoryParametres.Time, DigitComboBox.Text, AnswerComboBox.Text); break;
                        case "Данные": AnswerTextBox.Text = GetMeasure(Convert.ToDouble(DigitTextBox.Text), CategoryParametres.Data, DigitComboBox.Text, AnswerComboBox.Text); break;
                        case "Температура": AnswerTextBox.Text = GetTemperture(Convert.ToDouble(DigitTextBox.Text), DigitComboBox.Text, AnswerComboBox.Text); break;
                        case "Скорость": AnswerTextBox.Text = GetMeasure(Convert.ToDouble(DigitTextBox.Text), CategoryParametres.Speed, DigitComboBox.Text, AnswerComboBox.Text); break;
                        case "Энергия": AnswerTextBox.Text = GetMeasure(Convert.ToDouble(DigitTextBox.Text), CategoryParametres.Energy, DigitComboBox.Text, AnswerComboBox.Text); break;
                    }
                }
            }
            catch (OverflowException){
                AnswerTextBox.Text = "слишком большое число";
            }
            catch (Exception ex){
                AnswerTextBox.Text = ex.InnerException.ToString();
            }
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

        private void InsertText(string symbol){
            if (DigitTextBox.Text == "0")
                DigitTextBox.Text = symbol;
            else DigitTextBox.Text += symbol;
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
                case Keys.PageUp: SetItemInComboBox('+', CategoryComboBox, ref indexC); break;
                case Keys.PageDown: SetItemInComboBox('-', CategoryComboBox, ref indexC); break;
            }
        }
    }
    
    struct CategoryParametres{
        public static Dictionary<string, double>
            Length = new Dictionary<string, double>{
                ["метр"] = 1,
                ["сантиметр"] = 0.01,
                ["дециметр"] = 0.1,
                ["миллиметр"] = 0.001,
                ["километр"] = 1000,
                ["миля"] = 1609.34,
                ["дюйм"] = 0.025,
                ["фунт"] = 0.3
            },
            Square = new Dictionary<string, double>{
                ["кв.метр"] = 1,
                ["кв.сантиметр"] = 0.0001,
                ["гектар"] = 10000,
                ["кв.километр"] = 1000000,
                ["сотка"] = 100,
                ["кв.дюйм"] = 0.00065,
                ["кв.миля"] = 2589988.11,
                ["акра"] = 4046.86,
                ["кв.фунт"] = 0.093
            },
            Weight = new Dictionary<string, double>{
                ["миллиграмм"] = 0.000001,
                ["сантиграмм"] = 0.00001,
                ["дециграмм"] = 0.0001,
                ["грамм"] = 0.001,
                ["декаграмм"] = 0.01,
                ["гектограмм"] = 0.1,
                ["килограмм"] = 1,
                ["англ.фунт"] = 0.45,
                ["русс.фунт"] = 0.41,
                ["центнер"] = 100,
                ["тонна"] = 1000,
                ["пуд"] = 16.38,
                ["карат"] = 0.0002,
                ["унция"] = 0.028,
                ["тр.унция"] = 0.031,
            },
            Volume = new Dictionary<string, double>{
                ["куб.метр"] = 1,
                ["литр"] = 0.001,
                ["чайная ложка"] = 0.000005,
                ["столовая ложка"] = 0.000015,
                ["стакан"] = 0.0002,
                ["рюмка"] = 0.00005,
                ["миллилитр"] = 0.000001,
                ["амер.галлон"] = 0.0038,
                ["англ.галлон"] = 0.0045,
                ["баррель"] = 0.16,
                ["ведро"] = 0.012,
                ["куб.сантиметр"] = 0.000001,
                ["куб.дюйм"] = 0.000016,
            },
            Time = new Dictionary<string, double>{
                ["секунда"] = 0.017,
                ["минута"] = 1,
                ["час"] = 60,
                ["сутки"] = 1440,
                ["неделя"] = 10080,
                ["декада"] = 14400,
                ["год"] = 525600,
                ["век"] = 52560000,
                ["тысячалетие"] = 525600000,
                ["академи.час"] = 1,
                ["нано секунда"] = 1.67e-11,
                ["микросекунда"] = 1.67e-8,
                ["миллисекунда"] = 0.000017
            },
            Data = new Dictionary<string, double>{
                ["бит"] = 1,
                ["байт"] = 8,
                ["кило байт"] = 8192,
                ["кило бит"] = 1024,
                ["мега байт"] = 8388608,
                ["мега бит"] = 1048576,
                ["гига байт"] = 8589934592,
                ["гига бит"] = 1073741824,
                ["тера байт"] = 8.8e+12,
                ["тера бит"] = 1.1e+12,
                ["пета байт"] = 9.01e+15,
                ["пета бит"] = 1.13e+15,
                ["экса байт"] = 9.22e+18,
                ["экса бит"] = 1.15e+18,
                ["зетта байт"] = 9.44e+21,
                ["зетта бит"] = 1.18e+21,
                ["йотта байт"] = 9.67e+24,
                ["йотта бит"] = 1.21e+24,
                ["CD"] = 5898240000,
                ["DVD-5"] = 37658558464,
                ["DVD-9"] = 68349329408,
            },
            Speed = new Dictionary<string, double>{
                ["метр/секунда"] = 1,
                ["километр/час"] = 0.28,
                ["узел"] = 0.51,
                ["скорость света"] = 299792458,
                ["миля/час"] = 0.45,
                ["морская миля/час"] = 0.51,
            },
            Energy = new Dictionary<string, double>{
                ["джоуль"] = 1,
                ["килоджоуль"] = 1000,
                ["тепловой калорий"] = 4.184,
                ["пищевой калорий"] = 4184,
                ["фут-фунт"] = 1.355818,
                ["брит.тепл.ед."] = 1055.056,
                ["электрон-вольт"] = 1.602177e-19,
            };
    }
}






