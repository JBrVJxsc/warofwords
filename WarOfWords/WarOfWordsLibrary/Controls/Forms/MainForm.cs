using DevExpress.XtraBars;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Windows.Forms;
using WarOfWordsLibrary.Classes.Dictionary;
using WarOfWordsLibrary.Classes.Managers;
using WarOfWordsLibrary.Controls.Controls;

namespace WarOfWordsLibrary.Controls.Forms
{
    public partial class MainForm : BaseForm
    {
        public MainForm()
        {
            InitializeComponent();
            Init();
        }

        private DictionaryEngine dictionaryEngine = new DictionaryEngine();

        private void Init()
        {
            InitMenu();
            InitEngine();
        }

        private void InitMenu()
        {
            InitSettingMenu();
        }

        private void InitSettingMenu()
        {
            SettingManager.GlobalSettingManager.Init(barMenuConfiguration);
        }

        private void InitEngine()
        {
            dictionaryEngine.Init();
            dictionaryEngine.SetMinMaxOfProgress += dictionaryEngine_SetMinMaxOfProgress;
            dictionaryEngine.SetProgressValue += dictionaryEngine_SetProgressValue;
        }

        private void BackgroundQuery()
        {
            queryBackgroundWorker.RunWorkerAsync();
        }

        private void Query()
        {
            dictionaryEngine.Query(cmbInput.Text);
        }

        private void SetControlsEnabled(bool b)
        {
            if (b)
            {
                gridControl.DataSource = dictionaryEngine.QueryResult;
                gridView.BestFitColumns();
                gridControl.ResumeLayout();
                cmbInput.Enabled = true;
                barBtnQuery.Enabled = true;
                barProgress.Visibility = BarItemVisibility.Never;
                barProgress.EditValue = 0;
            }
            else
            {
                gridControl.DataSource = null;
                (gridControl.DefaultView as GridView).ClearSorting();
                cmbInput.Enabled = false;
                barBtnQuery.Enabled = false;
                (gridControl.DefaultView as GridView).HideFindPanel();
                gridControl.SuspendLayout();
            }
        }

        private void RequireSetControlsEnabled(SetControlsEnabledDelegate method,bool b)
        {
            if (InvokeRequired)
            {
                Invoke(method, b);
            }
            else
            {
                method(b);
            }
        }

        private void FocusToInput()
        {
            cmbInput.Focus();
            cmbInput.Select(0, cmbInput.Text.Length);
        }

        private void barBtnFixed_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            TopMost = barBtnFixed.Checked;
        }

        private void barBtnExit_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void barBtnQuery_ItemClick(object sender, ItemClickEventArgs e)
        {
            BackgroundQuery();
        }

        private void barBtnPrint_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridControl.ShowPrintPreview();
        }

        private void barBtnCopy_ItemClick(object sender, ItemClickEventArgs e)
        {
            (gridControl as GridControlPlus).CopySelectedContent();
        }

        private void cmbInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BackgroundQuery();
            }
            else if (e.Control && e.KeyCode == Keys.F)
            {
                (gridControl.DefaultView as GridView).ShowFindPanel();
            }
        }

        private void cmbInput_Properties_BeforeShowMenu(object sender, BeforeShowMenuEventArgs e)
        {
            e.Menu.Items.Clear();
        }

        private void gridControl_TabPressed()
        {
            FocusToInput();
        }

        private void gridControl_PastePressed()
        {
            cmbInput.PasteContent(true);
            FocusToInput();
        }

        void dictionaryEngine_SetProgressValue(int value)
        {
            RequireSetProgressValue(SetProgressValue, value);
        }

        private void SetProgressValue(int value)
        {
            barProgress.EditValue = value;
        }

        private void RequireSetProgressValue(SetProgressValueDelegate method, int value)
        {
            if (InvokeRequired)
            {
                Invoke(method, value);
            }
            else
            {
                method(value);
            }
        }

        void dictionaryEngine_SetMinMaxOfProgress(int min, int max)
        {
            RequireSetMinMaxOfProgress(SetMinMaxOfProgress, min, max);
        }

        private void SetMinMaxOfProgress(int min, int max)
        {
            barProgress.Visibility = BarItemVisibility.Always;
            progressBar.Minimum = min;
            progressBar.Maximum = max;
        }

        private void RequireSetMinMaxOfProgress(SetMinMaxOfProgressDelegate method, int min, int max)
        {
            if (InvokeRequired)
            {
                Invoke(method, min,max);
            }
            else
            {
                method(min,max);
            }
        }

        private void queryBackgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            RequireSetControlsEnabled(SetControlsEnabled, false);
            Query();
        }

        private void queryBackgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            RequireSetControlsEnabled(SetControlsEnabled, true);
        }

        protected override void OnLoad(EventArgs e)
        {
            SettingManager.GlobalSettingManager.Inited();
            base.OnLoad(e);
        }
    }

    public delegate void SetControlsEnabledDelegate(bool b);
    public delegate void SetProgressValueDelegate(int value);
    public delegate void SetMinMaxOfProgressDelegate(int min, int max);
}
