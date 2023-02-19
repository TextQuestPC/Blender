using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TimerText : Singleton<TimerText>
{
    [SerializeField] private Text textTime;
    
    public void ShowTextTime(float value, bool warning = false)
    {
        if (!textTime.gameObject.activeSelf)
        {
            textTime.gameObject.SetActive(true);
        }

        if (warning)
        {
            textTime.GetComponent<Animator>().SetTrigger("Warning");
        }

        textTime.text = value.ToString();
    }

    public void HideTextTime()
    {
        StartCoroutine(CoHideTextLevel());
    }

    private IEnumerator CoHideTextLevel()
    {
        textTime.gameObject.GetComponent<Animator>().SetTrigger("Hide");
        yield return new WaitForSeconds(.5f);
        textTime.gameObject.SetActive(false);
    }
}
