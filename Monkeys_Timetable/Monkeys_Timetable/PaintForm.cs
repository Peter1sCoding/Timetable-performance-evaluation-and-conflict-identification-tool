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
        DataTable ConflictTable;

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
            
            this.panel1.HorizontalScroll.Visible = true;
            this.panel1.VerticalScroll.Visible = true;

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
            gs = this.panel1.CreateGraphics();        
            int ix = dm.stationList.Count;
            double total = dm.stationList[ix - 1].totalMile;
            List<double> staMile = new List<double>();
            for (int i = 0; i < ix; i++)
            {
                staMile.Add(dm.stationList[i].totalMile);
            }
            if (checkBox1.Checked==true)
            {
                pt.TimetableFrame(this.panel1.Width, this.panel1.Height, total, staMile, gs);
                pt.TrainLine(gs, dm.upTrainList, dm.stationStringList);
            }
            else
            {
                gs.Clear(this.panel1.BackColor);
                pt.TimetableFrame(this.panel1.Width, this.panel1.Height, total, staMile, gs);
            }

        }//上行运行图的绘制

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            Graphics gs;
            gs = this.panel1.CreateGraphics();
            int ix = dm.stationList.Count;
            double total = dm.stationList[ix - 1].totalMile;
            List<double> staMile = new List<double>();
            for (int i = 0; i < ix; i++)
            {
                staMile.Add(dm.stationList[i].totalMile);
            }            
            if (checkBox2.Checked == true)
            {
                pt.TimetableFrame(this.panel1.Width, this.panel1.Height, total, staMile, gs);
                pt.TrainLine(gs, dm.downTrainList, dm.stationStringList);
            }
            else
            {
                gs.Clear(this.panel1.BackColor);
                pt.TimetableFrame(this.panel1.Width, this.panel1.Height, total, staMile, gs);
            }
        }//下行运行图的绘制

        private void panel3_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void 开行方案数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LinePlan lp = new LinePlan();
            lp.Show();
        }

        private void 检测ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Conflict_Identification ci = new Conflict_Identification(dm.stationList,dm.HeadwayDic,dm.TrainDic);
            ci.Conflict_Judge();
            ConflictTable = ci.ToDataTable();
        }

        private void 显示冲突列车数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConflictForm cf = new ConflictForm(ConflictTable);
            cf.Show();
        }

        private void 显示开行方案数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LinePlan lp = new LinePlan();
            lp.Show();
        }

        private void 运行图标记冲突ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Graphics gs = this.panel1.CreateGraphics();
            if (checkBox1.Checked)
            {
                pt.ConflictDrawUp(gs, ConflictTable, dm.TrainDic, dm.stationStringList);
            }
            else if (checkBox2.Checked)
            {
                pt.ConflictDrawDown(gs, ConflictTable, dm.TrainDic, dm.stationStringList);
            }
        }

        private void 计算ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AssessForm af = new AssessForm();
            af.Show();
        }

        private void panel1_Paint_2(object sender, PaintEventArgs e)
        {

        }
    }
}
