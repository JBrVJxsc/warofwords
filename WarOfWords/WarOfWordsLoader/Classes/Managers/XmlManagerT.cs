using DevExpress.XtraEditors;
using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace WarOfWordsLoader.Classes.Managers
{
    public class XmlManagerT<T>
    {
        private XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
        private LogManager logManager = new LogManager();

        public string SerializeToString(T t)
        {
            using (StringWriter sw = new StringWriter())
            {
                xmlSerializer.Serialize(sw, t);
                return sw.ToString();
            }
        }

        public T DeserializeToObject(string tXml)
        {
            using (StringReader sr = new StringReader(tXml))
            {
                T t = default(T);
                try
                {
                    t = ((T)xmlSerializer.Deserialize(sr));
                }
                catch (Exception e)
                {
                    logManager.CreateLog(e);
                    XtraMessageBox.Show("从字符串转化至实体出错。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return default(T);
                }
                return t;
            }
        }

        public bool SerializeToFile(T t, string url)
        {
            StreamWriter sw = new StreamWriter(url);
            try
            {
                sw.Write(SerializeToString(t));
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

        public T DeserializeToObjectFromFile(string url)
        {
            if (!File.Exists(url))
            {
                return default(T);
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
