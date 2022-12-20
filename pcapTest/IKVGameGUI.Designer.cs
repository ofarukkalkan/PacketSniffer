namespace pcapTest
{
	partial class IKVGameGUI
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
			this.enterGameClient1Btn = new System.Windows.Forms.Button();
			this.charsClient1List = new System.Windows.Forms.ListBox();
			this.openInvClient1Btn = new System.Windows.Forms.Button();
			this.stopClient1Btn = new System.Windows.Forms.Button();
			this.acceptRequestBtn1 = new System.Windows.Forms.Button();
			this.repeatClient1Chk = new System.Windows.Forms.CheckBox();
			this.startClient1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// enterGameClient1Btn
			// 
			this.enterGameClient1Btn.Location = new System.Drawing.Point(12, 241);
			this.enterGameClient1Btn.Name = "enterGameClient1Btn";
			this.enterGameClient1Btn.Size = new System.Drawing.Size(75, 23);
			this.enterGameClient1Btn.TabIndex = 48;
			this.enterGameClient1Btn.Text = "enter game";
			this.enterGameClient1Btn.UseVisualStyleBackColor = true;
			// 
			// charsClient1List
			// 
			this.charsClient1List.FormattingEnabled = true;
			this.charsClient1List.Location = new System.Drawing.Point(12, 140);
			this.charsClient1List.Name = "charsClient1List";
			this.charsClient1List.Size = new System.Drawing.Size(120, 95);
			this.charsClient1List.TabIndex = 47;
			// 
			// openInvClient1Btn
			// 
			this.openInvClient1Btn.Location = new System.Drawing.Point(12, 111);
			this.openInvClient1Btn.Name = "openInvClient1Btn";
			this.openInvClient1Btn.Size = new System.Drawing.Size(100, 23);
			this.openInvClient1Btn.TabIndex = 46;
			this.openInvClient1Btn.Text = "open inventory";
			this.openInvClient1Btn.UseVisualStyleBackColor = true;
			// 
			// stopClient1Btn
			// 
			this.stopClient1Btn.Enabled = false;
			this.stopClient1Btn.Location = new System.Drawing.Point(93, 38);
			this.stopClient1Btn.Name = "stopClient1Btn";
			this.stopClient1Btn.Size = new System.Drawing.Size(74, 27);
			this.stopClient1Btn.TabIndex = 45;
			this.stopClient1Btn.Text = "stop client 1";
			this.stopClient1Btn.UseVisualStyleBackColor = true;
			// 
			// acceptRequestBtn1
			// 
			this.acceptRequestBtn1.Location = new System.Drawing.Point(12, 71);
			this.acceptRequestBtn1.Name = "acceptRequestBtn1";
			this.acceptRequestBtn1.Size = new System.Drawing.Size(104, 27);
			this.acceptRequestBtn1.TabIndex = 44;
			this.acceptRequestBtn1.Text = "accept request";
			this.acceptRequestBtn1.UseVisualStyleBackColor = true;
			// 
			// repeatClient1Chk
			// 
			this.repeatClient1Chk.AutoSize = true;
			this.repeatClient1Chk.Location = new System.Drawing.Point(12, 15);
			this.repeatClient1Chk.Name = "repeatClient1Chk";
			this.repeatClient1Chk.Size = new System.Drawing.Size(70, 17);
			this.repeatClient1Chk.TabIndex = 43;
			this.repeatClient1Chk.Text = "Repeat 1";
			this.repeatClient1Chk.UseVisualStyleBackColor = true;
			// 
			// startClient1
			// 
			this.startClient1.Location = new System.Drawing.Point(12, 38);
			this.startClient1.Name = "startClient1";
			this.startClient1.Size = new System.Drawing.Size(75, 27);
			this.startClient1.TabIndex = 42;
			this.startClient1.Text = "start client 1";
			this.startClient1.UseVisualStyleBackColor = true;
			// 
			// IKVGameGUI
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(342, 376);
			this.Controls.Add(this.enterGameClient1Btn);
			this.Controls.Add(this.charsClient1List);
			this.Controls.Add(this.openInvClient1Btn);
			this.Controls.Add(this.stopClient1Btn);
			this.Controls.Add(this.acceptRequestBtn1);
			this.Controls.Add(this.repeatClient1Chk);
			this.Controls.Add(this.startClient1);
			this.Name = "IKVGameGUI";
			this.Text = "IKVGameGUI";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button enterGameClient1Btn;
		private System.Windows.Forms.ListBox charsClient1List;
		private System.Windows.Forms.Button openInvClient1Btn;
		private System.Windows.Forms.Button stopClient1Btn;
		private System.Windows.Forms.Button acceptRequestBtn1;
		private System.Windows.Forms.CheckBox repeatClient1Chk;
		private System.Windows.Forms.Button startClient1;
	}
}