using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Monkeys_Timetable
{
    public partial class PaintForm : Form //实现绘制运行图的界面
    {
        string filename;
        public PaintForm()
        {
            InitializeComponent();
            this.Size = new Size(1300, 650);
            
            
        }

        private void PaintForm_Load(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void 读取文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           OpenFileDialog dialog = new OpenFileDialog();
           dialog.Multiselect = true;
           dialog.Title = "请选择文件夹";
           dialog.Filter = "所有文件(*.*)|*.*";
           if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
           {
              filename = dialog.FileName;
           }
            DataManager dm = new DataManager();
            dm.ReadFile(filename);
            Console.Write(dm.trainDic["G9245"].staTimeDic["南京南"][0]);
            

        }
    }
}
