using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace SDP1_01
{
	public partial class DlgEditDiscountDetails : Form
	{
		internal Discount UsingDiscount { get; private set; }
		bool _readOnly;
		public bool ReadOnly {
			get { return _readOnly; }
			set {
				_readOnly = value;
				this.cbxExistingDiscountOperations.Enabled = !_readOnly;
				this.txtMinQuantities.ReadOnly = _readOnly;
				this.txtMinBuyPrice.ReadOnly = _readOnly;
				this.btnApply.Enabled = !_readOnly;
			}
		}
		private System.Collections.Generic.Dictionary<string, string> _old_values = new System.Collections.Generic.Dictionary<string, string>();
		
		public DlgEditDiscountDetails(Discount usingDiscount) : this(usingDiscount, false)
		{
		}
		
		public DlgEditDiscountDetails(Discount usingDiscount, bool readOnly)
		{
			InitializeComponent();
			this.UsingDiscount = usingDiscount;
			this.Text = "Edit Discount for Product";
			this.ReadOnly = readOnly;
		}
		
		private void DlgEditDiscountDetails_Load(object sender, System.EventArgs e)
		{
			// limit to double only
			this.txtOperand.TextChanged += new EventHandler(DoubleFields_TextChanged);
			this.txtMinQuantities.TextChanged += new EventHandler(UInt32Fields_TextChanged);
			this.txtMinBuyPrice.TextChanged += new EventHandler(DoubleFields_TextChanged);
			
			// load data from database
			this.cbxExistingDiscountOperations.DataSource = DatabaseCommunicator.SelectFromTable(new OleDbCommand("SELECT " + DiscountOperation.SQLAllRequiredColumnsSelect + " FROM DiscountOperation"));
			this.cbxExistingDiscountOperations.DisplayMember = "discountID";
			this.cbxExistingDiscountOperations.ValueMember = "discountID";
			
			// fill fields from discount that is using
			LoadFieldsOntoUIFromProduct();
		}
		
		private void LoadFieldsOntoUIFromProduct()
		{
			// discount ID
			for (int i = 0; i < this.cbxExistingDiscountOperations.Items.Count; i++) {
				DataRowView row = (DataRowView)this.cbxExistingDiscountOperations.Items[i];
				if ((string)row["discountID"] == UsingDiscount.LinkedDiscountOperation.DiscountID) {
					this.cbxExistingDiscountOperations.SelectedIndex = i;
					break;
				}
			}
			
			// min quantities
			this.txtMinQuantities.Text = UsingDiscount.Quantities + "";
			this.txtMinBuyPrice.Text = UsingDiscount.MinBuyPrice.ToString("0.0#");
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
		
		private void BtnCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}
		
		private void CbxExistingDiscountOperationsSelectedIndexChanged(object sender, EventArgs e)
		{
			DataRowView drw = (DataRowView)this.cbxExistingDiscountOperations.SelectedItem;
			
			this.cbxOperator.SelectedIndex = this.cbxOperator.Items.IndexOf((string)drw["discountOperator"]);
			this.txtOperand.Text = (float)drw["discountOperandNum"] + "";
			this.chkExclusively.Checked = (bool)drw["exclusively"];
			this.chkMemberOnly.Checked = (bool)drw["memberOnly"];
		}
		
		private void BtnApply_Click(object sender, EventArgs e)
		{
			// check fields correctness
			{
				System.Collections.Generic.List<string> err = new System.Collections.Generic.List<string>();
				
				// check fields (existing)
				if (cbxExistingDiscountOperations.SelectedIndex == -1)
					err.Add("No existing discount operation is selected.");
				
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
			
			// different with original version?
			if (((string)((DataRowView)this.cbxExistingDiscountOperations.SelectedItem)["discountID"]) != UsingDiscount.LinkedDiscountOperation.DiscountID
			    && Decimal.Parse(this.txtMinBuyPrice.Text) != UsingDiscount.MinBuyPrice
			    && Byte.Parse(this.txtMinQuantities.Text) != UsingDiscount.Quantities)
			{
				Discount result = new Discount();
				result.LinkedDiscountOperation = new DiscountOperation();
				result.LinkedDiscountOperation.UseExisting = true;
				result.LinkedDiscountOperation.DiscountID = (string)this.cbxExistingDiscountOperations.SelectedValue;
				
				DataRowView drw = (DataRowView)this.cbxExistingDiscountOperations.SelectedItem;
				result.LinkedDiscountOperation.DiscountOperator = (string)drw["discountOperator"];
				result.LinkedDiscountOperation.DiscountOperandNum = (float)drw["discountOperandNum"];
				result.LinkedDiscountOperation.Exclusively = (bool)drw["exclusively"];
				result.LinkedDiscountOperation.MemberOnly = (bool)drw["memberOnly"];
				
				result.MinBuyPrice = Decimal.Parse(this.txtMinBuyPrice.Text);
				result.Quantities = Byte.Parse(this.txtMinQuantities.Text);
				this.UsingDiscount = result;
			}
			
			this.Close();
		}
		
		private void BtnCancelClick(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
