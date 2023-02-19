using UnityEngine;

public class ManagerTime : Singleton<ManagerTime>
{
    [SerializeField] private ConTimerLevel conTimerLevel;

    private bool needTimer = false;

    /// <summary>
    /// Установка и запуск времени для следующего уровня
    /// </summary>
    public void StartNextLevel(float time)
    {
        if (time > 0)
        {
            conTimerLevel.gameObject.SetActive(true);
            conTimerLevel.SetTime(time);
            needTimer = true;
        }else
        {
            needTimer = false;
        }
    }

    /// <summary>
    /// Время уровня вышло
    /// </summary>
    public void TimeEnd()
    {
        needTimer = false;

        conTimerLevel.gameObject.SetActive(false);
        ManagerMain.Instance.LevelLose(TypeLoseLevel.EndTimeLevel);
    }

    /// <summary>
    /// Запуск времени после паузы
    /// </summary>
    public void TimerGo()
    {
        if (needTimer)
        {
            conTimerLevel.gameObject.SetActive(true);
        }
    }

    /// <summary>
    /// пауза - остановка времени
    /// </summary>
    public void TimerStop()
    {
        conTimerLevel.gameObject.SetActive(false);

        TimerText.Instance.HideTextTime();
    }

    public void AddTime(TypeBonusTime typeBonus)
    {
        float time = 0;

        if(typeBonus == TypeBonusTime.Small)
        {
            time = 5;
        }else if(typeBonus == TypeBonusTime.Big)
        {
            time = 10;
        }

        conTimerLevel.AddTime(time);
    }
}
