using Syncfusion.WinForms.Controls;
using Syncfusion.WinForms.DataGrid.Styles;
using System.Windows.Forms;
using Syncfusion.WinForms.DataGrid.Enums;
using System.Collections.Specialized;
using System.Threading.Tasks;
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.Core.Utils;
using System.Linq;
using System.Data;
using Syncfusion.WinForms.GridCommon.ScrollAxis;
using Syncfusion.WinForms.DataGrid.Renderers;

namespace GettingStarted
{   
    public partial class Form1 : Form
    {
        #region Constructor
        public Form1()
        {
            InitializeComponent();
            DataTable dt = new DataTable();
            dt.Columns.Add("CustomerName", typeof(string));
            dt.Columns.Add("Country", typeof(string));
            dt.Columns.Add("CustomerID", typeof(string));
            dt.Columns.Add("ShipCity", typeof(string));
            dt.Rows.Add(new string[] { "Antonio Moreno", "Mexico", "ANTON", "Mexico D.F." });
            dt.Rows.Add(new string[] { "Thomas Hardy", "UK", "AROUT", "London" });
            dt.Rows.Add(new string[] { "Christina Berglund", "Sweden", "BERGS", "Lula" });
            dt.Rows.Add(new string[] { "Hanna Moos", "Germany", "BLAUS", "Mannheim" });
            dt.Rows.Add(new string[] { "Frederique Citeaux", "France", "BLONP", "Strasbourg" });
            dt.Rows.Add(new string[] { "Martin Sommer", "Spain", "BOLID", "Madrid" });
            this.sfDataGrid.CellRenderers["TextBox"] = new GridTextBoxCellRendererExt();
            sfDataGrid.EditMode = Syncfusion.WinForms.DataGrid.Enums.EditMode.SingleClick;
            sfDataGrid.SelectionMode = Syncfusion.WinForms.DataGrid.Enums.GridSelectionMode.Single;
            sfDataGrid.DataSource = dt;
            sfDataGrid.CurrentCellActivated += SfDataGrid_CurrentCellActivated;
        }

        private void SfDataGrid_CurrentCellActivated(object sender, Syncfusion.WinForms.DataGrid.Events.CurrentCellActivatedEventArgs e)
        {
            RowColumnIndex rowColumnIndex = new RowColumnIndex(e.DataRow.Index, e.DataColumn.Index);
            sfDataGrid.MoveToCurrentCell(rowColumnIndex);
            this.sfDataGrid.CurrentCell.BeginEdit();
        }
        #endregion
    }

    class GridTextBoxCellRendererExt : GridTextBoxCellRenderer
    {
        protected override void OnInitializeEditElement(DataColumnBase column, Syncfusion.WinForms.GridCommon.ScrollAxis.RowColumnIndex rowColumnIndex, TextBox uiElement)
        {
            base.OnInitializeEditElement(column, rowColumnIndex, uiElement);
            uiElement.KeyDown += uiElement_KeyDown;
        }

        protected override void OnUnwireEditUIElement(TextBox uiElement)
        {
            base.OnUnwireEditUIElement(uiElement);
            uiElement.KeyDown -= uiElement_KeyDown;
        }

        void uiElement_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
                e.SuppressKeyPress = true;
        }
    }
}
