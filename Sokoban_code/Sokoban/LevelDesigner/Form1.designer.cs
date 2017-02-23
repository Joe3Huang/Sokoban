namespace LevelDesigner
{
    partial class Form1
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
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emptyBtn = new System.Windows.Forms.Button();
            this.boxBtn = new System.Windows.Forms.Button();
            this.playerBtn = new System.Windows.Forms.Button();
            this.goalBtn = new System.Windows.Forms.Button();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.setSizeBtn = new System.Windows.Forms.Button();
            this.btnGridPanel = new System.Windows.Forms.Panel();
            this.cleanBtn = new System.Windows.Forms.Button();
            this.wallBtn = new System.Windows.Forms.Button();
            this.menuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip2
            // 
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(994, 24);
            this.menuStrip2.TabIndex = 6;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newProjectToolStripMenuItem,
            this.openPToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newProjectToolStripMenuItem
            // 
            this.newProjectToolStripMenuItem.Name = "newProjectToolStripMenuItem";
            this.newProjectToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.newProjectToolStripMenuItem.Text = "New";
            this.newProjectToolStripMenuItem.Click += new System.EventHandler(this.newProjectToolStripMenuItem_Click);
            // 
            // openPToolStripMenuItem
            // 
            this.openPToolStripMenuItem.Name = "openPToolStripMenuItem";
            this.openPToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openPToolStripMenuItem.Text = "Open";
            this.openPToolStripMenuItem.Click += new System.EventHandler(this.openPToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // emptyBtn
            // 
            this.emptyBtn.Location = new System.Drawing.Point(505, 431);
            this.emptyBtn.Margin = new System.Windows.Forms.Padding(20);
            this.emptyBtn.Name = "emptyBtn";
            this.emptyBtn.Size = new System.Drawing.Size(75, 23);
            this.emptyBtn.TabIndex = 14;
            this.emptyBtn.Text = "Empty";
            this.emptyBtn.UseVisualStyleBackColor = true;
            this.emptyBtn.Click += new System.EventHandler(this.emptyBtn_Click);
            // 
            // boxBtn
            // 
            this.boxBtn.Location = new System.Drawing.Point(275, 431);
            this.boxBtn.Margin = new System.Windows.Forms.Padding(20);
            this.boxBtn.Name = "boxBtn";
            this.boxBtn.Size = new System.Drawing.Size(75, 23);
            this.boxBtn.TabIndex = 12;
            this.boxBtn.Text = "Box$";
            this.boxBtn.UseVisualStyleBackColor = true;
            this.boxBtn.Click += new System.EventHandler(this.boxBtn_Click);
            // 
            // playerBtn
            // 
            this.playerBtn.Location = new System.Drawing.Point(160, 431);
            this.playerBtn.Margin = new System.Windows.Forms.Padding(20);
            this.playerBtn.Name = "playerBtn";
            this.playerBtn.Size = new System.Drawing.Size(75, 23);
            this.playerBtn.TabIndex = 11;
            this.playerBtn.Text = "Player@";
            this.playerBtn.UseVisualStyleBackColor = true;
            this.playerBtn.Click += new System.EventHandler(this.playerBtn_Click);
            // 
            // goalBtn
            // 
            this.goalBtn.Location = new System.Drawing.Point(390, 431);
            this.goalBtn.Margin = new System.Windows.Forms.Padding(20);
            this.goalBtn.Name = "goalBtn";
            this.goalBtn.Size = new System.Drawing.Size(75, 23);
            this.goalBtn.TabIndex = 13;
            this.goalBtn.Text = "Goal.";
            this.goalBtn.UseVisualStyleBackColor = true;
            this.goalBtn.Click += new System.EventHandler(this.goalBtn_Click);
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(63, 38);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDown2.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown2.TabIndex = 9;
            this.numericUpDown2.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Height :";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(63, 12);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 4;
            this.numericUpDown1.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Width :";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.numericUpDown1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.numericUpDown2);
            this.panel1.Location = new System.Drawing.Point(761, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(198, 73);
            this.panel1.TabIndex = 10;
            // 
            // setSizeBtn
            // 
            this.setSizeBtn.Location = new System.Drawing.Point(761, 152);
            this.setSizeBtn.Name = "setSizeBtn";
            this.setSizeBtn.Size = new System.Drawing.Size(75, 23);
            this.setSizeBtn.TabIndex = 15;
            this.setSizeBtn.Text = "Set size";
            this.setSizeBtn.UseVisualStyleBackColor = true;
            this.setSizeBtn.Click += new System.EventHandler(this.setSizeBtn_Click);
            // 
            // btnGridPanel
            // 
            this.btnGridPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnGridPanel.Location = new System.Drawing.Point(45, 55);
            this.btnGridPanel.Name = "btnGridPanel";
            this.btnGridPanel.Size = new System.Drawing.Size(673, 346);
            this.btnGridPanel.TabIndex = 16;
            this.btnGridPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.btnGridPanel_Paint_1);
            // 
            // cleanBtn
            // 
            this.cleanBtn.Location = new System.Drawing.Point(761, 192);
            this.cleanBtn.Name = "cleanBtn";
            this.cleanBtn.Size = new System.Drawing.Size(75, 23);
            this.cleanBtn.TabIndex = 17;
            this.cleanBtn.Text = "Clean";
            this.cleanBtn.UseVisualStyleBackColor = true;
            this.cleanBtn.Click += new System.EventHandler(this.cleanBtn_Click);
            // 
            // wallBtn
            // 
            this.wallBtn.Location = new System.Drawing.Point(45, 431);
            this.wallBtn.Margin = new System.Windows.Forms.Padding(20);
            this.wallBtn.Name = "wallBtn";
            this.wallBtn.Size = new System.Drawing.Size(75, 23);
            this.wallBtn.TabIndex = 0;
            this.wallBtn.Text = "Wall#";
            this.wallBtn.UseVisualStyleBackColor = true;
            this.wallBtn.Click += new System.EventHandler(this.wallBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 497);
            this.Controls.Add(this.wallBtn);
            this.Controls.Add(this.cleanBtn);
            this.Controls.Add(this.btnGridPanel);
            this.Controls.Add(this.setSizeBtn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.emptyBtn);
            this.Controls.Add(this.playerBtn);
            this.Controls.Add(this.goalBtn);
            this.Controls.Add(this.boxBtn);
            this.Controls.Add(this.menuStrip2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Button goalBtn;
        private System.Windows.Forms.Button playerBtn;
        private System.Windows.Forms.Button boxBtn;
        private System.Windows.Forms.Button emptyBtn;
        private System.Windows.Forms.Button wallBtn;
        private System.Windows.Forms.Button setSizeBtn;
        private System.Windows.Forms.Panel btnGridPanel;
        private System.Windows.Forms.Button cleanBtn;
    }
}

