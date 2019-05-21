using System;
using System.Windows.Forms;
using System.Drawing;
using System.Data.SqlClient;

namespace CalculaterPro
{
    class PanelLogBook : PanelCustom{
        private static Point location = new Point(7, 7);
        private static string ReaderName = "";
        public ButtonCustom ButtonDeleteLogs = new ButtonCustom(
            new Point(7, 7), new Size(228, 30), new Padding(0), "ButtonDeleteLogs", "Удалить"){
            TabIndex = 0, TabStop = false
        };
        public static Panel PanelShowsText = new Panel();
        private int index = -1;

        public PanelLogBook(){
            Controls.Add(ButtonDeleteLogs);
            Controls.Add(PanelShowsText);
            BackColor = RedGreenBlue.Color2;
            Name = "PanelLogBook";
            Size = new Size(242, 523);

            ButtonDeleteLogs.AddColor1();
            ButtonDeleteLogs.Click += new EventHandler(RemoveVariable);

            // PanelButtons
            PanelShowsText.Location = new Point(7, 44);
            PanelShowsText.Margin = new Padding(7);
            PanelShowsText.Name = "TextShowLogs";
            PanelShowsText.Size = new Size(228, 472);
            PanelShowsText.TabIndex = 0;
            PanelShowsText.BackColor = RedGreenBlue.Color1;
            PanelShowsText.AutoScrollMinSize = new Size(10, 444);
            PanelShowsText.AutoScroll = true;
        }
        
        private async void RemoveVariable(object sender, EventArgs e){
            if (ReaderName != ""){
                SqlCommand command = new SqlCommand("DELETE FROM [LogBookEvents] WHERE [Id] = @Id", MainForm.SqlConnection);
                command.Parameters.AddWithValue("Id", ReaderName);
                await command.ExecuteNonQueryAsync();
                SelectingItems(); index--;
                ReaderName = "";
            }
        }

        private static void SetActiveOption(object sender, EventArgs e){
            int index = PanelShowsText.Controls.GetChildIndex((Control)sender);
            for (var i = 0; i < PanelShowsText.Controls.Count; i++)
                if (i == index && PanelShowsText.Controls[i].BackColor != RedGreenBlue.Color3){
                    ReaderName = PanelShowsText.Controls[i].Name;
                    PanelShowsText.Controls[i].BackColor = RedGreenBlue.Color3;
                }
                else PanelShowsText.Controls[i].BackColor = RedGreenBlue.Color2;
        }

        public static async void InsertVariable(string control, string request, string answer){
            try {
                if (control != "" && request != "" && answer != ""){
                    SqlCommand command = new SqlCommand("INSERT INTO [LogBookEvents] (Request, Answer, Panel)VALUES(@Request, @Answer, @Panel)", MainForm.SqlConnection);
                    command.Parameters.AddWithValue("Request", request);
                    command.Parameters.AddWithValue("Answer", answer);
                    command.Parameters.AddWithValue("Panel", control);
                    await command.ExecuteNonQueryAsync();
                    PanelShowsText.Controls.Add(new TextBoxCustom(
                        location, new Size(195, 100), new Padding(0),
                        $"{PanelShowsText.Controls.Count}",
                        "Вкладка: " + control + Environment.NewLine +
                        "Запрос: " + request + Environment.NewLine +
                        "Ответ: " + answer, true, true, 10F){
                        BackColor = RedGreenBlue.Color2,
                        ScrollBars = ScrollBars.Vertical
                    });
                    PanelShowsText.Controls[PanelShowsText.Controls.Count - 1].Click += new EventHandler(SetActiveOption);
                    location.Y += 107;
                }
            }
            catch (Exception ex){
                MessageBox.Show(ex.InnerException.ToString(), ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async void SelectingItems(){
            PanelShowsText.Controls.Clear();
            SqlDataReader reader = null;
            SqlCommand command = new SqlCommand("SELECT * FROM [LogBookEvents]", MainForm.SqlConnection);
            try {
                reader = await command.ExecuteReaderAsync();
                location = new Point(7, 7);
                while (await reader.ReadAsync()){
                    PanelShowsText.Controls.Add(new TextBoxCustom(
                        location, new Size(195, 100), new Padding(0), reader["Id"].ToString(), 
                        "Вкладка: " + reader["Panel"].ToString() + Environment.NewLine +
                        "Запрос: " + reader["Request"].ToString() + Environment.NewLine + 
                        "Ответ: " + reader["Answer"].ToString(), true, true, 10F){
                            BackColor = RedGreenBlue.Color2,
                            ScrollBars = ScrollBars.Vertical
                    });
                    location.Y += 107; 
                }
                foreach (TextBox i in PanelShowsText.Controls)
                    i.Click += new EventHandler(SetActiveOption);
            }
            catch (Exception ex){
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally{
                if (reader != null) reader.Close();
            }
        }

        public void SetControlsToolTip(){
            MainForm.ToolTip.SetToolTip(ButtonDeleteLogs, "Удалить элемен(т/ты)");
            foreach (TextBox i in PanelShowsText.Controls)
                MainForm.ToolTip.SetToolTip(i, $"{PanelShowsText.Controls.IndexOf(i)}-ое событие");
        }

        private void ChangeItem(char command){
            if (command == '+')
                if (PanelShowsText.Controls.Count - 1 == index) index = 0;
                else index++;
            else if (command == '-')
                if (index == 0 || index == -1) index = PanelShowsText.Controls.Count - 1;
                else index--;
            SetActiveOption(PanelShowsText.Controls[index], null);
        }

        public void ControlKeys(KeyEventArgs e){
            switch (e.KeyCode){
                case Keys.Up: if (PanelShowsText.Controls != null) ChangeItem('-'); break;
                case Keys.Down: if (PanelShowsText.Controls != null) ChangeItem('+'); break;
                case Keys.Delete: RemoveVariable(ButtonDeleteLogs, null); break;
            }
        }
    }
}
