using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class DeathScript : MonoBehaviour
{
    public static int deathValue = 0;
    TextMeshProUGUI score;
    public bool shouldCountDeaths;


    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
		{
            shouldCountDeaths = true;
		}
		else
		{
            shouldCountDeaths = false;
            deathValue = 0;
		}
        score = GetComponent<TextMeshProUGUI>();
        Debug.Log(deathValue);
    }

    void Update()
    {
        score.text = "Deaths " + deathValue;
    }
}
