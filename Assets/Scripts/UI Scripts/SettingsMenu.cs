using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;
using UnityEngine.UI;


public class SettingsMenu : MonoBehaviour {
    public AudioMixer audioMixer;
    public Dropdown resolutionDropdown;
    public Dropdown qualityDropdown;
    public Dropdown textureDropdown;
    public Dropdown aaDropdown;
    public Slider volumeSlider;
    private float currentVolume;
    private Resolution[] resolutions;
    
  
    void Start() {  // Start is called before the first frame update
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        resolutions = Screen.resolutions;
        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++) {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
                currentResolutionIndex = i;
            resolutionDropdown.AddOptions(options);
            resolutionDropdown.RefreshShownValue();
            LoadSettings(currentResolutionIndex);
        }
    }

    public void SetVolume(float volume) {
        audioMixer.SetFloat("volume", volume);
        currentVolume = volume;
    }

    public void SetFullscreen(bool isfullscreen) {
        Screen.fullScreen = isfullscreen;
    }

    public void SetResolution(int resolutionIndex) {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetTextureQuality(int textureIndex) {
        QualitySettings.globalTextureMipmapLimit = textureIndex;
        qualityDropdown.value = 6;
    }

    public void SetAntiAliasing(int aaIndex) {
        QualitySettings.antiAliasing = aaIndex;
        qualityDropdown.value = 6;
    }

    public void SetQuality(int qualityIndex) {
        if (qualityIndex != 6) QualitySettings.SetQualityLevel(qualityIndex);
        switch (qualityIndex) {
            case 0:
                textureDropdown.value = 3;
                aaDropdown.value = 0;
                break;
            case 1:
                textureDropdown.value = 2;
                aaDropdown.value = 0;
                break;
            case 2:
                textureDropdown.value = 1;
                aaDropdown.value = 0;
                break;
            case 3:
                textureDropdown.value = 0;
                aaDropdown.value = 0;
                break;
            case 4:
                textureDropdown.value = 0;
                aaDropdown.value = 1;
                break;
            case 5:
                textureDropdown.value = 0;
                aaDropdown.value = 2;
                break;
        }
        qualityDropdown.value = qualityIndex;
    }

    public void ExitGame() {
        Application.Quit();
    }

    public void SaveSettings() {
        PlayerPrefs.SetInt("QualitySettingPreference", qualityDropdown.value);
        PlayerPrefs.SetInt("ResolutionPreference", resolutionDropdown.value);
        PlayerPrefs.SetInt("TextureQualityPreference", textureDropdown.value);
        PlayerPrefs.SetInt("AntiAliasingPreference", aaDropdown.value);
        PlayerPrefs.SetInt("FullscreenPreference", Convert.ToInt32(Screen.fullScreen));
        PlayerPrefs.SetFloat("VolumePreference", currentVolume);
    }

    public void LoadSettings(int currentResolutionIndex) {
        if (PlayerPrefs.HasKey("QualitySettingPreference"))
            qualityDropdown.value = PlayerPrefs.GetInt("QualitySettingPreference");
        else qualityDropdown.value = 3;

        if (PlayerPrefs.HasKey("ResolutionPreference"))
            resolutionDropdown.value = PlayerPrefs.GetInt("ResolutionPreference");
        else resolutionDropdown.value = currentResolutionIndex;
        
        if(PlayerPrefs.HasKey("TextureQualityPreference"))
            textureDropdown.value = PlayerPrefs.GetInt("TextureQualityPreference");
        else textureDropdown.value = 0;
        
        if (PlayerPrefs.HasKey("AntiAliasingPreference"))
            aaDropdown.value = PlayerPrefs.GetInt("AntiAliasingPreference");
        else aaDropdown.value = PlayerPrefs.GetInt("FullscreenPreference");

        if (PlayerPrefs.HasKey("FullscreenPreference"))
            Screen.fullScreen = Convert.ToBoolean(PlayerPrefs.GetInt("FullscreenPreference"));
        else Screen.fullScreen = true;
        
        //if (PlayerPrefs.HasKey("VolumePreference"))
        //    volumeSlider.value = PlayerPrefs.GetFloat("VolumePreference");
       // else volumeSlider.value = PlayerPrefs.GetFloat("VolumePreference");

        
    }
}
