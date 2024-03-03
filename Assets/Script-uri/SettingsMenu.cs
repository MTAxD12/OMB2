using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer musicMixer;
	public AudioMixer sfxMixer;
	public Slider musicSlider;
	public Slider sfxSlider;

	public TextMeshProUGUI textProcentMusic;
	public TextMeshProUGUI textProcentSFX;

	public TMP_Dropdown resolutionDropdown;
	public TMP_Dropdown graphicsDropdown;

	public Toggle toggleFullScreen;

	int fullScreen;

	Resolution[] resolutions;

	void Start()
	{
		musicSlider.value = PlayerPrefs.GetFloat("SliderMusicLevel", musicSlider.value);
		sfxSlider.value = PlayerPrefs.GetFloat("SliderSFXLevel", sfxSlider.value);
		toggleFullScreen.isOn = intToBool(PlayerPrefs.GetInt("isFullScreen"));
		graphicsDropdown.value = PlayerPrefs.GetInt("qualityLevel", graphicsDropdown.value);

		resolutions = Screen.resolutions.Select(resolution => new Resolution {width = resolution.width, height = resolution.height }).Distinct().ToArray();

		resolutionDropdown.ClearOptions();

		List<string> options = new List<string>();


		// graphicsDropdown.value = QualitySettings.GetQualityLevel(); 

		for (int i = 0; i < resolutions.Length; i++)
		{
			string option = resolutions[i].width + " x " + resolutions[i].height;
			options.Add(option);
		}
		resolutionDropdown.AddOptions(options);
		resolutionDropdown.value = PlayerPrefs.GetInt("ResolutionIndex", resolutionDropdown.value); ;
		resolutionDropdown.RefreshShownValue();
		Debug.Log(PlayerPrefs.GetInt("qualityLevel"));
	}

	public void SetResolution(int resolutionIndex)
	{
		Resolution resolution = resolutions[resolutionIndex];
		Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
		PlayerPrefs.SetInt("ResolutionIndex", resolutionIndex);
	}

	public void SetMusic(float volume)
	{
		musicMixer.SetFloat("musicvolume", Mathf.Log10(volume) * 20);
		textProcentMusic.text = Mathf.FloorToInt(volume * 100) + "%";
		PlayerPrefs.SetFloat("SliderMusicLevel", volume);
	}
	
	public void SetSFX(float volume)
	{
		sfxMixer.SetFloat("sfxvolume", Mathf.Log10(volume) * 20);
		textProcentSFX.text = Mathf.FloorToInt(volume * 100) + "%";
		PlayerPrefs.SetFloat("SliderSFXLevel", volume);
	}

	public void SetQuality(int qualityIndex)
	{
		QualitySettings.SetQualityLevel(qualityIndex);
		PlayerPrefs.SetInt("qualityLevel", qualityIndex);
	}	

	public void SetFullscreen(bool isFullscreen)
	{

		Screen.fullScreen = isFullscreen;
		PlayerPrefs.SetInt("isFullScreen", boolToInt(isFullscreen));

	}

	int boolToInt(bool val)
	{
		if (val)
			return 1;
		else
			return 0;
	}

	bool intToBool(int val)
	{
		if (val != 0)
			return true;
		else
			return false;
	}

}
