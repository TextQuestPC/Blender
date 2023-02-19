using UnityEngine;

public class TutorSwipeTap : MonoBehaviour
{
    [SerializeField] private GameObject swipeHand;
    [SerializeField] private GameObject tapHand;

    private int countSwipe = 0;
    private int countTap = 0;

    private int maxSwipe = 3;
    private int maxTap = 3;

    public void StartTutor()
    {
        ManagerCanvaces.Instance.SetShowRecipe = false;
        ManagerLevel.Instance.SetCanCheckFruit = false;

        swipeHand.SetActive(true);
        ManagerSwipeTap swipeTap = ManagerSwipeTap.Instance;

        swipeTap.TutorSwipe();
        swipeTap.Swipe += AddSwipe;
        swipeTap.Tap += AddTap;
    }

    private void AddSwipe(bool right)
    {
        countSwipe++;

        if(countSwipe > 0)
        {
            swipeHand.SetActive(false);
        }

        if (countSwipe >= maxSwipe)
        {
            ManagerSwipeTap.Instance.EndTutorSwipe();
            tapHand.SetActive(true);
        }
    }

    private void AddTap(int value)
    {
        countTap++;

        if(countTap > 0)
        {
            tapHand.SetActive(false);
        }

        if(countTap >= maxTap)
        {
            ManagerSwipeTap swipeTap = ManagerSwipeTap.Instance;

            swipeTap.Swipe -= AddSwipe;
            swipeTap.Tap -= AddTap;

            ManagerSwipeTap.Instance.EndTutorTap();
            ManagerCanvaces.Instance.SetShowRecipe = true;
            ManagerLevel.Instance.SetCanCheckFruit = true;
            ManagerLevel.Instance.ShowRecipe();
        }
    }
}
