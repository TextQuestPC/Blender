using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class DontDestroy : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
