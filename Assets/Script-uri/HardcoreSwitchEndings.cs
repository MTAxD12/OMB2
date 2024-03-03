using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HardcoreSwitchEndings : MonoBehaviour
{
    private static int n;

    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex > n)
        {
            n = 8;
        }
        if (MainMenu.isHardcore == true)
        {
            PlayerPrefs.SetInt("HighscoreHardcore", n);
            Debug.Log("n=" + n);
        }
    }
}
