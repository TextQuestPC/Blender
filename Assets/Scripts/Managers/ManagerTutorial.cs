using UnityEngine;

public class ManagerTutorial : Singleton<ManagerTutorial>
{
    [SerializeField] private TutorSwipeTap tutorSwipeTap;
    [SerializeField] private TutorDanger tutorDanger;

    private int[] levelsWithTutor = new int[5] { 0, 2, 4, 5, 6 };

    public void CheckLevel(int number)
    {
        foreach (var numberLevel in levelsWithTutor)
        {
            if (number == numberLevel)
            {
                StartTutor(number);
            }
        }
    }

    private void StartTutor(int number)
    {
        if (number == 0)
        {
            tutorSwipeTap.StartTutor();
        }
        else if (number == 2)
        {
            SetWaitTutor();
            tutorDanger.StartTutor(BubbleType.Tree);
        }
        else if (number == 4)
        {
            SetWaitTutor();
            tutorDanger.StartTutor(BubbleType.Ice);
        }
        else if (number == 5)
        {
            SetWaitTutor();
            tutorDanger.StartTutor(BubbleType.Time);
        }
        else if (number == 6)
        {
            SetWaitTutor();
            tutorDanger.StartTutor(BubbleType.BonusTime);
        }
    }

    private void SetWaitTutor()
    {
        ManagerLevel.Instance.SetWaitTutor = true;
    }
}
