using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Singleton<SingletonType> : MonoBehaviour where SingletonType : MonoBehaviour
{
    private static SingletonType _instance = null;
    [SerializeField]  private bool _isPersistent = false;

    public static SingletonType Instance
    {
        // Not thread safe
        get
        {

            if (_instance != null) return _instance;
            // --------------------------------------------------------------------
            // Attributes to find an instance
            string singletonName = RemoveNamespacesFromAssemblyType(typeof(SingletonType).ToString());
            var instances = FindObjectsOfType<SingletonType>();
            var count = instances.Length;
            //Debug.Log(typeof(SingletonType).ToString() + " have count: " + count);
            // --------------------------------------------------------------------
            // More than one instance in Scene
            while (count > 1)
            {
                Destroy(instances[--count].gameObject); // prefix '--' to not OutOfBounds errors
            }

            // --------------------------------------------------------------------
            // Only one instance in Scene
            if (count == 1)
            {
                _instance = instances[0];
                return _instance;
            }

            // --------------------------------------------------------------------
            // No instance in Scene so try to instantiate from prefab else construct one
            try
            {
                GameObject newInstance = (GameObject)Instantiate(Resources.Load(singletonName, typeof(GameObject)));
                _instance = newInstance.GetComponent<SingletonType>();
                return _instance;
            }
            catch (Exception e) // send error and create blank new
            {
                Debug.LogError("could not instantiate prefab[ " + singletonName + " ]" + e.Message + "\n" + e.StackTrace);

                GameObject newInstance = new GameObject(singletonName);
                newInstance.AddComponent<SingletonType>();
                _instance = newInstance.GetComponent<SingletonType>();
            }

            return _instance;
        }
    }

    private static string RemoveNamespacesFromAssemblyType(string name)
    {
        string typename = "";
        for (int i = name.Length - 1; i > 0; --i)
        {
            if (name[i] == '.')
            {
                for (int j = i + 1; j < name.Length; ++j)
                {
                    typename += name[j];
                }
                return typename;
            }
        }
        return name;
    }

    private void Awake()
    {
        if (_isPersistent) DontDestroyOnLoad(this.gameObject);
    }
}
