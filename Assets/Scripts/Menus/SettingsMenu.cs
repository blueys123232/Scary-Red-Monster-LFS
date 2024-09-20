using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer mainMixer;
    public Slider volumeSlider;
    public Dropdown qualityDropdown;

    public float defaultVolume = 0.75f;
    public int defaultQualityIndex = 2;

    private void Start()
    {
        // Load saved settings on startup
        LoadSettings();

        // Initialize the volume slider to the saved or default volume
        if (volumeSlider != null)
        {
            volumeSlider.value = PlayerPrefs.HasKey("volume") ? PlayerPrefs.GetFloat("volume") : defaultVolume;
        }

        // Initialize the quality dropdown to the saved or default value
        if (qualityDropdown != null)
        {
            qualityDropdown.value = PlayerPrefs.HasKey("quality") ? PlayerPrefs.GetInt("quality") : defaultQualityIndex;
        }
    }

    public void SetVolume(float volume)
    {
        // If the volume is at the slider's minimum, mute the audio by setting a very low value
        if (volumeSlider != null && volumeSlider.value == volumeSlider.minValue)
        {
            mainMixer.SetFloat("volume", -80f);  // Mute
        }
        else
        {
            mainMixer.SetFloat("volume", volume);
        }

        // Save volume setting
        PlayerPrefs.SetFloat("volume", volume);
        PlayerPrefs.Save();
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        // Save quality setting
        PlayerPrefs.SetInt("quality", qualityIndex);
        PlayerPrefs.Save();
    }

    public void LoadSettings()
    {
        // Load volume setting
        if (PlayerPrefs.HasKey("volume"))
        {
            float volume = PlayerPrefs.GetFloat("volume");
            if (volumeSlider != null && volume == volumeSlider.minValue)
            {
                mainMixer.SetFloat("volume", -80f);  // Mute
            }
            else
            {
                mainMixer.SetFloat("volume", volume);
            }
        }
        else
        {
            mainMixer.SetFloat("volume", defaultVolume);
        }

        // Load quality setting
        if (PlayerPrefs.HasKey("quality"))
        {
            int qualityIndex = PlayerPrefs.GetInt("quality");
            QualitySettings.SetQualityLevel(qualityIndex);
        }
        else
        {
            QualitySettings.SetQualityLevel(defaultQualityIndex);
        }
    }

    public void ResetToDefaults()
    {
        SetVolume(defaultVolume);
        SetQuality(defaultQualityIndex);

        // Save default settings as the current settings
        SaveSettings();

        // Update UI elements to reflect default values
        if (volumeSlider != null)
        {
            volumeSlider.value = defaultVolume;
        }

        if (qualityDropdown != null)
        {
            qualityDropdown.value = defaultQualityIndex;
        }
    }

    public void SaveSettings()
    {
        // Save volume setting
        float volume;
        if (mainMixer.GetFloat("volume", out volume))
        {
            PlayerPrefs.SetFloat("volume", volume);
        }

        // Save quality setting
        PlayerPrefs.SetInt("quality", QualitySettings.GetQualityLevel());

        // Ensure PlayerPrefs are saved to disk
        PlayerPrefs.Save();
    }

    public void LoadDefaults()
    {
        // Load default settings
        SetVolume(defaultVolume);
        SetQuality(defaultQualityIndex);

        // Update UI elements to reflect default values
        if (volumeSlider != null)
        {
            volumeSlider.value = defaultVolume;
        }

        if (qualityDropdown != null)
        {
            qualityDropdown.value = defaultQualityIndex;
        }
    }
}
