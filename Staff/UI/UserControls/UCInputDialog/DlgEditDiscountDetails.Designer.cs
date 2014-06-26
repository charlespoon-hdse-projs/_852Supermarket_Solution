/*
 * Created by SharpDevelop.
 * User: Charles Poon
 * Date: 21/6/2014
 * Time: 18:19
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace SDP1_01
{
	partial class DlgEditDiscountDetails
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.gbxConditions = new System.Windows.Forms.GroupBox();
			this.txtMinBuyPrice = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.txtMinQuantities = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnApply = new System.Windows.Forms.Button();
			this.gbxDiscountOperation = new System.Windows.Forms.GroupBox();
			this.label6 = new System.Windows.Forms.Label();
			this.chkMemberOnly = new System.Windows.Forms.CheckBox();
			this.chkExclusively = new System.Windows.Forms.CheckBox();
			this.txtOperand = new System.Windows.Forms.TextBox();
			this.cbxOperator = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.cbxExistingDiscountOperations = new System.Windows.Forms.ComboBox();
			this.gbxConditions.SuspendLayout();
			this.gbxDiscountOperation.SuspendLayout();
			this.SuspendLayout();
			// 
			// gbxConditions
			// 
			this.gbxConditions.Controls.Add(this.txtMinBuyPrice);
			this.gbxConditions.Controls.Add(this.label7);
			this.gbxConditions.Controls.Add(this.txtMinQuantities);
			this.gbxConditions.Controls.Add(this.label8);
			this.gbxConditions.Location = new System.Drawing.Point(12, 192);
			this.gbxConditions.Name = "gbxConditions";
			this.gbxConditions.Size = new System.Drawing.Size(270, 76);
			this.gbxConditions.TabIndex = 17;
			this.gbxConditions.TabStop = false;
			this.gbxConditions.Text = "Condition of this product for selected discount code";
			// 
			// txtMinBuyPrice
			// 
			this.txtMinBuyPrice.Location = new System.Drawing.Point(87, 45);
			this.txtMinBuyPrice.Name = "txtMinBuyPrice";
			this.txtMinBuyPrice.Size = new System.Drawing.Size(177, 20);
			this.txtMinBuyPrice.TabIndex = 10;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(6, 48);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(75, 13);
			this.label7.TabIndex = 0;
			this.label7.Text = "Min. Buy Price";
			// 
			// txtMinQuantities
			// 
			this.txtMinQuantities.Location = new System.Drawing.Point(87, 19);
			this.txtMinQuantities.Name = "txtMinQuantities";
			this.txtMinQuantities.Size = new System.Drawing.Size(177, 20);
			this.txtMinQuantities.TabIndex = 9;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(6, 22);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(77, 13);
			this.label8.TabIndex = 0;
			this.label8.Text = "Min. Quantities";
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(150, 274);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(132, 36);
			this.btnCancel.TabIndex = 16;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.BtnCancelClick);
			// 
			// btnApply
			// 
			this.btnApply.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnApply.Location = new System.Drawing.Point(12, 274);
			this.btnApply.Name = "btnApply";
			this.btnApply.Size = new System.Drawing.Size(132, 36);
			this.btnApply.TabIndex = 15;
			this.btnApply.Text = "Apply";
			this.btnApply.UseVisualStyleBackColor = true;
			this.btnApply.Click += new System.EventHandler(this.BtnApply_Click);
			// 
			// gbxDiscountOperation
			// 
			this.gbxDiscountOperation.Controls.Add(this.label6);
			this.gbxDiscountOperation.Controls.Add(this.chkMemberOnly);
			this.gbxDiscountOperation.Controls.Add(this.chkExclusively);
			this.gbxDiscountOperation.Controls.Add(this.txtOperand);
			this.gbxDiscountOperation.Controls.Add(this.cbxOperator);
			this.gbxDiscountOperation.Controls.Add(this.label3);
			this.gbxDiscountOperation.Controls.Add(this.label2);
			this.gbxDiscountOperation.Controls.Add(this.label1);
			this.gbxDiscountOperation.Controls.Add(this.cbxExistingDiscountOperations);
			this.gbxDiscountOperation.Location = new System.Drawing.Point(12, 12);
			this.gbxDiscountOperation.Name = "gbxDiscountOperation";
			this.gbxDiscountOperation.Size = new System.Drawing.Size(270, 174);
			this.gbxDiscountOperation.TabIndex = 14;
			this.gbxDiscountOperation.TabStop = false;
			this.gbxDiscountOperation.Text = "Operation to apply discount";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(6, 20);
			this.label6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(219, 13);
			this.label6.TabIndex = 8;
			this.label6.Text = "Details of existing Discount Operation details:";
			// 
			// chkMemberOnly
			// 
			this.chkMemberOnly.AutoSize = true;
			this.chkMemberOnly.Enabled = false;
			this.chkMemberOnly.Location = new System.Drawing.Point(73, 145);
			this.chkMemberOnly.Name = "chkMemberOnly";
			this.chkMemberOnly.Size = new System.Drawing.Size(88, 17);
			this.chkMemberOnly.TabIndex = 7;
			this.chkMemberOnly.Text = "Member Only";
			this.chkMemberOnly.UseVisualStyleBackColor = true;
			// 
			// chkExclusively
			// 
			this.chkExclusively.AutoSize = true;
			this.chkExclusively.Enabled = false;
			this.chkExclusively.Location = new System.Drawing.Point(73, 122);
			this.chkExclusively.Name = "chkExclusively";
			this.chkExclusively.Size = new System.Drawing.Size(78, 17);
			this.chkExclusively.TabIndex = 6;
			this.chkExclusively.Text = "Exclusively";
			this.chkExclusively.UseVisualStyleBackColor = true;
			// 
			// txtOperand
			// 
			this.txtOperand.Enabled = false;
			this.txtOperand.Location = new System.Drawing.Point(73, 96);
			this.txtOperand.Name = "txtOperand";
			this.txtOperand.Size = new System.Drawing.Size(191, 20);
			this.txtOperand.TabIndex = 5;
			// 
			// cbxOperator
			// 
			this.cbxOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxOperator.Enabled = false;
			this.cbxOperator.FormattingEnabled = true;
			this.cbxOperator.Items.AddRange(new object[] {
									"+",
									"-",
									"*",
									"/"});
			this.cbxOperator.Location = new System.Drawing.Point(73, 69);
			this.cbxOperator.Name = "cbxOperator";
			this.cbxOperator.Size = new System.Drawing.Size(191, 21);
			this.cbxOperator.TabIndex = 4;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 99);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(48, 13);
			this.label3.TabIndex = 7;
			this.label3.Text = "Operand";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 72);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 13);
			this.label2.TabIndex = 7;
			this.label2.Text = "Operator";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 46);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(60, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "DiscountID";
			// 
			// cbxExistingDiscountOperations
			// 
			this.cbxExistingDiscountOperations.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxExistingDiscountOperations.Enabled = false;
			this.cbxExistingDiscountOperations.FormattingEnabled = true;
			this.cbxExistingDiscountOperations.Location = new System.Drawing.Point(73, 43);
			this.cbxExistingDiscountOperations.Name = "cbxExistingDiscountOperations";
			this.cbxExistingDiscountOperations.Size = new System.Drawing.Size(191, 21);
			this.cbxExistingDiscountOperations.TabIndex = 2;
			this.cbxExistingDiscountOperations.SelectedIndexChanged += new System.EventHandler(this.CbxExistingDiscountOperationsSelectedIndexChanged);
			// 
			// DlgEditDiscountDetails
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(294, 322);
			this.Controls.Add(this.gbxConditions);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnApply);
			this.Controls.Add(this.gbxDiscountOperation);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DlgEditDiscountDetails";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Load += new System.EventHandler(this.DlgEditDiscountDetails_Load);
			this.gbxConditions.ResumeLayout(false);
			this.gbxConditions.PerformLayout();
			this.gbxDiscountOperation.ResumeLayout(false);
			this.gbxDiscountOperation.PerformLayout();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.ComboBox cbxExistingDiscountOperations;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cbxOperator;
		private System.Windows.Forms.TextBox txtOperand;
		private System.Windows.Forms.CheckBox chkExclusively;
		private System.Windows.Forms.CheckBox chkMemberOnly;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.GroupBox gbxDiscountOperation;
		private System.Windows.Forms.Button btnApply;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txtMinQuantities;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtMinBuyPrice;
		private System.Windows.Forms.GroupBox gbxConditions;
	}
}
