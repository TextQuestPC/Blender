using UnityEngine;

public class Singleton2<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    protected void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = gameObject.GetComponent<T>();
        }

        AfterAwaik();
    }

    protected virtual void AfterAwaik() { }

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError(typeof(T) + "  ?? ??????!!!");
            }

            return instance;
        }
    }
}
