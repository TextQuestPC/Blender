using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BubbleTutor : Singleton<BubbleTutor>
{
    [SerializeField] private GameObject background;
    [SerializeField] private GameObject tree;
    [SerializeField] private GameObject ice;
    [SerializeField] private GameObject time;
    [SerializeField] private GameObject bonusTime;
    [SerializeField] private Text textTutor;

    public void ShowTutor(BubbleType bubbleType, string text)
    {
        if (bubbleType == BubbleType.Tree)
        {
            tree.SetActive(true);
        }
        else if (bubbleType == BubbleType.Ice)
        {
            ice.SetActive(true);
        }
        else if (bubbleType == BubbleType.Time)
        {
            time.SetActive(true);
        }
        else if (bubbleType == BubbleType.BonusTime)
        {
            bonusTime.SetActive(true);
        }

        textTutor.text = text;
        background.SetActive(true);
    }

    public void HideTutor()
    {
        StartCoroutine(CoHideTutor());
    }

    private IEnumerator CoHideTutor()
    {
        background.GetComponent<Animator>().SetTrigger("Hide");
        yield return new WaitForSeconds(.3f);
        background.SetActive(false);

        tree.gameObject.SetActive(false);
        ice.gameObject.SetActive(false);
        time.gameObject.SetActive(false);
        bonusTime.gameObject.SetActive(false);
    }
}
