using System;
using UnityEngine;

public class UserSettings : MonoBehaviour
{
    public event Action OnSettingChange;
   
    const string musicVolumeKey = "MUSICVOLUMEKEY";
    const string effectVolumeKey = "EFFECTVOLUMEKEY";
    public float MusicVolume { get; set; }
    public float EffectVolume { get; set; }
    [SerializeField] private float defaultVolume;

    private void Start()
    {
        MusicVolume = PlayerPrefs.GetFloat(musicVolumeKey);
        EffectVolume = PlayerPrefs.GetFloat(effectVolumeKey);
    }

    public void SaveSettings(float newMusicVolume, float newEffectVolume)
    {
        PlayerPrefs.SetFloat(musicVolumeKey,newMusicVolume);
        PlayerPrefs.SetFloat(effectVolumeKey, newEffectVolume);
        MusicVolume = PlayerPrefs.GetFloat(musicVolumeKey);
        EffectVolume = PlayerPrefs.GetFloat(effectVolumeKey);
        OnSettingChange?.Invoke();
    }

    public void Reset()
    {
        PlayerPrefs.SetFloat(musicVolumeKey, defaultVolume);
        PlayerPrefs.SetFloat(effectVolumeKey, defaultVolume);
        MusicVolume = PlayerPrefs.GetFloat(musicVolumeKey);
        EffectVolume = PlayerPrefs.GetFloat(effectVolumeKey);
        OnSettingChange?.Invoke();
    }
}
