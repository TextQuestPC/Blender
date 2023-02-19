using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerScenes : DontDestroySingleton<ManagerScenes>
{
    [SerializeField] private bool isGameScene = false;
    public bool GetIsGameScene { get => isGameScene; }

    public void LoadGameScene()
    {
        isGameScene = true;
        SceneManager.LoadScene(1);
    }

    public void LoadMenuScene()
    {
        isGameScene = false;
        SceneManager.LoadScene(0);
    }
}
