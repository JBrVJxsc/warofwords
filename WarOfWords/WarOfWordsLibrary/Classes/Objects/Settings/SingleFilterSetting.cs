
using System;
using WarOfWordsLibrary.Classes.Interfaces;
using WarOfWordsLoader.Classes.Managers;
namespace WarOfWordsLibrary.Classes.Objects.Settings
{
    public class SingleFilterSetting
    {
        public SingleFilterSetting()
        { 
            
        }

        public SingleFilterSetting(IFilter iFilter)
        {
            FilterName = iFilter.GetType().FullName;
            XmlManager xmlManager = new XmlManager(iFilter.GetType());
            Content = xmlManager.SerializeToString(iFilter);
        }

        public string FilterName
        {
            get;
            set;
        }

        public string Content
        {
            get;
            set;
        }

        public object GetFilterSettingObject()
        {
            XmlManager xmlManager = new XmlManager(Type.GetType(FilterName));
            return xmlManager.DeserializeToObject(Content);
        }
    }
}
