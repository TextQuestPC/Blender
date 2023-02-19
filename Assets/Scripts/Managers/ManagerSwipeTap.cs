using UnityEngine;

public class ManagerSwipeTap : Singleton<ManagerSwipeTap>
{
    public delegate void SwipeEvent(bool rightSwipe);
    public delegate void TapEvent(int numberLine);

    public event SwipeEvent Swipe;
    public event TapEvent Tap;

    [SerializeField] private ConSwipeTap conSwipeTap;

    private bool canSwipe = true;
    private bool canTap = true;

    private int numberLineTap = 0;

    /// <summary>
    /// Произошёл свайп в сторону right = bool
    /// </summary>
    /// <param name="right"></param>
    public void DoSwipe(bool right)
    {
        if(!canSwipe)
        {
            return;
        }

        if (right)
        {
            numberLineTap++;
        }
        else
        {
            numberLineTap--;
        }

        Swipe?.Invoke(right);
    }

    /// <summary>
    /// Произошёл tap по линии номер swipeByNumberLine
    /// </summary>
    /// <param name="swipeByNumberLine"></param>
    public void DoTap(int swipeByNumberLine)
    {
        if (!canTap)
        {
            return;
        }

        if (numberLineTap != swipeByNumberLine)
        {
            numberLineTap = swipeByNumberLine;
            Tap?.Invoke(swipeByNumberLine);
        }
    }

    /// <summary>
    /// Если можно делать свайп, то включается объект который считывает свайп,
    /// если нет, то он отключается
    /// </summary>
    /// <param name="canSwipe"></param>
    public void ChangeCanSwipeTap(bool canSwipe)
    {
        if (canSwipe)
            OnConSwipeTap();
        else
            OffConSwipeTap();
    }

    private void OnConSwipeTap()
    {
        conSwipeTap.gameObject.SetActive(true);
        canTap = true;
    }

    private void OffConSwipeTap()
    {
        conSwipeTap.gameObject.SetActive(false);
        canTap = false;
    }

    #region Tutorial
    public void TutorSwipe()
    {
        canTap = false;
    }

    public void EndTutorSwipe()
    {
        canTap = true;
        canSwipe = false;
    }

    public void EndTutorTap()
    {
        canSwipe = true;
    }
    #endregion
}
