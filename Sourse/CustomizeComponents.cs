using System;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using CalculaterPro.Properties;

namespace CalculaterPro
{
    class ButtonCustom : Button{
        public ButtonCustom(Point point, Size size, Padding margin, string name, string text = "", float font_size = 12F){
            Cursor = Cursors.Default;
            FlatStyle = FlatStyle.Flat;
            ForeColor = SystemColors.Control;
            FlatAppearance.BorderSize = 0;
            TabIndex = 0;
            TabStop = false;
            Text = text;
            Location = point;
            Size = size;
            Name = name;
            Margin = margin;
            UseVisualStyleBackColor = true;
            Font = new Font("Ubuntu Light", font_size, FontStyle.Regular, GraphicsUnit.Point, 204);
        }

        public void AddColor1(){
            BackColor = RedGreenBlue.Color1;
            FlatAppearance.MouseOverBackColor = RedGreenBlue.Color3;
        }
    }

    public class TextBoxCustom : TextBox{
        const int WM_SETFOCUS = 0x0007;
        const int WM_KILLFOCUS = 0x0008;
        public byte green1, blue1, red1, green2, blue2, red2;
        public TextBoxCustom(Point point, Size size, Padding padding, string name, string text = "",
            bool Readonly = false, bool MultiLine = false, float font_size = 12F){
            Location = point;
            Size = size;
            Name = name;
            Text = text;
            Margin = padding;
            ForeColor = SystemColors.Control;
            BorderStyle = BorderStyle.None;
            Cursor = Cursors.Default;
            Font = new Font("Ubuntu Light", font_size, FontStyle.Regular, GraphicsUnit.Point, 204);
            ReadOnly = Readonly;
            Multiline = MultiLine;
            TabIndex = 0;
            TabStop = false;
            SelectAll();
        }
        public void AddColor1(){
            BackColor = RedGreenBlue.Color1;
        }
        protected override void WndProc(ref Message m){
            if (m.Msg == WM_SETFOCUS) m.Msg = WM_KILLFOCUS;
            base.WndProc(ref m);
        }
    }

    public class LabelCustom : Label {
        public LabelCustom(Point point, Size size, Padding padding, ContentAlignment content, string name, 
            string text = "", float font_size = 12F)
        {
            AutoSize = false;
            Location = point;
            Name = name;
            Size = size;
            TabIndex = 0;
            TabStop = false;
            Text = text;
            Margin = padding;
            TextAlign = content;
            Font = new Font("Ubuntu Light", font_size, FontStyle.Regular, GraphicsUnit.Point, 204);
        }
    }

    public class TrackBarCustom : TrackBar {
        public TrackBarCustom(Point point, Size size, Padding padding, string name, RightToLeft rightleft,
            int Max = 100, int Min = 0, int value = 0, int inc = 1, float font_size = 12F)
        {
            Location = point;
            Size = size;
            Margin = padding;
            Name = name;
            RightToLeft = rightleft;
            Maximum = Max;
            Minimum = Min;
            Value = value;
            LargeChange = inc;
            TabIndex = 0;
            TabStop = false;
            Font = new Font("Ubuntu Light", font_size, FontStyle.Regular, GraphicsUnit.Point, 204);
        }
    }

    public class CheckCustom : CheckBox {
        public CheckCustom(Point point, Size size, string name, float font_size = 12F){
            Size = size;
            Location = point;
            Name = name;
            Font = new Font("Ubuntu Light", font_size, FontStyle.Regular, GraphicsUnit.Point, 204);
        }
    }

    public class DateTimeCustom : DateTimePicker {
        public DateTimeCustom(Point point, Size size, Padding padding, string name, float font_size = 12F){
            Location = point;
            Margin = padding;
            Name = name;
            Size = size;
            TabIndex = 0;
            TabStop = false;
            BackColor = Color.Fuchsia;
            Font = new Font("Ubuntu Light", font_size, FontStyle.Regular, GraphicsUnit.Point, 204);
        }
    }

    public class ComboBoxCustom : ComboBox {
        public ComboBoxCustom(Point point, Size size, Padding padding, ComboBoxStyle boxStyle, FlatStyle flatStyle, 
            string name, float font_size = 12F)
        {
            Location = point;
            Size = size;
            Margin = padding;
            DropDownStyle = boxStyle;
            FlatStyle = flatStyle;
            ForeColor = SystemColors.Control;
            TabIndex = 0;
            TabStop = false;
            Font = new Font("Ubuntu Light", font_size, FontStyle.Regular, GraphicsUnit.Point, 204);
        }
    }

    public class RichTextCustom : RichTextBox{
        public RichTextCustom(Point point, Size size, Padding padding, string name, string text = "",
            bool Readonly = false, bool MultiLine = false, float font_size = 12F)
        {
            Location = point;
            Size = size;
            Name = name;
            Text = text;
            Margin = padding;
            ForeColor = SystemColors.Control;
            BorderStyle = BorderStyle.None;
            Cursor = Cursors.Default;
            ReadOnly = Readonly;
            Multiline = MultiLine;
            TabIndex = 0;
            TabStop = false;
            Font = new Font("Ubuntu Light", font_size, FontStyle.Regular, GraphicsUnit.Point, 204);
        }
        
        public void AddColor1(){
            BackColor = Color.FromArgb(RedGreenBlue.red, RedGreenBlue.green, RedGreenBlue.blue);
            ChangeSelectColour(Color.FromArgb(RedGreenBlue.RegularRed(70), RedGreenBlue.RegularGreen(70), RedGreenBlue.RegularBlue(70)));
        }

        [DllImport("user32.dll")]
        static extern bool SetSysColors(int cElements, int[] lpaElements, uint[] lpaRgbValues);

        void ChangeSelectColour(Color color){
            const int COLOR_HIGHLIGHT = 13;
            //const int COLOR_HIGHLIGHTTEXT = 14;
            // You will have to set the HighlightText colour if you want to change that as well. 

            //array of elements to change 
            int[] elements = { COLOR_HIGHLIGHT };

            List<uint> colours = new List<uint>();
            colours.Add((uint)ColorTranslator.ToWin32(color));

            //set the desktop color using p/invoke 
            SetSysColors(elements.Length, elements, colours.ToArray());
        }
    }

    public class NumericUpCustom : NumericUpDown{
        public NumericUpCustom(Point point, Size size, Padding padding, decimal max, decimal min, decimal val, string name, float font_size = 12F){
            BorderStyle = BorderStyle.None;
            Font = new Font("Ubuntu Light", font_size, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            ForeColor = SystemColors.Control;
            Location = point;
            Margin = padding;
            ReadOnly = true;
            Maximum = max;
            Minimum = min;
            Name = name;
            Size = size;
            TabIndex = 0;
            TabStop = false;
            TextAlign = HorizontalAlignment.Center;
            Value = val;
        }
        public void AddColor1(){
            BackColor = Color.FromArgb(RedGreenBlue.red, RedGreenBlue.green, RedGreenBlue.blue);
            ForeColor = SystemColors.Control;
        }
    }

    public class ToolTipCustom : ToolTip{
        public byte green, blue, red;
        public ToolTipCustom(){
            BackColor = Color.FromArgb(RedGreenBlue.Red2, RedGreenBlue.Green2, RedGreenBlue.Blue2);
            UseAnimation = true;
            ToolTipTitle = "Подсказка";
            OwnerDraw = true;
            ForeColor = SystemColors.Control;
            Draw += new DrawToolTipEventHandler(DrawRender);
        }
        private void DrawRender(object sender, DrawToolTipEventArgs e){
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
        }
    }

    public struct RedGreenBlue{
        // Эта структура предназначена для упорядовачиния цветов в программе
        // основной цвет формы
        public static byte
            red = Convert.ToByte(Settings.Default["Bred"]),
            green = Convert.ToByte(Settings.Default["Bgreen"]),
            blue = Convert.ToByte(Settings.Default["Bblue"]);
        // неопределенный цвет

        public static byte
            Red1 = RegularRed(25),
            Green1 = RegularGreen(25),
            Blue1 = RegularBlue(25),
            Red2 = RegularRed(50),
            Green2 = RegularGreen(50),
            Blue2 = RegularBlue(50);

        public static Color 
            Color1 = Color.FromArgb(red, green, blue), 
            Color2 = Color.FromArgb(Red1, Green1, Blue1), 
            Color3 = Color.FromArgb(Red2, Green2, Blue2);

        public static byte RegularRed(byte index){
            try{
                return Convert.ToByte((int)red + (int)index);
            }
            catch (Exception){
                return Convert.ToByte((int)red - (int)index);
            }
        }

        public static byte RegularGreen(byte index){
            try{
                return Convert.ToByte((int)green + (int)index);
            }
            catch (Exception){
                return Convert.ToByte((int)green - (int)index);
            }
        }

        public static byte RegularBlue(byte index){
            try{
                return Convert.ToByte((int)blue + (int)index);
            }
            catch (Exception){
                return Convert.ToByte((int)blue - (int)index);
            }
        }
    }

    public abstract class PanelCustom : Panel {
        public PanelCustom() {
            Dock = DockStyle.Fill;
            Location = new Point(0, 0);
            Margin = new Padding(0);
            Size = new Size(487, 523);
            TabIndex = 0;
            SuspendLayout();
            ResumeLayout(false);
            PerformLayout();
            ForeColor = SystemColors.Control;
            TabStop = false;
        }
    }

    public class TBLayoutCustom : TableLayoutPanel{
        public TBLayoutCustom(Point point, Size size, Padding padding, string name, int rows = 2, int columns = 2)
        {
            Location = point;
            Size = size;
            Margin = padding;
            RowCount = rows;
            ColumnCount = columns;
            TabIndex = 0;
            TabStop = false;
            for (int i = 0; i < rows; i++)
                RowStyles.Add(new RowStyle(SizeType.Percent, 100 / rows));
            for (int i = 0; i < columns; i++)
                ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100 / columns));

            //for (var i = 0; i < rows; i++)
            //    for (var j = 0; j < columns; j++)
            //        Controls.Add(Children[i * columns + j], j, i);
            //Name = name;
        }
    }

    public class PictureCustom : PictureBox
    {
        public PictureCustom(Point point, Size size, Padding margin, PictureBoxSizeMode sizemode, string name)
        {
            Location = point;
            Size = size;
            Margin = margin;
            TabIndex = 0;
            TabStop = false;
            SizeMode = sizemode;
            Name = name;
        }
    }
}



