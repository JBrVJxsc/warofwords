using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using System.Windows.Forms;
using WarOfWordsLibrary.Classes.Interfaces;

namespace WarOfWordsLibrary.Controls.Controls
{
    public partial class RepositoryItemTrackBarPlus : RepositoryItemTrackBar
    {
        public RepositoryItemTrackBarPlus()
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
                EditValueChanged += RepositoryItemTrackBarPlus_EditValueChanged;
            }
        }

        void RepositoryItemTrackBarPlus_EditValueChanged(object sender, System.EventArgs e)
        {
            TrackBarControl trackBarControl = sender as TrackBarControl;
            trackBarControl.MouseUp += trackBarControl_MouseUp;
            IFilter.Precision = (int)trackBarControl.EditValue;
        }

        void trackBarControl_MouseUp(object sender, MouseEventArgs e)
        {
            TrackBarControl trackBarControl = sender as TrackBarControl;
            SendKeys.Send("{TAB}");
            trackBarControl.Focus();
        }
    }
}
