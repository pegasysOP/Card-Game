using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

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
        ApplyConfig();
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
        Screen.fullScreen = Constants.startInFullScreen;
        Screen.SetResolution(Constants.VIEWPORT_WIDTH, Constants.VIEWPORT_HEIGHT, Constants.startInFullScreen);
    }
}
