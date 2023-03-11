using UnityEngine;
using UnityEngine.UI;
using YG;

public class EndLevelPanel : MonoBehaviour
{
    [SerializeField] private GameObject background;
    [SerializeField] private Text endGameText;

    private const string endTextRu = "Уровни кончились. Победа!", endTextEn = "The levels are over. Victory!";

    private const float timeHide = 0.5f;

    public void ShowPanel()
    {
        bool isRu = YandexGame.savesData.language == "ru";

        if (isRu)
        {
            endGameText.text = endTextRu;
        }
        else
        {
            endGameText.text = endTextEn;
        }

        background.SetActive(true);
    }
}
