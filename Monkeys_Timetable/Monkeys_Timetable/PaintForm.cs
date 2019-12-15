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
        Conflict_Identification ci;
        DataTable dt;
        PaintTool pt = new PaintTool();
        public PaintForm()
        {
            InitializeComponent();
            this.Size = new Size(1300, 650);
            dm = new DataManager();
            dm.ReadHeadway(Application.StartupPath + @"\\车站列车安全间隔.csv");
            dm.ReadStation(Application.StartupPath + @"\\沪宁车站信息.csv");
            dm.ReadTrain(Application.StartupPath + @"\\沪宁时刻图.csv");
            dm.DivideUpDown();
            dm.AddTra2sta();
            dm.GetStop();
            for(int i = 0; i < dm.stationList[3].upStaTraArrList.Count; i++)
            {
             Console.WriteLine(dm.stationList[3].upStaTraArrList[i].trainNo + "," + dm.stationList[3].upStaTraArrList[i].MinuteDic[dm.stationList[3].stationName][0] + "," + dm.stationList[3].upStaTraArrList[i].MinuteDic[dm.stationList[3].stationName][1]);
            }
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

        

        private void 冲突检测ToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void 冲突检测数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ci = new Conflict_Identification(dm.stationList, dm.HeadwayDic, dm.TrainDic);
            ci.Conflict_Judge();
            dt = ci.ToDataTable();
            ConflictForm cf = new ConflictForm(dt);
            cf.Show();
        }

        private void 绘制运行图ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Graphics gs;
            gs = this.panel1.CreateGraphics();
            int ix = dm.stationList.Count;
            double total = dm.stationList[ix - 1].totalMile;
            List<double> staMile = new List<double>();
            for(int i=0;i<ix;i++)
            {
                staMile.Add(dm.stationList[i].totalMile);
            }
            pt.TimetableFrame(this.panel1.Width, this.panel1.Height, total, staMile, gs);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Graphics gs;
            gs = this.panel2.CreateGraphics();
            if (checkBox1.Checked==true)
            {
                panel2.Visible = true;
                pt.TrainLine(gs, dm.upTrainList, dm.stationStringList);
            }
            else
            {
                panel2.Visible = false;
            }

        }//上行运行图的绘制

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            Graphics gs;
            gs = this.panel3.CreateGraphics();
            if (checkBox2.Checked == true)
            {
                panel3.Visible = true;
                pt.TrainLine(gs, dm.upTrainList, dm.stationStringList);
            }
            else
            {
                panel3.Visible = false;
            }
        }//下行运行图的绘制
    }
}
