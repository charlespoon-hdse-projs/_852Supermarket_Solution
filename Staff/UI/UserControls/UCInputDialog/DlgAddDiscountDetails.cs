using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace SDP1_01
{
	public partial class DlgAddDiscountDetails : Form
	{
		internal Discount ResultDetails { get; private set; }
		private System.Collections.Generic.Dictionary<string, string> _old_values = new System.Collections.Generic.Dictionary<string, string>();
		
		public DlgAddDiscountDetails()
		{
			this.Text = "Add Discount to Product";
			InitializeComponent();
		}
		
		private void DlgAddDiscountDetails_Load(object sender, System.EventArgs e)
		{
			// limit to double only
			this.txtOperand.TextChanged += new EventHandler(DoubleFields_TextChanged);
			this.txtMinQuantities.TextChanged += new EventHandler(UInt32Fields_TextChanged);
			this.txtMinBuyPrice.TextChanged += new EventHandler(DoubleFields_TextChanged);
			
			// load data from database
			this.cbxExistingDiscountOperations.DataSource = DatabaseCommunicator.SelectFromTable(new OleDbCommand("SELECT " + DiscountOperation.SQLAllRequiredColumnsSelect + " FROM DiscountOperation"));
			this.cbxExistingDiscountOperations.DisplayMember = "discountID";
			this.cbxExistingDiscountOperations.ValueMember = "discountID";
		}
		
		private void DoubleFields_TextChanged(object sender, EventArgs e)
		{
			if (sender.GetType() == typeof(TextBox)) {
				TextBox textbox = (TextBox)sender;
				
				// check data
				double x = 0.0;
				if (textbox.Text.Length > 0 && !Double.TryParse(textbox.Text, out x)) {
					textbox.Text = _old_values.ContainsKey(textbox.Text) ? _old_values[textbox.Name] : "";
					return;
				}
				
				// record to history
				if (_old_values.ContainsKey(textbox.Name)) {
					_old_values[textbox.Name] = textbox.Text;
				} else {
					_old_values.Add(textbox.Name, textbox.Text);
				}
			}
		}
		
		private void UInt32Fields_TextChanged(object sender, EventArgs e)
		{
			if (sender.GetType() == typeof(TextBox)) {
				TextBox textbox = (TextBox)sender;
				
				// check data
				uint x = 0;
				if (textbox.Text.Length > 0 && !UInt32.TryParse(textbox.Text, out x)) {
					textbox.Text = _old_values.ContainsKey(textbox.Text) ? _old_values[textbox.Name] : "";
					return;
				}
				
				// record to history
				if (_old_values.ContainsKey(textbox.Name)) {
					_old_values[textbox.Name] = textbox.Text;
				} else {
					_old_values.Add(textbox.Name, textbox.Text);
				}
			}
		}
		
		private void RbnNew_CheckedChanged(object sender, EventArgs e)
		{
			bool enable = this.rbnNewDiscountOperation.Checked;
			this.txtDiscountID.Enabled = enable;
			this.cbxOperator.Enabled = enable;
			this.txtOperand.Enabled = enable;
			this.chkExclusively.Enabled = enable;
			this.chkMemberOnly.Enabled = enable;
			this.txtDiscountID.Clear();
			this.cbxOperator.SelectedIndex = 0;
			this.txtOperand.Clear();
			this.chkExclusively.Checked = false;
			this.chkMemberOnly.Checked = false;
		}
		
		private void RbnExistingDiscountID_CheckedChanged(object sender, EventArgs e)
		{
			bool enable = this.rbnExistingDiscountOperation.Checked;
			this.cbxExistingDiscountOperations.Enabled = enable;
		}
		
		private void BtnApply_Click(object sender, EventArgs e)
		{
			// check fields correctness
			{
				System.Collections.Generic.List<string> err = new System.Collections.Generic.List<string>();
				
				// existing checked -> check fields in existing
				if (this.rbnExistingDiscountOperation.Checked) {
					if (cbxExistingDiscountOperations.SelectedIndex == -1)
						err.Add("No existing discount operation is selected.");
				}
				// new checked -> check fields in new
				else if (this.rbnNewDiscountOperation.Checked) {
					// txtDiscountID
					foreach (DataRowView drv in this.cbxExistingDiscountOperations.Items) {
						if (this.txtDiscountID.Text == (string)drv.Row.ItemArray[0]) {
							err.Add("The discountID cannot be same as any exising discountIDs");
							break;
						}
					}
					
					// cbxOperator
					if (this.cbxOperator.SelectedIndex == -1)
						err.Add("No operator is selected for discount operation.");
					
					// txtOperand
					if (this.txtOperand.Text.Length == 0)
						err.Add("The field operand is blank.");
				}
				
				//txtMinQuantities
				if (this.txtMinQuantities.Text.Length == 0)
					err.Add("The \"Min. Quantities\" field is blank.");
				
				// txtMinBuyPrice
				if (this.txtMinBuyPrice.Text.Length == 0)
					err.Add("The \"Min. Buying Price\" field is blank.");
				
				
				// output error and reject operation
				if (err.Count > 0) {
					string errContext = "";
					bool first = true;
					foreach (string s in err) {
						errContext += (first ? "" : "\r\n") + s;
						first = false;
					}
					
					MessageBox.Show("Fields are incomplete: \r\n\r\n" + errContext + "\r\n\r\nPlease check your field if it's complete before continue.",
					                "Incomplete fields", 
					                MessageBoxButtons.OK,
					                MessageBoxIcon.Warning);
					return;
				}
			}
			
			Discount result = new Discount();
			result.LinkedDiscountOperation = new DiscountOperation();
			if (this.rbnExistingDiscountOperation.Checked) {
				result.LinkedDiscountOperation.UseExisting = true;
				result.LinkedDiscountOperation.DiscountID = (string)this.cbxExistingDiscountOperations.SelectedValue;
			} else if (this.rbnNewDiscountOperation.Checked) {
				result.LinkedDiscountOperation.UseExisting = false;
				result.LinkedDiscountOperation.DiscountID = this.txtDiscountID.Text;
				result.LinkedDiscountOperation.DiscountOperator = (string)this.cbxOperator.SelectedItem;
				result.LinkedDiscountOperation.DiscountOperandNum = Double.Parse(this.txtOperand.Text);
				result.LinkedDiscountOperation.Exclusively = this.chkExclusively.Checked;
				result.LinkedDiscountOperation.MemberOnly = this.chkMemberOnly.Checked;
			}
			result.MinBuyPrice = Decimal.Parse(this.txtMinBuyPrice.Text);
			result.Quantities = Byte.Parse(this.txtMinQuantities.Text);
			this.ResultDetails = result;
			
			this.Close();
		}
		
		private void BtnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		
		private void CbxExistingDiscountOperationsSelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.rbnExistingDiscountOperation.Checked) {
				DataRowView drw = (DataRowView)this.cbxExistingDiscountOperations.SelectedItem;
				
				this.txtDiscountID.Text = (string)drw["discountID"];
				this.cbxOperator.SelectedIndex = this.cbxOperator.Items.IndexOf((string)drw["discountOperator"]);
				this.txtOperand.Text = (float)drw["discountOperandNum"] + "";
				this.chkExclusively.Checked = (bool)drw["exclusively"];
				this.chkMemberOnly.Checked = (bool)drw["memberOnly"];
			}
		}
	}
}
