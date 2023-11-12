using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MonoBehaviourSingleton<T> : MonoBehaviour where T : Component
{

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                if (Resources.FindObjectsOfTypeAll<T>().Length > 0 &&
                    Resources.FindObjectsOfTypeAll<T>()[0] != null)
                {
                    instance = Resources.FindObjectsOfTypeAll<T>()[0];
                }
                else
                {
                    var createdOne = (T)new GameObject().AddComponent(typeof(T));
                    createdOne.name = typeof(T).Name.Substring(2);
                    instance = createdOne;
                }

            }
            return instance;
        }
    }

    private static T instance;
}