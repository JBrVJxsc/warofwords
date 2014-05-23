using System.Collections;
using System.Collections.Generic;
using System.Data;
using WarOfWordsLibrary.Classes.Interfaces;
using WarOfWordsLibrary.Classes.Managers;
using WarOfWordsLibrary.Classes.Objects;
using WarOfWordsLibrary.Classes.Settings;

namespace WarOfWordsLibrary.Classes.Dictionary
{
    public class DictionaryEngine
    {
        private DataBaseManager dataBaseManager = new DataBaseManager();
        private Hashtable htWordDataSetList = null;
        private DataTable queryResult = new DataTable();
        public event SetMinMaxOfProgressHandle SetMinMaxOfProgress;
        public event SetProgressValueHandle SetProgressValue;

        public DataTable QueryResult
        {
            get
            {
                return queryResult;
            }
            set
            {
                queryResult = value;
            }
        }

        public void Init()
        {
            InitQueryResult();
            List<int> wordLengthList = dataBaseManager.GetWordLengthList();
            InitDictionary(wordLengthList);
            int maxWordLength = dataBaseManager.GetMaxWordLength();
            InitFilters(maxWordLength, wordLengthList);
        }

        private void InitQueryResult()
        {
            QueryResult.Columns.Add("单词", typeof(string));
            QueryResult.Columns.Add("音标", typeof(string));
            QueryResult.Columns.Add("翻译", typeof(string));
            QueryResult.Columns.Add("评级", typeof(string));
            QueryResult.Columns.Add("过滤", typeof(string));
        }

        private void InitDictionary(List<int> wordLengthList)
        {
            htWordDataSetList = dataBaseManager.GetWordDataSets(wordLengthList);
        }

        private void InitFilters(int maxWordLength, List<int> wordLengthList)
        {
            foreach (IFilter iFilter in FilterSetting.iFilterList)
            {
                iFilter.MaxWordLength = maxWordLength;
                iFilter.WordLengthList = wordLengthList;
            }
        }

        private void GetWords(ref int count, string rank, string logicName, List<FilterElement> filterElementList)
        {
            List<string> results = new List<string>();
            foreach (FilterElement filterElement in filterElementList)
            {
                int baseSortID = filterElement.BaseSortID * 100000;
                DataRow[] dataRows = null; ;
                if (filterElement.QueryFromDataBase)
                {
                    dataRows = dataBaseManager.GetWordDataRows(filterElement.Filter);
                }
                else
                {
                    DataSet dataSet = htWordDataSetList[filterElement.WordLength] as DataSet;
                    if (dataSet == null)
                    {
                        continue;
                    }
                    dataRows = dataSet.Tables[0].DataSet.Tables[0].Select(filterElement.Filter);
                }
                if (dataRows == null)
                {
                    continue;
                }
                for (int i = 0; i < dataRows.Length; i++)
                {
                    DataRow dataRow = QueryResult.NewRow();
                    dataRow[0] = dataRows[i][0].ToString();
                    dataRow[1] = dataRows[i][1].ToString();
                    dataRow[2] = dataRows[i][2].ToString();
                    dataRow[3] = rank + baseSortID;
                    dataRow[4] = logicName;
                    string word = dataRow[0].ToString();
                    if (!results.Contains(word))
                    {
                        QueryResult.Rows.Add(dataRow);
                        results.Add(word);
                        baseSortID++;
                    }
                }
                count++;
                SetProgressValue(count);
            }
        }

        public void Query(string keyWord)
        {
            QueryResult.Clear();
            int count = 0;
            int minNumber = 0;
            int maxNumber = 0;
            string keyWordTrimed = keyWord.Trim().ToLower();
            if (keyWordTrimed == string.Empty)
            {
                return;
            }
            foreach (IFilter iFilter in FilterSetting.iFilterList)
            {
                if (!iFilter.Enabled)
                {
                    continue;
                }
                maxNumber += iFilter.GetFilterElements(keyWordTrimed);
            }
            SetMinMaxOfProgress(minNumber, maxNumber);
            foreach (IFilter iFilter in FilterSetting.iFilterList)
            {
                if (!iFilter.Enabled)
                {
                    continue;
                }
                GetWords(ref count, iFilter.Rank, iFilter.GetType().Name, iFilter.FilterElements);
            }
            QueryResult.DefaultView.Sort = "评级";
        }
    }

    public delegate void SetMinMaxOfProgressHandle(int min, int max);
    public delegate void SetProgressValueHandle(int value);
}
