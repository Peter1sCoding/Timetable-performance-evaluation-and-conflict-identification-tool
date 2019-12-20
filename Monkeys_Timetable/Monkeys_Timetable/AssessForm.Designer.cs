namespace Monkeys_Timetable
{
    partial class AssessForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.绘制区间列车密度图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查询列车停站信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.查询车站服务列车ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.绘制区间列车密度图ToolStripMenuItem,
            this.查询列车停站信息ToolStripMenuItem,
            this.查询车站服务列车ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1047, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 绘制区间列车密度图ToolStripMenuItem
            // 
            this.绘制区间列车密度图ToolStripMenuItem.Name = "绘制区间列车密度图ToolStripMenuItem";
            this.绘制区间列车密度图ToolStripMenuItem.Size = new System.Drawing.Size(158, 24);
            this.绘制区间列车密度图ToolStripMenuItem.Text = "绘制区间列车密度图";
            this.绘制区间列车密度图ToolStripMenuItem.Click += new System.EventHandler(this.绘制区间列车密度图ToolStripMenuItem_Click);
            // 
            // 查询列车停站信息ToolStripMenuItem
            // 
            this.查询列车停站信息ToolStripMenuItem.Name = "查询列车停站信息ToolStripMenuItem";
            this.查询列车停站信息ToolStripMenuItem.Size = new System.Drawing.Size(143, 24);
            this.查询列车停站信息ToolStripMenuItem.Text = "查询列车停站信息";
            this.查询列车停站信息ToolStripMenuItem.Click += new System.EventHandler(this.查询列车停站信息ToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 28);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1047, 592);
            this.splitContainer1.SplitterDistance = 384;
            this.splitContainer1.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.splitContainer2.Size = new System.Drawing.Size(384, 592);
            this.splitContainer2.SplitterDistance = 235;
            this.splitContainer2.TabIndex = 0;
            // 
            // 查询车站服务列车ToolStripMenuItem
            // 
            this.查询车站服务列车ToolStripMenuItem.Name = "查询车站服务列车ToolStripMenuItem";
            this.查询车站服务列车ToolStripMenuItem.Size = new System.Drawing.Size(143, 24);
            this.查询车站服务列车ToolStripMenuItem.Text = "查询车站服务列车";
            // 
            // AssessForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1047, 620);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AssessForm";
            this.Text = "运行图指标统计";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 绘制区间列车密度图ToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ToolStripMenuItem 查询列车停站信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查询车站服务列车ToolStripMenuItem;
    }
}