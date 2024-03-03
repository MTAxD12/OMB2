using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
	private static bool shownFPS = false;

	public GameObject pauseMenuUI;
	public GameObject pauseMenuMenu;
	public GameObject pauseMenuOptions;

	//public AudioSource sunetFundal;
	public AudioSource sunetFinal; 

	public Animator animator;

	public GameObject timer;
	public GameObject FPS_Counter;

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
    }
  

	public void Resume()
	{
		pauseMenuMenu.SetActive(true);
		pauseMenuOptions.SetActive(false);
		pauseMenuUI.SetActive(false);
		if(GameIsPaused == true)
		{
			if(FindObjectOfType<GameManager>().jocTerminat == false)
			{
				FindObjectOfType<SunetFundal>().StartMuzica();
			}
		}
		if (FindObjectOfType<GameManager>().jocTerminat == true)
		{
			sunetFinal.Play();
		}
		Time.timeScale = 1f;
		GameIsPaused = false;
		if (FindObjectOfType<GameManager>().jocTerminat == false)
		{
			animator.GetComponent<Animator>().enabled = true;
		}
		timer.SetActive(true);
		if (shownFPS == true)
		{
			FPS_Counter.SetActive(true);
			shownFPS = false;
		}
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}


	public void Pause() 
	{
		if(GameIsPaused == false)
		{
			FindObjectOfType<SunetFundal>().PauseMenuMuzica();
		}
		if(FindObjectOfType<GameManager>().jocTerminat == false)
		{
			animator.GetComponent<Animator>().enabled = false;
		}
		pauseMenuUI.SetActive(true);
		if (FindObjectOfType<GameManager>().jocTerminat == true)
		{
			sunetFinal.Pause();
		}	
		Time.timeScale = 0f;
		GameIsPaused = true;
		if (FPSController.fpsIsOn == true)
		{
			FPS_Counter.SetActive(false);
			shownFPS = true;
		}
		timer.SetActive(false);
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;

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

