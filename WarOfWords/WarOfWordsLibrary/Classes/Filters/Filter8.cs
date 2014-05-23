using System.Collections.Generic;
using WarOfWordsLibrary.Classes.Interfaces;
using WarOfWordsLibrary.Classes.Objects;

namespace WarOfWordsLibrary.Classes.Filters
{
    public class Filter8 : BaseFilter, IFilter
    {
        public string Rank
        {
            get
            {
                return "G";
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
                return "word->world";
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
                return 8;
            }
        }

        public int GetFilterElements(string keyWord)
        {
            FilterElements = new List<FilterElement>();
            for (int i = 1; i <= keyWord.Length; i++)
            {
                float portion = (float)i / keyWord.Length;
                if (portion > (1 - 0.1f * Precision))
                {
                    break;
                }
                List<int[]> mapList = GetWildcardMap(i, keyWord.Length);
                int groupSplitNumber = 998;
                int partsNumber = mapList.Count / groupSplitNumber;
                for (int j = 0; j <= partsNumber; j++)
                {
                    FilterElement filterElement = new FilterElement();
                    filterElement.BaseSortID = i;
                    filterElement.QueryFromDataBase = true;
                    if (j != partsNumber)
                    {
                        for (int k = j * groupSplitNumber; k < (j + 1) * groupSplitNumber; k++)
                        {
                            filterElement.Filter += "WORD LIKE '" + FillWordWithWildcard(mapList[k], keyWord) + "' OR ";
                        }
                    }
                    else
                    {
                        for (int k = j * groupSplitNumber; k < mapList.Count; k++)
                        {
                            filterElement.Filter += "WORD LIKE '" + FillWordWithWildcard(mapList[k], keyWord) + "' OR ";
                        }
                    }
                    if (filterElement.Filter == null)
                    {
                        continue;
                    }
                    filterElement.Filter = filterElement.Filter.Substring(0, filterElement.Filter.Length - 4);
                    filterElement.Filter = "WORD <> '" + keyWord + "' AND (" + filterElement.Filter + ")";
                    FilterElements.Add(filterElement);
                }
            }
            return FilterElements.Count;
        }

        public List<int[]> GetWildcardMap(int wildcardNumber, int wordWidth)
        {
            List<int[]> map = new List<int[]>();
            int[] start = new int[wildcardNumber];
            int[] end = new int[wildcardNumber];
            for (int i = 1; i <= wildcardNumber; i++)
            {
                start[i - 1] = i;
                end[i - 1] = wordWidth - wildcardNumber + i;
            }
            map.Add(((int[])start.Clone()));
            while (!CompareArray(start, end))
            {
                StartSelfAdd(ref start, wordWidth, start.Length - 1);
                map.Add(((int[])start.Clone()));
            }
            return map;
        }

        public void StartSelfAdd(ref int[] start, int wordWidth, int addLocation)
        {
            if (addLocation == start.Length - 1)
            {
                if (start[addLocation] + 1 <= wordWidth)
                {
                    start[addLocation]++;
                }
                else
                {
                    StartSelfAdd(ref start, wordWidth, addLocation - 1);
                }
            }
            else
            {
                if (start[addLocation] + 1 <= wordWidth - (start.Length - 1 - addLocation))
                {
                    start[addLocation]++;
                    for (int i = 1; i < start.Length - addLocation; i++)
                    {
                        start[addLocation + i] = start[addLocation] + i;
                    }
                }
                else
                {
                    StartSelfAdd(ref start, wordWidth, addLocation - 1);
                }
            }
        }

        public bool CompareArray(int[] a, int[] b)
        {
            if (a.Length != b.Length)
            {
                return false;
            }
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                {
                    return false;
                }
            }
            return true;
        }

        public string FillWordWithWildcard(int[] map, string word)
        {
            string wordFilled = word;
            for (int i = 0; i < map.Length; i++)
            {
                wordFilled = wordFilled.Remove(map[i] - 1, 1);
                wordFilled = wordFilled.Insert(map[i] - 1, "%");
            }
            return wordFilled;
        }
    }
}
