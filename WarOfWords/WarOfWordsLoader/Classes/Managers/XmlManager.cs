using DevExpress.XtraEditors;
using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace WarOfWordsLoader.Classes.Managers
{
    public class XmlManager
    {
        private Type type = null;
        private XmlSerializer xmlSerializer = null;
        private LogManager logManager = new LogManager();

        public XmlManager(Type type)
        {
            this.type = type;
            xmlSerializer = new XmlSerializer(this.type);
        }

        public string SerializeToString(object obj)
        {
            using (StringWriter sw = new StringWriter())
            {
                xmlSerializer.Serialize(sw, obj);
                return sw.ToString();
            }
        }

        public object DeserializeToObject(string tXml)
        {
            using (StringReader sr = new StringReader(tXml))
            {
                object t = null;
                try
                {
                    t = xmlSerializer.Deserialize(sr);
                }
                catch (Exception e)
                {
                    logManager.CreateLog(e);
                    XtraMessageBox.Show("从字符串转化至实体出错。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
                return t;
            }
        }

        public bool SerializeToFile(object obj, string url)
        {
            StreamWriter sw = new StreamWriter(url);
            try
            {
                sw.Write(SerializeToString(obj));
                return true;
            }
            catch (Exception e)
            {
                logManager.CreateLog(e);
                XtraMessageBox.Show("从实体转化至文件出错。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                sw.Close();
                sw.Dispose();
            }
            return false;
        }

        public object DeserializeToObjectFromFile(string url)
        {
            if (!File.Exists(url))
            {
                return null;
            }
            StreamReader sr = new StreamReader(url);
            string content = string.Empty;
            try
            {
                content = sr.ReadToEnd();
                sr.Close();
            }
            catch (Exception e)
            {
                logManager.CreateLog(e);
                XtraMessageBox.Show("从文件转化至实体出错。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                sr.Close();
                sr.Dispose();
            }
            return DeserializeToObject(content);
        }
    }
}
