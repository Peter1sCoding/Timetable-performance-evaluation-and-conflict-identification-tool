using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Monkeys_Timetable
{

    //运行图界面类，实现输入到发时刻数据后，绘制可缩放的运行图，最好站名线根据用户输入确定
    public partial class DrawTimetable : Form
    {
        Button openFile;
        TextBox fileName;
        Label input;
        string file;
        public DrawTimetable()
        {
            InitializeComponent();

            this.Size = new Size(1300, 700);
            this.Text = "高速铁路运行图冲突检测与评估系统 V1.0";

            openFile = new Button();
            openFile.Size = new Size(50, 25);
            openFile.Text = "读取";
            openFile.Location = new Point(800, 550);

            fileName = new TextBox();
            fileName.Size = new Size(160, 60);
            fileName.Location = new Point(630, 550);

            input = new Label();
            input.Size = new Size(160, 40);
            input.Location = new Point(510, 555);
            input.Text = "请输入列车到发时刻";

            this.Controls.Add(openFile);
            this.Controls.Add(fileName);
            this.Controls.Add(input);

            openFile.Click += openFile_Click;


        }
        public void openFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;
            dialog.Title = "请选择文件夹";
            dialog.Filter = "所有文件(*.*)|*.*";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                file = dialog.FileName;
            }
        }
    }
}
