using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace WarOfWordsLibrary.Controls.Controls
{
    public partial class GridViewPlus : GridView
    {
        public GridViewPlus()
        {
            InitializeComponent();
        }

        public event CellDoubleClickHandle CellDoubleClick;

        private void GridViewPlus_DoubleClick(object sender, System.EventArgs e)
        {
            Point point = GridControl.PointToClient(Control.MousePosition);
            GridHitInfo gridHitInfo = CalcHitInfo(point);
            if (gridHitInfo.InRow || gridHitInfo.InRowCell)
            {
                if (CellDoubleClick != null)
                {
                    CellDoubleClick(this, gridHitInfo);
                }
            }
        }

        public string GetSelectedContent(int[] columns)
        {
            if (DataSource == null)
            {
                return string.Empty;
            }
            int[] rows = GetSelectedRows();
            if (rows.Length == 0)
            {
                return string.Empty;
            }
            DataTable dataTable = (DataSource as DataView).Table;
            string content = string.Empty;
            for (int row = 0; row < rows.Length; row++)
            {
                for (int j = 0; j < columns.Length; j++)
                {
                    content += GetRowCellValue(rows[row], dataTable.Columns[columns[j]].ColumnName).ToString().Replace("\r", "").Replace("\n", "") + " ";
                }
                content = content.Substring(0, content.Length - 1);
                content += "\r\n";
            }
            content = content.Substring(0, content.Length - 1);
            return content;
        }
    }

    public delegate void CellDoubleClickHandle(object sender, GridHitInfo gridHitInfo);
}
