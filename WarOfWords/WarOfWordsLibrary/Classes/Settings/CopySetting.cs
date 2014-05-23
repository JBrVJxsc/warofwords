using DevExpress.XtraBars;
using System.Drawing;
using WarOfWordsLibrary.Classes.Interfaces;

namespace WarOfWordsLibrary.Classes.Settings
{
    public class CopySetting : ISetting
    {
        private BarSubItem barSubItem = new BarSubItem();
        public event SettingChangedHandle SettingChanged;
        private int[] copyedColumns;

        public bool Enabled
        {
            get
            {
                return false;
            }
        }

        public string Name
        {
            get
            {
                return "复制";
            }
        }

        public int SortID
        {
            get
            {
                return 2;
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
                return copyedColumns;
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
            return true;
        }

        public void Changed()
        {
            if (SettingChanged != null)
            {
                SettingChanged(this);
            }
        }
    }
}
