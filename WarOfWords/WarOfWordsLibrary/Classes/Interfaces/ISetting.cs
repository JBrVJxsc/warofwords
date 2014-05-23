using DevExpress.XtraBars;
using System.Drawing;

namespace WarOfWordsLibrary.Classes.Interfaces
{
    public interface  ISetting
    {
        event SettingChangedHandle SettingChanged;

        bool Enabled
        {
            get;
        }

        string Name
        {
            get;
        }

        int SortID
        {
            get;
        }

        Image Icon
        {
            get;
        }

        string SettingContent
        {
            get;
            set;
        }

        object SettingObject
        {
            get;
        }

        BarSubItem BarSubItem
        {
            get;
        }

        bool Init();

        void Changed();
    }

    public delegate void SettingChangedHandle(object sender);
}
