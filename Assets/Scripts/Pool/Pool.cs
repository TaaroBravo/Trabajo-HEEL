using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pool<T>
{
    private List<ObjectPool<T>> _poolList;
    public delegate T CallbackFactory();

    public int count;
    public int currentActiveCount;
    private bool _isDinamic = false;
    private ObjectPool<T>.PoolCallback _init;
    private ObjectPool<T>.PoolCallback _finalize;
    private CallbackFactory _factoryMethod;

    public Pool(int initialStock, CallbackFactory factoryMethod, ObjectPool<T>.PoolCallback initialize, ObjectPool<T>.PoolCallback finalize, bool isDinamic)
    {
        _poolList = new List<ObjectPool<T>>();

        _factoryMethod = factoryMethod;
        _isDinamic = isDinamic;
        count = initialStock;
        currentActiveCount = initialStock;
        _init = initialize;
        _finalize = finalize;

        for (int i = 0; i < count; i++)
        {
            _poolList.Add(new ObjectPool<T>(_factoryMethod(), _init, _finalize));
        }
    }

    public ObjectPool<T> GetPoolObject()
    {
        for (int i = 0; i < count; i++)
        {
            if (!_poolList[i].isActive)
            {
                _poolList[i].isActive = true;
                return _poolList[i];
            }
        }
        if (_isDinamic)
        {
            ObjectPool<T> po = new ObjectPool<T>(_factoryMethod(), _init, _finalize);
            po.isActive = true;
            _poolList.Add(po);
            count++;
            return po;
        }
        return null;
    }

    public T GetObjectFromPool()
    {
        for (int i = 0; i < count; i++)
        {
            if (!_poolList[i].isActive)
            {
                _poolList[i].isActive = true;
                return _poolList[i].GetObj;
            }
        }

        if (_isDinamic)
        {
            ObjectPool<T> po = new ObjectPool<T>(_factoryMethod(), _init, _finalize);
            po.isActive = true;
            _poolList.Add(po);
            count++;
            currentActiveCount++;
            return po.GetObj;
        }

        return default(T);
    }

    public void DisablePoolObject(T obj)
    {
        foreach (ObjectPool<T> poolObj in _poolList)
        {
            if (poolObj.GetObj.Equals(obj))
            {
                poolObj.isActive = false;
                currentActiveCount--;
                return;
            }
        }
    }

    public void Clear()
    {
        _poolList.Clear();
    }
}
