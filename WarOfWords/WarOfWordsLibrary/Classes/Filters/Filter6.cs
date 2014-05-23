using System.Collections.Generic;
using WarOfWordsLibrary.Classes.Interfaces;
using WarOfWordsLibrary.Classes.Objects;

namespace WarOfWordsLibrary.Classes.Filters
{
    public class Filter6 : BaseFilter, IFilter
    {
        public string Rank
        {
            get
            {
                return "E";
            }
        }

        public string FilterName
        {
            get { throw new System.NotImplementedException(); }
        }

        public string FilterDescription
        {
            get { throw new System.NotImplementedException(); }
        }

        public string FilterExample
        {
            get
            {
                return "word->or";
            }
        }

        public int MaxPrecision
        {
            get
            {
                return 9;
            }
        }

        public int SortID
        {
            get
            {
                return 6;
            }
        }

        public int GetFilterElements(string keyWord)
        {
            FilterElements = new List<FilterElement>();
            if (keyWord.Length < 4)
            {
                return FilterElements.Count;
            }
            string keyWordTrimed = keyWord.Substring(1, keyWord.Length - 2);
            for (int i = 0; i < keyWordTrimed.Length; i++)
            {
                FilterElement filterElement = new FilterElement();
                filterElement.BaseSortID = i + 1;
                filterElement.WordLength = keyWordTrimed.Length - i;
                float portion = (float)filterElement.WordLength / keyWord.Length;
                if (portion < 0.1f * Precision)
                {
                    break;
                }
                if (!WordLengthList.Contains(filterElement.WordLength))
                {
                    continue;
                }
                for (int j = 0; j <= i; j++)
                {
                    filterElement.Filter += "WORD = '" + keyWordTrimed.Substring(j, filterElement.WordLength) + "' OR ";
                }
                filterElement.Filter = filterElement.Filter.Substring(0, filterElement.Filter.Length - 4);
                FilterElements.Add(filterElement);
            }
            return FilterElements.Count;
        }
    }
}
