using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using System;
using System.Windows.Forms;
using WarOfWordsLibrary.Classes.Objects;

namespace WarOfWordsLibrary.Controls.Controls
{
    public partial class RepositoryItemSpinEditPlus : RepositoryItemSpinEdit
    {
        public RepositoryItemSpinEditPlus()
        {
            InitializeComponent();
        }

        private QueryHistory queryHistory = null;

        public QueryHistory QueryHistory
        {
            get
            {
                return queryHistory;
            }
            set
            {
                queryHistory = value;
                EditValueChanged += RepositoryItemSpinEditPlus_EditValueChanged;
            }
        }

        void RepositoryItemSpinEditPlus_EditValueChanged(object sender, System.EventArgs e)
        {
            SpinEdit spinEdit = sender as SpinEdit;
            QueryHistory.MaxNumber = Convert.ToInt32(spinEdit.EditValue);
            SendKeys.Send("{TAB}");
            spinEdit.Focus();
        }
    }
}
