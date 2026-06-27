using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [Header("Audio Mixers")]
    public AudioMixer MusicMixer;
    public AudioMixer SoundMixer;
    [Header("UI")]
    public Slider musicSlider;
    public Slider soundSlider;
    public Toggle fullscreenToggle;
    
    [Header("Defaults")]
    public float defaultMusicVolume = 0.75f;
    public float defaultSoundVolume = 0.75f;
    public bool defaultFullscreen = true;
    private void Start()
    {
        // Load saved settings on startup
        LoadSettings();

        // Initialize the volume slider to the saved or default volume
        if (musicSlider != null)
        {
            musicSlider.value = PlayerPrefs.HasKey("musicvolume") ? PlayerPrefs.GetFloat("musicvolume") : defaultMusicVolume;
        }
        if (soundSlider != null)
        {
            soundSlider.value = PlayerPrefs.HasKey("soundvolume") ? PlayerPrefs.GetFloat("soundvolume") : defaultSoundVolume;
        }
        if (fullscreenToggle != null)
        {
            fullscreenToggle.isOn = PlayerPrefs.HasKey("fullscreen") ? PlayerPrefs.GetInt("fullscreen") == 1 : defaultFullscreen;
        }
       
    }

    public void SetMusicVolume(float musicvolume)
    {
        // If the volume is at the slider's minimum, mute the audio by setting a very low value
        if (musicSlider != null && musicSlider.value == musicSlider.minValue)
        {
            MusicMixer.SetFloat("musicvolume", -80f);  // Mute
        }
        else
        {
            MusicMixer.SetFloat("musicvolume", musicvolume);
        }

        // Save volume setting
        PlayerPrefs.SetFloat("musicvolume", musicvolume);
        PlayerPrefs.Save();
    }
    public void SetSoundVolume(float Soundvolume)
    {
        // If the volume is at the slider's minimum, mute the audio by setting a very low value
        if (musicSlider != null && musicSlider.value == musicSlider.minValue)
        {
            MusicMixer.SetFloat("soundvolume", -80f);  // Mute
        }
        else
        {
            MusicMixer.SetFloat("soundvolume", Soundvolume);
        }

        // Save volume setting
        PlayerPrefs.SetFloat("soundvolume", Soundvolume);
        PlayerPrefs.Save();
    }
  public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        PlayerPrefs.SetInt("fullscreen", isFullscreen ? 1 : 0);
        PlayerPrefs.Save();
    }

    public void LoadSettings()
    {
        // Load Music volume setting
        if (PlayerPrefs.HasKey("musicvolume"))
        {
            float musicvolume = PlayerPrefs.GetFloat("musicvolume");
            if (musicSlider != null && musicvolume == musicSlider.minValue)
            {
                MusicMixer.SetFloat("musicvolume", -80f);  // Mute
            }
            else
            {
                MusicMixer.SetFloat("musicvolume", musicvolume);
            }
        }
        else
        {
            SoundMixer.SetFloat("musicvolume", defaultMusicVolume);
        }
        if (PlayerPrefs.HasKey("soundvolume"))
        {
            float musicvolume = PlayerPrefs.GetFloat("soundvolume");
            if (soundSlider != null && musicvolume == musicSlider.minValue)
            {
                SoundMixer.SetFloat("soundvolume", -80f);  // Mute
            }
            else
            {
                SoundMixer.SetFloat("soundvolume", musicvolume);
            }
        }
        else
        {
            SoundMixer.SetFloat("soundvolume", defaultSoundVolume);
        }

    }

    public void ResetToDefaults()
    {
        SetMusicVolume(defaultMusicVolume);
        SetSoundVolume(defaultSoundVolume);
        SetFullscreen(defaultFullscreen);

        // Save default settings as the current settings
        SaveSettings();

        // Update UI elements to reflect default values
        if (musicSlider != null)
        {
            musicSlider.value = defaultMusicVolume;
        }
        if (soundSlider != null)
        {
            soundSlider.value = defaultSoundVolume;
        }
        if (fullscreenToggle != null)
        {
            fullscreenToggle.isOn = defaultFullscreen;
        }


    }

    public void SaveSettings()
    {
        // Save volume setting
        float musicvolume;
        if (MusicMixer.GetFloat("musicvolume", out musicvolume))
        {
            PlayerPrefs.SetFloat("musicvolume", musicvolume);
        }
        float soundvolume;
        if (SoundMixer.GetFloat("soundvolume", out soundvolume))
        {
            PlayerPrefs.SetFloat("soundvolume", soundvolume);
        }


        // Ensure PlayerPrefs are saved to disk
        PlayerPrefs.Save();
    }

    public void LoadDefaults()
    {
        // Load default settings
        SetMusicVolume(defaultMusicVolume);
        
        SetSoundVolume(defaultSoundVolume);
        // Update UI elements to reflect default values
        if (musicSlider != null)
        {
            musicSlider.value = defaultMusicVolume;
        }
        if (soundSlider != null)
        {
            soundSlider.value = defaultSoundVolume;
        }

    }
}
