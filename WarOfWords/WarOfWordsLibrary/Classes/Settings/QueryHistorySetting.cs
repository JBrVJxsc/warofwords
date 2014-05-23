using DevExpress.XtraBars;
using DevExpress.XtraEditors.Controls;
using System.Drawing;
using WarOfWordsLibrary.Classes.Interfaces;
using WarOfWordsLibrary.Classes.Objects;
using WarOfWordsLibrary.Controls.Controls;
using WarOfWordsLoader.Classes.Managers;

namespace WarOfWordsLibrary.Classes.Settings
{
    public class QueryHistorySetting : ISetting
    {
        private BarSubItem barSubItem = new BarSubItem();
        private XmlManagerT<QueryHistory> xmlManager = new XmlManagerT<QueryHistory>();
        private QueryHistory queryHistory = null;
        public event SettingChangedHandle SettingChanged;

        public bool Enabled
        {
            get
            {
                return true;
            }
        }

        public string Name
        {
            get
            {
                return "历史";
            }
        }

        public int SortID
        {
            get
            {
                return 1;
            }
        }

        public Image Icon
        {
            get
            {
                return null;
            }
        }

        public string SettingContent
        {
            get;
            set;
        }

        public object SettingObject
        {
            get
            {
                return queryHistory;
            }
        }

        public BarSubItem BarSubItem
        {
            get
            {
                return barSubItem;
            }
        }

        public bool Init()
        {
            if (SettingContent != null && SettingContent.Trim() != string.Empty)
            {
                queryHistory = xmlManager.DeserializeToObject(SettingContent);
            }
            if (queryHistory == null)
            {
                queryHistory = new QueryHistory();
            }
            RepositoryItemSpinEditPlus repositoryItemSpinEditPlus = new RepositoryItemSpinEditPlus();
            BarEditItem barSpinEditItem = new BarEditItem();
            barSpinEditItem.Edit = repositoryItemSpinEditPlus;
            barSpinEditItem.EditValue = queryHistory.MaxNumber;
            barSpinEditItem.Caption = "数量";
            repositoryItemSpinEditPlus.MinValue = 0;
            repositoryItemSpinEditPlus.Buttons.Add(new EditorButton(ButtonPredefines.Combo));
            repositoryItemSpinEditPlus.QueryHistory = queryHistory;
            repositoryItemSpinEditPlus.EditValueChanged += repositoryItemSpinEditPlus_EditValueChanged;
            barSubItem.AddItem(barSpinEditItem);
            return true;
        }

        void repositoryItemSpinEditPlus_EditValueChanged(object sender, System.EventArgs e)
        {
            Changed();
        }

        public void Changed()
        {
            SettingContent = xmlManager.SerializeToString(queryHistory);
            if (SettingChanged != null)
            {
                SettingChanged(this);
            }
        }
    }
}
