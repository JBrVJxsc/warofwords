using System.Collections.Generic;
using WarOfWordsLibrary.Classes.Interfaces;
using WarOfWordsLibrary.Classes.Objects;

namespace WarOfWordsLibrary.Classes.Filters
{
    public class Filter : BaseFilter, IFilter
    {
        public string Rank
        {
            get
            {
                return "A";
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
                return "word->word";
            }
        }

        public int MaxPrecision
        {
            get
            {
                return 0;
            }
        }

        public int SortID
        {
            get
            {
                return 0;
            }
        }

        public int GetFilterElements(string keyWord)
        {
            FilterElements = new List<FilterElement>();
            FilterElement filterElement = new FilterElement();
            filterElement.BaseSortID = 1;
            filterElement.WordLength = keyWord.Length;
            filterElement.Filter = "WORD = '" + keyWord + "'";
            if (WordLengthList.Contains(filterElement.WordLength))
            {
                FilterElements.Add(filterElement);
            }
            return FilterElements.Count;
        }
    }
}
