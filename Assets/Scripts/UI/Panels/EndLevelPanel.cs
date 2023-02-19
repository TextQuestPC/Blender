using UnityEngine;

public class EndLevelPanel : MonoBehaviour
{
    [SerializeField] private GameObject background;

    private const float timeHide = 0.5f;

    public void ShowPanel()
    {
        background.SetActive(true);
    }
}
