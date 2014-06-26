/*
 * Created by SharpDevelop.
 * User: Charles Poon
 * Date: 22/6/2014
 * Time: 4:52
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace SDP1_01
{
	public class ProductCollection : List<Product>
	{
		public static ProductCollection Parse(DataTable dataTable)
		{
			ProductCollection result = new ProductCollection();
			foreach (DataRow row in dataTable.Rows) {
				result.Add(Product.Parse(row));
			}
			
			return result;
		}
	}
	
	public class Product
	{
		internal const string SQLAllRequiredColumnsInsert = "productID, barcode, productName, productName_ZHHK, productName_ZHCN, description, description_ZHHK, description_ZHCN, packagingInfo, packagingInfo_ZHHK, packagingInfo_ZHCN, quantity, unit, unit_ZHHK, unit_ZHCN, price, subCategoryID";
		internal const string SQLAllRequiredColumnsSelect = "Product.productID, Product.barcode, Product.productName, Product.productName_ZHHK, Product.productName_ZHCN, Product.description, Product.description_ZHHK, Product.description_ZHCN, Product.packagingInfo, Product.packagingInfo_ZHHK, Product.packagingInfo_ZHCN, Product.quantity, Product.unit, Product.unit_ZHHK, Product.unit_ZHCN, Product.price, Product.subCategoryID";
//		internal const string SQLColumnProductNameMultilingualConcat = "Product.productName & ' ' & Product.productName_ZHHK & ' ' & Product.productName_ZHCN AS productNameConcat";
//		internal const string SQLColumnDescriptionMultilingualConcat = "Product.description & ' ' & Product.description_ZHHK & ' ' & Product.description_ZHCN AS descriptionConcat";
//		internal const string SQLColumnPackagingInfoMultilingualConcat = "Product.packagingInfo & ' ' & Product.packagingInfo_ZHHK & ' ' & packagingInfo_ZHCN AS packagingInfoConcat";
//		internal const string SQLColumnQuantityUnitMultilingualConcat = "Product.quantity & ' ' & Product.unit & ' ' & Product.unit_ZHHK & ' ' & unit_ZHCN AS quantityUnitConcat";
		internal const string SQLAllRequiredValuesInsertAttribute = "?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?";
		
		internal string ProductID { get; set; }
		internal string Barcode { get; set; }
		internal string ProductName { get; set; }
		internal string ProductName_ZHHK { get; set; }
		internal string ProductName_ZHCN { get; set; }
		internal string Description { get; set; }
		internal string Description_ZHHK { get; set; }
		internal string Description_ZHCN { get; set; }
		internal string PackagingInfo { get; set; }
		internal string PackagingInfo_ZHHK { get; set; }
		internal string PackagingInfo_ZHCN { get; set; }
		internal short Quantity { get; set; }
		internal string Unit { get; set; }
		internal string Unit_ZHHK { get; set; }
		internal string Unit_ZHCN { get; set; }
		internal decimal Price { get; set; }
		internal string SubCategoryID { get; set; }
		
		public Product()
		{
			this.ProductID = "";
			this.Barcode = "";
			this.ProductName = "";
			this.ProductName_ZHHK = "";
			this.ProductName_ZHCN = "";
			this.Description = "";
			this.Description_ZHHK = "";
			this.Description_ZHCN = "";
			this.PackagingInfo = "";
			this.PackagingInfo_ZHHK = "";
			this.PackagingInfo_ZHCN = "";
			this.Quantity = 0;
			this.Unit = "";
			this.Unit_ZHHK = "";
			this.Unit_ZHCN = "";
			this.Price = 0.0m;
			this.SubCategoryID = "";
		}
		
		public static Product Parse(DataRow dataRow)
		{
			Product ret = new Product();
			ret.ProductID = (string)dataRow["productID"];
			ret.Barcode = (string)dataRow["barcode"];
			ret.ProductName = (string)dataRow["productName"];
			if (dataRow["productName_ZHHK"].GetType() != typeof(DBNull))
				ret.ProductName_ZHHK = (string)dataRow["productName_ZHHK"];
			if (dataRow["productName_ZHCN"].GetType() != typeof(DBNull))
				ret.ProductName_ZHCN = (string)dataRow["productName_ZHCN"];
			ret.Description = (string)dataRow["description"];
			if (dataRow["description_ZHHK"].GetType() != typeof(DBNull))
				ret.Description_ZHHK = (string)dataRow["description_ZHHK"];
			if (dataRow["description_ZHCN"].GetType() != typeof(DBNull))
				ret.Description_ZHCN = (string)dataRow["description_ZHCN"];
			ret.PackagingInfo = (string)dataRow["packagingInfo"];
			if (dataRow["packagingInfo_ZHHK"].GetType() != typeof(DBNull))
				ret.PackagingInfo_ZHHK = (string)dataRow["packagingInfo_ZHHK"];
			if (dataRow["packagingInfo_ZHCN"].GetType() != typeof(DBNull))
				ret.PackagingInfo_ZHCN = (string)dataRow["packagingInfo_ZHCN"];
			ret.Quantity = (short)dataRow["quantity"];
			ret.Unit = (string)dataRow["unit"];
			if (dataRow["unit_ZHHK"].GetType() != typeof(DBNull))
				ret.Unit_ZHHK = (string)dataRow["unit_ZHHK"];
			if (dataRow["unit_ZHCN"].GetType() != typeof(DBNull))
				ret.Unit_ZHCN = (string)dataRow["unit_ZHCN"];
			ret.Price = (decimal)dataRow["price"];
			ret.SubCategoryID = (string)dataRow["subCategoryID"];
			
			return ret;
		}
		
		public static List<Product> Parse(string[][] oldSystemStringFormat)
		{
			List<Product> ret = new List<Product>();
			
			foreach (string[] si in oldSystemStringFormat) {
				if (si.Length != 6)
					continue;
				
				// Barcode  Category  Sub-Category  Description  Qty  Unit
				
				// cat
				string catID = "";
				{
					string newCatID = si[1].Substring(0, (si[2].Length > 5 ? 5 : si[2].Length)).ToUpper();
					OleDbCommand cmdCat = new OleDbCommand("SELECT categoryID FROM Category WHERE categoryID LIKE ? OR name = ?");
					cmdCat.Parameters.Add(new OleDbParameter("?", newCatID));
					cmdCat.Parameters.Add(new OleDbParameter("?", si[1]));
					try {
						catID = (string)DatabaseCommunicator.SelectSingleFromTable(cmdCat);
					} catch (Exception) {
						OleDbCommand cmdNewCat = new OleDbCommand("INSERT INTO Category (categoryID, name) VALUES (?, ?)");
						cmdNewCat.Parameters.Add(new OleDbParameter("?", newCatID));
						cmdNewCat.Parameters.Add(new OleDbParameter("?", si[1]));
						if (DatabaseCommunicator.InsertIntoTable(cmdNewCat) != 1)
							throw new Exception();
						catID = newCatID;
					}
				}
				
				Product p = new Product();
				
				p.ProductID = si[0];
				
				p.Barcode = si[0];
				p.ProductName = si[3];
				p.ProductName_ZHHK = "";
				p.ProductName_ZHCN = "";
				p.Description = si[4];
				p.Description_ZHHK = "";
				p.Description_ZHCN = "";
				p.PackagingInfo = "unknown";
				p.PackagingInfo_ZHHK = "";
				p.PackagingInfo_ZHCN = "";
				p.Quantity = Int16.Parse(si[4]);
				p.Unit = si[5];
				p.Unit_ZHHK = "";
				p.Unit_ZHCN = "";
				p.Price = 0.0m;
				
				// sub cat
				{
					string newSubCatID = si[2].Substring(0, (si[2].Length > 5 ? 5 : si[2].Length)).ToUpper();
					OleDbCommand cmdSubCat = new OleDbCommand("SELECT subCategoryID FROM SubCategory WHERE subCategoryID LIKE ? OR name = ? OR categoryID = ?");
					cmdSubCat.Parameters.Add(new OleDbParameter("?", newSubCatID));
					cmdSubCat.Parameters.Add(new OleDbParameter("?", si[2]));
					cmdSubCat.Parameters.Add(new OleDbParameter("?", catID));
					try {
						p.SubCategoryID = (string)DatabaseCommunicator.SelectSingleFromTable(cmdSubCat);
					} catch (Exception) {
						OleDbCommand cmdNewSubCat = new OleDbCommand("INSERT INTO SubCategory (subCategoryID, categoryID, name) VALUES (?, ?, ?)");
						cmdNewSubCat.Parameters.Add(new OleDbParameter("?", newSubCatID));
						cmdNewSubCat.Parameters.Add(new OleDbParameter("?", catID));
						cmdNewSubCat.Parameters.Add(new OleDbParameter("?", si[2]));
						if (DatabaseCommunicator.InsertIntoTable(cmdNewSubCat) != 1)
							throw new Exception();
						p.SubCategoryID = newSubCatID;
					}
				}
				
				ret.Add(p);
			}
			
			return ret;
		}
		
		public virtual ProductWithUnderlyings ToProductWithUnderlyings()
		{
			ProductWithUnderlyings converted = new ProductWithUnderlyings();
			converted.ProductID = this.ProductID;
			converted.Barcode = this.Barcode;
			converted.ProductName = this.ProductName;
			converted.ProductName_ZHHK = this.ProductName_ZHHK;
			converted.ProductName_ZHCN = this.ProductName_ZHCN;
			converted.Description = this.Description;
			converted.Description_ZHHK = this.Description_ZHHK;
			converted.Description_ZHCN = this.Description_ZHCN;
			converted.PackagingInfo = this.PackagingInfo;
			converted.PackagingInfo_ZHHK = this.PackagingInfo_ZHHK;
			converted.PackagingInfo_ZHCN = this.PackagingInfo_ZHCN;
			converted.Quantity = this.Quantity;
			converted.Unit = this.Unit;
			converted.Unit_ZHHK = this.Unit_ZHHK;
			converted.Unit_ZHCN = this.Unit_ZHCN;
			converted.Price = this.Price;
			converted.SubCategoryID = this.SubCategoryID;
			return converted;
		}
	}
	
	public class ProductWithUnderlyings : Product
	{
		internal DiscountCollection Discounts { get; set; }
		internal List<string> ShelfUsages { get; set; }
		internal List<string> InShopWarehouseUsages { get; set; }
		
		public ProductWithUnderlyings() : base()
		{
			Discounts = new DiscountCollection();
			ShelfUsages = new List<string>();
			InShopWarehouseUsages = new List<string>();
		}
		
		public sealed override ProductWithUnderlyings ToProductWithUnderlyings()
		{
			return this;
		}
		
		// TODO: re-write get uiderlying details
		public void GetUnderlyingDetails()
		{
			// discount
			{
				OleDbCommand cmdDiscount = new OleDbCommand("SELECT " + Discount.SQLAllRequiredColumnsSelect + " FROM Discount WHERE productID = ?");
				cmdDiscount.Parameters.Add(new OleDbParameter("?", this.ProductID));
				DataTable dtbDiscount = DatabaseCommunicator.SelectFromTable(cmdDiscount);
				
				foreach (DataRow row in dtbDiscount.Rows) {
					Discount newDiscount = Discount.Parse(row);
					
					// discount operation
					OleDbCommand cmdDiscountOperation = new OleDbCommand("SELECT " + DiscountOperation.SQLAllRequiredColumnsSelect + " "
					                                                     + "FROM DiscountOperation "
					                                                     + "WHERE discountID = ?");
					cmdDiscountOperation.Parameters.Add(new OleDbParameter("?", newDiscount.LinkedDiscountOperation.DiscountID));
					DataTable dtbDiscountOperation = DatabaseCommunicator.SelectFromTable(cmdDiscountOperation);
					
					newDiscount.LinkedDiscountOperation = DiscountOperation.Parse(dtbDiscountOperation.Rows[0]);
					
					this.Discounts.Add(newDiscount);
				}
			}
			
			// shelf usage
			{
				OleDbCommand cmdShelfUsage = new OleDbCommand("SELECT shelfLocation FROM ShelfUsage WHERE productID = ?");
				cmdShelfUsage.Parameters.Add(new OleDbParameter("?", this.ProductID));
				DataTable dtbShelfUsage = DatabaseCommunicator.SelectFromTable(cmdShelfUsage);
				
				foreach (DataRow row in dtbShelfUsage.Rows) {
					this.ShelfUsages.Add((string)row["shelfLocation"]);
				}
			}
			
			// in shop warehouse usage
			{
				OleDbCommand cmdInShopWarehouseUsage = new OleDbCommand("SELECT inShopWarehouseLoc FROM InShopWarehouseUsage WHERE productID = ?");
				cmdInShopWarehouseUsage.Parameters.Add(new OleDbParameter("?", this.ProductID));
				DataTable dtbInShopWarehouseUsage = DatabaseCommunicator.SelectFromTable(cmdInShopWarehouseUsage);
				
				foreach (DataRow row in dtbInShopWarehouseUsage.Rows) {
					this.InShopWarehouseUsages.Add((string)row["inShopWarehouseLoc"]);
				}
			}
		}
	}
	
	internal class DiscountCollection : Dictionary<string, Discount>
	{
		internal void Add(Discount item)
		{
			if ((item != null) && (item.LinkedDiscountOperation != null)) {
				base.Add(item.LinkedDiscountOperation.DiscountID, item);
			} else {
				throw new ArgumentException();
			}
		}
		
		public static DiscountCollection Clone(DiscountCollection original)
		{
			DiscountCollection ret = new DiscountCollection();
			foreach (KeyValuePair<string, Discount> entry in original)
			{
				ret.Add(entry.Key, ((Discount)entry.Value).Clone());
			}
			return ret;
		}
	}
	
	public class Discount
	{
		internal const string SQLAllRequiredColumnsInsert = "productID, discountID, quantities, minBuyPrice";
		internal const string SQLAllRequiredColumnsInsertAttribute = "?, ?, ?, ?";
		internal const string SQLAllRequiredColumnsSelect = "Discount.productID, Discount.discountID, Discount.quantities, Discount.minBuyPrice";
		
		public DiscountOperation LinkedDiscountOperation;
		public byte Quantities;
		public decimal MinBuyPrice;
		
		
		public static Discount Parse(DataRow discount)
		{
			Discount result = new Discount();
			string _discountID = (string)discount["discountID"];
			if (_discountID != null && _discountID.Length > 0) {
				result.LinkedDiscountOperation = new DiscountOperation();
				result.LinkedDiscountOperation.DiscountID = _discountID;
			}
			result.Quantities = (byte)discount["quantities"];
			result.MinBuyPrice = (decimal)discount["minBuyPrice"];
			return result;
		}
		
		public Discount Clone()
		{
			Discount ret = new Discount();
			
			ret.LinkedDiscountOperation = this.LinkedDiscountOperation.Clone();
			ret.MinBuyPrice = this.MinBuyPrice;
			ret.Quantities = this.Quantities;
			
			return ret;
		}
	}
	
	public class DiscountOperation
	{
		internal const string SQLAllRequiredColumnsInsert = "discountID, discountOperator, discountOperandNum, exclusively, memberOnly";
		internal const string SQLAllRequiredColumnsInsertAttribute = "?, ?, ?, ?, ?";
		internal const string SQLAllRequiredColumnsSelect = "DiscountOperation.discountID, DiscountOperation.discountOperator, DiscountOperation.discountOperandNum, DiscountOperation.exclusively, DiscountOperation.memberOnly";
		
		public bool UseExisting;
		public string DiscountID;
		public string DiscountOperator;
		public double DiscountOperandNum;
		public bool Exclusively;
		public bool MemberOnly;
		
		public static DiscountOperation Parse(DataRow dataRow)
		{
			DiscountOperation result = new DiscountOperation();
			result.UseExisting = true;
			result.DiscountID = (string)dataRow["discountID"];
			result.DiscountOperator = (string)dataRow["discountOperator"];
			result.DiscountOperandNum = (float)dataRow["discountOperandNum"];
			result.Exclusively = (bool)dataRow["exclusively"];
			result.MemberOnly = (bool)dataRow["memberOnly"];
			return result;
		}
		
		public DiscountOperation Clone()
		{
			DiscountOperation ret = new DiscountOperation();
			
			ret.UseExisting = this.UseExisting;
			ret.DiscountID = this.DiscountID;
			ret.DiscountOperandNum = this.DiscountOperandNum;
			ret.DiscountOperator = this.DiscountOperator;
			ret.Exclusively = this.Exclusively;
			ret.MemberOnly = this.MemberOnly;
			
			return ret;
		}
	}
}
