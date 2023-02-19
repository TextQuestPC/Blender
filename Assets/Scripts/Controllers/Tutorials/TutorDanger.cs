using System.Collections;
using UnityEngine;

public class TutorDanger : MonoBehaviour
{
    private string textDanderTree = "Дерево опасно!";
    private string textDanderIce = "Лёд замораживает!";
    private string textDanderTime = "Следи за временем, что бы успеть!";
    private string textDanderBonusTime = "Собирай бонусы время, что бы успеть!";

    public void StartTutor(BubbleType bubbleType)
    {
        if (bubbleType == BubbleType.Tree)
        {
            BubbleTutor.Instance.ShowTutor(bubbleType, textDanderTree);
        }
        else if (bubbleType == BubbleType.Ice)
        {
            BubbleTutor.Instance.ShowTutor(bubbleType, textDanderIce);
        }
        else if (bubbleType == BubbleType.Time)
        {
            BubbleTutor.Instance.ShowTutor(bubbleType, textDanderTime);
        }
        else if (bubbleType == BubbleType.BonusTime)
        {
            BubbleTutor.Instance.ShowTutor(bubbleType, textDanderBonusTime);
        }
    }

    public void EndTutor()
    {
        BubbleTutor.Instance.HideTutor();
        StartCoroutine(CoWaitEndTutor());
    }

    private IEnumerator CoWaitEndTutor()
    {
        yield return new WaitForSeconds(.3f);
        ManagerLevel.Instance.TutorEnd();
    }
}

public enum BubbleType
{
    Tree,
    Ice,
    Time,
    BonusTime
}
