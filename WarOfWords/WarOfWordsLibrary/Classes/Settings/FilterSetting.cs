using DevExpress.Utils;
using DevExpress.XtraBars;
using System.Collections.Generic;
using System.Drawing;
using WarOfWordsLibrary.Classes.Interfaces;
using WarOfWordsLibrary.Classes.Objects.Settings;
using WarOfWordsLibrary.Controls.Controls;
using WarOfWordsLibrary.Managers;
using WarOfWordsLoader.Classes.Managers;

namespace WarOfWordsLibrary.Classes.Settings
{
    public class FilterSetting : ISetting
    {
        public event SettingChangedHandle SettingChanged;
        private BarSubItem barSubItem = new BarSubItem();
        public static List<IFilter> iFilterList = new List<IFilter>();
        private SingleFilterSettingList singleFilterSettingList = new SingleFilterSettingList();
        private XmlManagerT<SingleFilterSettingList> xmlManagerSingleFilterSettingList = new XmlManagerT<SingleFilterSettingList>();
        private Font exampleTitleFont = new Font("微软雅黑", 10.5F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));

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
                return "过滤";
            }
        }

        public int SortID
        {
            get
            {
                return 0;
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

        public BarSubItem BarSubItem
        {
            get
            {
                return barSubItem;
            }
        }

        public object SettingObject
        {
            get
            {
                return null;
            }
        }

        public bool Init()
        {
            if (SettingContent != null && SettingContent.Trim() != string.Empty)
            {
                singleFilterSettingList = xmlManagerSingleFilterSettingList.DeserializeToObject(SettingContent);
            }
            List<object> objectListSaved = new List<object>();
            if (singleFilterSettingList != null)
            {
                objectListSaved = singleFilterSettingList.GetSettingList();
            }
            List<object> objectList = ReflectionManager.CreateInstancesByInterface(typeof(IFilter));
            foreach (object obj in objectList)
            {
                bool useSaved = false;
                IFilter iFilter = obj as IFilter;
                foreach (object objSaved in objectListSaved)
                {
                    IFilter iFilterSaved = objSaved as IFilter;
                    if (iFilter.GetType().Name == iFilterSaved.GetType().Name)
                    {
                        iFilterList.Add(iFilterSaved);
                        useSaved = true;
                        break;
                    }
                }
                if (!useSaved)
                {
                    iFilterList.Add(iFilter);
                }
            }
            BarSubItem[] subItems = new BarSubItem[objectList.Count];
            for (int i = 0; i < subItems.Length; i++)
            {
                subItems[i] = new BarSubItem();
                barSubItem.AddItem(subItems[i]);
            }
            foreach (IFilter iFilter in iFilterList)
            {
                PrepareSubItem(subItems[iFilter.SortID], iFilter);
            }
            return true;
        }

        public void Changed()
        {
            singleFilterSettingList.SetSettingList(iFilterList);
            SettingContent = xmlManagerSingleFilterSettingList.SerializeToString(singleFilterSettingList);
            if (SettingChanged != null)
            {
                SettingChanged(this);
            }
        }

        private void PrepareSubItem(BarSubItem barSubItem, IFilter iFilter)
        {
            barSubItem.Caption = iFilter.GetType().Name;
            RepositoryItemCheckEditPlus repositoryItemCheckEditPlus = new RepositoryItemCheckEditPlus();
            BarEditItem barCheckItem = new BarEditItem();
            barCheckItem.Edit = repositoryItemCheckEditPlus;
            barCheckItem.EditValue = iFilter.Enabled;
            barCheckItem.Caption = "启用";
            repositoryItemCheckEditPlus.IFilter = iFilter;
            repositoryItemCheckEditPlus.EditValueChanged += repositoryItemCheckEditPlus_EditValueChanged;
            barSubItem.AddItem(barCheckItem);
            if (iFilter.MaxPrecision != 0)
            {
                RepositoryItemZoomTrackBarPlus repositoryItemZoomTrackBarPlus = new RepositoryItemZoomTrackBarPlus();
                BarEditItem barZoomTrackBarItem = new BarEditItem();
                barZoomTrackBarItem.Edit = repositoryItemZoomTrackBarPlus;
                if (iFilter.Precision <0)
                {
                    iFilter.Precision = iFilter.DefaultPrecision;
                }
                barZoomTrackBarItem.EditValue = iFilter.Precision;
                barZoomTrackBarItem.Caption = "精度";
                barZoomTrackBarItem.Width = 150;
                repositoryItemZoomTrackBarPlus.Middle = iFilter.DefaultPrecision;
                repositoryItemZoomTrackBarPlus.Maximum = iFilter.MaxPrecision;
                repositoryItemZoomTrackBarPlus.IFilter = iFilter;
                repositoryItemZoomTrackBarPlus.EditValueChanged += repositoryItemZoomTrackBarPlus_EditValueChanged;
                barSubItem.AddItem(barZoomTrackBarItem);
            }
            BarStaticItem barStaticItem = new BarStaticItem();
            barStaticItem.Caption = "示例";
            barStaticItem.ItemAppearance.Normal.Font = exampleTitleFont;
            barStaticItem.ItemAppearance.Normal.Options.UseFont = true;
            barSubItem.AddItem(barStaticItem);
            BarStaticItem barStaticItemExample = new BarStaticItem();
            barStaticItemExample.Caption = "    " + iFilter.FilterExample;
            barSubItem.AddItem(barStaticItemExample);
        }

        void repositoryItemZoomTrackBarPlus_EditValueChanged(object sender, System.EventArgs e)
        {
            Changed();
        }

        void repositoryItemTrackBarPlus_EditValueChanged(object sender, System.EventArgs e)
        {
            Changed();
        }

        void repositoryItemCheckEditPlus_EditValueChanged(object sender, System.EventArgs e)
        {
            Changed();
        }
    }
}
