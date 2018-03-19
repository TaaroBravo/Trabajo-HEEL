using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadResources{

    private static LoadResources _instance;
    public static LoadResources Instance {
        get
        {
            if (_instance == null) _instance = new LoadResources();
            return _instance;
        }
    }
    public LookUpTable<string, Object> resourcesTable;

    public LoadResources()
    { 
        resourcesTable = new LookUpTable<string, Object>(FactoryMethodResources);
    }

    private Object FactoryMethodResources(string n)
    {
        return Resources.Load(n);
    }
}
