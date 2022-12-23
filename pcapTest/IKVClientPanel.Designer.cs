namespace pcapTest
{
	partial class IKVClientPanel
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IKVClientPanel));
			this.enterGameBtn = new System.Windows.Forms.Button();
			this.charsList = new System.Windows.Forms.ListBox();
			this.openInventoryBtn = new System.Windows.Forms.Button();
			this.stopClientBtn = new System.Windows.Forms.Button();
			this.acceptRequestBtn = new System.Windows.Forms.Button();
			this.startClientBtn = new System.Windows.Forms.Button();
			this.repeatChk = new System.Windows.Forms.CheckBox();
			this.loginDataListBox = new System.Windows.Forms.ListBox();
			this.charSelectionDataListBox = new System.Windows.Forms.ListBox();
			this.portListBox = new System.Windows.Forms.ListBox();
			this.chatBox = new System.Windows.Forms.ListBox();
			this.autoAcceptPartyChk = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// enterGameBtn
			// 
			this.enterGameBtn.Enabled = false;
			this.enterGameBtn.Location = new System.Drawing.Point(122, 45);
			this.enterGameBtn.Name = "enterGameBtn";
			this.enterGameBtn.Size = new System.Drawing.Size(75, 23);
			this.enterGameBtn.TabIndex = 48;
			this.enterGameBtn.Text = "enter game";
			this.enterGameBtn.UseVisualStyleBackColor = true;
			this.enterGameBtn.Click += new System.EventHandler(this.enterGameBtn_Click);
			// 
			// charsList
			// 
			this.charsList.Enabled = false;
			this.charsList.FormattingEnabled = true;
			this.charsList.Location = new System.Drawing.Point(12, 339);
			this.charsList.Name = "charsList";
			this.charsList.Size = new System.Drawing.Size(291, 82);
			this.charsList.TabIndex = 47;
			// 
			// openInventoryBtn
			// 
			this.openInventoryBtn.Enabled = false;
			this.openInventoryBtn.Location = new System.Drawing.Point(12, 85);
			this.openInventoryBtn.Name = "openInventoryBtn";
			this.openInventoryBtn.Size = new System.Drawing.Size(100, 23);
			this.openInventoryBtn.TabIndex = 46;
			this.openInventoryBtn.Text = "open inventory";
			this.openInventoryBtn.UseVisualStyleBackColor = true;
			this.openInventoryBtn.Click += new System.EventHandler(this.openInventoryBtn_Click);
			// 
			// stopClientBtn
			// 
			this.stopClientBtn.Enabled = false;
			this.stopClientBtn.Location = new System.Drawing.Point(93, 12);
			this.stopClientBtn.Name = "stopClientBtn";
			this.stopClientBtn.Size = new System.Drawing.Size(74, 27);
			this.stopClientBtn.TabIndex = 45;
			this.stopClientBtn.Text = "stop client";
			this.stopClientBtn.UseVisualStyleBackColor = true;
			this.stopClientBtn.Click += new System.EventHandler(this.stopClientBtn_Click);
			// 
			// acceptRequestBtn
			// 
			this.acceptRequestBtn.Enabled = false;
			this.acceptRequestBtn.Location = new System.Drawing.Point(12, 45);
			this.acceptRequestBtn.Name = "acceptRequestBtn";
			this.acceptRequestBtn.Size = new System.Drawing.Size(104, 27);
			this.acceptRequestBtn.TabIndex = 44;
			this.acceptRequestBtn.Text = "accept request";
			this.acceptRequestBtn.UseVisualStyleBackColor = true;
			this.acceptRequestBtn.Click += new System.EventHandler(this.acceptRequestBtn_Click);
			// 
			// startClientBtn
			// 
			this.startClientBtn.Location = new System.Drawing.Point(12, 12);
			this.startClientBtn.Name = "startClientBtn";
			this.startClientBtn.Size = new System.Drawing.Size(75, 27);
			this.startClientBtn.TabIndex = 43;
			this.startClientBtn.Text = "start client";
			this.startClientBtn.UseVisualStyleBackColor = true;
			this.startClientBtn.Click += new System.EventHandler(this.startClientBtn_Click);
			// 
			// repeatChk
			// 
			this.repeatChk.AutoSize = true;
			this.repeatChk.Enabled = false;
			this.repeatChk.Location = new System.Drawing.Point(242, 12);
			this.repeatChk.Name = "repeatChk";
			this.repeatChk.Size = new System.Drawing.Size(61, 17);
			this.repeatChk.TabIndex = 50;
			this.repeatChk.Text = "Repeat";
			this.repeatChk.UseVisualStyleBackColor = true;
			// 
			// loginDataListBox
			// 
			this.loginDataListBox.FormattingEnabled = true;
			this.loginDataListBox.Items.AddRange(new object[] {
            resources.GetString("loginDataListBox.Items"),
            resources.GetString("loginDataListBox.Items1"),
            resources.GetString("loginDataListBox.Items2")});
			this.loginDataListBox.Location = new System.Drawing.Point(12, 114);
			this.loginDataListBox.Name = "loginDataListBox";
			this.loginDataListBox.Size = new System.Drawing.Size(291, 56);
			this.loginDataListBox.TabIndex = 51;
			// 
			// charSelectionDataListBox
			// 
			this.charSelectionDataListBox.FormattingEnabled = true;
			this.charSelectionDataListBox.Items.AddRange(new object[] {
            "ii 0a24c474",
            "iii e1e60f72",
            "iiii d316d145"});
			this.charSelectionDataListBox.Location = new System.Drawing.Point(12, 251);
			this.charSelectionDataListBox.Name = "charSelectionDataListBox";
			this.charSelectionDataListBox.Size = new System.Drawing.Size(291, 82);
			this.charSelectionDataListBox.TabIndex = 52;
			// 
			// portListBox
			// 
			this.portListBox.FormattingEnabled = true;
			this.portListBox.Items.AddRange(new object[] {
            "beyazkosk 27205"});
			this.portListBox.Location = new System.Drawing.Point(12, 176);
			this.portListBox.Name = "portListBox";
			this.portListBox.Size = new System.Drawing.Size(291, 69);
			this.portListBox.TabIndex = 53;
			// 
			// chatBox
			// 
			this.chatBox.FormattingEnabled = true;
			this.chatBox.Location = new System.Drawing.Point(12, 427);
			this.chatBox.Name = "chatBox";
			this.chatBox.Size = new System.Drawing.Size(291, 147);
			this.chatBox.TabIndex = 54;
			// 
			// autoAcceptPartyChk
			// 
			this.autoAcceptPartyChk.AutoSize = true;
			this.autoAcceptPartyChk.Location = new System.Drawing.Point(191, 85);
			this.autoAcceptPartyChk.Name = "autoAcceptPartyChk";
			this.autoAcceptPartyChk.Size = new System.Drawing.Size(112, 17);
			this.autoAcceptPartyChk.TabIndex = 55;
			this.autoAcceptPartyChk.Text = "Auto Accept Party";
			this.autoAcceptPartyChk.UseVisualStyleBackColor = true;
			// 
			// IKVClientPanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(315, 589);
			this.Controls.Add(this.autoAcceptPartyChk);
			this.Controls.Add(this.chatBox);
			this.Controls.Add(this.portListBox);
			this.Controls.Add(this.charSelectionDataListBox);
			this.Controls.Add(this.loginDataListBox);
			this.Controls.Add(this.repeatChk);
			this.Controls.Add(this.enterGameBtn);
			this.Controls.Add(this.charsList);
			this.Controls.Add(this.openInventoryBtn);
			this.Controls.Add(this.stopClientBtn);
			this.Controls.Add(this.acceptRequestBtn);
			this.Controls.Add(this.startClientBtn);
			this.Name = "IKVClientPanel";
			this.Text = "IKVClientPanel";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IKVClientPanel_FormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button enterGameBtn;
		private System.Windows.Forms.ListBox charsList;
		private System.Windows.Forms.Button openInventoryBtn;
		private System.Windows.Forms.Button stopClientBtn;
		private System.Windows.Forms.Button acceptRequestBtn;
		private System.Windows.Forms.Button startClientBtn;
		public System.Windows.Forms.CheckBox repeatChk;
		private System.Windows.Forms.ListBox loginDataListBox;
		private System.Windows.Forms.ListBox charSelectionDataListBox;
		private System.Windows.Forms.ListBox portListBox;
		private System.Windows.Forms.ListBox chatBox;
		public System.Windows.Forms.CheckBox autoAcceptPartyChk;
	}
}