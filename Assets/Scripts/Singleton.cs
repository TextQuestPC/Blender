﻿using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    public static T Instance { get; private set; }

    public virtual void Awake()
    {
        if (FindObjectsOfType<T>().Length > 1)
        {
            DestroyImmediate(gameObject);
            return;
        }

        Instance = (T)this;
    }
}
