namespace pcapTest
{
	partial class IKVBankGUI
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
			this.itemsGroup = new System.Windows.Forms.GroupBox();
			this.SuspendLayout();
			// 
			// itemsGroup
			// 
			this.itemsGroup.Location = new System.Drawing.Point(12, 12);
			this.itemsGroup.Name = "itemsGroup";
			this.itemsGroup.Size = new System.Drawing.Size(1023, 669);
			this.itemsGroup.TabIndex = 0;
			this.itemsGroup.TabStop = false;
			this.itemsGroup.Text = "bank";
			// 
			// IKVBankGUI
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1047, 693);
			this.Controls.Add(this.itemsGroup);
			this.Name = "IKVBankGUI";
			this.Text = "IKVBankGUI";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IKVBankGUI_FormClosing);
			this.ResumeLayout(false);

		}

		#endregion

		public System.Windows.Forms.GroupBox itemsGroup;
	}
}