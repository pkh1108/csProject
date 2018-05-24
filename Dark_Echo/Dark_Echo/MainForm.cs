using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dark_Echo
{
    public partial class MainForm : Form
    {
       
        public MainForm()
        {
            InitializeComponent();
           
        }

        //private void MainForm_Paint(object sender, PaintEventArgs e)
        //{
           

        //    //PrivateFontCollection privateFonts = new PrivateFontCollection();
        //    //Graphics g = CreateGraphics();

        //    //// 오프닝 제목
        //    //privateFonts.AddFontFile("AmaticSC-Bold.ttf");
        //    //Font f = new Font(privateFonts.Families[0], 100);
        //    //g.DrawString("Dark  Echo", f, Brushes.White, 1000 / 4, 1000 / 8);
        //    //f.Dispose();

        //    //// 플레이 버튼
        //    //string s = "P L A Y";
        //    //f = new Font(privateFonts.Families[0], 50);
        //    //SizeF sf = g.MeasureString(s, f);
        //    //g.DrawString(s, f, Brushes.White, 1000 / 5 * 2, 1000 / 2);
        //    //g.DrawRectangle(Pens.White, 1000 / 5 * 2, 1000 / 2, sf.Width, sf.Height);
        //    //f.Dispose();

        //    //privateFonts.Dispose();
            
        //}

        private void MainForm_Load(object sender, EventArgs e)
        {
           
           
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            Game f = new Game();
            f.ShowDialog();
           
        }
    }
}
