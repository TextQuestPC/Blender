using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class SettingsPanel : Singleton<SettingsPanel>
{
    [SerializeField] private GameObject panel;
    [SerializeField] public Text scoreText;
    [SerializeField] private GameObject inMenuButton;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider soundSlider;

    private const string textEndLevels = "Пройдено: ";
    private float timeHide = .35f;

    //private void OnEnable()
    //{
    //    YandexGame.OpenFullAdEvent += ShowPanel;
    //    //YandexGame.GetDataEvent += OnGetData;
    //}

    //private void OnDisable()
    //{
    //    YandexGame.OpenFullAdEvent -= ShowPanel;
    //    //YandexGame.GetDataEvent -= OnGetData;
    //}

    private void Start()
    {
        YandexGame.savesData.CurrentLevel += ManagerSaveLoad.Instance.LoadLevel() + 1;
        YandexGame.SaveProgress();

        musicSlider.value = ManagerSaveLoad.Instance.LoadMusicVolume();
        soundSlider.value = ManagerSaveLoad.Instance.LoadSoundVolume();

        musicSlider.onValueChanged.AddListener(delegate { ChangeMusicVolume(); });
        soundSlider.onValueChanged.AddListener(delegate { ChangeSoundVolume(); });
    }

    public void ShowPanel()
    {
        scoreText.text = textEndLevels + ManagerSaveLoad.Instance.LoadLevel() + 1;

        if (ManagerScenes.Instance.GetIsGameScene)
        {
            ManagerStates.Instance.ChangeStateGame(TypeStateGame.Pause);
            inMenuButton.SetActive(true);
        }
        else
        {
            inMenuButton.SetActive(false);
        }

        panel.SetActive(true);

        if (ManagerScenes.Instance.GetIsGameScene)
        {
            ManagerCanvaces.Instance.HideSettingsButton();
        }
        scoreText.text += ManagerSaveLoad.Instance.LoadLevel();
    }

    public void HidePanel()
    {
        StartCoroutine(CoHidePanel());
    }

    private IEnumerator CoHidePanel()
    {
        panel.GetComponent<Animator>().SetTrigger("Hide");
        yield return new WaitForSeconds(timeHide);
        panel.SetActive(false);

        if (ManagerScenes.Instance.GetIsGameScene)
        {
            ManagerStates.Instance.ChangeStateGame(TypeStateGame.Game);
        }

        if (ManagerScenes.Instance.GetIsGameScene)
        {
            ManagerCanvaces.Instance.ShowSettingsButton();
        }
    }

    private void ChangeMusicVolume()
    {
        ManagerAudio.Instance.ChangeMusicVolume(musicSlider.value);
    }

    private void ChangeSoundVolume()
    {
        ManagerAudio.Instance.ChangeSoundVolume(soundSlider.value);
    }
}
