using System.Collections.Generic;
using WarOfWordsLibrary.Classes.Interfaces;

namespace WarOfWordsLibrary.Classes.Objects.Settings
{
    public class SingleFilterSettingList
    {
        private List<SingleFilterSetting> filterList = new List<SingleFilterSetting>();

        public List<SingleFilterSetting> FilterList
        {
            get
            {
                return filterList;
            }
            set
            {
                filterList = value;
            }
        }

        public List<object> GetSettingList()
        {
            List<object> objectList = new List<object>();
            foreach (SingleFilterSetting singleFilterSetting in FilterList)
            {
                object obj = singleFilterSetting.GetFilterSettingObject();
                if (obj != null)
                {
                    objectList.Add(obj);
                }
            }
            return objectList;
        }

        public void SetSettingList(List<IFilter> iFilterList)
        {
            FilterList = new List<SingleFilterSetting>();
            foreach (IFilter iFilter in iFilterList)
            {
                SingleFilterSetting singleFilterSetting = new SingleFilterSetting(iFilter);
                FilterList.Add(singleFilterSetting);
            }
        }
    }
}
