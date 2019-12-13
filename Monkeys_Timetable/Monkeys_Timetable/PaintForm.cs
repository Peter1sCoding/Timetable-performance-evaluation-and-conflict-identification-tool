using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Monkeys_Timetable
{
    public partial class PaintForm : Form //实现绘制运行图的界面
    {
        string traFileName;
        string staFileName;
        string headFileName;
        DataManager dm;
        Conflict_Indentification ci;
        public PaintForm()
        {
            InitializeComponent();
            this.Size = new Size(1300, 650);
            dm = new DataManager();
        }

        private void PaintForm_Load(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void 读取文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void 读取车站信息ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;
            dialog.Title = "请选择文件夹";
            dialog.Filter = "所有文件(*.*)|*.*";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                staFileName = dialog.FileName;
            }
            dm.ReadStation(staFileName);
        }

        private void 读取时刻表信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;
            dialog.Title = "请选择文件夹";
            dialog.Filter = "所有文件(*.*)|*.*";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                traFileName = dialog.FileName;
            }
            dm.ReadTrain(traFileName);
            dm.DivideUpDown();
            dm.AddTra2sta();
            dm.GetStop();
            for(int i = 0; i < dm.stationList[0].upStaTraArrList.Count; i++)
            {
                Console.WriteLine(dm.stationList[0].upStaTraArrList[i].trainNo + "," + dm.stationList[0].upStaTraArrList[i].MinuteDic[dm.stationList[0].stationName][0] + "," + dm.stationList[0].upStaTraArrList[i].MinuteDic[dm.stationList[0].stationName][1]);
            }
        }

        private void 读取列车间隔信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;
            dialog.Title = "请选择文件夹";
            dialog.Filter = "所有文件(*.*)|*.*";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                headFileName = dialog.FileName;
            }
            dm.ReadHeadway(headFileName);
        }

        private void 图像ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        public void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void 绘制运行图ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 绘制ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void 冲突检测ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ci = new Conflict_Indentification(dm.stationList, dm.HeadwayDic);
            ci.Conflict_Judge();
            for(int i = 0; i < ci.stationList.Count; i++)
            {
                for(int j = 0; j < ci.stationList[i].upStaTraArrList.Count; j++)
                {
                    foreach (KeyValuePair<string, Train> Conflict in ci.stationList[i].upStaTraArrList[j].ConflictTrain)//给trainList赋值
                    {
                        Console.WriteLine(Conflict.Key);
                    }

                }
            }
        }
    }
}
