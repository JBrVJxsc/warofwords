using DevExpress.XtraEditors;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using WarOfWordsLibrary.Classes.Interfaces;
using WarOfWordsLibrary.Classes.Managers;
using WarOfWordsLibrary.Classes.Objects;
using WarOfWordsLibrary.Classes.Settings;

namespace WarOfWordsLibrary.Controls.Controls
{
    public partial class ComboBoxEditPlus : ComboBoxEdit
    {
        public ComboBoxEditPlus()
        {
            InitializeComponent();
        }

        private QueryHistory queryHistory = null;
        private ISetting queryHistorySetting = null;
        private Regex regex = new Regex("^[A-Za-z]+$");

        public void SaveToQueryHistory()
        {
            if (Text.Trim() == string.Empty)
            {
                return;
            }
            queryHistory.Add(Text);
            queryHistorySetting.Changed();
            AddToItems();
        }

        public void PasteContent(bool replace)
        {
            string content = Clipboard.GetText();
            string trimedText = string.Empty;
            GetTrimedText(content, ref trimedText);
            if (replace)
            {
                Text = trimedText;
            }
            else
            {
                int start = SelectionStart;
                int length = SelectionLength;
                Text = Text.Remove(start, length);
                Text = Text.Insert(start, trimedText);
                Select(start + trimedText.Length, 0);
            }
        }

        private void AddToItems()
        {
            if (queryHistory == null || queryHistory.HistoryList == null)
            {
                return;
            }
            Properties.Items.Clear();
            for (int i = queryHistory.HistoryList.Count - 1; 0 <= i; i--)
            {
                Properties.Items.Add(queryHistory.HistoryList[i]);
            }
        }

        private void GetTrimedText(string text, ref string trimedText)
        {
            char[] chars = text.ToCharArray(0, text.Length);
            for (int i = 0; i < chars.Length; i++)
            {
                if (!regex.IsMatch(chars[i].ToString()))
                {
                    chars[i] = '-';
                }
            }
            trimedText = new string(chars).Replace("-", string.Empty);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.Enter)
            {
                SaveToQueryHistory();
            }
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (e.KeyChar == 0x16)
            {
                e.Handled = true;
                PasteContent(false);
            }
            else if (e.KeyChar != 0x08 && e.KeyChar != 0x0D && e.KeyChar != 0x03 && e.KeyChar != 0x18 && e.KeyChar != 0x01)
            {
                if (!regex.IsMatch(e.KeyChar.ToString()))
                {
                    e.Handled = true;
                }
            }
            base.OnKeyPress(e);
        }

        protected override void OnLoaded()
        {
            SettingManager.GlobalSettingManager.SettingInited += GlobalSettingManager_SettingInited;
            base.OnLoaded();
        }

        void GlobalSettingManager_SettingInited()
        {
            queryHistorySetting = SettingManager.GlobalSettingManager.GetISetting(typeof(QueryHistorySetting));
            queryHistory = queryHistorySetting.SettingObject as QueryHistory;
            AddToItems();
        }
    }
}
