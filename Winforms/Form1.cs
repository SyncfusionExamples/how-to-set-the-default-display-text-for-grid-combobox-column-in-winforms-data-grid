using Syncfusion.WinForms.Controls;
using Syncfusion.WinForms.DataGrid.Styles;
using System.Windows.Forms;
using Syncfusion.WinForms.DataGrid.Enums;
using Syncfusion.WinForms.DataGrid;
using System.Globalization;
using Syncfusion.WinForms.DataGrid.Renderers;
using Syncfusion.WinForms.GridCommon.ScrollAxis;
using Syncfusion.WinForms.ListView;
using System.Drawing;

namespace ComboBoxColumn
{   
    public partial class Form1 : Form
    {
        #region Constructor
        public Form1()
        {
            InitializeComponent();
            sfDataGrid.AutoGenerateColumns = false;
            sfDataGrid.DataSource = new CountryInfoRepository().OrderDetails;
            GridSettings();
        }

        private void GridSettings()
        {
            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.NumberDecimalDigits = 0;
            nfi.NumberGroupSizes = new int[] { };

            sfDataGrid.Columns.Add(new GridNumericColumn() { MappingName = "OrderID", HeaderText = "Order ID", NumberFormatInfo = nfi });
            sfDataGrid.Columns.Add(new GridTextColumn() { MappingName = "CustomerID", HeaderText = "Customer ID" });
            sfDataGrid.Columns.Add(new GridTextColumn() { MappingName = "ProductName", HeaderText = "Product Name" });
            sfDataGrid.Columns.Add(new GridComboBoxColumn() { MappingName = "ShipCountry", HeaderText = "Ship Country",
                DataSource = new CountryInfoRepository().CountryList});

            this.sfDataGrid.DrawCell += SfDataGrid_DrawCell;
        }

        private void SfDataGrid_DrawCell(object sender, Syncfusion.WinForms.DataGrid.Events.DrawCellEventArgs e)
        {
            if(e.Column.MappingName == "ShipCountry" && string.IsNullOrEmpty(e.DisplayText))
            {
                e.DisplayText = "Select Item";
            }
        }

        #endregion
    }
}
