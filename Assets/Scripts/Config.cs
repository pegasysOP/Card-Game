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
        ApplyAudioConfig();
        ApplyGraphicsConfig();
        ApplyScreenConfig();
    }

    public void ApplyAudioConfig()
    {
        SetVolume(volume);
        //AudioManager.instance.SetVolume(volume);
    }
    public void ApplyScreenConfig()
    {
        Screen.fullScreen = Constants.START_IN_FULLSCREEN;
        Screen.SetResolution(Constants.WINDOW_WIDTH, Constants.WINDOW_HEIGHT, Constants.START_IN_FULLSCREEN);

        Camera.main.aspect = Constants.TARGET_ASPECT_RATIO;

        //This updates the FOV based on the resolution so everything still looks good at 4K vs 1080p for example
        //float verticalFOV = Camera.main.fieldOfView;
        //float horizontalFOV = 2.0f * Mathf.Atan(Mathf.Tan(verticalFOV * 0.5f) * Constants.TARGET_ASPECT_RATIO) * Mathf.Rad2Deg;
        //Camera.main.fieldOfView = horizontalFOV;
    }

    public void ApplyGraphicsConfig()
    {
        QualitySettings.shadowResolution = (ShadowResolution)shadowQuality;
    }
}
