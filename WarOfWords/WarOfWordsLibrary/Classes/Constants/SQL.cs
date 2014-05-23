
namespace WarOfWordsLibrary.Classes.Constants
{
    public static class SQL
    {
        public static readonly string Get_Max_WordLength = "SELECT MAX(LENGTH(WORD)) FROM DICTIONARY";
        public static readonly string Get_WordLength_List = "SELECT DISTINCT LENGTH(WORD) FROM DICTIONARY";
        public static readonly string Get_DataSets_By_WordLength = "SELECT WORD, ACCENT, MEANING FROM DICTIONARY WHERE LENGTH(WORD)= {0}";
        public static readonly string Get_DataRows_By_WordLength_And_Filter = "SELECT WORD, ACCENT, MEANING FROM DICTIONARY WHERE {0}";
    }
}
