namespace pcapTest
{
	partial class IKVInventoryGUI
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
			this.bagList = new System.Windows.Forms.ListBox();
			this.itemList = new System.Windows.Forms.ListBox();
			this.openBagBtn = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// bagList
			// 
			this.bagList.FormattingEnabled = true;
			this.bagList.Location = new System.Drawing.Point(12, 12);
			this.bagList.Name = "bagList";
			this.bagList.Size = new System.Drawing.Size(183, 186);
			this.bagList.TabIndex = 45;
			// 
			// itemList
			// 
			this.itemList.FormattingEnabled = true;
			this.itemList.Location = new System.Drawing.Point(12, 233);
			this.itemList.Name = "itemList";
			this.itemList.Size = new System.Drawing.Size(183, 134);
			this.itemList.TabIndex = 46;
			// 
			// openBagBtn
			// 
			this.openBagBtn.Location = new System.Drawing.Point(12, 204);
			this.openBagBtn.Name = "openBagBtn";
			this.openBagBtn.Size = new System.Drawing.Size(75, 23);
			this.openBagBtn.TabIndex = 47;
			this.openBagBtn.Text = "open bag";
			this.openBagBtn.UseVisualStyleBackColor = true;
			this.openBagBtn.Click += new System.EventHandler(this.openBagBtn_Click);
			// 
			// IKVInventoryGUI
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(735, 442);
			this.Controls.Add(this.openBagBtn);
			this.Controls.Add(this.itemList);
			this.Controls.Add(this.bagList);
			this.Name = "IKVInventoryGUI";
			this.Text = "inventory";
			this.ResumeLayout(false);

		}

		#endregion
		public System.Windows.Forms.ListBox bagList;
		public System.Windows.Forms.ListBox itemList;
		private System.Windows.Forms.Button openBagBtn;
	}
}