using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class LanguageButton : MonoBehaviour
{
    public SettingsPanel settingsPanel;
    //[SerializeField] private LanguageYG[] languageYG;

    //public string lang1;
    //public string lang2;
    //bool activ = false;
    //private void Start()
    //{
    //    settingsPanel.scoreText.text += ManagerSaveLoad.Instance.LoadLevel();
    //}
    public void buttonLanguage()
    {
        //activ = !activ;
        settingsPanel.scoreText.text += ManagerSaveLoad.Instance.LoadLevel();
    }
}
