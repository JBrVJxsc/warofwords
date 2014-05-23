using WarOfWordsLibrary.Controls.Controls;
namespace WarOfWordsLibrary.Controls.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.barMain = new DevExpress.XtraBars.Bar();
            this.barBtnQuery = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnFlag = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnCopy = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnPrint = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnSynchronize = new DevExpress.XtraBars.BarButtonItem();
            this.barMenuConfiguration = new DevExpress.XtraBars.BarSubItem();
            this.barBtnExit = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnFixed = new DevExpress.XtraBars.BarCheckItem();
            this.barStatus = new DevExpress.XtraBars.Bar();
            this.barProgress = new DevExpress.XtraBars.BarEditItem();
            this.progressBar = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barImages = new DevExpress.Utils.ImageCollection(this.components);
            this.barBtnConfiguration = new DevExpress.XtraBars.BarButtonItem();
            this.pnlTop = new DevExpress.XtraEditors.PanelControl();
            this.cmbInput = new WarOfWordsLibrary.Controls.Controls.ComboBoxEditPlus();
            this.gridControl = new WarOfWordsLibrary.Controls.Controls.GridControlPlus();
            this.gridView = new WarOfWordsLibrary.Controls.Controls.GridViewPlus();
            this.queryBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barImages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTop)).BeginInit();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbInput.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager
            // 
            this.barManager.AllowCustomization = false;
            this.barManager.AllowMoveBarOnToolbar = false;
            this.barManager.AllowQuickCustomization = false;
            this.barManager.AllowShowToolbarsPopup = false;
            this.barManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barMain,
            this.barStatus});
            this.barManager.DockControls.Add(this.barDockControlTop);
            this.barManager.DockControls.Add(this.barDockControlBottom);
            this.barManager.DockControls.Add(this.barDockControlLeft);
            this.barManager.DockControls.Add(this.barDockControlRight);
            this.barManager.Form = this;
            this.barManager.Images = this.barImages;
            this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barBtnQuery,
            this.barBtnConfiguration,
            this.barBtnExit,
            this.barBtnPrint,
            this.barBtnFlag,
            this.barBtnCopy,
            this.barBtnSynchronize,
            this.barProgress,
            this.barMenuConfiguration,
            this.barBtnFixed});
            this.barManager.MainMenu = this.barMain;
            this.barManager.MaxItemId = 36;
            this.barManager.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.progressBar});
            this.barManager.StatusBar = this.barStatus;
            // 
            // barMain
            // 
            this.barMain.BarName = "Main menu";
            this.barMain.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
            this.barMain.DockCol = 0;
            this.barMain.DockRow = 0;
            this.barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnQuery),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnFlag),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnCopy, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnPrint),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnSynchronize, true),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barMenuConfiguration, DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnExit, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBtnFixed)});
            this.barMain.OptionsBar.AllowQuickCustomization = false;
            this.barMain.OptionsBar.DisableCustomization = true;
            this.barMain.OptionsBar.DrawDragBorder = false;
            this.barMain.OptionsBar.MultiLine = true;
            this.barMain.OptionsBar.UseWholeRow = true;
            this.barMain.Text = "Main menu";
            // 
            // barBtnQuery
            // 
            this.barBtnQuery.Caption = "查询";
            this.barBtnQuery.Id = 0;
            this.barBtnQuery.ImageIndex = 0;
            this.barBtnQuery.Name = "barBtnQuery";
            this.barBtnQuery.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnQuery_ItemClick);
            // 
            // barBtnFlag
            // 
            this.barBtnFlag.Caption = "标记";
            this.barBtnFlag.Id = 4;
            this.barBtnFlag.ImageIndex = 4;
            this.barBtnFlag.Name = "barBtnFlag";
            this.barBtnFlag.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barBtnCopy
            // 
            this.barBtnCopy.Caption = "复制";
            this.barBtnCopy.Id = 5;
            this.barBtnCopy.ImageIndex = 3;
            this.barBtnCopy.Name = "barBtnCopy";
            this.barBtnCopy.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnCopy_ItemClick);
            // 
            // barBtnPrint
            // 
            this.barBtnPrint.Caption = "打印";
            this.barBtnPrint.Id = 3;
            this.barBtnPrint.ImageIndex = 5;
            this.barBtnPrint.Name = "barBtnPrint";
            this.barBtnPrint.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnPrint_ItemClick);
            // 
            // barBtnSynchronize
            // 
            this.barBtnSynchronize.Caption = "同步";
            this.barBtnSynchronize.Id = 6;
            this.barBtnSynchronize.ImageIndex = 6;
            this.barBtnSynchronize.Name = "barBtnSynchronize";
            this.barBtnSynchronize.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barMenuConfiguration
            // 
            this.barMenuConfiguration.Caption = "设置";
            this.barMenuConfiguration.Id = 11;
            this.barMenuConfiguration.ImageIndex = 1;
            this.barMenuConfiguration.Name = "barMenuConfiguration";
            // 
            // barBtnExit
            // 
            this.barBtnExit.Caption = "退出";
            this.barBtnExit.Id = 2;
            this.barBtnExit.ImageIndex = 2;
            this.barBtnExit.Name = "barBtnExit";
            this.barBtnExit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnExit_ItemClick);
            // 
            // barBtnFixed
            // 
            this.barBtnFixed.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barBtnFixed.Caption = "固定";
            this.barBtnFixed.Id = 18;
            this.barBtnFixed.ImageIndex = 8;
            this.barBtnFixed.Name = "barBtnFixed";
            this.barBtnFixed.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnFixed_CheckedChanged);
            // 
            // barStatus
            // 
            this.barStatus.BarName = "Status bar";
            this.barStatus.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.barStatus.DockCol = 0;
            this.barStatus.DockRow = 0;
            this.barStatus.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.barStatus.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barProgress)});
            this.barStatus.OptionsBar.AllowQuickCustomization = false;
            this.barStatus.OptionsBar.DrawDragBorder = false;
            this.barStatus.OptionsBar.UseWholeRow = true;
            this.barStatus.Text = "Status bar";
            // 
            // barProgress
            // 
            this.barProgress.AutoFillWidth = true;
            this.barProgress.AutoHideEdit = false;
            this.barProgress.Edit = this.progressBar;
            this.barProgress.EditHeight = 20;
            this.barProgress.EditValue = "";
            this.barProgress.Id = 7;
            this.barProgress.Name = "barProgress";
            this.barProgress.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.barProgress.Width = 212;
            // 
            // progressBar
            // 
            this.progressBar.EndColor = System.Drawing.Color.DimGray;
            this.progressBar.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.progressBar.LookAndFeel.UseDefaultLookAndFeel = false;
            this.progressBar.Name = "progressBar";
            this.progressBar.ProgressViewStyle = DevExpress.XtraEditors.Controls.ProgressViewStyle.Solid;
            this.progressBar.StartColor = System.Drawing.Color.Silver;
            this.progressBar.Step = 1;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(665, 40);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 379);
            this.barDockControlBottom.Size = new System.Drawing.Size(665, 25);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 40);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 339);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(665, 40);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 339);
            // 
            // barImages
            // 
            this.barImages.ImageSize = new System.Drawing.Size(32, 32);
            this.barImages.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("barImages.ImageStream")));
            this.barImages.Images.SetKeyName(0, "Query.png");
            this.barImages.Images.SetKeyName(1, "Configuration.png");
            this.barImages.Images.SetKeyName(2, "Exit.png");
            this.barImages.Images.SetKeyName(3, "Copy.png");
            this.barImages.Images.SetKeyName(4, "Flag.png");
            this.barImages.Images.SetKeyName(5, "Print.png");
            this.barImages.Images.SetKeyName(6, "Synchronize.png");
            this.barImages.Images.SetKeyName(7, "Wordbook.png");
            this.barImages.Images.SetKeyName(8, "Fixed.png");
            // 
            // barBtnConfiguration
            // 
            this.barBtnConfiguration.Caption = "设置";
            this.barBtnConfiguration.Id = 1;
            this.barBtnConfiguration.ImageIndex = 1;
            this.barBtnConfiguration.Name = "barBtnConfiguration";
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.cmbInput);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 40);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(665, 40);
            this.pnlTop.TabIndex = 4;
            // 
            // cmbInput
            // 
            this.cmbInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbInput.EditValue = "";
            this.cmbInput.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.cmbInput.Location = new System.Drawing.Point(5, 6);
            this.cmbInput.Name = "cmbInput";
            this.cmbInput.Properties.AllowMouseWheel = false;
            this.cmbInput.Properties.Appearance.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbInput.Properties.Appearance.Options.UseFont = true;
            this.cmbInput.Properties.AppearanceDropDown.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.cmbInput.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cmbInput.Properties.AutoComplete = false;
            this.cmbInput.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbInput.Properties.BeforeShowMenu += new DevExpress.XtraEditors.Controls.BeforeShowMenuEventHandler(this.cmbInput_Properties_BeforeShowMenu);
            this.cmbInput.Size = new System.Drawing.Size(655, 34);
            this.cmbInput.TabIndex = 3;
            this.cmbInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbInput_KeyDown);
            // 
            // gridControl
            // 
            this.gridControl.CopyedColumns = new int[] {
        0,
        2};
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(0, 80);
            this.gridControl.MainView = this.gridView;
            this.gridControl.MenuManager = this.barManager;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(665, 299);
            this.gridControl.TabIndex = 9;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            this.gridControl.TabPressed += new WarOfWordsLibrary.Controls.Controls.TabPressedHandle(this.gridControl_TabPressed);
            this.gridControl.PastePressed += new WarOfWordsLibrary.Controls.Controls.PastePressedHandle(this.gridControl_PastePressed);
            // 
            // gridView
            // 
            this.gridView.Appearance.HeaderPanel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView.Appearance.Row.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gridView.Appearance.Row.Options.UseFont = true;
            this.gridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.AllowPixelScrolling = DevExpress.Utils.DefaultBoolean.True;
            this.gridView.OptionsBehavior.CopyToClipboardWithColumnHeaders = false;
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
            this.gridView.OptionsCustomization.AllowColumnMoving = false;
            this.gridView.OptionsCustomization.AllowFilter = false;
            this.gridView.OptionsHint.ShowCellHints = false;
            this.gridView.OptionsHint.ShowColumnHeaderHints = false;
            this.gridView.OptionsHint.ShowFooterHints = false;
            this.gridView.OptionsMenu.EnableColumnMenu = false;
            this.gridView.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView.OptionsPrint.PrintSelectedRowsOnly = true;
            this.gridView.OptionsSelection.MultiSelect = true;
            this.gridView.OptionsView.ShowGroupPanel = false;
            // 
            // queryBackgroundWorker
            // 
            this.queryBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.queryBackgroundWorker_DoWork);
            this.queryBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.queryBackgroundWorker_RunWorkerCompleted);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 404);
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ar Of Words";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barImages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTop)).EndInit();
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmbInput.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar barMain;
        private DevExpress.XtraBars.Bar barStatus;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.PanelControl pnlTop;
        private ComboBoxEditPlus cmbInput;
        private DevExpress.XtraBars.BarButtonItem barBtnQuery;
        private DevExpress.Utils.ImageCollection barImages;
        private DevExpress.XtraBars.BarButtonItem barBtnConfiguration;
        private DevExpress.XtraBars.BarButtonItem barBtnExit;
        private DevExpress.XtraBars.BarButtonItem barBtnPrint;
        private DevExpress.XtraBars.BarButtonItem barBtnFlag;
        private DevExpress.XtraBars.BarButtonItem barBtnCopy;
        private DevExpress.XtraBars.BarButtonItem barBtnSynchronize;
        private GridControlPlus gridControl;
        private GridViewPlus gridView;
        private DevExpress.XtraBars.BarEditItem barProgress;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar progressBar;
        private System.ComponentModel.BackgroundWorker queryBackgroundWorker;
        private DevExpress.XtraBars.BarSubItem barMenuConfiguration;
        private DevExpress.XtraBars.BarCheckItem barBtnFixed;

    }
}