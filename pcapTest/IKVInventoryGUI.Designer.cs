namespace pcapTest
{
	partial class IKVBackPackGUI
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
			this.grabSelectedItemBtn = new System.Windows.Forms.Button();
			this.move2BankBtn = new System.Windows.Forms.Button();
			this.itemSlotsGroup = new System.Windows.Forms.GroupBox();
			this.openBankBtn = new System.Windows.Forms.Button();
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
			// grabSelectedItemBtn
			// 
			this.grabSelectedItemBtn.Location = new System.Drawing.Point(12, 373);
			this.grabSelectedItemBtn.Name = "grabSelectedItemBtn";
			this.grabSelectedItemBtn.Size = new System.Drawing.Size(87, 23);
			this.grabSelectedItemBtn.TabIndex = 48;
			this.grabSelectedItemBtn.Text = "grab selected item";
			this.grabSelectedItemBtn.UseVisualStyleBackColor = true;
			this.grabSelectedItemBtn.Click += new System.EventHandler(this.grabSelectedItemBtn_Click);
			// 
			// move2BankBtn
			// 
			this.move2BankBtn.Location = new System.Drawing.Point(609, 407);
			this.move2BankBtn.Name = "move2BankBtn";
			this.move2BankBtn.Size = new System.Drawing.Size(114, 23);
			this.move2BankBtn.TabIndex = 49;
			this.move2BankBtn.Text = "move to bank";
			this.move2BankBtn.UseVisualStyleBackColor = true;
			this.move2BankBtn.Click += new System.EventHandler(this.move2BankBtn_Click);
			// 
			// itemSlotsGroup
			// 
			this.itemSlotsGroup.Location = new System.Drawing.Point(201, 12);
			this.itemSlotsGroup.Name = "itemSlotsGroup";
			this.itemSlotsGroup.Size = new System.Drawing.Size(522, 355);
			this.itemSlotsGroup.TabIndex = 50;
			this.itemSlotsGroup.TabStop = false;
			this.itemSlotsGroup.Text = "items";
			// 
			// openBankBtn
			// 
			this.openBankBtn.Location = new System.Drawing.Point(479, 407);
			this.openBankBtn.Name = "openBankBtn";
			this.openBankBtn.Size = new System.Drawing.Size(124, 23);
			this.openBankBtn.TabIndex = 51;
			this.openBankBtn.Text = "open bank";
			this.openBankBtn.UseVisualStyleBackColor = true;
			this.openBankBtn.Click += new System.EventHandler(this.openBankBtn_Click);
			// 
			// IKVBackPackGUI
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(735, 442);
			this.Controls.Add(this.openBankBtn);
			this.Controls.Add(this.itemSlotsGroup);
			this.Controls.Add(this.move2BankBtn);
			this.Controls.Add(this.grabSelectedItemBtn);
			this.Controls.Add(this.openBagBtn);
			this.Controls.Add(this.itemList);
			this.Controls.Add(this.bagList);
			this.Name = "IKVBackPackGUI";
			this.Text = "inventory";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IKVInventoryGUI_FormClosing);
			this.ResumeLayout(false);

		}

		#endregion
		public System.Windows.Forms.ListBox bagList;
		public System.Windows.Forms.ListBox itemList;
		private System.Windows.Forms.Button openBagBtn;
		public System.Windows.Forms.Button grabSelectedItemBtn;
		private System.Windows.Forms.Button move2BankBtn;
		public System.Windows.Forms.GroupBox itemSlotsGroup;
		private System.Windows.Forms.Button openBankBtn;
	}
}