using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ResultPanel : MonoBehaviour
{
    [SerializeField] private GameObject background;
    [SerializeField] private Text textResult;
    [SerializeField] private GameObject nextLevelButton;
    [SerializeField] private GameObject restartLevelButton;

    private const float timeHide = 0.3f;

    private const string winText = "Победа!";
    private const string loseTextTree = "Проиграл. Деревья блендер не сможет порезать.";
    private const string loseTextTime = "Проиграл. Время вышло.";
    private const string loseTextTime2 = "Проиграл. Следи за счётчиком времени!";

    public void ShowWinPanel()
    {
        textResult.text = winText;
        nextLevelButton.SetActive(true);
        restartLevelButton.SetActive(false);

        background.SetActive(true);
    }

    public void ShowLosePanel()
    {
        ChangeLoseText();

        nextLevelButton.SetActive(false);
        restartLevelButton.SetActive(true);

        background.SetActive(true);
    }

    private void ChangeLoseText()
    {
        TypeLoseLevel typeLose = ManagerMain.Instance.GetTypeLoseLevel;
        string text = "";

        if (typeLose == TypeLoseLevel.DamagerTree)
        {
            text = loseTextTree;
        }
        else if (typeLose == TypeLoseLevel.EndTimeLevel)
        {
            text = loseTextTime;
        }

        if(text == "")
        {
            Debug.LogError($"Не присвоено значение textResult. Тип проигыши {typeLose}");
        }

        textResult.text = text;

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
