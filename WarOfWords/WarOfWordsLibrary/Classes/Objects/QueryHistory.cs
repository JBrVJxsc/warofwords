
using System.Collections.Generic;
namespace WarOfWordsLibrary.Classes.Objects
{
    public class QueryHistory
    {
        private int maxNumber = 10;

        public int MaxNumber
        {
            get
            {
                return maxNumber;
            }
            set
            {
                maxNumber = value;
            }
        }

        public List<string> HistoryList
        {
            get;
            set;
        }

        public void Add(string word)
        {
            if (HistoryList == null)
            {
                HistoryList = new List<string>();
            }
            HistoryList.Remove(word);
            HistoryList.Add(word);
            while (HistoryList.Count > MaxNumber)
            {
                if (HistoryList.Count > 0)
                {
                    HistoryList.RemoveAt(0);
                }
            }
        }
    }
}
