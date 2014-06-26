<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Product Enquiry</title>
    <style>
        body {
            margin: 0;
            padding: 0;
            height: 100%;
        }

        .wrapper {
            position: fixed;
            left: 0px;
            right: 0px;
            min-height: 100%;
            height: auto !important;
            height: 100%;
            margin: 0;
        }

        #greet {
            background-color: black;
            color: white;
            margin: 0;
            padding: 5px 2px;
            font-size: 12px;
            height: 16px;
        }

            #greet a {
                color: orange;
            }

        .topBarOfContainer {
            width: 100%;
            margin: 0;
            padding: 0;
        }

        .justPutOnRight {
            float: right;
            text-align: right;
        }

        #banner {
            background: #ffcc00 url(img/banner.jpg) no-repeat center;
            padding: 20px;
            font: bold 24px Segoe UI, Arial, sans-serif;
            color: #fff;
            text-shadow: 0 0 5px #000;
            height: 75px;
        }

        .sidebar {
            width: 280px;
            position: fixed;
            height: 100%;
            float: left;
            min-height: 100%;
            background: #ff9900;
            padding: 10px;
        }

        .result {
            position: fixed;
            display: block;
            float: right;
            overflow-y: auto;
            left: 0;
            right: 0;
            height: 77%;
            margin-bottom: 132px;
            margin-left: 300px;
            padding: 10px;
        }

        .auto-style1 {
            width: 100%;
            border-spacing: 0;
        }

            .auto-style1 td {
                padding: 4px;
            }
    </style>
</head>

<body style="font-family: Arial, Helvetica, sans-serif">

    <div id="greet" class="topBarOfContainers">
        Welcome!
			<span id="langSel" class="justPutOnRight">
                <a href="#">繁</a>&nbsp;|&nbsp;<a href="#">简</a>&nbsp;|&nbsp;<a href="#">Eng</a>
            </span>
    </div>
    <div id="banner">
        852 Supermarket
			<br />
        Online Product Catalog Enquiry
    </div>
    <div class="wrapper">
        <div class="sidebar" id="search">
            <form id="search" runat="server">
                <table class="auto-style1">
                    <tr>
                        <td>Search</td>
                        <td align="right">
                            <asp:TextBox ID="txtSearchValue" runat="server" Width="132px" AutoPostBack="True"></asp:TextBox>
                            <asp:Button ID="btnSearch" runat="server" Height="22px" Text="Search" Width="68px" OnClick="BtnSearch_Click" />
                        </td>
                    </tr>
                </table>
                &nbsp;<br />
                <br />
                Filters:<br />
                <table class="auto-style1">
                    <tr>
                        <td width="50%">Category</td>
                        <td>
                            <asp:DropDownList ID="ddlCategory" runat="server" OnSelectedIndexChanged="DdlCategory_SelectedIndexChanged" Width="100%" AppendDataBoundItems="True" AutoPostBack="True" OnInit="ddlCategory_Init">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>Sub-category:</td>
                        <td>
                            <asp:DropDownList ID="ddlSubCategory" runat="server" Width="100%" AppendDataBoundItems="True" AutoPostBack="True" OnInit="ddlSubCategory_Init">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
                <br />
                Sorted by:<br />
                <table class="auto-style1">
                    <tr>
                        <td width="50%">Price</td>
                        <td width="25%">
                            <asp:RadioButton ID="rbnPriceAsc" runat="server" Text="Asc" Checked="True" GroupName="PriceOrder" AutoPostBack="True" />
                        </td>
                        <td>
                            <asp:RadioButton ID="rbnPriceDesc" runat="server" Text="Desc" GroupName="PriceOrder" AutoPostBack="True" />
                        </td>
                    </tr>
                    <tr>
                        <td>Quantity</td>
                        <td>
                            <asp:RadioButton ID="rbnQtyAsc" runat="server" Text="Asc" Checked="True" GroupName="QuantityOrder" AutoPostBack="True" />
                        </td>
                        <td>
                            <asp:RadioButton ID="rbnQtyDesc" runat="server" Text="Desc" GroupName="QuantityOrder" AutoPostBack="True" />
                        </td>
                    </tr>
                    <tr>
                        <td>Discount</td>
                        <td>
                            <asp:RadioButton ID="rbnDiscountAsc" runat="server" Text="Asc" Checked="True" GroupName="DiscountOrder" AutoPostBack="True" />
                        </td>
                        <td>
                            <asp:RadioButton ID="rbnDiscountDesc" runat="server" Text="Desc" GroupName="DiscountOrder" AutoPostBack="True" />
                        </td>
                    </tr>
                </table>
            </form>
        </div>
        <div class="result">
            <div id="resultTop" class="topBarOfContainer">
                <b>Result:</b>
                <span class="justPutOnRight">Page 
                <asp:Label ID="lblCurrentPage" runat="server" Text="0"></asp:Label>
                    &nbsp;of&nbsp<asp:Label ID="lblTotalPage" runat="server" Text="0"></asp:Label></span>
                [<asp:Label ID="lblResultCategory" runat="server" Text="(Any)"></asp:Label>
                ] → [<asp:Label ID="lblResultSubCategory" runat="server" Text="(Any)"></asp:Label>
                ] → [Product Name Contains &quot;<asp:Label ID="lblResultSearchValue" runat="server" Text="(Any)"></asp:Label>
                &quot;]<br />
            </div>
            <hr width="100%" border="1" />
            <asp:Panel ID="pnlResult" runat="server">
            </asp:Panel>
        </div>
    </div>
</body>

</html>
