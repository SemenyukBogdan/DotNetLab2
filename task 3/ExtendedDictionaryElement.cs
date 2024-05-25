using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2_netcore
{
    public class ExtendedDictionaryElement<T, U, V>
    {
        public T Key { get; }
        public U Value1 { get; }
        public V Value2 { get; }

        public ExtendedDictionaryElement(T key, U value1, V value2)
        {
            Key = key;
            Value1 = value1;
            Value2 = value2;
        }
    }

}
