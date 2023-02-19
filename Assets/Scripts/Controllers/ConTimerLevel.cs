using UnityEngine;

public class ConTimerLevel : MonoBehaviour
{
    private bool goTime = false;
    private float lastTime;
    private float prevTime = 0;

    private int warningValue = 5;

    public void SetTime(float time)
    {
        lastTime = time;
        goTime = true;
    }

    private void Update()
    {
        if (goTime)
        {
            lastTime -= Time.deltaTime;

            if (lastTime > 0)
            {
                float time = Mathf.Floor(lastTime);

                if (time != prevTime)
                {
                    prevTime = time;

                    bool warning = false;

                    if(time <= warningValue)
                    {
                        warning = true;
                    }

                    TimerText.Instance.ShowTextTime(time, warning);
                }
            }
            else
            {
                TimerText.Instance.HideTextTime();
                ManagerTime.Instance.TimeEnd();
            }
        }
    }

    public void StopTimer()
    {
        goTime = false;
    }

    public void AddTime(float value)
    {
        lastTime += value;

        float time = Mathf.Floor(lastTime);
        TimerText.Instance.ShowTextTime(time, true);
    }
}
