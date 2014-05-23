using DevExpress.XtraGrid;
using System.Windows.Forms;

namespace WarOfWordsLibrary.Controls.Controls
{
    public partial class GridControlPlus : GridControl
    {
        public event TabPressedHandle TabPressed;
        public event PastePressedHandle PastePressed;

        public GridControlPlus()
        {
            InitializeComponent();
        }

        public int[] CopyedColumns
        {
            get;
            set;
        }

        public void CopySelectedContent()
        {
            string content = (Views[0] as GridViewPlus).GetSelectedContent(CopyedColumns);
            if (content != string.Empty)
            {
                Clipboard.SetText(content);
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (CopyedColumns != null && e.Control && e.KeyCode == Keys.C)
            {
                e.Handled = true;
                CopySelectedContent();
            }
            else if(e.Control && e.KeyCode == Keys.V)
            {
                e.Handled = true;
                if (PastePressed != null)
                {
                    PastePressed();
                }
            }
            else if (e.KeyCode == Keys.Tab)
            {
                if (TabPressed != null)
                {
                    e.Handled = true;
                    TabPressed();
                }
            }
            base.OnKeyDown(e);
        }
    }

    public delegate void TabPressedHandle();
    public delegate void PastePressedHandle();
}
