using lab_2_netcore;
using System;
using System.Collections;
using System.Collections.Generic;

public class ExtendedDictionary<T, U, V> : IEnumerable<ExtendedDictionaryElement<T, U, V>>
{
    private readonly Dictionary<T, ExtendedDictionaryElement<T, U, V>> _dictionary;

    public ExtendedDictionary()
    {
        _dictionary = new Dictionary<T, ExtendedDictionaryElement<T, U, V>>();
    }

    public void Add(T key, U value1, V value2)
    {
        var element = new ExtendedDictionaryElement<T, U, V>(key, value1, value2);
        _dictionary[key] = element;
    }

    public bool Remove(T key)
    {
        return _dictionary.Remove(key);
    }

    public bool ContainsKey(T key)
    {
        return _dictionary.ContainsKey(key);
    }

    public bool ContainsValue(U value1, V value2)
    {
        foreach (var element in _dictionary.Values)
        {
            if (element.Value1.Equals(value1) && element.Value2.Equals(value2))
            {
                return true;
            }
        }
        return false;
    }

    public ExtendedDictionaryElement<T, U, V> this[T key]
    {
        get
        {
            if (_dictionary.TryGetValue(key, out var element))
            {
                return element;
            }
            throw new KeyNotFoundException($"Key '{key}' not found.");
        }
    }

    public int Count => _dictionary.Count;

    public IEnumerator<ExtendedDictionaryElement<T, U, V>> GetEnumerator()
    {
        return _dictionary.Values.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
