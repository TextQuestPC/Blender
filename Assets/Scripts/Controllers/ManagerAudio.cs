using System.Collections;
using UnityEngine;

public class ManagerAudio : DontDestroySingleton<ManagerAudio>
{
    [SerializeField] private AudioSource mainAudio;
    [SerializeField] private AudioSource soundAudio1;
    [SerializeField] private AudioSource soundAudio2;
    [SerializeField] private AudioSource soundAudio3;

    [SerializeField] private AudioClip backAudio;

    private const float stepChangeVolume = .05f;
    private const float timeStepChangeVolume = .05f;

    private float maxVolumeMusic = 1f;
    private float maxVolumeSound = 1f;

    private void Start()
    {
        float music = ManagerSaveLoad.Instance.LoadMusicVolume();
        float sound = ManagerSaveLoad.Instance.LoadSoundVolume();

        ChangeMusicVolume(music);
        ChangeSoundVolume(sound);
    }

    public void ChangeMusicVolume(float value)
    {
        maxVolumeMusic = value;
        mainAudio.volume = value;

        ManagerSaveLoad.Instance.SaveMusicVolume(value);
    }

    public void ChangeSoundVolume(float value)
    {
        maxVolumeSound = value;
        soundAudio1.volume = value;
        soundAudio2.volume = value;
        soundAudio3.volume = value;

        ManagerSaveLoad.Instance.SaveSoundVolume(value);
    }

    /// <summary>
    /// Воспроизвести звук
    /// </summary>
    /// <param name="audio"></param>
    public void PlaySound(AudioClip audio)
    {
        AudioSource source = soundAudio1;

        if (soundAudio1.isPlaying)
        {
            if (soundAudio2.isPlaying)
            {
                if (soundAudio3.isPlaying)
                {
                    source = soundAudio1;
                }
                else
                {
                    source = soundAudio3;
                }
            }
            else
            {
                source = soundAudio2;
            }
        }

        source.clip = audio;
        source.Play();
    }

    /// <summary>
    /// Включить back audio определённого типа
    /// </summary>
    public void PlayMusicLevel()
    {
        PlayBackAudio(backAudio);
    }

    private void PlayBackAudio(AudioClip clip)
    {
        if (!mainAudio.isPlaying)
        {
            StartCoroutine(CoPlayMusic(clip));
        }
    }

    private IEnumerator CoChangeAudio(AudioClip clip)
    {
        while(mainAudio.volume > 0)
        {
            mainAudio.volume -= stepChangeVolume;
            yield return new WaitForSeconds(timeStepChangeVolume);
        }

        mainAudio.clip = clip;
        mainAudio.Play();

        while (mainAudio.volume < maxVolumeMusic)
        {
            mainAudio.volume += stepChangeVolume;
            yield return new WaitForSeconds(timeStepChangeVolume);
        }

        mainAudio.volume = maxVolumeMusic;
    }

    private IEnumerator CoTakeOffMusic()
    {
        while (mainAudio.volume > 0)
        {
            mainAudio.volume -= stepChangeVolume;
            yield return new WaitForSeconds(timeStepChangeVolume);
        }
    }

    private IEnumerator CoPlayMusic(AudioClip clip)
    {
        mainAudio.clip = clip;
        mainAudio.Play();

        while (mainAudio.volume <maxVolumeMusic)
        {
            mainAudio.volume += stepChangeVolume;
            yield return new WaitForSeconds(timeStepChangeVolume);
        }

        mainAudio.volume = maxVolumeMusic;
    }
}
