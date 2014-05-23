using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using System.Windows.Forms;
using WarOfWordsLibrary.Classes.Interfaces;

namespace WarOfWordsLibrary.Controls.Controls
{
    public partial class RepositoryItemCheckEditPlus : RepositoryItemCheckEdit
    {
        public RepositoryItemCheckEditPlus()
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
                EditValueChanged += RepositoryItemCheckEditPlus_EditValueChanged;
            }
        }

        void RepositoryItemCheckEditPlus_EditValueChanged(object sender, System.EventArgs e)
        {
            CheckEdit checkEdit = sender as CheckEdit;
            IFilter.Enabled = (bool)checkEdit.EditValue; 
            SendKeys.Send("{TAB}");
            checkEdit.Focus();
        }
    }
}
