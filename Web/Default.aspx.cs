using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class _Default : System.Web.UI.Page
{
    string lingual = "";
    Dictionary<string, string>[] searchResult = null;

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void ddlCategory_Init(object sender, EventArgs e)
    {
        this.ddlCategory.Items.Clear();
        OleDbCommand cmdCategory = new OleDbCommand("SELECT categoryID, name" + lingual + " AS name_clocale FROM Category");
        this.ddlCategory.DataSource = DatabaseCommunicator.SelectFromTable(cmdCategory);
        this.ddlCategory.DataValueField = "categoryID";
        this.ddlCategory.DataTextField = "name_clocale";
        this.ddlCategory.DataBind();
    }

    protected void ddlSubCategory_Init(object sender, EventArgs e)
    {
        DdlCategory_SelectedIndexChanged(null, new EventArgs());
    }

    protected void DdlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.ddlSubCategory.Items.Clear();
        OleDbCommand cmdSubCategory = new OleDbCommand("SELECT subCategoryID, name" + lingual + " AS name_clocale FROM SubCategory WHERE categoryID = ?");
        cmdSubCategory.Parameters.Add(new OleDbParameter("?", this.ddlCategory.SelectedValue));
        this.ddlSubCategory.DataSource = DatabaseCommunicator.SelectFromTable(cmdSubCategory);
        this.ddlSubCategory.DataValueField = "subCategoryID";
        this.ddlSubCategory.DataTextField = "name_clocale";
        this.ddlSubCategory.DataBind();
    }

    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        bool priceDesc = this.rbnPriceDesc.Checked;
        bool quantityDesc = this.rbnPriceDesc.Checked;
        bool discountDesc = this.rbnPriceDesc.Checked;

        this.pnlResult.Controls.Clear();

        // result title bar
        this.lblResultCategory.Text = this.ddlCategory.Text;
        this.lblResultSubCategory.Text = this.ddlSubCategory.Text;
        this.lblResultSearchValue.Text = this.txtSearchValue.Text;

        searchResult = Search(this.txtSearchValue.Text, 1, priceDesc, quantityDesc, discountDesc);

        if (searchResult == null) return;

        for (int i = 0; i < (searchResult.Length > 15 ? 15 : searchResult.Length); i++)
        {
            string imagePath = WebProductImageStorage.GetImageLocation(searchResult[i]["productID"]);

            string html = "<br />\r\n" +
            "<table width=\"100%\" border=\"1\" cellpadding=\"5\" cellspacing=\"0\">\r\n" +
            "<tr>\r\n" +
            "<td rowspan=\"2\" style=\"vertical-align: top;\"><p>Name: " + searchResult[i]["productName"] + "</p>\r\n" +
            "<p>Description: " + searchResult[i]["description"] + "</p>\r\n" +
            "<p>Barcode: " + searchResult[i]["barcode"] + "</p>\r\n" +
            "<p>Packaging Info: " + searchResult[i]["packagingInfo"] + "</p>\r\n" +
            "<p>Quantity: " + searchResult[i]["quantity"] + searchResult[i]["unit"] + "</p>\r\n";

            string[] discountStrs = ShowDiscountStringListFromProductID(searchResult[i]["productID"]);

            if (discountStrs != null)
            {
                html += "<p>Discount (for reference only): \r\n" +
                "<ol>\r\n";

                foreach (string s in discountStrs)
                {
                    html += "<li>" + s + "</li>\r\n";
                }

                html += "</ol>\r\n";
                html += "<span style=\"font-size: 0.8em; font-style: italic;\">(The above discount information is for reference only. Please ask to our shop staffs for more details.)</span>";
            }

            html += "</td>\r\n" +
            "<td width=\"30%\" style=\"text-align: center;\"><img src=\"";

            if (imagePath == null)
                html += "img/no_pic.gif";
            else
                html += imagePath;

            html += "\" style=\"max-width: 100%; height: auto;\" /></td>\r\n" +
            "</tr>\r\n" +
            "<tr><td style=\"height: 3em;\"><p>Price: $" + searchResult[i]["price"] + "</p></td></tr>\r\n" +
            "</table>";

            LiteralControl lc = new LiteralControl(html);
            this.pnlResult.Controls.Add(lc);
        }
    }

    private Dictionary<string, string>[] Search(string query, int page, bool priceDesc, bool quantityDesc, bool discountDesc)
    {
        query = "%" + query + "%";
        OleDbCommand cmdSearch = new OleDbCommand("SELECT productID, productName, description, barcode, packagingInfo, quantity, unit, price " +
                                                  "FROM Product " +
                                                  "WHERE (productName LIKE ? OR productName_ZHHK LIKE ? OR productName_ZHCN LIKE ? " +
                                                  "OR description LIKE ? OR description_ZHHK LIKE ? OR description_ZHCN LIKE ? " +
                                                  "OR barcode LIKE ? OR packagingInfo LIKE ? OR packagingInfo_ZHHK LIKE ? OR packagingInfo_ZHCN LIKE ? ) " +
                                                  "AND subCategoryID = ? " +
                                                  "ORDER BY price " + (!priceDesc ? "ASC" : "DESC") + ", " +
                                                  "quantity " + (!quantityDesc ? "ASC" : "DESC"));
        cmdSearch.Parameters.Add(new OleDbParameter("?", query));
        cmdSearch.Parameters.Add(new OleDbParameter("?", query));
        cmdSearch.Parameters.Add(new OleDbParameter("?", query));
        cmdSearch.Parameters.Add(new OleDbParameter("?", query));
        cmdSearch.Parameters.Add(new OleDbParameter("?", query));
        cmdSearch.Parameters.Add(new OleDbParameter("?", query));
        cmdSearch.Parameters.Add(new OleDbParameter("?", query));
        cmdSearch.Parameters.Add(new OleDbParameter("?", query));
        cmdSearch.Parameters.Add(new OleDbParameter("?", query));
        cmdSearch.Parameters.Add(new OleDbParameter("?", query));
        cmdSearch.Parameters.Add(new OleDbParameter("?", this.ddlSubCategory.SelectedValue));

        List<Dictionary<string, string>> ret = new List<Dictionary<string, string>>();
        DataTable result = DatabaseCommunicator.SelectFromTable(cmdSearch);
        foreach (DataRow dr in result.Rows)
        {
            Dictionary<string, string> d = new Dictionary<string, string>();
            for (int i = 0; i < result.Columns.Count; i++)
            {
                if (result.Columns[i].ColumnName == "price")
                    d.Add(result.Columns[i].ColumnName, ((decimal)dr[i]).ToString("0.0#"));
                else
                    d.Add(result.Columns[i].ColumnName, dr[i].ToString());
            }
            ret.Add(d);
        }

        return ret.ToArray();
    }

    private string[] ShowDiscountStringListFromProductID(string productID)
    {
        DataTable listOfLinkedDiscountOperations = DatabaseCommunicator.SelectFromTable(new OleDbCommand("SELECT discountID FROM Discount WHERE productID = \'" + productID + "\'"));
        if (listOfLinkedDiscountOperations.Rows.Count == 0) return null;

        List<string> retList = new List<string>();
        foreach (DataRow rowDscnt in listOfLinkedDiscountOperations.Rows)
        {
            // 割引をその商品の条件
            string add = "";
            {
                DataRow cond = DatabaseCommunicator.SelectFromTable(
                                   new OleDbCommand("SELECT quantities, minBuyPrice " +
                                                    "FROM Discount " + 
                                                    "WHERE productID = \'" + productID + "\' " +
                                                    "AND discountID = \'" + rowDscnt[0] + "\'")).Rows[0];
                add += "Buy this product by " + (byte)cond["quantities"];
                add += " with total price of " + (decimal)cond["minBuyPrice"];
            }

            // その他の商品
            {
                DataTable withProd = DatabaseCommunicator.SelectFromTable(
                                         new OleDbCommand("SELECT productID " +
                                                          "FROM Discount " +
                                                          "WHERE discountID = \'" + rowDscnt[0] + "\' " +
                                                          "AND productID <> \'" + productID + "\'"));

                int rowC = withProd.Rows.Count;
                if (rowC > 0)
                {
                    add += " and also buying ";
                    for (int i = 0; i < (rowC > 4 ? 4 : rowC); i++)
			        {
                        if (i >= 3)
                            add += " and " + rowC + " other products";
                        else
                            add += (i > 0 ? ", " : "") + (string)withProd.Rows[i][0];
			        }
                }
            }

            // 割引の操作
            {
                DataRow dOp = DatabaseCommunicator.SelectFromTable(
                                  new OleDbCommand("SELECT discountOperator, discountOperandNum, exclusively, memberOnly " +
                                                   "FROM DiscountOperation " +
                                                   "WHERE discountID = \'" + rowDscnt[0] + "\' ")).Rows[0];

                if ((bool)dOp["memberOnly"])
                    add = "(Member Only)" + add;

                if ((bool)dOp["exclusively"])
                    add = "(Exclusively)" + add;

                switch ((string)dOp["discountOperator"])
                {
                    case "+" :
                        add += " can have a rebation of -$" + (float)dOp["discountOperandNum"];
                        break;
                    case "-" :
                        add += " can have a rebation of $" + (float)dOp["discountOperandNum"];
                        break;
                    case "*" :
                        add += " can have a discount of " + (100 - (int)(100 * (float)dOp["discountOperandNum"])) + "% off for those products";
                        break;
                    case "/":
                        add += " can have a discount of " + (100 - (int)(100 / (float)dOp["discountOperandNum"])) + "% off for those products";
                        break;
                }
            }

            retList.Add(add);
        }

        return retList.ToArray();
    }
}