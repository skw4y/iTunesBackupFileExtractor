using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace ItunesBackupFileExtractor
{
    public class ConfigHelper : ConfigurationSection
    {
        [ConfigurationProperty("ExtensionTypeElements")]
        public ExtensionTypeCollection ETCol
        {
            get { return ((ExtensionTypeCollection)(base["ExtensionTypeElements"])); }
        }
    }

    [ConfigurationCollection(typeof(ExtensionTypeElem))]
    public class ExtensionTypeCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new ExtensionTypeElem();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ExtensionTypeElem)(element)).Extension;
        }

        public ExtensionTypeElem this[int idx]
        {
            get
            {
                return (ExtensionTypeElem)BaseGet(idx);
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

    public class ExtensionTypeElem : ConfigurationElement
    {
        [ConfigurationProperty("Type", DefaultValue = "")]
        public string Type
        {
            get
            {
                return ((string)(base["Type"]));
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
