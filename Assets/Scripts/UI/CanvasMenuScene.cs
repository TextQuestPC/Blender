using UnityEngine;
using YG;

public class CanvasMenuScene : Singleton<CanvasMenuScene>
{
    [SerializeField] private GameObject mainButtons;
    [SerializeField] private GameObject startButtons;
    public void ClickFirstStart()
    {
        if(ManagerSaveLoad.Instance.LoadLevel() > 0)
        {
            mainButtons.GetComponent<Animator>().SetTrigger("Hide");
            startButtons.GetComponent<Animator>().SetTrigger("Show");
        }
        else
        {
            ManagerScenes.Instance.LoadGameScene();
        }
    }

    public void ClickSecondStart()
    {
        ManagerScenes.Instance.LoadGameScene();
    }

    public void ClickRestartAllLevels()
    {
        ManagerSaveLoad.Instance.ResetValueLevels();
        ManagerScenes.Instance.LoadGameScene();
    }

    public void BackMainButtons()
    {
        mainButtons.GetComponent<Animator>().SetTrigger("Show");
        startButtons.GetComponent<Animator>().SetTrigger("Hide");
    }
}
