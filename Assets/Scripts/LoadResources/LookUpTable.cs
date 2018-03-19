using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookUpTable<T1, T2>
{

    public delegate T2 FactoryMethod(T1 n);

    private Dictionary<T1, T2> _table = new Dictionary<T1, T2>();
    private FactoryMethod _factoryMethod;

    public LookUpTable(FactoryMethod factoryMethod)
    {
        _factoryMethod = factoryMethod;
    }

    public T2 GetValue(T1 key)
    {
        if (_table.ContainsKey(key))
        {
            return _table[key];
        }
        else
        {
            var value = _factoryMethod(key);
            _table[key] = value;
            return value;
        }
    }
}
