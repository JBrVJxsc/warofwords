using System;

namespace WarOfWordsLibrary.Classes.Objects
{
    public class Word : IComparable
    {
        public string Name
        {
            get;
            set;
        }

        public string Accent
        {
            get;
            set;
        }

        public string Meaning
        {
            get;
            set;
        }

        public int SortID
        {
            get;
            set;
        }

        public int CompareTo(object obj)
        {
            Word word = obj as Word;
            if (SortID > word.SortID)
            {
                return 1;
            }
            else if (SortID < word.SortID)
            {
                return -1;
            }
            return 0;
        }
    }
}
