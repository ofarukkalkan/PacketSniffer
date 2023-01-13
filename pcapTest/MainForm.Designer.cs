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
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
			this.toolStripFilterTextBox = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripPacketDetailsBtn = new System.Windows.Forms.ToolStripButton();
			this.toolStripNewClientBtn = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripMainCharIDTxtBox = new System.Windows.Forms.ToolStripTextBox();
			this.toggleRepeatsBtn = new System.Windows.Forms.ToolStripButton();
			this.togglePartyBtn = new System.Windows.Forms.ToolStripButton();
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
			// toolStrip1
			// 
			this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripButton5,
            this.toolStripButton6,
            this.toolStripFilterTextBox,
            this.toolStripPacketDetailsBtn,
            this.toolStripNewClientBtn,
            this.toolStripSeparator1,
            this.toolStripMainCharIDTxtBox,
            this.toggleRepeatsBtn,
            this.togglePartyBtn});
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
			// toolStripFilterTextBox
			// 
			this.toolStripFilterTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.toolStripFilterTextBox.Name = "toolStripFilterTextBox";
			this.toolStripFilterTextBox.Size = new System.Drawing.Size(100, 27);
			this.toolStripFilterTextBox.Text = "src port";
			// 
			// toolStripPacketDetailsBtn
			// 
			this.toolStripPacketDetailsBtn.Image = ((System.Drawing.Image)(resources.GetObject("toolStripPacketDetailsBtn.Image")));
			this.toolStripPacketDetailsBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripPacketDetailsBtn.Name = "toolStripPacketDetailsBtn";
			this.toolStripPacketDetailsBtn.Size = new System.Drawing.Size(104, 24);
			this.toolStripPacketDetailsBtn.Text = "Packet Details";
			this.toolStripPacketDetailsBtn.Click += new System.EventHandler(this.toolStripPacketDetailsBtn_Click);
			// 
			// toolStripNewClientBtn
			// 
			this.toolStripNewClientBtn.Image = ((System.Drawing.Image)(resources.GetObject("toolStripNewClientBtn.Image")));
			this.toolStripNewClientBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripNewClientBtn.Name = "toolStripNewClientBtn";
			this.toolStripNewClientBtn.Size = new System.Drawing.Size(89, 24);
			this.toolStripNewClientBtn.Text = "New Client";
			this.toolStripNewClientBtn.Click += new System.EventHandler(this.toolStripNewClientBtn_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
			// 
			// toolStripMainCharIDTxtBox
			// 
			this.toolStripMainCharIDTxtBox.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.toolStripMainCharIDTxtBox.Name = "toolStripMainCharIDTxtBox";
			this.toolStripMainCharIDTxtBox.Size = new System.Drawing.Size(100, 27);
			this.toolStripMainCharIDTxtBox.Text = "776491";
			// 
			// toggleRepeatsBtn
			// 
			this.toggleRepeatsBtn.Image = ((System.Drawing.Image)(resources.GetObject("toggleRepeatsBtn.Image")));
			this.toggleRepeatsBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toggleRepeatsBtn.Name = "toggleRepeatsBtn";
			this.toggleRepeatsBtn.Size = new System.Drawing.Size(106, 24);
			this.toggleRepeatsBtn.Text = "toggle repeats";
			this.toggleRepeatsBtn.Click += new System.EventHandler(this.toolStripButton7_Click);
			// 
			// togglePartyBtn
			// 
			this.togglePartyBtn.Image = ((System.Drawing.Image)(resources.GetObject("togglePartyBtn.Image")));
			this.togglePartyBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.togglePartyBtn.Name = "togglePartyBtn";
			this.togglePartyBtn.Size = new System.Drawing.Size(95, 24);
			this.togglePartyBtn.Text = "toggle party";
			this.togglePartyBtn.Click += new System.EventHandler(this.togglePartyBtn_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(886, 760);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.IsMdiContainer = true;
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
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
		private System.Windows.Forms.ToolStripTextBox toolStripFilterTextBox;
		private System.Windows.Forms.ToolStripButton toolStripPacketDetailsBtn;
		private System.Windows.Forms.ToolStripButton toolStripNewClientBtn;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripTextBox toolStripMainCharIDTxtBox;
		private System.Windows.Forms.ToolStripButton toggleRepeatsBtn;
		private System.Windows.Forms.ToolStripButton togglePartyBtn;
	}
}