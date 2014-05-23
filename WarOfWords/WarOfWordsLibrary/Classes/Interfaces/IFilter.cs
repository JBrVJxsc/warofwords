
using System.Collections.Generic;
using WarOfWordsLibrary.Classes.Objects;
namespace WarOfWordsLibrary.Classes.Interfaces
{
    public interface IFilter
    {
        bool Enabled
        {
            get;
            set;
        }

        string Rank
        {
            get;
        }

        int MaxWordLength
        {
            get;
            set;
        }

        List<int> WordLengthList
        {
            get;
            set;
        }

        string FilterName
        {
            get;
        }

        string FilterDescription
        {
            get;
        }

        string FilterExample
        {
            get;
        }

        int MaxPrecision
        {
            get;
        }

        int DefaultPrecision
        {
            get;
        }

        int Precision
        {
            get;
            set;
        }

        List<FilterElement> FilterElements
        {
            get;
            set;
        }

        int SortID
        {
            get;
        }

        int GetFilterElements(string keyWord);
    }
}
