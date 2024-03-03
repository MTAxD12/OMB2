using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.Video;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class SecretLevelPauseMenu : MonoBehaviour
{
	public static bool GameIsPaused = false;

	public GameObject pauseMenuUI;
	public GameObject pauseMenuMenu;
	public GameObject pauseMenuOptions;


	public VideoPlayer videoRicardo; 

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
		toggleFullScreen.isOn = intToBool(PlayerPrefs.GetInt("isFullScreen", 0));
		graphicsDropdown.value = PlayerPrefs.GetInt("qualityLevel", graphicsDropdown.value);

		resolutions = Screen.resolutions.Select(resolution => new Resolution { width = resolution.width, height = resolution.height }).Distinct().ToArray();

		resolutionDropdown.ClearOptions();

		List<string> options = new List<string>();

		// graphicsDropdown.value = QualitySettings.GetQualityLevel(); 

		for (int i = 0; i < resolutions.Length; i++)
		{
			string option = resolutions[i].width + " x " + resolutions[i].height;
			options.Add(option);

		}
		resolutionDropdown.AddOptions(options);
		resolutionDropdown.value = PlayerPrefs.GetInt("ResolutionIndex", resolutionDropdown.value);
		resolutionDropdown.RefreshShownValue();
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (GameIsPaused == true)
			{
				Resume();
			}
			else
			{
				Pause();
			}
		}

		if (Input.GetKey("r"))
		{
			if (GameIsPaused == false)
			{
				FindObjectOfType<GameManager>().Restart();
			}
		}
	}


	public void Resume()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		pauseMenuMenu.SetActive(true);
		pauseMenuOptions.SetActive(false);
		pauseMenuUI.SetActive(false);
		videoRicardo.Play();
		Time.timeScale = 1f;
		GameIsPaused = false;
	}

	public void Pause()
	{
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		pauseMenuUI.SetActive(true);
		videoRicardo.Pause();
		Time.timeScale = 0f;
		GameIsPaused = true;

	}

	public void LoadMenu()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene(0);
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

	public void EndGameFinal()
	{
		SceneManager.LoadScene(11);
		Time.timeScale = 1f;
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
