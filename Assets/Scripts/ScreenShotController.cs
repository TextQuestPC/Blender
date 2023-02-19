using UnityEngine;

public class ScreenShotController : MonoBehaviour
{
    private const string pathFolder = "ScreenShots/screen";
    private const string strPng = ".png";
    private const string nameSave = "NumberScreenshot";

    private int number = 0;

    private void Awake()
    {
        number = PlayerPrefs.GetInt(nameSave);        
    }

    public void DoScreen()
    {
        ScreenCapture.CaptureScreenshot(pathFolder + number + strPng);
        number++;

        PlayerPrefs.SetInt(nameSave, number);
    }
}
