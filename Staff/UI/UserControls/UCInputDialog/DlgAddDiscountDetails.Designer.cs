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
	partial class DlgAddDiscountDetails
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
			this.label5 = new System.Windows.Forms.Label();
			this.txtMinQuantities = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.btnApply = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.gbxDiscountOperation = new System.Windows.Forms.GroupBox();
			this.chkMemberOnly = new System.Windows.Forms.CheckBox();
			this.chkExclusively = new System.Windows.Forms.CheckBox();
			this.txtOperand = new System.Windows.Forms.TextBox();
			this.cbxOperator = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtDiscountID = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.rbnNewDiscountOperation = new System.Windows.Forms.RadioButton();
			this.rbnExistingDiscountOperation = new System.Windows.Forms.RadioButton();
			this.cbxExistingDiscountOperations = new System.Windows.Forms.ComboBox();
			this.gbxConditions.SuspendLayout();
			this.gbxDiscountOperation.SuspendLayout();
			this.SuspendLayout();
			// 
			// gbxConditions
			// 
			this.gbxConditions.Controls.Add(this.txtMinBuyPrice);
			this.gbxConditions.Controls.Add(this.label5);
			this.gbxConditions.Controls.Add(this.txtMinQuantities);
			this.gbxConditions.Controls.Add(this.label4);
			this.gbxConditions.Location = new System.Drawing.Point(12, 192);
			this.gbxConditions.Name = "gbxConditions";
			this.gbxConditions.Size = new System.Drawing.Size(270, 76);
			this.gbxConditions.TabIndex = 8;
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
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(6, 48);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(75, 13);
			this.label5.TabIndex = 0;
			this.label5.Text = "Min. Buy Price";
			// 
			// txtMinQuantities
			// 
			this.txtMinQuantities.Location = new System.Drawing.Point(87, 19);
			this.txtMinQuantities.Name = "txtMinQuantities";
			this.txtMinQuantities.Size = new System.Drawing.Size(177, 20);
			this.txtMinQuantities.TabIndex = 9;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(6, 22);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(77, 13);
			this.label4.TabIndex = 0;
			this.label4.Text = "Min. Quantities";
			// 
			// btnApply
			// 
			this.btnApply.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnApply.Location = new System.Drawing.Point(12, 274);
			this.btnApply.Name = "btnApply";
			this.btnApply.Size = new System.Drawing.Size(132, 36);
			this.btnApply.TabIndex = 11;
			this.btnApply.Text = "Apply";
			this.btnApply.UseVisualStyleBackColor = true;
			this.btnApply.Click += new System.EventHandler(this.BtnApply_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(150, 274);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(132, 36);
			this.btnCancel.TabIndex = 12;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
			// 
			// gbxDiscountOperation
			// 
			this.gbxDiscountOperation.Controls.Add(this.chkMemberOnly);
			this.gbxDiscountOperation.Controls.Add(this.chkExclusively);
			this.gbxDiscountOperation.Controls.Add(this.txtOperand);
			this.gbxDiscountOperation.Controls.Add(this.cbxOperator);
			this.gbxDiscountOperation.Controls.Add(this.label3);
			this.gbxDiscountOperation.Controls.Add(this.label2);
			this.gbxDiscountOperation.Controls.Add(this.txtDiscountID);
			this.gbxDiscountOperation.Controls.Add(this.label1);
			this.gbxDiscountOperation.Controls.Add(this.rbnNewDiscountOperation);
			this.gbxDiscountOperation.Controls.Add(this.rbnExistingDiscountOperation);
			this.gbxDiscountOperation.Controls.Add(this.cbxExistingDiscountOperations);
			this.gbxDiscountOperation.Location = new System.Drawing.Point(12, 12);
			this.gbxDiscountOperation.Name = "gbxDiscountOperation";
			this.gbxDiscountOperation.Size = new System.Drawing.Size(270, 174);
			this.gbxDiscountOperation.TabIndex = 0;
			this.gbxDiscountOperation.TabStop = false;
			this.gbxDiscountOperation.Text = "Operation to apply discount";
			// 
			// chkMemberOnly
			// 
			this.chkMemberOnly.AutoSize = true;
			this.chkMemberOnly.Location = new System.Drawing.Point(73, 147);
			this.chkMemberOnly.Name = "chkMemberOnly";
			this.chkMemberOnly.Size = new System.Drawing.Size(88, 17);
			this.chkMemberOnly.TabIndex = 7;
			this.chkMemberOnly.Text = "Member Only";
			this.chkMemberOnly.UseVisualStyleBackColor = true;
			// 
			// chkExclusively
			// 
			this.chkExclusively.AutoSize = true;
			this.chkExclusively.Location = new System.Drawing.Point(73, 124);
			this.chkExclusively.Name = "chkExclusively";
			this.chkExclusively.Size = new System.Drawing.Size(78, 17);
			this.chkExclusively.TabIndex = 6;
			this.chkExclusively.Text = "Exclusively";
			this.chkExclusively.UseVisualStyleBackColor = true;
			// 
			// txtOperand
			// 
			this.txtOperand.Location = new System.Drawing.Point(139, 98);
			this.txtOperand.Name = "txtOperand";
			this.txtOperand.Size = new System.Drawing.Size(125, 20);
			this.txtOperand.TabIndex = 5;
			// 
			// cbxOperator
			// 
			this.cbxOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxOperator.FormattingEnabled = true;
			this.cbxOperator.Items.AddRange(new object[] {
									"+",
									"-",
									"*",
									"/"});
			this.cbxOperator.Location = new System.Drawing.Point(139, 71);
			this.cbxOperator.Name = "cbxOperator";
			this.cbxOperator.Size = new System.Drawing.Size(125, 21);
			this.cbxOperator.TabIndex = 4;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(73, 101);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(48, 13);
			this.label3.TabIndex = 7;
			this.label3.Text = "Operand";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(73, 74);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 13);
			this.label2.TabIndex = 7;
			this.label2.Text = "Operator";
			// 
			// txtDiscountID
			// 
			this.txtDiscountID.Location = new System.Drawing.Point(139, 45);
			this.txtDiscountID.MaxLength = 10;
			this.txtDiscountID.Name = "txtDiscountID";
			this.txtDiscountID.Size = new System.Drawing.Size(125, 20);
			this.txtDiscountID.TabIndex = 3;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(73, 48);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(60, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "DiscountID";
			// 
			// rbnNewDiscountOperation
			// 
			this.rbnNewDiscountOperation.AutoSize = true;
			this.rbnNewDiscountOperation.Checked = true;
			this.rbnNewDiscountOperation.Location = new System.Drawing.Point(6, 46);
			this.rbnNewDiscountOperation.Name = "rbnNewDiscountOperation";
			this.rbnNewDiscountOperation.Size = new System.Drawing.Size(47, 17);
			this.rbnNewDiscountOperation.TabIndex = 1;
			this.rbnNewDiscountOperation.TabStop = true;
			this.rbnNewDiscountOperation.Text = "New";
			this.rbnNewDiscountOperation.UseVisualStyleBackColor = true;
			this.rbnNewDiscountOperation.CheckedChanged += new System.EventHandler(this.RbnNew_CheckedChanged);
			// 
			// rbnExistingDiscountOperation
			// 
			this.rbnExistingDiscountOperation.AutoSize = true;
			this.rbnExistingDiscountOperation.Location = new System.Drawing.Point(6, 19);
			this.rbnExistingDiscountOperation.Name = "rbnExistingDiscountOperation";
			this.rbnExistingDiscountOperation.Size = new System.Drawing.Size(61, 17);
			this.rbnExistingDiscountOperation.TabIndex = 1;
			this.rbnExistingDiscountOperation.Text = "Existing";
			this.rbnExistingDiscountOperation.UseVisualStyleBackColor = true;
			this.rbnExistingDiscountOperation.CheckedChanged += new System.EventHandler(this.RbnExistingDiscountID_CheckedChanged);
			// 
			// cbxExistingDiscountOperations
			// 
			this.cbxExistingDiscountOperations.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxExistingDiscountOperations.Enabled = false;
			this.cbxExistingDiscountOperations.FormattingEnabled = true;
			this.cbxExistingDiscountOperations.Location = new System.Drawing.Point(73, 19);
			this.cbxExistingDiscountOperations.Name = "cbxExistingDiscountOperations";
			this.cbxExistingDiscountOperations.Size = new System.Drawing.Size(191, 21);
			this.cbxExistingDiscountOperations.TabIndex = 2;
			this.cbxExistingDiscountOperations.SelectedIndexChanged += new System.EventHandler(this.CbxExistingDiscountOperationsSelectedIndexChanged);
			// 
			// DlgAddDiscountDetails
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
			this.Name = "DlgAddDiscountDetails";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Load += new System.EventHandler(this.DlgAddDiscountDetails_Load);
			this.gbxConditions.ResumeLayout(false);
			this.gbxConditions.PerformLayout();
			this.gbxDiscountOperation.ResumeLayout(false);
			this.gbxDiscountOperation.PerformLayout();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.TextBox txtMinQuantities;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtMinBuyPrice;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.CheckBox chkMemberOnly;
		private System.Windows.Forms.CheckBox chkExclusively;
		private System.Windows.Forms.TextBox txtOperand;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cbxOperator;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtDiscountID;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.RadioButton rbnNewDiscountOperation;
		private System.Windows.Forms.RadioButton rbnExistingDiscountOperation;
		private System.Windows.Forms.ComboBox cbxExistingDiscountOperations;
		private System.Windows.Forms.GroupBox gbxDiscountOperation;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnApply;
		private System.Windows.Forms.GroupBox gbxConditions;
	}
}
