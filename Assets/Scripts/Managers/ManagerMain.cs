using System.Collections;
using UnityEngine;
using YG;

public class ManagerMain : Singleton<ManagerMain>
{
    [SerializeField] private BlenderAnimation blenderAnimation;
    [SerializeField] private GameObject collidersBlender;

    private TypeLoseLevel typeLoseLevel;
    public TypeLoseLevel GetTypeLoseLevel { get => typeLoseLevel; }

    private void Start()
    {
#if !UNITY_EDITOR
        ManagerLevel.Instance.SetCurrentNumberLevel = ManagerSaveLoad.Instance.LoadLevel();
#endif
        YandexGame.SaveProgress();
        ManagerLevel.Instance.NextLevel();
        ManagerStates.Instance.ChangeStateGame(TypeStateGame.Game);
    }

    /// <summary>
    /// Рецепт собран, отключение spawn, подгрузка нового уровня
    /// </summary>
    public void LevelWin()
    {
        ManagerTime.Instance.TimerStop();
        ManagerStates.Instance.ChangeStateGame(TypeStateGame.LoadingLevel);
    }

    /// <summary>
    /// Запуск следующего уровня
    /// </summary>
    public void LevelNext()
    {
        ManagerLevel.Instance.NextLevel();
    }

    public void LevelLose(TypeLoseLevel typeLoseLevel)
    {
        this.typeLoseLevel = typeLoseLevel;

        ManagerTime.Instance.TimerStop();
        ManagerStates.Instance.ChangeStateGame(TypeStateGame.LoadingLevel);

        StartCoroutine(CoWaitBeforeShowUI());
    }

    private IEnumerator CoWaitBeforeShowUI()
    {
        yield return new WaitForSeconds(1f);

        ManagerCanvaces.Instance.ShowLoseLevel();
    }

    public void LevelRestart()
    {
        ManagerObjects.Instance.DestroyAllObjects();
        ManagerLevel.Instance.NextLevel();

        if (blenderAnimation.GetDamage)
        {
            blenderAnimation.Work();
        }
    }

    /// <summary>
    /// Все уровни пройдены
    /// </summary>
    public void EndLevels()
    {
        ManagerStates.Instance.ChangeStateGame(TypeStateGame.LoadingLevel);
        ManagerTime.Instance.TimerStop();

        collidersBlender.SetActive(false);
        ManagerSpawner.Instance.EndGame();
        StartCoroutine(CoWaitEndGame());
    }

    private IEnumerator CoWaitEndGame()
    {
        yield return new WaitForSeconds(5f);

        ManagerCanvaces.Instance.ShowEndLevelPanel();
    }
}
