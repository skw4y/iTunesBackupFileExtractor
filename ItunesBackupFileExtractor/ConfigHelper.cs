using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace ItunesBackupFileExtractor
{
    public class ConfigHelper : ConfigurationSection
    {
        [ConfigurationProperty("MagicNumberElements")]
        public MagicNumberCollection MNCol
        {
            get { return ((MagicNumberCollection)(base["MagicNumberElements"])); }
        }


        //[ConfigurationProperty("MagicNumberElements")]
        //[ConfigurationCollection(typeof(MagicNumberElem), AddItemName = "add", ClearItemsName = "clear", RemoveItemName = "remove")]
        //public GenericConfigurationElementCollection<MagicNumberElem> MNCol
        //{
        //    get { return (GenericConfigurationElementCollection<MagicNumberElem>)this["MagicNumberElements"]; }
        //}
    }

    [ConfigurationCollection(typeof(MagicNumberElem))]
    public class MagicNumberCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new MagicNumberElem();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((MagicNumberElem)(element)).MagicNumber;
        }

        public MagicNumberElem this[int idx]
        {
            get
            {
                return (MagicNumberElem)BaseGet(idx);
            }
        }
    }

    public class GenericConfigurationElementCollection<T> : ConfigurationElementCollection, IEnumerable<T> where T : ConfigurationElement, new()
    {
        List<T> _elements = new List<T>();

        protected override ConfigurationElement CreateNewElement()
        {
            T newElement = new T();
            _elements.Add(newElement);
            return newElement;
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return _elements.Find(e => e.Equals(element));
        }

        public new IEnumerator<T> GetEnumerator()
        {
            return _elements.GetEnumerator();
        }
    }

    public class MagicNumberElem : ConfigurationElement
    {
        [ConfigurationProperty("MagicNumber", DefaultValue = "")]
        public string MagicNumber
        {
            get
            {
                return ((string)(base["MagicNumber"]));
            }
        }

        [ConfigurationProperty("Extension", DefaultValue = "")]
        public string Extension
        {
            get
            {
                return ((string)(base["Extension"]));
            }
        }
    }
}
