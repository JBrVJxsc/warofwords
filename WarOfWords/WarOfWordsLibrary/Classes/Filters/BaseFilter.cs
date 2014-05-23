using System.Collections.Generic;
using System.Xml.Serialization;
using WarOfWordsLibrary.Classes.Objects;

namespace WarOfWordsLibrary.Classes.Filters
{
    public abstract class BaseFilter
    {
        private bool enabled = true; 
        private int precision = -1;

        public bool Enabled
        {
            get
            {
                return enabled;
            }
            set
            {
                enabled = value;
            }
        }

        [XmlIgnore]
        public int MaxWordLength
        {
            get;
            set;
        }

        [XmlIgnore]
        public List<int> WordLengthList
        {
            get;
            set;
        }

        [XmlIgnore]
        public List<FilterElement> FilterElements
        {
            get;
            set;
        }

        public int DefaultPrecision
        {
            get
            {
                return 4;
            }
        }

        public int Precision
        {
            get
            {
                return precision;
            }
            set
            {
                precision = value;
            }
        }
    }
}
