namespace pcapTest
{
    partial class MainForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.chooseInterfaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.listView1 = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
			this.label2 = new System.Windows.Forms.Label();
			this.startClient1 = new System.Windows.Forms.Button();
			this.startClient2 = new System.Windows.Forms.Button();
			this.repeatClient1Chk = new System.Windows.Forms.CheckBox();
			this.repeatClient2Chk = new System.Windows.Forms.CheckBox();
			this.acceptRequestBtn1 = new System.Windows.Forms.Button();
			this.acceptRequestBtn2 = new System.Windows.Forms.Button();
			this.mainCharIDTxt = new System.Windows.Forms.TextBox();
			this.stopClient1Btn = new System.Windows.Forms.Button();
			this.stopClien2Btn = new System.Windows.Forms.Button();
			this.openInvClient1Btn = new System.Windows.Forms.Button();
			this.openInvClient2Btn = new System.Windows.Forms.Button();
			this.charsClient1List = new System.Windows.Forms.ListBox();
			this.enterGameClient1Btn = new System.Windows.Forms.Button();
			this.client1TerminalBox = new System.Windows.Forms.TextBox();
			this.menuStrip1.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
			this.menuStrip1.Size = new System.Drawing.Size(886, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chooseInterfaceToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// chooseInterfaceToolStripMenuItem
			// 
			this.chooseInterfaceToolStripMenuItem.Name = "chooseInterfaceToolStripMenuItem";
			this.chooseInterfaceToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
			this.chooseInterfaceToolStripMenuItem.Text = "Choose interface";
			this.chooseInterfaceToolStripMenuItem.Click += new System.EventHandler(this.chooseInterfaceToolStripMenuItem_Click);
			// 
			// viewToolStripMenuItem
			// 
			this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
			this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.viewToolStripMenuItem.Text = "View";
			// 
			// listView1
			// 
			this.listView1.AllowColumnReorder = true;
			this.listView1.AutoArrange = false;
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
			this.listView1.FullRowSelect = true;
			this.listView1.GridLines = true;
			this.listView1.HideSelection = false;
			this.listView1.Location = new System.Drawing.Point(9, 113);
			this.listView1.Margin = new System.Windows.Forms.Padding(2);
			this.listView1.MultiSelect = false;
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(185, 277);
			this.listView1.TabIndex = 3;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = System.Windows.Forms.View.Details;
			this.listView1.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listView1_ItemSelectionChanged);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Number";
			this.columnHeader1.Width = 70;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Time";
			this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader2.Width = 100;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Source";
			this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader3.Width = 140;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Destination";
			this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader4.Width = 140;
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "Protocol";
			this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader5.Width = 70;
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "Length";
			this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader6.Width = 80;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(9, 79);
			this.textBox1.Margin = new System.Windows.Forms.Padding(2);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(185, 20);
			this.textBox1.TabIndex = 6;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(6, 408);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(125, 17);
			this.label1.TabIndex = 8;
			this.label1.Text = "Packet Information";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(9, 436);
			this.textBox2.Margin = new System.Windows.Forms.Padding(2);
			this.textBox2.Multiline = true;
			this.textBox2.Name = "textBox2";
			this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBox2.Size = new System.Drawing.Size(185, 114);
			this.textBox2.TabIndex = 9;
			// 
			// toolStrip1
			// 
			this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripButton5,
            this.toolStripButton6});
			this.toolStrip1.Location = new System.Drawing.Point(0, 24);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(886, 27);
			this.toolStrip1.TabIndex = 11;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// toolStripButton1
			// 
			this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
			this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton1.Name = "toolStripButton1";
			this.toolStripButton1.Size = new System.Drawing.Size(24, 24);
			this.toolStripButton1.Text = "toolStripButton1";
			this.toolStripButton1.ToolTipText = "Start sniffing";
			this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
			// 
			// toolStripButton2
			// 
			this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
			this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton2.Name = "toolStripButton2";
			this.toolStripButton2.Size = new System.Drawing.Size(24, 24);
			this.toolStripButton2.Text = "toolStripButton2";
			this.toolStripButton2.ToolTipText = "Stop sniffing";
			this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
			// 
			// toolStripButton3
			// 
			this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
			this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton3.Name = "toolStripButton3";
			this.toolStripButton3.Size = new System.Drawing.Size(24, 24);
			this.toolStripButton3.Text = "toolStripButton3";
			this.toolStripButton3.ToolTipText = "Previous packet";
			this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
			// 
			// toolStripButton4
			// 
			this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
			this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton4.Name = "toolStripButton4";
			this.toolStripButton4.Size = new System.Drawing.Size(24, 24);
			this.toolStripButton4.Text = "toolStripButton4";
			this.toolStripButton4.ToolTipText = "Next packet";
			this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
			// 
			// toolStripButton5
			// 
			this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
			this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton5.Name = "toolStripButton5";
			this.toolStripButton5.Size = new System.Drawing.Size(24, 24);
			this.toolStripButton5.Text = "toolStripButton5";
			this.toolStripButton5.ToolTipText = "First packet";
			this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
			// 
			// toolStripButton6
			// 
			this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
			this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton6.Name = "toolStripButton6";
			this.toolStripButton6.Size = new System.Drawing.Size(24, 24);
			this.toolStripButton6.Text = "toolStripButton6";
			this.toolStripButton6.ToolTipText = "Last packet";
			this.toolStripButton6.Click += new System.EventHandler(this.toolStripButton6_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(6, 53);
			this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(96, 17);
			this.label2.TabIndex = 12;
			this.label2.Text = "Filter packets:";
			// 
			// startClient1
			// 
			this.startClient1.Location = new System.Drawing.Point(199, 135);
			this.startClient1.Name = "startClient1";
			this.startClient1.Size = new System.Drawing.Size(75, 27);
			this.startClient1.TabIndex = 13;
			this.startClient1.Text = "start client 1";
			this.startClient1.UseVisualStyleBackColor = true;
			this.startClient1.Click += new System.EventHandler(this.startClient1_Click);
			// 
			// startClient2
			// 
			this.startClient2.Location = new System.Drawing.Point(542, 135);
			this.startClient2.Name = "startClient2";
			this.startClient2.Size = new System.Drawing.Size(75, 27);
			this.startClient2.TabIndex = 16;
			this.startClient2.Text = "start client 2";
			this.startClient2.UseVisualStyleBackColor = true;
			this.startClient2.Click += new System.EventHandler(this.startClient2_Click);
			// 
			// repeatClient1Chk
			// 
			this.repeatClient1Chk.AutoSize = true;
			this.repeatClient1Chk.Location = new System.Drawing.Point(199, 112);
			this.repeatClient1Chk.Name = "repeatClient1Chk";
			this.repeatClient1Chk.Size = new System.Drawing.Size(70, 17);
			this.repeatClient1Chk.TabIndex = 18;
			this.repeatClient1Chk.Text = "Repeat 1";
			this.repeatClient1Chk.UseVisualStyleBackColor = true;
			// 
			// repeatClient2Chk
			// 
			this.repeatClient2Chk.AutoSize = true;
			this.repeatClient2Chk.Location = new System.Drawing.Point(542, 112);
			this.repeatClient2Chk.Name = "repeatClient2Chk";
			this.repeatClient2Chk.Size = new System.Drawing.Size(70, 17);
			this.repeatClient2Chk.TabIndex = 19;
			this.repeatClient2Chk.Text = "Repeat 2";
			this.repeatClient2Chk.UseVisualStyleBackColor = true;
			// 
			// acceptRequestBtn1
			// 
			this.acceptRequestBtn1.Location = new System.Drawing.Point(199, 168);
			this.acceptRequestBtn1.Name = "acceptRequestBtn1";
			this.acceptRequestBtn1.Size = new System.Drawing.Size(104, 27);
			this.acceptRequestBtn1.TabIndex = 20;
			this.acceptRequestBtn1.Text = "accept request";
			this.acceptRequestBtn1.UseVisualStyleBackColor = true;
			this.acceptRequestBtn1.Click += new System.EventHandler(this.acceptRequestBtn1_Click);
			// 
			// acceptRequestBtn2
			// 
			this.acceptRequestBtn2.Location = new System.Drawing.Point(542, 168);
			this.acceptRequestBtn2.Name = "acceptRequestBtn2";
			this.acceptRequestBtn2.Size = new System.Drawing.Size(104, 27);
			this.acceptRequestBtn2.TabIndex = 21;
			this.acceptRequestBtn2.Text = "accept request";
			this.acceptRequestBtn2.UseVisualStyleBackColor = true;
			this.acceptRequestBtn2.Click += new System.EventHandler(this.acceptRequestBtn2_Click);
			// 
			// mainCharIDTxt
			// 
			this.mainCharIDTxt.Location = new System.Drawing.Point(199, 79);
			this.mainCharIDTxt.Name = "mainCharIDTxt";
			this.mainCharIDTxt.Size = new System.Drawing.Size(100, 20);
			this.mainCharIDTxt.TabIndex = 22;
			this.mainCharIDTxt.Text = "775860";
			// 
			// stopClient1Btn
			// 
			this.stopClient1Btn.Enabled = false;
			this.stopClient1Btn.Location = new System.Drawing.Point(280, 135);
			this.stopClient1Btn.Name = "stopClient1Btn";
			this.stopClient1Btn.Size = new System.Drawing.Size(74, 27);
			this.stopClient1Btn.TabIndex = 36;
			this.stopClient1Btn.Text = "stop client 1";
			this.stopClient1Btn.UseVisualStyleBackColor = true;
			this.stopClient1Btn.Click += new System.EventHandler(this.stopClient1Btn_Click);
			// 
			// stopClien2Btn
			// 
			this.stopClien2Btn.Enabled = false;
			this.stopClien2Btn.Location = new System.Drawing.Point(623, 135);
			this.stopClien2Btn.Name = "stopClien2Btn";
			this.stopClien2Btn.Size = new System.Drawing.Size(74, 27);
			this.stopClien2Btn.TabIndex = 37;
			this.stopClien2Btn.Text = "stop client 2";
			this.stopClien2Btn.UseVisualStyleBackColor = true;
			this.stopClien2Btn.Click += new System.EventHandler(this.stopClien2Btn_Click);
			// 
			// openInvClient1Btn
			// 
			this.openInvClient1Btn.Location = new System.Drawing.Point(199, 208);
			this.openInvClient1Btn.Name = "openInvClient1Btn";
			this.openInvClient1Btn.Size = new System.Drawing.Size(100, 23);
			this.openInvClient1Btn.TabIndex = 38;
			this.openInvClient1Btn.Text = "open inventory";
			this.openInvClient1Btn.UseVisualStyleBackColor = true;
			this.openInvClient1Btn.Click += new System.EventHandler(this.openInvClient1Btn_Click);
			// 
			// openInvClient2Btn
			// 
			this.openInvClient2Btn.Location = new System.Drawing.Point(542, 208);
			this.openInvClient2Btn.Name = "openInvClient2Btn";
			this.openInvClient2Btn.Size = new System.Drawing.Size(100, 23);
			this.openInvClient2Btn.TabIndex = 39;
			this.openInvClient2Btn.Text = "open inventory";
			this.openInvClient2Btn.UseVisualStyleBackColor = true;
			// 
			// charsClient1List
			// 
			this.charsClient1List.FormattingEnabled = true;
			this.charsClient1List.Location = new System.Drawing.Point(199, 237);
			this.charsClient1List.Name = "charsClient1List";
			this.charsClient1List.Size = new System.Drawing.Size(120, 95);
			this.charsClient1List.TabIndex = 40;
			// 
			// enterGameClient1Btn
			// 
			this.enterGameClient1Btn.Location = new System.Drawing.Point(199, 338);
			this.enterGameClient1Btn.Name = "enterGameClient1Btn";
			this.enterGameClient1Btn.Size = new System.Drawing.Size(75, 23);
			this.enterGameClient1Btn.TabIndex = 41;
			this.enterGameClient1Btn.Text = "enter game";
			this.enterGameClient1Btn.UseVisualStyleBackColor = true;
			this.enterGameClient1Btn.Click += new System.EventHandler(this.enterGameClient1Btn_Click);
			// 
			// client1TerminalBox
			// 
			this.client1TerminalBox.Location = new System.Drawing.Point(199, 436);
			this.client1TerminalBox.Multiline = true;
			this.client1TerminalBox.Name = "client1TerminalBox";
			this.client1TerminalBox.Size = new System.Drawing.Size(276, 312);
			this.client1TerminalBox.TabIndex = 42;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(886, 760);
			this.Controls.Add(this.client1TerminalBox);
			this.Controls.Add(this.enterGameClient1Btn);
			this.Controls.Add(this.charsClient1List);
			this.Controls.Add(this.openInvClient2Btn);
			this.Controls.Add(this.openInvClient1Btn);
			this.Controls.Add(this.stopClien2Btn);
			this.Controls.Add(this.stopClient1Btn);
			this.Controls.Add(this.mainCharIDTxt);
			this.Controls.Add(this.acceptRequestBtn2);
			this.Controls.Add(this.acceptRequestBtn1);
			this.Controls.Add(this.repeatClient2Chk);
			this.Controls.Add(this.repeatClient1Chk);
			this.Controls.Add(this.startClient2);
			this.Controls.Add(this.startClient1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.listView1);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Packet sniffer";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chooseInterfaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button startClient1;
		private System.Windows.Forms.Button startClient2;
		private System.Windows.Forms.CheckBox repeatClient1Chk;
		private System.Windows.Forms.CheckBox repeatClient2Chk;
		private System.Windows.Forms.Button acceptRequestBtn1;
		private System.Windows.Forms.Button acceptRequestBtn2;
		private System.Windows.Forms.TextBox mainCharIDTxt;
		private System.Windows.Forms.Button stopClient1Btn;
		private System.Windows.Forms.Button stopClien2Btn;
		private System.Windows.Forms.Button openInvClient1Btn;
		private System.Windows.Forms.Button openInvClient2Btn;
		private System.Windows.Forms.ListBox charsClient1List;
		private System.Windows.Forms.Button enterGameClient1Btn;
		private System.Windows.Forms.TextBox client1TerminalBox;
	}
}