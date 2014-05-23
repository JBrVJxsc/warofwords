using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using System.Windows.Forms;
using WarOfWordsLibrary.Classes.Interfaces;

namespace WarOfWordsLibrary.Controls.Controls
{
    public partial class RepositoryItemZoomTrackBarPlus : RepositoryItemZoomTrackBar
    {
        public RepositoryItemZoomTrackBarPlus()
        {
            InitializeComponent();
        }

        private IFilter iFilter = null;

        public IFilter IFilter
        {
            get
            {
                return iFilter;
            }
            set
            {
                iFilter = value;
                EditValueChanged += RepositoryItemZoomTrackBarPlus_EditValueChanged;
            }
        }

        void RepositoryItemZoomTrackBarPlus_EditValueChanged(object sender, System.EventArgs e)
        {
            ZoomTrackBarControl zoomTrackBarControl = sender as ZoomTrackBarControl;
            zoomTrackBarControl.MouseUp += zoomTrackBarControl_MouseUp;
            IFilter.Precision = (int)zoomTrackBarControl.EditValue;
        }

        void zoomTrackBarControl_MouseUp(object sender, MouseEventArgs e)
        {
            ZoomTrackBarControl zoomTrackBarControl = sender as ZoomTrackBarControl;
            SendKeys.Send("{TAB}");
            zoomTrackBarControl.Focus();
        }
    }
}
