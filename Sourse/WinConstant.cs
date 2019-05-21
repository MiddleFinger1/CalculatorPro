using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Data.SqlClient;

namespace CalculaterPro
{
    class WinConstant : PanelCustom {
        private string ReaderName = "";
        private int index = 0;
        public Panel PanelButtons = new Panel();
        private ButtonCustom
            DeleteButton = new ButtonCustom(
                new Point(124, 33), new Size(111, 32), new Padding(3, 0, 3, 0), "DeleteButton", "Удалить", 10F),
            CreateButton = new ButtonCustom(
                new Point(7, 33), new Size(110, 32), new Padding(3, 0, 3, 0), "CreateButton", "Создать", 10F);
        private TextBoxCustom TextBoxChange = new TextBoxCustom(
            new Point(7, 7), new Size(228, 19), new Padding(0), "TextBoxChange", "", true, false){
            BackColor = RedGreenBlue.Color1
        };
        
        public WinConstant(){
            BackColor = RedGreenBlue.Color2;
            Controls.Add(PanelButtons);
            Controls.Add(DeleteButton);
            Controls.Add(CreateButton);
            Controls.Add(TextBoxChange);

            DeleteButton.AddColor1();
            CreateButton.AddColor1();
            CreateButton.Click += new EventHandler(delegate (object sender, EventArgs e) { CreateVariable(); });
            DeleteButton.Click += new EventHandler(delegate (object sender, EventArgs e) { DeleteVariable(); });

            PanelButtons.ControlAdded += new ControlEventHandler(delegate (object sender, ControlEventArgs e) {
                foreach (LabelCustom i in ((Panel)sender).Controls)
                    if (((Panel)sender).Controls.Count > 11){
                        i.Width = 195; ((Panel)sender).AutoScroll = true;
                    }
                    else { i.Width = 214; ((Panel)sender).AutoScroll = false; }
            });

            // PanelButtons
            PanelButtons.Location = new Point(7, 72);
            PanelButtons.Margin = new Padding(7);
            PanelButtons.Name = "PanelButtons";
            PanelButtons.Size = new Size(228, 444);
            PanelButtons.TabIndex = 0;
            PanelButtons.BackColor = RedGreenBlue.Color1;
            PanelButtons.AutoScrollMinSize = new Size(10, 444);
        }

        private string DeleteSpace(string request){
            string answer = "";
            foreach (var i in request)
                if (i != ' ') answer += i;
            return answer;
        }

        private async void CreateVariable(){
            try {
                if (TextBoxChange.Text != "" && TextBoxChange.Text.IndexOf('=') >= 0){
                    string request = DeleteSpace(TextBoxChange.Text);
                    string name = request.Split('=')[0], value = request.Split('=')[1];
                    if (name != "" && value != ""){
                        SqlCommand command = new SqlCommand("INSERT INTO [Constants] (Name, Value)VALUES(@Name, @Value)", MainForm.SqlConnection);
                        command.Parameters.AddWithValue("Name", name);
                        command.Parameters.AddWithValue("Value", Convert.ToDouble(value).ToString());
                        await command.ExecuteNonQueryAsync();
                        SelectingItems();
                    }
                }
            }
            catch (Exception ex){
                MessageBox.Show(ex.InnerException.ToString(), ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void DeleteVariable(){
            if (TextBoxChange.Text != ""){
                SqlCommand command = new SqlCommand("DELETE FROM [Constants] WHERE [Id] = @Id", MainForm.SqlConnection);
                command.Parameters.AddWithValue("Id", ReaderName);
                await command.ExecuteNonQueryAsync();
                SelectingItems(); index--;
                TextBoxChange.Clear(); ReaderName = "";
            }
        }

        private async void UpdateVariable(){
            try {
                if (TextBoxChange.Text != "" && TextBoxChange.Text.IndexOf('=') >= 0){
                    SqlCommand command = new SqlCommand("UPDATE [Constants] Set [Name] = @Name, [Value] = @Value WHERE [Id] = @Id ", MainForm.SqlConnection);
                    command.Parameters.AddWithValue("Id", ReaderName);
                    string request = DeleteSpace(TextBoxChange.Text);
                    string name = request.Split('=')[0], value = request.Split('=')[1];
                    command.Parameters.AddWithValue("Name", name);
                    command.Parameters.AddWithValue("Value", value.ToString());
                    await command.ExecuteNonQueryAsync();
                    SelectingItems(); 
                }
            }
            catch (Exception ex){
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async void SelectingItems(){
            PanelButtons.Controls.Clear();
            SqlDataReader reader = null;
            SqlCommand command = new SqlCommand("SELECT * FROM [Constants]", MainForm.SqlConnection);
            try {
                reader = await command.ExecuteReaderAsync();
                Point Location = new Point(7, 7);
                while (await reader.ReadAsync()){
                    PanelButtons.Controls.Add(new LabelCustom(
                        Location, new Size(195, 30), new Padding(0), ContentAlignment.MiddleCenter,
                        reader["Id"].ToString(), reader["Name"].ToString() + " = " + reader["Value"].ToString()) {
                        BackColor = RedGreenBlue.Color2
                    });
                    Location.Y += 37;
                }
                foreach (Label i in PanelButtons.Controls){
                    i.Click += new EventHandler(SetActiveOption);
                    i.DoubleClick += new EventHandler(SetConstantToUse);
                }
            }
            catch(Exception ex){
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally{
                if (reader != null) reader.Close();
            }
        }

        private void SetActiveOption(object sender, EventArgs e){
            ReaderName = ((Label)sender).Name;
            foreach (Label h in PanelButtons.Controls)
                if (h.Name == ReaderName && h.BackColor != RedGreenBlue.Color3){
                    h.BackColor = RedGreenBlue.Color3;
                    TextBoxChange.Text = h.Text;
                    index = PanelButtons.Controls.GetChildIndex(h);
                }
                else if (h.BackColor == RedGreenBlue.Color3)
                    h.BackColor = RedGreenBlue.Color2;
        }

        private void SetConstantToUse(object sender, EventArgs e){
            switch (MainForm.index){
                case 1: if (SimpleCalculater.TextLine.Text == ""){
                        string value = DeleteSpace(((Label)sender).Text).Split('=')[1];
                        SimpleCalculater.TextArea.Text += value;
                        SimpleCalculater.TextLine.Text = value;
                    }
                    break;
                case 2:
                    if (EngineerCalculater.TextLine.Text == ""){
                        string value = DeleteSpace(((Label)sender).Text).Split('=')[1];
                        EngineerCalculater.TextArea.Text += value;
                        EngineerCalculater.TextLine.Text = value;
                    }
                    break;
                case 3: if (NumberSystem.TextLine.Text == ""){
                        string value = DeleteSpace(((Label)sender).Text).Split('=')[1];
                        NumberSystem.TextLine.Text = value;
                    }
                    break;
                case 5:
                    if (ValuteCompute.DigitTextBox.Text == ""){
                        string value = DeleteSpace(((Label)sender).Text).Split('=')[1];
                        ValuteCompute.DigitTextBox.Text = value;
                    }
                    break;
                case 8:
                    if (ConverterDigits.TextLine.Text == ""){
                        string value = DeleteSpace(((Label)sender).Text).Split('=')[1];
                        if (value.IndexOf(',') < 0 && value.IndexOf('.') < 0)
                            ConverterDigits.TextLine.Text = value;
                    }
                    break;
                case 9: if (SystemMeasure.DigitTextBox.Text == "" || SystemMeasure.DigitTextBox.Text == "0"){
                        string value = DeleteSpace(((Label)sender).Text).Split('=')[1];
                        SystemMeasure.DigitTextBox.Text = value;
                    }
                    break;
            }
        }

        private void ChangeItem(char command){
            if (command == '+')
                if (PanelButtons.Controls.Count - 1 == index) index = 0;
                else index++;
            else if (command == '-')
                if (index == 0 || index == -1) index = PanelButtons.Controls.Count - 1;
                else index--;
            SetActiveOption(PanelButtons.Controls[index], null);
        }

        public void ControlKeys(KeyEventArgs e){
            string symbol = "";
            Dictionary<Keys, char> keys = new Dictionary<Keys, char>{
                [Keys.D0] = '0', [Keys.D1] = '1', [Keys.D2] = '2', [Keys.D3] = '3', [Keys.D4] = '4',
                [Keys.D5] = '5', [Keys.D6] = '6', [Keys.D7] = '7', [Keys.D8] = '8', [Keys.D9] = '9',
                [Keys.A] = 'A', [Keys.B] = 'B', [Keys.C] = 'C', [Keys.D] = 'D', [Keys.E] = 'E',
                [Keys.F] = 'F', [Keys.G] = 'G', [Keys.H] = 'H', [Keys.I] = 'I', [Keys.J] = 'J',
                [Keys.K] = 'K', [Keys.L] = 'L', [Keys.M] = 'M', [Keys.N] = 'N', [Keys.O] = 'O',
                [Keys.P] = 'P', [Keys.Q] = 'Q', [Keys.R] = 'R', [Keys.S] = 'S', [Keys.T] = 'T',
                [Keys.U] = 'U', [Keys.V] = 'V', [Keys.W] = 'W', [Keys.X] = 'X', [Keys.Y] = 'Y',
                [Keys.Z] = 'Z'
            };
            switch (e.KeyCode){ // работа при сочитании клавиш с Shift
                case Keys.Enter: CreateVariable(); break;
                case Keys.Delete: DeleteVariable(); break;
                case Keys.Home: SetActiveOption(PanelButtons.Controls[index], null); break;
                case Keys.Up: if (PanelButtons.Controls != null) ChangeItem('-'); break;
                case Keys.Down: if (PanelButtons.Controls != null) ChangeItem('+'); break;
                case Keys.Space:
                    foreach (Label i in PanelButtons.Controls)
                        if (ReaderName == i.Name)
                            SetConstantToUse(i, null);
                    break;
                case Keys.End: UpdateVariable(); break;
                case Keys.Back:
                    try {
                        TextBoxChange.Text = TextBoxChange.Text.Substring(0, TextBoxChange.Text.Length - 1);
                    }
                    catch (Exception){ }
                    break;
                case Keys.Oemcomma:
                    if (TextBoxChange.Text.IndexOf(',') < 0)
                        symbol = ",";
                    break;
                case Keys.OemMinus:
                    if (TextBoxChange.Text.IndexOf('-') < 0)
                        symbol = "-";
                    break;
                case Keys.Add:
                    if (TextBoxChange.Text.IndexOf('+') < 0)
                        symbol = "+";
                    break;
                case Keys.Oemplus:
                    if (TextBoxChange.Text.IndexOf('=') < 0)
                        symbol = "=";
                    break;
            }
            foreach(var i in keys.Keys)
                if (e.KeyCode == i) symbol = keys[i].ToString();
            TextBoxChange.Text += symbol;
        }
    }
}

