using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class ManagerCanvaces : Singleton<ManagerCanvaces>
{
    [SerializeField] private RecipePanel recipePanel;
    [SerializeField] private ResultPanel resultPanel;
    [SerializeField] private EndLevelPanel endLevelPanel;

    [SerializeField] private Text levelText;
    [SerializeField] private GameObject settingsButton;

    private const string strLevel = "Уровень ";

    private float timeShowLevelText = 2f;
    private float timeHideResultPanel = .5f;

    private bool showRecipe = true;
    public bool SetShowRecipe { set => showRecipe = value; }

    /// <summary>
    /// Показать рецепт
    /// </summary>
    /// <param name="recipe"></param>
    public void ShowRecipe(DataNeedFruit dataFruit)
    {
        if (showRecipe)
        {
            recipePanel.ShowRecipe(dataFruit);
            ShowSettingsButton();
        }
    }

    /// <summary>
    /// Сокрытие отображаемого рецепта, показ победы
    /// </summary>
    public void ShowWinLevel()
    {
        resultPanel.ShowWinPanel();
        HideSettingsButton();
    }

    public void ShowLoseLevel()
    {
        resultPanel.ShowLosePanel();
        HideSettingsButton();
    }

    public void ClickNextLevel()
    {
        StartCoroutine(CoWaitHideResultPanel(true));
    }

    public void ClickRestartLevel()
    {
        StartCoroutine(CoWaitHideResultPanel(false));
    }

    private IEnumerator CoWaitHideResultPanel(bool nextLevel)
    {
        ManagerObjects.Instance.DestroyAllObjects();

        resultPanel.HidePanel();
        yield return new WaitForSeconds(timeHideResultPanel);

        if (nextLevel)
            ManagerMain.Instance.LevelNext();
        else
            ManagerMain.Instance.LevelRestart();
    }

    public void ShowEndLevelPanel()
    {
        endLevelPanel.ShowPanel();
    }

    public void ShowSettingsButton()
    {
        settingsButton.SetActive(true);
    }

    public void HideSettingsButton()
    {
        settingsButton.SetActive(false);
    }

    public void ShowLevelText(int numberText)
    {
        numberText = YandexGame.savesData.CurrentLevel;
        //numberText = ManagerSaveLoad.Instance.LoadLevel() + 1;
        levelText.text = strLevel + numberText;
        StartCoroutine(CoShowLevelText());
    }

    private IEnumerator CoShowLevelText()
    {
        levelText.gameObject.SetActive(true);
        levelText.text += ManagerSaveLoad.Instance.LoadLevel() + 1;
        yield return new WaitForSeconds(timeShowLevelText);
        levelText.gameObject.SetActive(false);
    }
}
