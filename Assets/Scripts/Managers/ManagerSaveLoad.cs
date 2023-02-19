using UnityEngine;

public class ManagerSaveLoad : DontDestroySingleton<ManagerSaveLoad>
{
    private const string levelName = "Level";
    private const string musicName = "Music";
    private const string soundName = "Sound";

    public void SaveLevel(int level)
    {
        PlayerPrefs.SetInt(levelName, level);
    }

    public void SaveMusicVolume(float value)
    {
        PlayerPrefs.SetFloat(musicName, value);
    }

    public void SaveSoundVolume(float value)
    {
        PlayerPrefs.SetFloat(soundName, value);
    }

    public int LoadLevel()
    {
        if (PlayerPrefs.HasKey(levelName))
        {
            return PlayerPrefs.GetInt(levelName);
        }
        else
        {
            return 0;
        }
    }

    public float LoadMusicVolume()
    {
        if (PlayerPrefs.HasKey(musicName))
        {
            return PlayerPrefs.GetFloat(musicName);
        }
        else
        {
            return 1;
        }
    }

    public float LoadSoundVolume()
    {
        if (PlayerPrefs.HasKey(soundName))
        {
            return PlayerPrefs.GetFloat(soundName);
        }
        else
        {
            return 1;
        }
    }

    public void ResetValueLevels()
    {
        PlayerPrefs.SetInt(levelName, 0);
    }
}
