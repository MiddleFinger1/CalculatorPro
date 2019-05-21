using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Scripting.Hosting;
using IronPython.Hosting;

namespace CalculaterPro
{
    class CodingMathRequest : PanelCustom
    {
        private string filepath = "";
        private OpenFileDialog openfile = new OpenFileDialog();
        private SaveFileDialog savefile = new SaveFileDialog();
        public RichTextCustom TextArea = new RichTextCustom(
            new Point(7, 7), new Size(473, 397), new Padding(7), "TextArea", "", false, true, 13F) {
            BackColor = RedGreenBlue.Color1,
            ScrollBars = RichTextBoxScrollBars.Both,
            AllowDrop = true,
        };
        public TextBoxCustom ConsoleTextBox = new TextBoxCustom(
            new Point(7, 44), new Size(473, 199), new Padding(7), "ConsoleTextBox", "", true, true, 13F);
        public Panel Console = new Panel();
        public LabelCustom ConsoleTitle = new LabelCustom(
            new Point(7, 7), new Size(473, 30), new Padding(7), ContentAlignment.MiddleLeft, "ConsoleTitle", "Консоль"){
            BackColor = RedGreenBlue.Color1
        };
        public TBLayoutCustom TBLayout = new TBLayoutCustom(
            new Point(0, 405), new Size(480, 74), new Padding(0, 0, 0, 7), "TBLayout", 2, 4);
        public ButtonCustom
            HowSaveFile = new ButtonCustom(
                new Point(0, 0), new Size(113, 30), new Padding(7, 7, 0, 0), "HowSaveFile", "Сохранить как", 9.749999F),
            OpenFile = new ButtonCustom(
                new Point(0, 0), new Size(113, 30), new Padding(7, 7, 0, 0), "OpenFile", "Открыть", 9.749999F),
            SaveFile = new ButtonCustom(
                new Point(0, 0), new Size(113, 30), new Padding(7, 7, 0, 0), "SaveFile", "Сохранить", 9.749999F),
            CloseFile = new ButtonCustom(
                new Point(0, 0), new Size(113, 30), new Padding(7, 7, 0, 0), "CloseFile", "Закрыть", 9.749999F),
            ButtonCopy = new ButtonCustom(
                new Point(0, 0), new Size(113, 30), new Padding(7, 7, 0, 0), "ButtonCopy", "Скопировать", 9.749999F),
            ButtonPaste = new ButtonCustom(
                new Point(0, 0), new Size(113, 30), new Padding(7, 7, 0, 0), "ButtonPaste", "Вставить", 9.749999F),
            ButtonDelete = new ButtonCustom(
                new Point(0, 0), new Size(113, 30), new Padding(7, 7, 0, 0), "ButtonDelete", "Удалить", 9.749999F),
            ButtonEnter = new ButtonCustom(
                new Point(0, 0), new Size(113, 30), new Padding(7, 7, 0, 0), "ButtonEnter", "Обработать", 9.749999F);

        public CodingMathRequest(){
            ConsoleTextBox.AddColor1();
            HowSaveFile.AddColor1();
            OpenFile.AddColor1();
            ButtonCopy.AddColor1();
            ButtonPaste.AddColor1();
            ButtonDelete.AddColor1();
            ButtonEnter.AddColor1();
            SaveFile.AddColor1();
            CloseFile.AddColor1();
            ButtonDelete.Click += new EventHandler(delegate(object sender, EventArgs e){TextArea.Clear();});
            ButtonCopy.Click += new EventHandler(Copy);
            ButtonPaste.Click += new EventHandler(Paste);
            ButtonEnter.Click += new EventHandler(StartScript);
            Console.SuspendLayout();
            TBLayout.SuspendLayout();
            Console.ResumeLayout(false);
            Console.PerformLayout();
            TBLayout.ResumeLayout(false);
            
            // CodingMathRequest
            Controls.Add(Console);
            Controls.Add(TBLayout);
            Controls.Add(TextArea);
            Name = "CodingMathRequest";

            OpenFile.Click += new EventHandler(OpenFiles);
            SaveFile.Click += new EventHandler(SaveFiles);
            CloseFile.Click += new EventHandler(CloseFiles);
            HowSaveFile.Click += new EventHandler(HowSaveFiles);
            TextArea.DragEnter += new DragEventHandler(DragEnterFile);
            TextArea.DragDrop += new DragEventHandler(DragDropFile);
            ConsoleTitle.DoubleClick += new EventHandler(OpenConsole);

            // Console
            Console.Controls.Add(ConsoleTextBox);
            Console.Controls.Add(ConsoleTitle);
            Console.Dock = DockStyle.Bottom;
            Console.Location = new Point(0, 479);
            Console.Margin = new Padding(0);
            Console.MaximumSize = new Size(487, 250);
            Console.MinimumSize = new Size(487, 44);
            Console.Name = "Console";
            Console.Size = new Size(487, 44);
            Console.TabIndex = 0;

            TBLayout.Controls.AddRange(new Control[] {
                OpenFile, SaveFile, HowSaveFile, CloseFile, ButtonPaste, ButtonCopy, ButtonDelete, ButtonEnter });
        }
        
		private void CloseFiles(object sender, EventArgs e){
                SaveFiles(sender, e); TextArea.Clear();
        }
		
        public void SetControlsToolTip(){
            MainForm.ToolTip.SetToolTip(OpenFile, "Открыть файл");
            MainForm.ToolTip.SetToolTip(SaveFile, "Сохранить файл");
            MainForm.ToolTip.SetToolTip(HowSaveFile, "Сохранить как");
            MainForm.ToolTip.SetToolTip(CloseFile, "закрыть файл");
            MainForm.ToolTip.SetToolTip(ButtonCopy, "Скопировать фрагмент");
            MainForm.ToolTip.SetToolTip(ButtonPaste, "Вставить фрагмент");
            MainForm.ToolTip.SetToolTip(ButtonEnter, "Обработать запрос");
            MainForm.ToolTip.SetToolTip(ConsoleTitle, "Открыть/закрыть консоль");
            MainForm.ToolTip.SetToolTip(TextArea, "Текстовое поле для редактирования");
        }

        private void HowSaveFiles(object sender, EventArgs e){
            savefile.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            savefile.ShowDialog();
            string filename = savefile.FileName;
            if (!string.IsNullOrEmpty(filepath))
                File.WriteAllText(filename, TextArea.Text); 
        }

        private void SaveFiles(object sender, EventArgs e){
            if (!string.IsNullOrEmpty(filepath)){
                StreamWriter writer = new StreamWriter(filepath, false);
                foreach (var i in TextArea.Lines)
                    if (!string.IsNullOrEmpty(i))
                        writer.WriteLine(i);
                writer.Close();
            }
        }

        private void OpenFiles(object sender, EventArgs e){
            openfile.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            openfile.ShowDialog();
            filepath = openfile.FileName;
            if (!string.IsNullOrEmpty(filepath)){
                StreamReader reader = new StreamReader(filepath, Encoding.Default);
                TextArea.Text = reader.ReadToEnd();
                reader.Close();
            }
        }

        private void OpenConsole(object sender, EventArgs e){
            if (Console.Height == Console.MinimumSize.Height)
                Console.Height = Console.MaximumSize.Height;
            else Console.Height = Console.MinimumSize.Height; 
        }

        private void Copy(object sender, EventArgs e){
            try {Clipboard.SetText(TextArea.Text);}
            catch (Exception){ }
        }

        private void Paste(object sender, EventArgs e){
            try {TextArea.Text = Clipboard.GetText();}
            catch (Exception){ }
        }

        public void ControlKeys(KeyEventArgs e){
            if (e.Control)
                switch (e.KeyCode){
                    case Keys.C: Copy(ButtonCopy, null); break;
                    case Keys.V: Paste(ButtonPaste, null); break;
                    case Keys.Enter: StartScript(ButtonEnter, null); break;
					case Keys.Delete: TextArea.Clear(); break;
                    case Keys.O: OpenFiles(OpenFile, null); break;
                    case Keys.S: SaveFiles(SaveFile, null); break;
					case Keys.E: CloseFiles(CloseFile, null); break;
                }
            else if (e.Control && e.Shift && e.KeyCode == Keys.S){
                SaveFiles(HowSaveFile, e); TextArea.Clear();
            }
        }

        private void DragEnterFile(object sender, DragEventArgs e){
            if (e.Data.GetDataPresent(DataFormats.FileDrop)){
                string file = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
                if (file.IndexOf(".txt") >= 0)
                    e.Effect = DragDropEffects.Copy;
                else e.Effect = DragDropEffects.None;
            }
            else e.Effect = DragDropEffects.None;
        }

        private void DragDropFile(object sender, DragEventArgs e){
            if (e.Data.GetDataPresent(DataFormats.FileDrop)){
                filepath = ((string[])(e.Data.GetData(DataFormats.FileDrop)))[0];
                StreamReader reader = new StreamReader(filepath, Encoding.Default);
                TextArea.Text = reader.ReadToEnd();
                reader.Close();
            }
        }

        private void StartScript(object sender, EventArgs e){
            try {
                ConsoleTextBox.Text = "";
                Console.Height = Console.MaximumSize.Height;
                string answer = "", error = "";
                Evaluate.Eval(TextArea.Lines, out answer, out error);
                if (error != "")
                    ConsoleTextBox.Text += error;
                else if (error == "" && answer != "")
                    ConsoleTextBox.Text += answer;
                if (SettingsPage.CheckEventLogger)
                    PanelLogBook.InsertVariable("MathScript", TextArea.Text, ConsoleTextBox.Text);
            }
            catch (Exception ex){
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    abstract class Evaluate{
        public static ScriptEngine ScriptEngine;
        public static ScriptScope ScriptScope;
        protected static List<string> lexems = new List<string>{
            "input", "import", "class", "def", "from", ":", "#", "\"", 
            "list", "object", "str", "tuple", "dict", "bool", "\'", "{", "}", "[", "]",
            "and", "or", "not", "is", "!", ">", "<", "&&", "||", "if", "else", "in",
            "for", "while", "break", "continue", "len", "global", "object", "self", "|",
            "==", "lambda", "None", "True", "False", "nonlocal", "as", "raise", "@",
            "try", "except", "finally", "return", "pass", "with", "yield", "del", "assert",
            "abs", "eval", "chr", "open"
        };

        protected static string LibraryFunctions(){
            string path = @"libraryfunctions.py";
            StreamReader reader = new StreamReader(path, Encoding.Default);
            return reader.ReadToEnd();
        }

        protected static string strings(string[] array){
            string strings = "";
            foreach (var i in array)
                strings += i;
            return strings;
        }

        protected static bool HasSymbol(string[] request){
            string reader = "";
            foreach (var i in strings(request)){
                foreach (var h in lexems)
                    if (reader == h || i.ToString() == h)
                        return false;
                if (i == ' ') reader = " ";
                else reader += i;
            }
            return true;
        }

        public static void Eval(string[] request, out string answer, out string error){
            string answer1 = "", error1 = "";
            if (HasSymbol(request) == false){
                answer1 = "";
                error1 = "Неправильный запрос";
            }
            else{
                string function = "";
                for (var i = 0; i < request.Length; i++) {
                    if (request[i].IndexOf(" print ") >= 0 || request[i].IndexOf("print ") >= 0) {
                        foreach (var sbstr in new string[] { "+=", "-=", "/=", "*=", "//=", "**=", "%=" }){
                            if (request[i].IndexOf(sbstr) >= 0) {
                                answer1 += "в функции print нельзя использовать операторы инкримента";
                                goto outer;
                            }
                        }
                        string pythonCode = "";
                        try{
                            ScriptEngine = Python.CreateEngine();
                            ScriptScope = ScriptEngine.CreateScope();
                            string func = "def function():" + Environment.NewLine + function + "\n    " + request[i].Replace("print", "return");
                            pythonCode = LibraryFunctions() + "\n" + func;
                            ScriptEngine.Execute(pythonCode, ScriptScope);
                            dynamic mainfunc = ScriptScope.GetVariable("function");
                            double exe = mainfunc();
                            answer1 += exe + Environment.NewLine;
                            answer1 = answer1.IndexOf(',') >= 0 ? answer1.Replace(',', '.') : answer1;
                        }
                        catch (Exception ex){
                            error1 += ex.Message.ToString() + "\n";
                            error1 += ex.Source.ToString() + "\n";
                            error1 += ex.Data.ToString() + "\n";
                            error1 += pythonCode;
                        }
                    }
                    else function += "    " + request[i] + "\n";
                }
            }
            outer:
            answer = answer1;
            error = error1;
        }
    }
}
