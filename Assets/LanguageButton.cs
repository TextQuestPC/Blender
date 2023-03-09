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
    //private void Update()
    //{
    //    languageYG = FindObjectsOfType<LanguageYG>();
    //    if (activ)
    //    {
    //        for (int i = 0; i < languageYG.Length; i++)
    //        {
    //            languageYG[i].SwitchLanguage(lang1);
    //        }
    //    }
    //    if (!activ)
    //    {
    //        for (int i = 0; i < languageYG.Length; i++)
    //        {
    //            languageYG[i].SwitchLanguage(lang2);
    //        }
    //    }
    //}
    public void buttonLanguage()
    {
        //activ = !activ;
        settingsPanel.scoreText.text += ManagerSaveLoad.Instance.LoadLevel();
    }
}
