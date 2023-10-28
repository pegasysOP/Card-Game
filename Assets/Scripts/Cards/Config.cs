using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config : MonoBehaviour
{
    private int volume;

    public static Config instance;
    
    public enum ShadowQuality { Low, Medium, High, VeryHigh}

    public ShadowQuality shadowQuality;

    private Config() { }

    public void Awake()
    {
        instance = this;
        volume = 100;
        shadowQuality = ShadowQuality.Low;
    }

    public void SetVolume(int volume)
    {
        this.volume = volume;
    }

    public void SetShadowQuality(ShadowQuality shadowQuality)
    {
        this.shadowQuality = shadowQuality;
    }

    public void ApplyConfig()
    {
        SetVolume(volume);
        //AudioManager.instance.SetVolume(volume);
        QualitySettings.shadowResolution = (ShadowResolution)shadowQuality;
    }
}
