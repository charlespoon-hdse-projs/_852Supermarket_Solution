using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace SDP1_01
{
	public static class DatabaseCommunicator
	{
		private static DatabaseConnector dbConnector = new DatabaseConnector("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=database.accdb");
		
		#region general commands
		private static DataTable ExecSQLDataTable(OleDbCommand command) {
			DataSet ds = ExecSQLDataSet(command);
			return ds.Tables[0];
		}
		
		private static DataSet ExecSQLDataSet(OleDbCommand command) {
			OleDbDataAdapter adapter = ExecSQLDataAdapter(command);
			DataSet ds = new DataSet();
			adapter.Fill(ds);
			return ds;
		}
		
		private static OleDbDataAdapter ExecSQLDataAdapter(OleDbCommand command) {
			string dbConnId = command.CommandText + command.GetHashCode();
			command.Connection = dbConnector.AssignNewConnectionToDbConn(dbConnId);
			
			OleDbDataAdapter adapter = new OleDbDataAdapter(command);
			DataSet ds = new DataSet();
			
			dbConnector.RejectConnectionFromDbConn(dbConnId);
			
			return adapter;
		}
		
		private static int ExecSQLNonQuery(OleDbCommand command) {
			string dbConnId = command.CommandText + command.GetHashCode();
			command.Connection = dbConnector.AssignNewConnectionToDbConn(dbConnId);
			try {
				command.Connection.Open();
			} catch (Exception) {
			}
			
			int affectingRows = command.ExecuteNonQuery();
			
			command.Connection.Close();
			dbConnector.RejectConnectionFromDbConn(dbConnId);
			
			return affectingRows;
		}
		
		private static object ExecSQLScalar(OleDbCommand command) {
			object result = ExecSQLDataTable(command).Rows[0][0];
			
			return result;
		}
		
		internal static DataTable SelectFromTable(OleDbCommand command) {
			return ExecSQLDataTable(command);
		}
		
		internal static DataSet SelectFromTableReturnDataSet(OleDbCommand command) {
			return ExecSQLDataSet(command);
		}
		
		internal static OleDbDataAdapter SelectFromTableReturnDataAdapter(OleDbCommand command) {
			return ExecSQLDataAdapter(command);
		}
		
		internal static object SelectSingleFromTable(OleDbCommand command) {
			return ExecSQLScalar(command);
		}
		
		internal static int InsertIntoTable(OleDbCommand command) {
			return ExecSQLNonQuery(command);
		}
		
		internal static int UpdateFromTable(OleDbCommand command) {
			return ExecSQLNonQuery(command);
		}
		
		internal static int DeleteFromTable(OleDbCommand command) {
			return ExecSQLNonQuery(command);
		}
		#endregion
		
		internal static class Selector
		{
			internal static Product SelectProductFromProductID(string productID)
			{
				OleDbCommand cmd = new OleDbCommand("SELECT " + Product.SQLAllRequiredColumnsSelect + " " +
				                                    "FROM Product " +
				                                    "WHERE productID = ?");
				cmd.Parameters.Add(new OleDbParameter("?", productID));
				return Product.Parse(SelectFromTable(cmd).Rows[0]);
			}
		}
		
		internal static class Inserter
		{
			internal static bool InsertProduct(Product p)
			{
				OleDbCommand cmd = new OleDbCommand("INSERT INTO Product (" + Product.SQLAllRequiredColumnsInsert + ") " +
				                                  "VALUES (" + Product.SQLAllRequiredValuesInsertAttribute + ")");
				// productID, barcode, productName, productName_ZHHK, productName_ZHCN,
				// description, description_ZHHK, description_ZHCN, 
				// packagingInfo, packagingInfo_ZHHK, packagingInfo_ZHCN, quantity, 
				// unit, unit_ZHHK, unit_ZHCN, price, subCategoryID
				cmd.Parameters.Add(new OleDbParameter("?", p.ProductID));
				cmd.Parameters.Add(new OleDbParameter("?", p.Barcode));
				cmd.Parameters.Add(new OleDbParameter("?", p.ProductName));
				cmd.Parameters.Add(new OleDbParameter("?", p.ProductName_ZHHK));
				cmd.Parameters.Add(new OleDbParameter("?", p.ProductName_ZHCN));
				cmd.Parameters.Add(new OleDbParameter("?", p.Description));
				cmd.Parameters.Add(new OleDbParameter("?", p.Description_ZHHK));
				cmd.Parameters.Add(new OleDbParameter("?", p.Description_ZHCN));
				cmd.Parameters.Add(new OleDbParameter("?", p.PackagingInfo));
				cmd.Parameters.Add(new OleDbParameter("?", p.PackagingInfo_ZHHK));
				cmd.Parameters.Add(new OleDbParameter("?", p.PackagingInfo_ZHCN));
				cmd.Parameters.Add(new OleDbParameter("?", p.Quantity));
				cmd.Parameters.Add(new OleDbParameter("?", p.Unit));
				cmd.Parameters.Add(new OleDbParameter("?", p.Unit_ZHHK));
				cmd.Parameters.Add(new OleDbParameter("?", p.Unit_ZHCN));
				cmd.Parameters.Add(new OleDbParameter("?", p.Price));
				cmd.Parameters.Add(new OleDbParameter("?", p.SubCategoryID));
				
				return InsertIntoTable(cmd) == 1;
			}
			
			internal static bool InsertDiscountOperation(DiscountOperation discountOperation)
			{
				OleDbCommand cmd = new OleDbCommand("INSERT INTO DiscountOperation (" + DiscountOperation.SQLAllRequiredColumnsInsert + ") " +
				                                    " VALUES (" + DiscountOperation.SQLAllRequiredColumnsInsertAttribute +  ")");
				// discountID, discountOperator, discountOperandNum, exclusively, memberOnly
				cmd.Parameters.Add(new OleDbParameter("?", discountOperation.DiscountID));
				cmd.Parameters.Add(new OleDbParameter("?", discountOperation.DiscountOperator));
				cmd.Parameters.Add(new OleDbParameter("?", discountOperation.DiscountOperandNum));
				cmd.Parameters.Add(new OleDbParameter("?", discountOperation.Exclusively));
				cmd.Parameters.Add(new OleDbParameter("?", discountOperation.MemberOnly));
				
				return InsertIntoTable(cmd) == 1;
			}
			
			internal static bool InsertDiscount(Discount discount, string productID)
			{
				OleDbCommand cmd = new OleDbCommand("INSERT INTO Discount (" + Discount.SQLAllRequiredColumnsInsert + ") " +
				                                    "VALUES (" + Discount.SQLAllRequiredColumnsInsertAttribute + ")");
				// productID, discountID, quantities, minBuyPrice
				cmd.Parameters.Add(new OleDbParameter("?", productID));
				cmd.Parameters.Add(new OleDbParameter("?", discount.LinkedDiscountOperation.DiscountID));
				cmd.Parameters.Add(new OleDbParameter("?", discount.Quantities));
				cmd.Parameters.Add(new OleDbParameter("?", discount.MinBuyPrice));
				
				return InsertIntoTable(cmd) == 1;
			}
			
			internal static bool InsertShelfUsage(string productID, string shelfLocation)
			{
				OleDbCommand cmd = new OleDbCommand("INSERT INTO ShelfUsage (productID, shelfLocation) VALUES (?, ?)");
				cmd.Parameters.Add(new OleDbParameter("?", productID));
				cmd.Parameters.Add(new OleDbParameter("?", shelfLocation));
				
				return InsertIntoTable(cmd) == 1;
			}
			
			internal static bool InsertInShopWarehouseUsage(string productID, string inShopWarehouseLoc)
			{
				OleDbCommand cmd = new OleDbCommand("INSERT INTO InShopWarehouseUsage (productID, inShopWarehouseLoc) VALUES (?, ?)");
				cmd.Parameters.Add(new OleDbParameter("?", productID));
				cmd.Parameters.Add(new OleDbParameter("?", inShopWarehouseLoc));
				
				return InsertIntoTable(cmd) == 1;
			}
		}
		
//		internal static class Updater
//		{
//			internal static bool UpdateProduct (
//		}
		
		internal static class Deleter
		{
			internal static bool DeleteProduct(string productID)
			{
				OleDbCommand cmd = new OleDbCommand("DELETE FROM Product WHERE productID = ?");
				cmd.Parameters.Add(new OleDbParameter("?", productID));
				
				return DeleteFromTable(cmd) == 1;
			}
			
			internal static bool DeleteDiscountOperation(string discountID)
			{
				OleDbCommand cmd = new OleDbCommand("DELETE FROM DiscountOperation WHERE discountID = ?");
				cmd.Parameters.Add(new OleDbParameter("?", discountID));
				
				return DeleteFromTable(cmd) == 1;
			}
			
			internal static bool DeleteDiscount(string productID, string discountID)
			{
				OleDbCommand cmd = new OleDbCommand("DELETE FROM Discount WHERE productID = ? AND discountID = ?");
				cmd.Parameters.Add(new OleDbParameter("?", productID));
				cmd.Parameters.Add(new OleDbParameter("?", discountID));
				
				return DeleteFromTable(cmd) == 1;
			}
			
			internal static bool DeleteShelfUsage(string productID, string shelfLocation)
			{
				OleDbCommand cmd = new OleDbCommand("DELETE FROM ShelfUsage WHERE productID = ? AND shelfLocation = ?");
				cmd.Parameters.Add(new OleDbParameter("?", productID));
				cmd.Parameters.Add(new OleDbParameter("?", shelfLocation));
				
				return DeleteFromTable(cmd) == 1;
			}
			
			internal static bool DeleteInShopWarehouseUsage(string productID, string inShopWarehouseLoc)
			{
				OleDbCommand cmd = new OleDbCommand("DELETE FROM InShopWarehouseUsage WHERE productID = ? AND inShopWarehouseLoc = ?");
				cmd.Parameters.Add(new OleDbParameter("?", productID));
				cmd.Parameters.Add(new OleDbParameter("?", inShopWarehouseLoc));
				
				return DeleteFromTable(cmd) == 1;
			}
		}
		
		#region Database Connector
		private sealed class DatabaseConnector
		{
			private OleDbConnection dbConn;
			private const int Capacity = 15;
			private List<object> pool = new List<object>(Capacity);
			
			public DatabaseConnector(string connectionString)
			{
                dbConn = new OleDbConnection(connectionString);
			}
			
			internal OleDbConnection AssignNewConnectionToDbConn(string identifier)
			{
				if (pool.Count < Capacity) {
					pool.Add(identifier);
				} else {
					throw new MaxConnectionExceedException();
				}
				
				return this.dbConn;
			}
			
			internal string RejectConnectionFromDbConn(string identifier)
			{
				bool success = pool.Remove(identifier);
				if (pool.Count == 0) dbConn.Close();
				return success ? identifier : null;
			}
			
			internal sealed class MaxConnectionExceedException : Exception
			{
				public MaxConnectionExceedException()
					: base("The maximum connection with the database connection has exceed. "
					       + "You should also better to handle this exception on your code.")
				{
				}
			}
		}
		#endregion
	}
}
