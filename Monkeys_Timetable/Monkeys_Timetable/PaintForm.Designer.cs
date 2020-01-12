namespace Monkeys_Timetable
{
    partial class PaintForm
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaintForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.读取文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.读取时刻表信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.读取车站信息ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.读取列车间隔信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.读取车站画图信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.绘制ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.绘制运行图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.绘制运行图上行ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.绘制运行图下行ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.绘制运行图上下行ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.检测ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.显示冲突列车数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.运行图标记冲突ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.计算ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.开行方案ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.显示开行方案数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出运行图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.框架图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.上行运行图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.下行运行图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.上下行运行图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出开行方案ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.计算ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.下行开行方案ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(22, 22);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.读取文件ToolStripMenuItem,
            this.绘制ToolStripMenuItem,
            this.检测ToolStripMenuItem,
            this.计算ToolStripMenuItem1,
            this.开行方案ToolStripMenuItem,
            this.导出ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(580, 29);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // 读取文件ToolStripMenuItem
            // 
            this.读取文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.读取时刻表信息ToolStripMenuItem,
            this.读取车站信息ToolStripMenuItem1,
            this.读取列车间隔信息ToolStripMenuItem,
            this.读取车站画图信息ToolStripMenuItem});
            this.读取文件ToolStripMenuItem.Name = "读取文件ToolStripMenuItem";
            this.读取文件ToolStripMenuItem.Size = new System.Drawing.Size(90, 27);
            this.读取文件ToolStripMenuItem.Text = "读取文件";
            this.读取文件ToolStripMenuItem.Click += new System.EventHandler(this.读取文件ToolStripMenuItem_Click);
            // 
            // 读取时刻表信息ToolStripMenuItem
            // 
            this.读取时刻表信息ToolStripMenuItem.Name = "读取时刻表信息ToolStripMenuItem";
            this.读取时刻表信息ToolStripMenuItem.Size = new System.Drawing.Size(226, 28);
            this.读取时刻表信息ToolStripMenuItem.Text = "读取时刻表信息";
            this.读取时刻表信息ToolStripMenuItem.Click += new System.EventHandler(this.读取时刻表信息ToolStripMenuItem_Click);
            // 
            // 读取车站信息ToolStripMenuItem1
            // 
            this.读取车站信息ToolStripMenuItem1.Name = "读取车站信息ToolStripMenuItem1";
            this.读取车站信息ToolStripMenuItem1.Size = new System.Drawing.Size(226, 28);
            this.读取车站信息ToolStripMenuItem1.Text = "读取车站信息";
            this.读取车站信息ToolStripMenuItem1.Click += new System.EventHandler(this.读取车站信息ToolStripMenuItem1_Click);
            // 
            // 读取列车间隔信息ToolStripMenuItem
            // 
            this.读取列车间隔信息ToolStripMenuItem.Name = "读取列车间隔信息ToolStripMenuItem";
            this.读取列车间隔信息ToolStripMenuItem.Size = new System.Drawing.Size(226, 28);
            this.读取列车间隔信息ToolStripMenuItem.Text = "读取列车间隔信息";
            this.读取列车间隔信息ToolStripMenuItem.Click += new System.EventHandler(this.读取列车间隔信息ToolStripMenuItem_Click);
            // 
            // 读取车站画图信息ToolStripMenuItem
            // 
            this.读取车站画图信息ToolStripMenuItem.Name = "读取车站画图信息ToolStripMenuItem";
            this.读取车站画图信息ToolStripMenuItem.Size = new System.Drawing.Size(226, 28);
            this.读取车站画图信息ToolStripMenuItem.Text = "读取车站画图信息";
            this.读取车站画图信息ToolStripMenuItem.Click += new System.EventHandler(this.读取车站画图信息ToolStripMenuItem_Click);
            // 
            // 绘制ToolStripMenuItem
            // 
            this.绘制ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.绘制运行图ToolStripMenuItem,
            this.绘制运行图上行ToolStripMenuItem,
            this.绘制运行图下行ToolStripMenuItem,
            this.绘制运行图上下行ToolStripMenuItem});
            this.绘制ToolStripMenuItem.Name = "绘制ToolStripMenuItem";
            this.绘制ToolStripMenuItem.Size = new System.Drawing.Size(56, 27);
            this.绘制ToolStripMenuItem.Text = "绘制";
            this.绘制ToolStripMenuItem.Click += new System.EventHandler(this.绘制ToolStripMenuItem_Click);
            // 
            // 绘制运行图ToolStripMenuItem
            // 
            this.绘制运行图ToolStripMenuItem.Name = "绘制运行图ToolStripMenuItem";
            this.绘制运行图ToolStripMenuItem.Size = new System.Drawing.Size(260, 28);
            this.绘制运行图ToolStripMenuItem.Text = "绘制运行图底图";
            this.绘制运行图ToolStripMenuItem.Click += new System.EventHandler(this.绘制运行图ToolStripMenuItem_Click_1);
            // 
            // 绘制运行图上行ToolStripMenuItem
            // 
            this.绘制运行图上行ToolStripMenuItem.Name = "绘制运行图上行ToolStripMenuItem";
            this.绘制运行图上行ToolStripMenuItem.Size = new System.Drawing.Size(260, 28);
            this.绘制运行图上行ToolStripMenuItem.Text = "绘制运行图（上行）";
            this.绘制运行图上行ToolStripMenuItem.Click += new System.EventHandler(this.绘制运行图上行ToolStripMenuItem_Click);
            // 
            // 绘制运行图下行ToolStripMenuItem
            // 
            this.绘制运行图下行ToolStripMenuItem.Name = "绘制运行图下行ToolStripMenuItem";
            this.绘制运行图下行ToolStripMenuItem.Size = new System.Drawing.Size(260, 28);
            this.绘制运行图下行ToolStripMenuItem.Text = "绘制运行图（下行）";
            this.绘制运行图下行ToolStripMenuItem.Click += new System.EventHandler(this.绘制运行图下行ToolStripMenuItem_Click);
            // 
            // 绘制运行图上下行ToolStripMenuItem
            // 
            this.绘制运行图上下行ToolStripMenuItem.Name = "绘制运行图上下行ToolStripMenuItem";
            this.绘制运行图上下行ToolStripMenuItem.Size = new System.Drawing.Size(260, 28);
            this.绘制运行图上下行ToolStripMenuItem.Text = "绘制运行图（上下行）";
            this.绘制运行图上下行ToolStripMenuItem.Click += new System.EventHandler(this.绘制运行图上下行ToolStripMenuItem_Click);
            // 
            // 检测ToolStripMenuItem
            // 
            this.检测ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.显示冲突列车数据ToolStripMenuItem,
            this.运行图标记冲突ToolStripMenuItem});
            this.检测ToolStripMenuItem.Name = "检测ToolStripMenuItem";
            this.检测ToolStripMenuItem.Size = new System.Drawing.Size(56, 27);
            this.检测ToolStripMenuItem.Text = "检测";
            this.检测ToolStripMenuItem.Click += new System.EventHandler(this.检测ToolStripMenuItem_Click);
            // 
            // 显示冲突列车数据ToolStripMenuItem
            // 
            this.显示冲突列车数据ToolStripMenuItem.Name = "显示冲突列车数据ToolStripMenuItem";
            this.显示冲突列车数据ToolStripMenuItem.Size = new System.Drawing.Size(226, 28);
            this.显示冲突列车数据ToolStripMenuItem.Text = "显示冲突列车数据";
            this.显示冲突列车数据ToolStripMenuItem.Click += new System.EventHandler(this.显示冲突列车数据ToolStripMenuItem_Click);
            // 
            // 运行图标记冲突ToolStripMenuItem
            // 
            this.运行图标记冲突ToolStripMenuItem.Name = "运行图标记冲突ToolStripMenuItem";
            this.运行图标记冲突ToolStripMenuItem.Size = new System.Drawing.Size(226, 28);
            this.运行图标记冲突ToolStripMenuItem.Text = "运行图标记冲突";
            this.运行图标记冲突ToolStripMenuItem.Click += new System.EventHandler(this.运行图标记冲突ToolStripMenuItem_Click);
            // 
            // 计算ToolStripMenuItem1
            // 
            this.计算ToolStripMenuItem1.Name = "计算ToolStripMenuItem1";
            this.计算ToolStripMenuItem1.Size = new System.Drawing.Size(56, 27);
            this.计算ToolStripMenuItem1.Text = "计算";
            this.计算ToolStripMenuItem1.Click += new System.EventHandler(this.计算ToolStripMenuItem1_Click);
            // 
            // 开行方案ToolStripMenuItem
            // 
            this.开行方案ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.显示开行方案数据ToolStripMenuItem,
            this.下行开行方案ToolStripMenuItem});
            this.开行方案ToolStripMenuItem.Name = "开行方案ToolStripMenuItem";
            this.开行方案ToolStripMenuItem.Size = new System.Drawing.Size(90, 27);
            this.开行方案ToolStripMenuItem.Text = "开行方案";
            this.开行方案ToolStripMenuItem.Click += new System.EventHandler(this.开行方案ToolStripMenuItem_Click);
            // 
            // 显示开行方案数据ToolStripMenuItem
            // 
            this.显示开行方案数据ToolStripMenuItem.Name = "显示开行方案数据ToolStripMenuItem";
            this.显示开行方案数据ToolStripMenuItem.Size = new System.Drawing.Size(238, 28);
            this.显示开行方案数据ToolStripMenuItem.Text = "上行开行方案";
            this.显示开行方案数据ToolStripMenuItem.Click += new System.EventHandler(this.显示开行方案数据ToolStripMenuItem_Click);
            // 
            // 导出ToolStripMenuItem
            // 
            this.导出ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.导出运行图ToolStripMenuItem,
            this.导出开行方案ToolStripMenuItem});
            this.导出ToolStripMenuItem.Name = "导出ToolStripMenuItem";
            this.导出ToolStripMenuItem.Size = new System.Drawing.Size(56, 27);
            this.导出ToolStripMenuItem.Text = "导出";
            // 
            // 导出运行图ToolStripMenuItem
            // 
            this.导出运行图ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.框架图ToolStripMenuItem,
            this.上行运行图ToolStripMenuItem,
            this.下行运行图ToolStripMenuItem,
            this.上下行运行图ToolStripMenuItem});
            this.导出运行图ToolStripMenuItem.Name = "导出运行图ToolStripMenuItem";
            this.导出运行图ToolStripMenuItem.Size = new System.Drawing.Size(192, 28);
            this.导出运行图ToolStripMenuItem.Text = "导出运行图";
            // 
            // 框架图ToolStripMenuItem
            // 
            this.框架图ToolStripMenuItem.Name = "框架图ToolStripMenuItem";
            this.框架图ToolStripMenuItem.Size = new System.Drawing.Size(192, 28);
            this.框架图ToolStripMenuItem.Text = "运行图底图";
            this.框架图ToolStripMenuItem.Click += new System.EventHandler(this.框架图ToolStripMenuItem_Click);
            // 
            // 上行运行图ToolStripMenuItem
            // 
            this.上行运行图ToolStripMenuItem.Name = "上行运行图ToolStripMenuItem";
            this.上行运行图ToolStripMenuItem.Size = new System.Drawing.Size(192, 28);
            this.上行运行图ToolStripMenuItem.Text = "上行运行图";
            this.上行运行图ToolStripMenuItem.Click += new System.EventHandler(this.上行运行图ToolStripMenuItem_Click);
            // 
            // 下行运行图ToolStripMenuItem
            // 
            this.下行运行图ToolStripMenuItem.Name = "下行运行图ToolStripMenuItem";
            this.下行运行图ToolStripMenuItem.Size = new System.Drawing.Size(192, 28);
            this.下行运行图ToolStripMenuItem.Text = "下行运行图";
            this.下行运行图ToolStripMenuItem.Click += new System.EventHandler(this.下行运行图ToolStripMenuItem_Click);
            // 
            // 上下行运行图ToolStripMenuItem
            // 
            this.上下行运行图ToolStripMenuItem.Name = "上下行运行图ToolStripMenuItem";
            this.上下行运行图ToolStripMenuItem.Size = new System.Drawing.Size(192, 28);
            this.上下行运行图ToolStripMenuItem.Text = "上下行运行图";
            this.上下行运行图ToolStripMenuItem.Click += new System.EventHandler(this.上下行运行图ToolStripMenuItem_Click);
            // 
            // 导出开行方案ToolStripMenuItem
            // 
            this.导出开行方案ToolStripMenuItem.Name = "导出开行方案ToolStripMenuItem";
            this.导出开行方案ToolStripMenuItem.Size = new System.Drawing.Size(192, 28);
            this.导出开行方案ToolStripMenuItem.Text = "导出开行方案";
            // 
            // 计算ToolStripMenuItem
            // 
            this.计算ToolStripMenuItem.Name = "计算ToolStripMenuItem";
            this.计算ToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            this.计算ToolStripMenuItem.Text = "计算";
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(1365, 6);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(72, 23);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "上行";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.Location = new System.Drawing.Point(1446, 6);
            this.checkBox2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(72, 23);
            this.checkBox2.TabIndex = 0;
            this.checkBox2.Text = "下行";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.Location = new System.Drawing.Point(0, 33);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(2400, 1000);
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TimetableViewCtrl_MouseMove);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(377, 130);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(514, 422);
            this.dataGridView1.TabIndex = 9;
            this.dataGridView1.Visible = false;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(1846, 6);
            this.checkBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(132, 21);
            this.checkBox3.TabIndex = 11;
            this.checkBox3.Text = "显示详细信息";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(0, 33);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 29;
            this.dataGridView2.Size = new System.Drawing.Size(674, 107);
            this.dataGridView2.TabIndex = 12;
            this.dataGridView2.Visible = false;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick_1);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Location = new System.Drawing.Point(500, 0);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(60, 33);
            this.button1.TabIndex = 13;
            this.button1.Text = "放大";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.Location = new System.Drawing.Point(568, 0);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(60, 33);
            this.button2.TabIndex = 14;
            this.button2.Text = "缩小";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // 下行开行方案ToolStripMenuItem
            // 
            this.下行开行方案ToolStripMenuItem.Name = "下行开行方案ToolStripMenuItem";
            this.下行开行方案ToolStripMenuItem.Size = new System.Drawing.Size(238, 28);
            this.下行开行方案ToolStripMenuItem.Text = "下行开行方案";
            this.下行开行方案ToolStripMenuItem.Click += new System.EventHandler(this.下行开行方案ToolStripMenuItem_Click);
            // 
            // PaintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1444, 822);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "PaintForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "运行图显示及检测分析工具V1.0";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PaintForm_Load);
            this.Scroll += new System.Windows.Forms.ScrollEventHandler(this.PaintForm_Scroll);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem 读取文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 读取时刻表信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 读取车站信息ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 读取列车间隔信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 绘制ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 绘制运行图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 检测ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 计算ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 计算ToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.ToolStripMenuItem 显示冲突列车数据ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 运行图标记冲突ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 开行方案ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 显示开行方案数据ToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ToolStripMenuItem 绘制运行图上行ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 绘制运行图下行ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 绘制运行图上下行ToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripMenuItem 读取车站画图信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出运行图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 框架图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出开行方案ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 上行运行图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 下行运行图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 上下行运行图ToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolStripMenuItem 下行开行方案ToolStripMenuItem;
    }
}
