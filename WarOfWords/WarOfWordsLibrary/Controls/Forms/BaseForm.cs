using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;
using WarOfWordsLibrary.Classes.Constants;

namespace WarOfWordsLibrary.Controls.Forms
{
    public partial class BaseForm : XtraForm
    {
        public BaseForm()
        {
            InitializeComponent();
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == MESSAGE.WM_NCACTIVATE)
            {
                if (m.WParam == IntPtr.Zero)
                {
                    m.WParam = new IntPtr(1);
                }
            }
            base.WndProc(ref m);
        }
    }
}
