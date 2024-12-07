using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio; 

public class OptionsMenu : MonoBehaviour
{

    public float volume = 0;
    public bool isFullscreen = false;
    public AudioMixer audioMixer; 
    public TMPro.TMP_Dropdown resolutionDropdown;
    private Resolution[] resolutions;
    private int currResolutionIndex = 0;

    private void Start()
    {
        resolutionDropdown.ClearOptions();
        resolutions = Screen.resolutions;
        List<string> options = new List<string>(); 

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height; 
            options.Add(option);

            if (resolutions[i].Equals(Screen.currentResolution)) 
            {
                currResolutionIndex = i; 
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }
    public void ChangeVolume(float val)
    {
        volume = val;
    }

    public void ChangeResolution(int index)
    {
        currResolutionIndex = index;
    }

    public void ChangeFullscreenMode(bool val)
    {
        isFullscreen = val;
    }
    public void SaveSettings()
    {
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);
        Screen.fullScreen = isFullscreen;
        Screen.SetResolution(Screen.resolutions[currResolutionIndex].width, Screen.resolutions[currResolutionIndex].height, isFullscreen);
    }
}
