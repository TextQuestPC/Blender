using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class ResultPanel : MonoBehaviour
{
    [SerializeField] private GameObject background;
    [SerializeField] private Text textResult;
    [SerializeField] private GameObject nextLevelButton;
    [SerializeField] private GameObject restartLevelButton;

    private const float timeHide = 0.3f;

    [SerializeField] private GameObject textResultLoseTree;
    [SerializeField] private GameObject textResultLoseTime;

    private const string winTextRu = "Победа!", winTextEn = "Win!";
    private const string loseTextTreeRu = "Проиграл. Деревья блендер не сможет порезать.", loseTextTreeEn = "Lose. The blender will not be able to cut trees.";
    private const string loseTextTimeRu = "Проиграл. Время вышло.", loseTextTimeEn = "Lose. Time out.";
    //private const string loseTextTime2 = "Проиграл. Следи за счётчиком времени!";

    public void ShowWinPanel()
    {
        bool isRu = YandexGame.savesData.language == "ru";        

        textResult.gameObject.SetActive(true);

        textResultLoseTree.SetActive(false);
        textResultLoseTime.SetActive(false);

        nextLevelButton.SetActive(true);
        restartLevelButton.SetActive(false);

        background.SetActive(true);

        if (isRu)
        {
            textResult.text = winTextRu;
        }
        else
        {
            textResult.text = winTextEn;
        }
    }

    public void ShowLosePanel()
    {
        background.SetActive(true);

        ChangeLoseText();

        nextLevelButton.SetActive(false);
        restartLevelButton.SetActive(true);
    }

    private void ChangeLoseText()
    {
        bool isRu = YandexGame.savesData.language == "ru";
        TypeLoseLevel typeLose = ManagerMain.Instance.GetTypeLoseLevel;
        string text = "";

        if (typeLose == TypeLoseLevel.DamagerTree)
        {
            textResult.gameObject.SetActive(false);

            textResultLoseTree.SetActive(true);
            textResultLoseTime.SetActive(false);

            if (isRu)
            {
                text = loseTextTreeRu;
            }
            else
            {
                text = loseTextTreeEn;
            }
        }
        else if (typeLose == TypeLoseLevel.EndTimeLevel)
        {
            textResult.gameObject.SetActive(false);

            textResultLoseTree.SetActive(false);
            textResultLoseTime.SetActive(true);

            if (isRu)
            {
                text = loseTextTimeRu;
            }
            else
            {
                text = loseTextTimeEn;
            }
        }

        if (text == "")
        {
            Debug.LogError($"Не присвоено значение textResult. Тип проигыши {typeLose}");
        }
    }

    public void HidePanel()
    {
        StartCoroutine(CoHidePanel());
    }

    private IEnumerator CoHidePanel()
    {
        background.GetComponent<Animator>().SetTrigger(TypeAnimationPanel.Hide.ToString());
        yield return new WaitForSeconds(timeHide);
        background.SetActive(false);
    }
}
