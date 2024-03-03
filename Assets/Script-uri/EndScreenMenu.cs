using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using TMPro;

public class EndScreenMenu : MonoBehaviour
{
    public AudioMixer musicMixer;
    public Slider musicSlider;
    public TextMeshProUGUI textProcentMusic;

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }


    void Start()
    {
        musicSlider.value = PlayerPrefs.GetFloat("SliderMusicLevel", musicSlider.value);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void SetMusic(float volume)
    {
        musicMixer.SetFloat("musicvolume", Mathf.Log10(volume) * 20);
        textProcentMusic.text = Mathf.FloorToInt(volume * 100) + "%";
        PlayerPrefs.SetFloat("SliderMusicLevel", volume);
    }
}


