using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighscoreText : MonoBehaviour
{
    public TextMeshProUGUI textHardcore;
    private static int n;

    void Start()
    {
        n = PlayerPrefs.GetInt("HighscoreHardcore");
        if (n < 8)
        {
            textHardcore.text = "HIGHSCORE: " + n;
        }
        if (n == 8)
		{
            textHardcore.text = "Completed";
		}
    }
}
