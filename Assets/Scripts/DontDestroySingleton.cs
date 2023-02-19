public class DontDestroySingleton<T> : Singleton<T> where T : DontDestroySingleton<T>
{
    public override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }
}
