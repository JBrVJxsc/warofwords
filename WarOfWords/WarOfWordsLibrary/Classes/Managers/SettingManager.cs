using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.IO;
using WarOfWordsLibrary.Classes.Interfaces;
using WarOfWordsLibrary.Managers;
using WarOfWordsLoader.Classes.Managers;

namespace WarOfWordsLibrary.Classes.Managers
{
    public class SettingManager
    {
        private string settingFolderName = "Settings";
        private List<ISetting> iSettingList = new List<ISetting>();
        public static SettingManager GlobalSettingManager = new SettingManager();
        public event SettingInitedHandle SettingInited;

        public void Init(BarSubItem menu)
        {
            Check();
            SetMenu(menu);
        }

        public void Inited()
        {
            if (SettingInited != null)
            {
                SettingInited();
            }
        }

        private void SetMenu(BarSubItem barSubItem)
        {
            BarSubItem[] subItems = GetSubItems();
            for (int i = 0; i < subItems.Length; i++)
            {
                barSubItem.AddItem(subItems[i]);
            }
            foreach (ISetting iSetting in iSettingList)
            {
                iSetting.Init();
            }
        }

        public ISetting GetISetting(Type type)
        {
            foreach (ISetting iSetting in iSettingList)
            {
                if (iSetting.GetType() == type)
                {
                    return iSetting;
                }
            }
            return null;
        }

        private void Check()
        {
            if (!Directory.Exists(settingFolderName))
            {
                Directory.CreateDirectory(settingFolderName);
            }
        }

        private BarSubItem[] GetSubItems()
        {
            List<object> objectList = ReflectionManager.CreateInstancesByInterface(typeof(ISetting));
            List<object> finalObjectList = new List<object>();
            foreach (object obj in objectList)
            {
                Type type = obj.GetType();
                ISetting iSetting = obj as ISetting;
                if (!iSetting.Enabled)
                {
                    continue;
                }
                XmlManager xmlManager = new XmlManager(type);
                object temObject = xmlManager.DeserializeToObjectFromFile(settingFolderName+"\\"+type.Name);
                if (temObject != null)
                {
                    finalObjectList.Add(temObject);
                }
                else
                { 
                    finalObjectList.Add(obj);
                }
            }
            BarSubItem[] subItems = new BarSubItem[finalObjectList.Count];
            foreach (object obj in finalObjectList)
            {
                ISetting iSetting = obj as ISetting;
                iSettingList.Add(iSetting);
                iSetting.SettingChanged += iSetting_SettingChanged;
                subItems[iSetting.SortID] = iSetting.BarSubItem;
                subItems[iSetting.SortID].Caption = iSetting.Name;
            }
            return subItems;
        }

        void iSetting_SettingChanged(object sender)
        {
            XmlManager xmlManager = new XmlManager(sender.GetType());
            xmlManager.SerializeToFile(sender, settingFolderName + "\\" + sender.GetType().Name);
        }
    }

    public delegate void SettingInitedHandle();
}
