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
}
